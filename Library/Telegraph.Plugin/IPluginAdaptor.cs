using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleGraph.Plugin
{
    public interface IPluginAdaptor
    {
        TeleGraph.Plugin.IClient Client
        {
            get;
            set;
        }
        void OnMessage(object sender, string message);
        void OnError(object sender, Exception ex);
    }
}
