using System.Linq;
using FluentAssertions;
using PgrTools.Tools;
using Xunit;

namespace PgrTools.Unit.Tests.Tools
{
    public class ConfigReaderTests : BaseTest
    {
        private readonly IConfigReader _sut = new ConfigReader();

        [Fact]
        public void ReadXmlConfig_ShouldReturnDictionary_WhenPathExists()
        {
            var dict = _sut.ReadXmlConfig(TestFilePath);

            dict.Should().ContainKeys("PlayerKeyMapping", "CustomUI");
        }

        [Fact]
        public void ReadXmlConfig_ShouldNotConvertHex_WhenConvertToAsciiIsFalse()
        {
            var dict = _sut.ReadXmlConfig(TestFilePath, false);

            dict.Values.First()!.Should().Contain("%");
        }
    }
}
