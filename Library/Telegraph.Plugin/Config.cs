using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleGraph.Plugin;

namespace TeleGraph.Plugin
{
    public class Config : TeleGraph.Plugin.IConfig
    {
        public Config()
        {

        }
        private string author;
        public string Author
        {
            get
            {
                return author;
            }
            set
            {
                author = value;
            }
        }
        private string description;
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        private string version;
        public string Version
        {
            get
            {
                return version;
            }
            set
            {
                version = value;
            }
        }
        private Commands commands = new Commands();
        public  Commands Commands
        {
            get
            {
                return commands;
            }

            set
            {
                commands = value;
            }
        }
    }
}