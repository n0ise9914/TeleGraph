using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleGraph.Plugin
{
    public class Commands : List<Command>
    {
        public string GetName(string key)
        {
           
            foreach (Command command in this)
            {
                if (command.Key == key)
                {
                    return command.Name;
                }                  
            }
            return null;
        }
        public void SetName(string key,string name)
        {

            foreach (Command command in this)
            {
                if (command.Key == key)
                {
                    command.Name = name;
                }
            }
        }
        public bool ContainsKey(string key)
        {
            foreach (Command command in this)
            {
                if (command.Key == key)
                {
                    return true;
                }
               
            }
            return false;
        }
    }
}
