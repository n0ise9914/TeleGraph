using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleGraph.Plugin.Client;
using TeleGraph.Plugin;

namespace Sample_Plugin
{
    class Main : TeleGraph.Plugin.IMain
    {
        #region Default
        private int id;
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }
        public IPluginAdaptor pluginadaptor;
        public IPluginAdaptor PluginAdaptor
        {
            set
            {
                pluginadaptor = value;
                client = value.Client;
            }
        }
        private Config config = new Config();
        public Config Config
        {
            get
            {
                return config;
            }

            set
            {
                config = value;
            }
        }
        #endregion
        public Main()
        {
            //---About your Plugin---//
            config.Author = "Maxbuzz (n0!se & pr!mary)";
            config.Name = "Plugin-Test";
            config.Description = "something for fun !";
            config.Version = "1.0";

            //---Your Plugin's Commands---//
            Commands coms = new Commands();
            coms.Add(new Command("start", @"/start", "Start Game"));
            coms.Add(new Command("finish", @"/finish", "Finish Game"));
            coms.Add(new Command("roll", @"/roll", "Roll in Game"));
            config.Commands = coms;          
        }         
        private IClient client;
        public void OnReviceMessage(Message message)
        {
                pluginadaptor.OnMessage(this, message.Text);    
        }

    }

}
