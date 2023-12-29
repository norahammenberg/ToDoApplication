using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApplication
{
    internal class TaskManager
    {
        //instance variables:
        private List<Task> listOfTasks;

        /// <summary>
        /// Default constructor. 
        /// </summary>
        public TaskManager() 
        {
            //creating a new list of tasks. 
            listOfTasks = new List<Task>();
        }
   
        /// <summary>
        /// this method is adding the task to the list of tasks. By using the buidt in method Add we can add the task
        /// the task is set in as a parameter when this method is called. 
        /// if task is not null it is added to the list of tasks. and ok stays true. if on the other hand the task is null ok will be changed to false.
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public bool addTask(Task task)//need to send the parameter with type Task and the string that is created in the Task class
        {
            bool ok = true;
            if (task != null)
            {
                listOfTasks.Add(task);//adding the task to the list:
            }
            else
            {
                ok = false;
            }
           
            return ok;//returning ok as the task is now added to the list of tasks.
        }
        /// <summary>
        /// Creating a temp array with the length of the list.  looping through the array as long as i is less the the length of the array. 
        /// saving the list in the temp array as strings, to be able to display in the interface when this method is being called. 
        /// </summary>
        /// <returns> the array </returns>
        public string[] creatingListOfTasks()
        {
            //creating the array with the counted tasks that is already added to the list.
            string[] arrayOfTasks = new string[listOfTasks.Count];

            for (int i = 0; i < arrayOfTasks.Length; i++)
            {
                arrayOfTasks[i] = listOfTasks[i].ToString();
            }
            return arrayOfTasks;
        }

        /// <summary>
        /// creating a new object of the filemanager and calling the method in the file manager that saves the input to a text file. sending with thte parameter: list of the tasks and the filename. 
        /// The filename is sent from the mainform. 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool writeToFile(string fileName)
        {
            FileManager fileManger = new FileManager();
            return fileManger.SaveTaskListToFile(listOfTasks, fileName);
        }
        /// <summary>
        /// same as the above method but for reading/opening file instead of saving. 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool readFromFile(string fileName)
        {
            FileManager fileManager = new FileManager();
            return fileManager.ReadTaskListFromFile(listOfTasks, fileName);

        }

    }
}
