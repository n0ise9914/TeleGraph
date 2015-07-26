using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeleGraph;
using TeleGraph.Plugin;

namespace Sample_TeleGraph
{
    public partial class Item_Plugin : UserControl
    {
       
        public Item_Plugin()
        {
            InitializeComponent();

        }

        public delegate void EventOnSaveChanges(Commands commands , PluginObj plugin);
        public event EventOnSaveChanges OnSaveChanges;

        private PluginObj _plugin;
        public void LoadPlugin(PluginObj plugin)
        {
            _plugin = plugin;
            name.Text += plugin.ConfigAdaptor.Name;
            Author.Text += plugin.ConfigAdaptor.Author;
            Version.Text += plugin.ConfigAdaptor.Version;
            Description.Text += plugin.ConfigAdaptor.Description;
            foreach (Command command in plugin.ConfigAdaptor.Commands)
                CommandList.Controls.Add(new Item_command(command));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Commands coms = new Commands();
            coms = _plugin.ConfigAdaptor.Commands;
            foreach (Control command in CommandList.Controls)
            {
                if(command.GetType() == typeof(Item_command))
                {
                    foreach (Command com in coms)
                    {
                        if (((Item_command)command).Key.Text.Contains(com.Key))
                        {
                            com.Name = ((Item_command)command).name.Text;
                        }
                    }
                }
            }
            OnSaveChanges(coms, _plugin);
        }
    }
}
