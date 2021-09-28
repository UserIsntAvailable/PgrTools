using System.Linq;
using AutoFixture;
using FluentAssertions;
using PgrTools.Internals;
using Xunit;

namespace PgrTools.Unit.Tests.Internals.Utils
{
    public class StringUtilsTests
    {
        private readonly Fixture _fixture = new();

        [Fact]
        public void UrlHexToStr_ShouldPass_WhenHexStringIsValid()
        {
            var actual = _fixture.Create<string>();
            var hexActual = string.Concat(actual.Select(c => $"%{(int) c:X}"));

            var expected = StringUtils.UrlHexToStr(hexActual);

            expected.Should().Be(actual);
        }
    }
}
