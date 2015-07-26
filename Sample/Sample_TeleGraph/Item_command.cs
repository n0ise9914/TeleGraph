using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeleGraph.Plugin;

namespace Sample_TeleGraph
{
    public partial class Item_command : UserControl
    {
        public Item_command()
        {
            InitializeComponent();
        }

        public Item_command(Command command)
        {
            InitializeComponent();
            Key.Text += command.Key;
            name.Text += command.Name;
            Description.Text += command.Description;
        }
    }
}
