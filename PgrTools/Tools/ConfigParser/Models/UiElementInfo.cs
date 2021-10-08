// ReSharper disable once CheckNamespace
namespace PgrTools.Tools
{
    /// <summary>
    /// Holds data about a <see cref="CustomUiElement"/>.
    /// </summary>
    /// <param name="PositionX">The position from left to right of the object</param>
    /// <param name="PositionY">The position from bottom to top of the object</param>
    /// <param name="Scale">The scale of the object</param>
    public record UiElementInfo(double PositionX, double PositionY, double Scale);
}
