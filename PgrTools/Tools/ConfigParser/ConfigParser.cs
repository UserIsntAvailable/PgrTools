using System;
using System.Collections.Generic;
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
        /// <remarks>If <see cref="value"/> has hex values (%XX),
        /// the method will convert them automatically to ASCII.</remarks> 
        public IDictionary<KeyMappingKey, string> ParsePlayerKeyMapping(string value)
        {
            if(HasHexString(value)) value = _hexToStr(value);

            var pairs = value.Split(new[] {'|',}, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<KeyMappingKey, string> returned = new();

            foreach(var pair in pairs)
            {
                var split = pair.Split('#');

                var enumKey = (KeyMappingKey) Enum.Parse(typeof(KeyMappingKey), split[0]);

                returned.Add(enumKey, split[1]);
            }

            return returned;

            static bool HasHexString(string s) => s.Contains("%");
        }
    }
}
