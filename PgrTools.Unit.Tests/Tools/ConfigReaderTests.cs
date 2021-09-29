using System.Linq;
using FluentAssertions;
using PgrTools.Tools;
using Xunit;

namespace PgrTools.Unit.Tests.Tools
{
    public class ConfigReaderTests
    {
        private const string TEST_FILE_PATH = "Resources/playerprefs.sample.xml";

        private readonly IConfigReader _sut = new ConfigReader(_ => _);

        [Fact]
        public void ReadXmlConfig_ShouldReturnDictionary_WhenPathExists()
        {
            var dict = _sut.ReadXmlConfig(TEST_FILE_PATH);

            dict.Should().ContainKeys("PlayerKeyMapping", "CustomUI");
        }

        [Fact]
        public void ReadXmlConfig_ShouldNotConvertHex_WhenConvertToAsciiIsFalse()
        {
            var dict = _sut.ReadXmlConfig(TEST_FILE_PATH, false);

            dict.Values.First()!.Should().Contain("%");
        }
    }
}
