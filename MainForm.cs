using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoApplication
{
    public partial class MainForm : Form
    {
        TaskManager taskManager = new TaskManager();
       
        public MainForm()
        {
            InitializeComponent();
            comboBoxPrio.DataSource = Enum.GetValues(typeof(PriorityType));

            taskManager.test();
        }
    }
}
