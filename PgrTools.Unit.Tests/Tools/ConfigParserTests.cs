using System;
using FluentAssertions;
using PgrTools.Tools;
using Xunit;

namespace PgrTools.Unit.Tests.Tools
{
    public class ConfigParserTests : BaseTest
    {
        private readonly IConfigParser _sut = new ConfigParser();

        [Fact]
        public void ParsePlayerKeyMapping_ShouldWork_WhenValidValue()
        {
            var testValue = new ConfigReader()
                .ReadXmlConfig(TestFilePath, false)["PlayerKeyMapping"];

            var dict = _sut.ParsePlayerKeyMapping(testValue);

            var keysCount = Enum.GetValues(typeof(KeyMappingKey)).Length;

            dict.Should().HaveCount(keysCount)
                .And.ContainKey(KeyMappingKey.MoveUp)
                .WhoseValue.Should().Be("W");
        }

        [Fact]
        public void ParseCustomUi_ShouldWork_WhenValidValue()
        {
            var testValue = new ConfigReader()
                .ReadXmlConfig(TestFilePath, false)["CustomUI"];

            var dict = _sut.ParseCustomUi(testValue);

            var keysCount = Enum.GetNames(typeof(CustomUiComponent)).Length;

            dict.Should().HaveCount(keysCount)
                .And.ContainKey(CustomUiComponent.JoyStick)
                .WhoseValue.Should().Be(new CustomComponentData(125.9527, 130.9318, 0.6998));
        }
    }
}
