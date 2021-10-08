using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using PgrTools.Internals;

// ReSharper disable once CheckNamespace
namespace PgrTools.Tools
{
    public class ConfigParser : IConfigParser
    {
        private readonly Delegates.HexToString _hexToStr;

        public ConfigParser()
        {
            _hexToStr = StringUtils.UrlHexToStr;
        }

        internal ConfigParser(Delegates.HexToString hexToStr)
        {
            _hexToStr = hexToStr;
        }

        /// <inheritdoc/>
        /// <remarks>If <see cref="value"/> has any hex values (%XX),
        /// the method will convert them automatically to ASCII.</remarks> 
        public IDictionary<KeyMappingKey, string> ParsePlayerKeyMapping(string value)
        {
            if(HasHex(value)) value = _hexToStr(value);

            var pairs = value.Split(new[] {'|',}, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<KeyMappingKey, string> returned = new();

            foreach(var pair in pairs)
            {
                var split = pair.Split('#');

                var enumKey = (KeyMappingKey) Enum.Parse(typeof(KeyMappingKey), split[0]);

                returned.Add(enumKey, split[1]);
            }

            return returned;
        }

        /// <inheritdoc/>
        /// <remarks>If <see cref="value"/> has any hex values (%XX),
        /// the method will convert them automatically to ASCII.</remarks> 
        public IDictionary<CustomUiElement, UiElementInfo> ParseCustomUi(string value)
        {
            if(HasHex(value)) value = _hexToStr(value);

            using var jsonDoc = JsonDocument.Parse(value);

            return jsonDoc.RootElement.GetProperty("UiData").EnumerateObject().ToDictionary(
                p => (CustomUiElement) Enum.Parse(typeof(CustomUiElement), p.Name),
                p => new UiElementInfo(
                    Math.Round(p.Value.GetProperty("PositionX").GetDouble(), 4),
                    Math.Round(p.Value.GetProperty("PositionY").GetDouble(), 4),
                    Math.Round(p.Value.GetProperty("Scale").GetDouble(), 4)
                )
            );
        }

        private static bool HasHex(string s) => s.Contains("%");
    }
}
