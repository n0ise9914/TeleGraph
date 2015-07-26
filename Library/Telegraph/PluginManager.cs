using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TeleGraph.Plugin;

namespace TeleGraph
{
    public class PluginManager
    {
        public delegate void _OnPluginLoaded(TeleGraph.PluginObj plugin);
        public event _OnPluginLoaded OnPluginLoaded;

        public delegate void _OnMessage(object sender, string message);
        public event _OnMessage OnMessage;

        public delegate void _OnError(object sender, Exception ex);
        public event _OnError OnError;

        private TeleGraph.ClientAdapter client = new TeleGraph.ClientAdapter();
        private PluginAdaptor pluginadapter;
        private PluginValidator pluginvalidator = new PluginValidator();

        public PluginManager(Telegram.Bot.Api _Api, string plugin_directory)
        {
            try
            {
                PluginFolder = plugin_directory;
                client.OnTaskDone += OnTaskDone;
                client.Api = _Api;
                client.Id = 9914;
                pluginadapter = new PluginAdaptor(client);
                pluginadapter.Onerror += (sender, error) => { OnError(sender, error); };
                pluginadapter.Onmessage += (sender, message) => { OnMessage(sender, message); };
            }
            catch (Exception ex)
            {
                OnError(this, ex);
            }
        }

        private List<PluginObj> plugins = new List<PluginObj>();
        public List<PluginObj> Plugins
        {
            get
            {
                return plugins;
            }
        }
        private string PluginFolder;
        public void LoadPlugins()
        {
            try
            {
                DirectoryInfo Dir = new DirectoryInfo(PluginFolder);
                string PluginName;
                foreach (var file in Dir.GetFiles("*.dll"))
                {

                    PluginName = file.Name.Substring(0, file.Name.IndexOf(".dll"));
                    if (pluginvalidator.IsPLuginValid(PluginFolder, PluginName))
                    {
                        PluginObj p = new PluginObj();
                        p.OnError += P_OnError;
                        p.Load(PluginFolder, PluginName, pluginadapter);
                        plugins.Add(p);
                        OnPluginLoaded(p);
                    }
                }
            }
            catch (Exception ex)
            {
                OnError(this, ex);
            }
        }

        private void P_OnError(object sender, Exception ex)
        {
            OnError(sender, ex);
        }

        public void MessageReviced(TeleGraph.Plugin.Client.Message message)
        {
            try
            {
                foreach (PluginObj plugin in Plugins)
                {
                    plugin.MessageReviced(message);
                }
            }
            catch (Exception ex)
            {
                OnError(this, ex);
            }
        }
        private void OnTaskDone(Task<Telegram.Bot.Types.Message> task)
        {
            OnMessage(this, task.Status.ToString());
        }
        public void CheckCommand(PluginObj plugin, string commands_directory)
        {
            try
            {
                DirectoryInfo Dir = new DirectoryInfo(commands_directory);
                string JsonFileName;
                string SerializedCommands;
                foreach (var file in Dir.GetFiles("*.json"))
                {
                    JsonFileName = file.Name.Substring(0, file.Name.IndexOf(".json"));
                    if (HttpUtility.UrlDecode(JsonFileName) == plugin.ConfigAdaptor.Name)
                    {
                        SerializedCommands = System.IO.File.ReadAllText(commands_directory + HttpUtility.UrlEncode(plugin.ConfigAdaptor.Name) + ".json");
                        Commands DeSerializedCommands = JsonConvert.DeserializeObject<Commands>(SerializedCommands);
                        plugin.ConfigAdaptor.SetCommands(DeSerializedCommands);
                        OnMessage(this, Environment.NewLine + "Loaded commands for " + plugin.ConfigAdaptor.Name + Environment.NewLine);
                    }
                }
            }
            catch (Exception ex)
            {
                OnError(this, ex);
            }
        }
        public void SaveCommand(string Commands_Directory, Commands commands, string PluginName)
        {
            string SerializedCommands = JsonConvert.SerializeObject(commands);
            System.IO.File.WriteAllText(Commands_Directory + HttpUtility.UrlEncode(PluginName) + ".json", SerializedCommands);

        }
    }
}
