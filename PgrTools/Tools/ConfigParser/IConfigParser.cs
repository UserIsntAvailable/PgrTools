using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace PgrTools.Tools
{
    /*
     * TODO - Add ParseLastFightReplayData
     */
    public interface IConfigParser
    {
        /// <summary>
        /// Parses values of the key [PlayerKeyMapping].
        /// </summary>
        /// <param name="value">The value of the key [PlayerKeyMapping] on the pgr config.</param>
        public IDictionary<KeyMappingKey, string> ParsePlayerKeyMapping(string value);

        /// <summary>
        /// Parses values of the key [CustomUI]
        /// </summary>
        /// <param name="value">The value of the key [CustomUI] on the pgr config.</param>
        public IDictionary<CustomUiComponent, CustomComponentData> ParseCustomUi(string value);
    }
}
