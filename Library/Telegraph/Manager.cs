using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TeleGraph.Plugin;
using Newtonsoft.Json;

namespace TeleGraph
{
    public class Manager
    {
        public delegate void _OnMessage(object sender, string message);
        public event _OnMessage OnMessage;

        public delegate void _OnError(object sender, Exception ex);
        public event _OnError OnError;

        private string _bot_token;
        private string _plugins_directory;
        private string _commands_directory;

        private Client client;
        public Client Client
        {
            get
            {
                return client;
            }
        }
        private PluginManager pluginmanager;
        public PluginManager PluginManager
        {
            get
            {
                return pluginmanager;
            }
        }

        public Manager(string bot_token, string plugin_directory, string commands_directory)
        {
            try
            {
                parser = new Parser();
                parser.OnError += Parser_OnError;
                _plugins_directory = plugin_directory;
                _commands_directory = commands_directory;
                _bot_token = bot_token;

                client = new Client(bot_token);
                client.OnError += Client_OnError;
                client.OnUpdateRecived += Client_OnUpdateRecived;

                pluginmanager = new PluginManager(client.Api, plugin_directory);
                pluginmanager.OnPluginLoaded += PluginManager_OnPluginLoaded;
                pluginmanager.OnError += (sender, error) => { OnError(sender, error); };
                pluginmanager.OnMessage += (sender, message) => { OnMessage(sender, message); };
            }
            catch (Exception ex)
            {
                OnError(this, ex);
            }
        }

        private void Parser_OnError(object sender, Exception ex)
        {
            OnError(sender, ex);
        }

        public int UpdateDelay
        {
            get
            {
                return client.UpdateDelay;
            }
            set
            {
                client.UpdateDelay = value;
            }
        }

        private Parser parser;
        private void Client_OnUpdateRecived(object sender, Telegram.Bot.Types.Message message)
        {
            pluginmanager.MessageReviced(parser.ParseMessage(message));
        }

        private void Client_OnError(object sender, Exception ex)
        {
            OnError(sender, ex);
        }

        private void PluginManager_OnPluginLoaded(PluginObj plugin)
        {
            try
            {
               pluginmanager.CheckCommand(plugin, _commands_directory);
            }
            catch (Exception ex)
            {
                OnError(this, ex);
            }
        }
    }
}
