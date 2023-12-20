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

        //constroctor:

        public TaskManager() 
        {
            //creating a new list of tasks. 
            listOfTasks = new List<Task>();
        }

        //properties:
        /// <summary>
        /// properties read only, counting the amount of task that have been created. 
        /// </summary>
        public int CountTasks 
        { 
            get { return listOfTasks.Count; } 
        }

        //methods:
        //////////////i AM NOT GETTING THE TASK FROM ANYWHERE......!
        /// <summary>
        /// this method is adding the task to the list of tasks. By using the buidt in method Add we can add the task
        /// the task is set in as a parameter when this method is called. 
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public bool addTask(Task task)//need to send the parameter with type Task and the string that is created in the Task class
        {
            listOfTasks.Add(task);//adding the task to the list:
            return true;//returning true as the task is now added to the list of tasks.
        }

        public string[] creatingListOfTasks()
        {
            //creating the array with the counted tasks that is already added to the list.
            string[] arrayOfTasks = new string[listOfTasks.Count];

            int i = 0;

            foreach ( Task createdTask in listOfTasks)
            {
                arrayOfTasks[i++] = createdTask.ToString();
            }
            return arrayOfTasks;
        }

        public void test() 
        {

            string[] test = creatingListOfTasks();
            Console.WriteLine(test);
        }
    }
}
