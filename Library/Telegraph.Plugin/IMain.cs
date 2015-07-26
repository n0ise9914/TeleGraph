using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleGraph.Plugin.Client;

namespace TeleGraph.Plugin
{
    public interface IMain
    {
        TeleGraph.Plugin.Config Config
        {
            get;
            set;
        }
        TeleGraph.Plugin.IPluginAdaptor PluginAdaptor
        {
            set;
        }
        int Id
        {
            set;
            get;
        }
        void OnReviceMessage(Message message);
        
    }

}
