using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using PgrTools.Internals;

// ReSharper disable once CheckNamespace
namespace PgrTools.Tools
{
    public class ConfigReader : IConfigReader
    {
        private readonly Delegates.HexToString _hexToStr;

        public ConfigReader()
            : this(StringUtils.UrlHexToStr)
        {
        }

        internal ConfigReader(Delegates.HexToString hexToStr)
        {
            _hexToStr = hexToStr;
        }

        public IDictionary<string, string> ReadXmlConfig(string path, bool convertHexToAscii = true)
        {
            XDocument document = XDocument.Load(path);

            return document.Element("map")!.Elements().ToDictionary(
                e =>
                {
                    var key = e.Attribute("name")!.Value;

                    if(convertHexToAscii)
                    {
                        key = _hexToStr(key);
                    }

                    return key;
                },
                e => convertHexToAscii ? _hexToStr(e.Value) : e.Value
            );
        }
    }
}
