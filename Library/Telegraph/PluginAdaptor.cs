using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleGraph.Plugin;
using TeleGraph;

namespace TeleGraph
{
    public class PluginAdaptor : Plugin.IPluginAdaptor
    {
        public delegate void _OnMessage(object sender, string message);
        public event _OnMessage Onmessage;

        public delegate void _OnError(object sender, Exception ex);
        public event _OnError Onerror;

        public PluginAdaptor(Plugin.IClient _client)
        {
            client = _client;
        }
        private Plugin.IClient client;
        public Plugin.IClient Client
        {
            get
            {
                return client;
            }

            set
            {
                client = value;
            }
        }
        public void OnError(object sender, Exception error)
        {
            Onerror(sender, error);
        }
        public void OnMessage(object sender, string message)
        {
            Onmessage(sender, message);
        }

    }
}
