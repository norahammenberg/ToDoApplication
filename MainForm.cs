using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace ToDoApplication
{
    public partial class MainForm : Form
    {
        //instance varaibles. 
        private TaskManager taskManager;
        private string fileName = Application.StartupPath + "\\Tasks.txt";//filename where the 
       
        public MainForm()
        {
            InitializeComponent();
            InitializeUI();
        }
        /// <summary>
        /// Initialaxing the user interface, including for example adding the prioritytype to the cobobox and cleaing the listbox as well as creating the custom time format
        /// </summary>
        private void InitializeUI()
        {
            taskManager = new TaskManager();
            
            comboBoxPrio.DataSource = Enum.GetValues(typeof(PriorityType));
            textBoxToDo.Text = String.Empty;
            listBoxToDo.Items.Clear();
            groupBoxToDo.Enabled = true;
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "yyyy-MM-dd   HH:mm";
        }
        /// <summary>
        /// reading the userinput. starting with creating a new object of the task class.
        /// I f the description box is empty ask the user to please add a to do task. 
        /// getting all inouts from the user.
        /// </summary>
        /// <returns>returning the task created with</returns>
        private Task readUserInput()
        {
            Task task = new Task();
            if (string.IsNullOrEmpty(textBoxToDo.Text))
            {
                MessageBox.Show("Please write a to do task.");
                return null;
            }
            
            task.Description = textBoxToDo.Text.Trim();
            task.DateAndTime = dateTimePicker.Value;   
            task.Priority = (PriorityType)comboBoxPrio.SelectedIndex;
            
            return task;
            
        }

        /// <summary>
        /// updating the user interface,
        /// clearing the current list box and creating an array, calling the nethod in the tsakamanger thats creats the list. 
        /// if the array is not null add the array to the listbox and display. 
        /// </summary>
        private void updateUI()
        {
            listBoxToDo.Items.Clear();
            string[] arrayOfTasks = taskManager.creatingListOfTasks(); // creating the list
            if (arrayOfTasks != null)
            {
                //listBoxToDo.Items.Clear();
                listBoxToDo.Items.AddRange(arrayOfTasks);
            }
        }
        /// <summary>
        /// read user inout and save the input in the task if a task is added update the uerinterface. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Task task = readUserInput();
            if (taskManager.addTask(task))
            {
                updateUI();
            }
        }
        /// <summary>
        /// when clicking open, call the method thta opens the file. if that goes wrong the user is told it can not open the file, 
        /// if it works update the UI with the info from the file. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool ok = taskManager.readFromFile(fileName);
            if (!ok)
            {
                MessageBox.Show("Something went wrong when open your file");
            }
            else
                updateUI();
        }

        /// <summary>
        /// when the user is clicking on save the info in the listbox issaved to the file by calling the methods that saving on the file. 
        /// if something goes wrong the user is told if it goes right then user is told where the file is saved.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool ok = taskManager.writeToFile(fileName);
            if (!ok)
            {
                MessageBox.Show("Something went wrong when saving your file");
            }
            else
                MessageBox.Show("Task saved to file" + Environment.NewLine + fileName);
        }
        /// <summary>
        /// opening a new todolist.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitializeUI();
        }

        /// <summary>
        /// exit the application. 
        /// if the user choose cansel the application do not closes and stays as it were if the user says ok. the application exits. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogBox = MessageBox.Show("Would you like to exit?", "Yes or no?", MessageBoxButtons.OKCancel);
            if (dialogBox == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}