using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleGraph.Plugin
{
    public interface IConfig
    {
        Commands Commands
        {
            get;
        }
        string Name
        {
            get;
        }
        string Author
        {
            get;
 
        }
        string Version
        {
            get;
        }
        string Description
        {
            get;
        }
    }
}
