using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TeleGraph
{
    public class PluginValidator
    {
        private Assembly pluginAsm;
        private Type CoreType; private object Core; private PropertyInfo ClientPropertyInfo;
        private TeleGraph.Plugin.Config config;
        PropertyInfo ConfigPropertyInfo;
        public bool IsPLuginValid(string pluginfolder, string pluginname)
        {
            try
            {
                pluginAsm = Assembly.LoadFile(pluginfolder + pluginname + ".dll");
                CoreType = pluginAsm.GetType(pluginname + ".Main");
                Core = Activator.CreateInstance(CoreType);
                ClientPropertyInfo = CoreType.GetProperty("PluginAdapter");
                ConfigPropertyInfo = CoreType.GetProperty("Config");
                config = (TeleGraph.Plugin.Config)ConfigPropertyInfo.GetValue(Core, null);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            };
        }
    }
}
