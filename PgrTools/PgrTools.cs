using PgrTools.Tools;
using StaticInjector;

namespace PgrTools
{
    [Inject(typeof(ConfigReader))]
    [Inject(typeof(ConfigParser))]
    public static partial class PgrTools
    {
    }
}
