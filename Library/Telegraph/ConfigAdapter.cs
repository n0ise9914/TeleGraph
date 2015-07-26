using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TeleGraph.Plugin;

namespace TeleGraph
{
    public class ConfigAdapter : Plugin.IConfig
    {

        public delegate void _OnError(object sender, Exception ex);
        public event _OnError OnError;

        private Config _config;
        public ConfigAdapter(Config config)
        {
            _config = config;
        }
        public void SetCommands(Commands commands)
        {
            try
            {
                PropertyInfo CommandsPropertyInfo = _config.GetType().GetProperty("Commands");
                CommandsPropertyInfo.SetValue(_config, commands, null);
            }
            catch (Exception ex)
            {
                OnError(this, ex);
            }

        }
        public string Author
        {
            get
            {
                return _config.Author;
            }
        }
        public Commands Commands
        {
            get
            {
                return _config.Commands;
            }
        }
        public string Description
        {
            get
            {
                return _config.Description;
            }
        }
        public string Name
        {
            get
            {
                return _config.Name;
            }
        }
        public string Version
        {
            get
            {
                return _config.Version;
            }
        }
    }
}
