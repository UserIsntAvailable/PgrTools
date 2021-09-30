using System;
using System.Linq;
using FluentAssertions;
using PgrTools.Tools;
using Xunit;

namespace PgrTools.Unit.Tests.Tools
{
    public class ConfigParserTests : BaseTest
    {
        private readonly ConfigParser _sut = new();

        [Fact]
        public void ParsePlayerKeyMapping_Should_When()
        {
            var value = new ConfigReader()
                .ReadXmlConfig(TestFilePath, false)["PlayerKeyMapping"];

            var keysCount = Enum.GetValues(typeof(KeyMappingKey)).Length;

            var dict = _sut.ParsePlayerKeyMapping(value);

            dict.Should().HaveCount(keysCount)
                .And.ContainKey(KeyMappingKey.MoveUp)
                .WhoseValue.Should().Be("W");
        }
    }
}
