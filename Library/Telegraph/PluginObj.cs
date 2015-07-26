using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TeleGraph;
using TeleGraph.Plugin;

namespace TeleGraph
{
    public class PluginObj
    {
        public delegate void _OnError(object sender, Exception ex);
        public event _OnError OnError;

        private Assembly pluginAsm;
        private Type CoreType; private object Core; private PropertyInfo ClientPropertyInfo;
        private PropertyInfo ConfigPropertyInfo;

        private ConfigAdapter configAdaptor;
        public ConfigAdapter ConfigAdaptor
        {
            get
            {
                return configAdaptor;
            }
        }
        private string _pluginname;
        public void Load(string pluginfolder, string pluginname, PluginAdaptor pluginadaptor)
        {
            try
            {
                _pluginname = pluginname;
                pluginAsm = Assembly.LoadFile(pluginfolder + _pluginname + ".dll");
                CoreType = pluginAsm.GetType(_pluginname + ".Main");
                Core = Activator.CreateInstance(CoreType);
                ClientPropertyInfo = CoreType.GetProperty("PluginAdapter");
                ClientPropertyInfo.SetValue(Core, pluginadaptor, null);

                ConfigPropertyInfo = CoreType.GetProperty("Config");
                Config config = (Config)ConfigPropertyInfo.GetValue(Core, null);
                configAdaptor = new ConfigAdapter(config);
                configAdaptor.OnError += ConfigAdaptor_OnError;
            }
            catch (Exception ex)
            {
                OnError(this, ex);
            }

        }

        private void ConfigAdaptor_OnError(object sender, Exception ex)
        {
            OnError(sender, ex);
        }

        public void MessageReviced(TeleGraph.Plugin.Client.Message message)
        {
            try
            {
                CoreType.InvokeMember("OnReviceMessage",
                                        BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public,
                                        null, Core, new object[] { message });
            }
            catch (Exception ex)
            {
                OnError(this, ex);
            }


        }
    }
}
