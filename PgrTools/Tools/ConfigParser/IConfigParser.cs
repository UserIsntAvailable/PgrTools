using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace PgrTools.Tools
{
    /*
     * TODO - Add ParseCustomUi
     * TODO - Add ParseLastFightReplayData
     */
    public interface IConfigParser
    {
        /// <summary>
        /// Parses values of the key [PlayerKeyMapping].
        /// </summary>
        /// <param name="value">The value of the key [PlayerKeyMapping] on the pgr config.</param>
        /// <returns></returns>
        public IDictionary<KeyMappingKey, string> ParsePlayerKeyMapping(string value);
    }
}
