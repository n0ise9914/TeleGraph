using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot.Types;
using TeleGraph;
using TeleGraph.Plugin;
using Newtonsoft.Json;
using System.Web;
using System.IO;

namespace Sample_TeleGraph
{

    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        string Plugins_Directory = Application.StartupPath + @"\Plugins\";
        string Commands_Directory = Application.StartupPath + @"\commands\";

        private Manager manager;
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = Plugins_Directory;
            textBox2.Text = Commands_Directory;
            manager = new Manager(Bot_Token.Text, Plugins_Directory, Commands_Directory);
            manager.OnMessage += Manager_OnMessage;
            manager.OnError += Manager_OnError;
            manager.Client.OnConnected += Client_OnConnected;
            manager.PluginManager.LoadPlugins();

            cPlugin1.OnSaveChanges += CPlugin1_OnSaveChanges;

            foreach (PluginObj plugin in manager.PluginManager.Plugins)
                listBox1.Items.Add(plugin.ConfigAdaptor.Name);
        }

        private void CPlugin1_OnSaveChanges(Commands commands, PluginObj plugin)
        {
            manager.PluginManager.SaveCommand(Commands_Directory, commands, plugin.ConfigAdaptor.Name);
            MessageBox.Show("Saved Commands!");
        }

        private void Client_OnConnected(object sender, User me)
        {
            tabControl1.SelectTab(2);
            Console.Text += Environment.NewLine + "Connected to Telegram Web API ! " + Environment.NewLine + "Bot_ID: " + me.Id + " Bot_FirstName: " + me.FirstName + "Bot_LastName: " + me.LastName + " Bot_UserName: " + me.Username;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            manager.UpdateDelay = 1000;
            manager.Client.Connect();
        }
        private void Manager_OnError(object sender, Exception ex)
        {
            if (this.InvokeRequired) BeginInvoke(new MethodInvoker(delegate () { Console.Text += ex.Message + Environment.NewLine; }));
        }
        private void Manager_OnMessage(object sender, string message)
        {
            if (this.InvokeRequired) BeginInvoke(new MethodInvoker(delegate () { Console.Text += message + Environment.NewLine; }));
        }
        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (PluginObj plugin in manager.PluginManager.Plugins)
                if (plugin.ConfigAdaptor.Name == listBox1.Items[listBox1.SelectedIndex].ToString())
                    cPlugin1.LoadPlugin(plugin);
        }

    }
}
