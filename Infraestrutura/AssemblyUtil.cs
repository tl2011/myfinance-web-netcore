using System.Reflection;

namespace myfinance_web_netcore.Infraestrutura
{
    public class AssemblyUtil
    {
        public static IEnumerable<Assembly> GetCurrentAssemblies()
        {
            return new Assembly[]
            {
                Assembly.Load("myfinance-web-netcore"),
            };
        }

    }
}