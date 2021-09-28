using FluentAssertions;
using PgrTools.Tools;
using Xunit;

namespace PgrTools.Unit.Tests.Tools
{
    public class ConfigReaderTests
    {
        private readonly IConfigReader _sut = new ConfigReader(_ => _);

        [Fact]
        public void ReadXmlConfig_ShouldReturnDictionary_WhenPathExists()
        {
            const string path = "Resources/playerprefs.sample.xml";

            var dict = _sut.ReadXmlConfig(path);

            dict.Should().ContainKeys("PlayerKeyMapping", "CustomUI");
        }
    }
}
