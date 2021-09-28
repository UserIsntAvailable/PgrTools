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
        {
            _hexToStr = StringUtils.UrlHexToStr;
        }

        internal ConfigReader(Delegates.HexToString hexToStr)
        {
            _hexToStr = hexToStr;
        }

        /// <inheritdoc/>
        /// <remarks>Any hex value (%XX) will be parsed into its ASCII value</remarks>
        public IDictionary<string, string> ReadXmlConfig(string path)
        {
            XDocument document = XDocument.Load(path);

            return document.Element("map")!
                           .Elements().ToDictionary(
                               e => _hexToStr(e.Attribute("name")!.Value),
                               e => _hexToStr(e.Value)
                           );
        }
    }
}
