using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace PgrTools.Tools
{
    public interface IConfigReader
    {
        /// <summary>
        /// Reads a pgr xml config file. 
        /// </summary>
        /// <param name="path">The path of the file</param>
        /// <returns>An <see cref="IDictionary{TKey,TValue}"/> with each value</returns>
        public IDictionary<string, string> ReadXmlConfig(string path);
    }
}
