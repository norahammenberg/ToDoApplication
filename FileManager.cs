using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Linq.Expressions;

namespace ToDoApplication
{
    internal class FileManager
    {
        //const for our own knowladge for the file. We name the file ToDoApp and give it a versin number of 1. 
        private const string fileVersionToken = "ToDoApp";//a not to me that it is my program that made this file.
        private const int fileVersionNr = 1;//the versiobn of the appliation.

        /// <summary>
        /// this method saves the list the text file, by using the streamwriter. The application trys to creat an object of the streamwritter and writest the 
        /// filetoken and fileversion we declared above and the array of lists. It loops throug the list and write down description priorety and the date for every task that is added in the interface, 
        /// the method saves all this in the text file called tasks, declared in the mainform. Can the applications not do this and errors is catched and finelly the writer is closed. 
        /// </summary>
        /// <param name="listOfTasks"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool SaveTaskListToFile(List<Task> listOfTasks, string fileName)
        {
            bool ok = true;
            StreamWriter writer= null;
            try
            {
                writer = new StreamWriter(fileName);//creating a new object of the StreaWriter to write a file on the c drive on the computer with the given file path in the vairable filename. 
                writer.WriteLine(fileVersionToken);
                writer.WriteLine(fileVersionNr);
                writer.WriteLine(listOfTasks.Count);

                for ( int i = 0; i < listOfTasks.Count; i++ ) // looping through the array and write all parts of the tasks on its own line. 
                {
                    writer.WriteLine(listOfTasks[i].Description);
                    writer.WriteLine(listOfTasks[i].Priority.ToString());
                    writer.WriteLine(listOfTasks[i].DateAndTime.Year);
                    writer.WriteLine(listOfTasks[i].DateAndTime.Month);
                    writer.WriteLine(listOfTasks[i].DateAndTime.Day);
                    writer.WriteLine(listOfTasks[i].DateAndTime.Hour);
                    writer.WriteLine(listOfTasks[i].DateAndTime.Minute);
                    writer.WriteLine(listOfTasks[i].DateAndTime.Second);

                }
            }
            catch //catchin errors, if nthing can be written return false. 
            {
                ok = false;
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
            return ok;

        }

        /// <summary>
        /// this methods "opens" or reads an file and display t in the inteface. 
        /// if the listof task is not null clear it, but if it is create a new task list. 
        /// an object of the streamread is create dwith the parameter of the filename declared in the mainform. 
        /// to varify that the right file is being read we checking if the filetoken and fileversion number is the same as declared above. 
        /// if it is:
        /// we looping through all the task and reading line by line from the text file and adding the tasks to the list that will be displaed to the user. 
        /// </summary>
        /// <param name="listOfTasks"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool ReadTaskListFromFile(List<Task> listOfTasks, string fileName) 
        {
            bool ok = true; 
            StreamReader reader = null;

            try
            {
                if (listOfTasks != null)
                    listOfTasks.Clear();
                else
                    listOfTasks = new List<Task>();

                reader = new StreamReader(fileName);

                //making sure it is the correct file.
                string ver = reader.ReadLine();
                int vernum = int.Parse(reader.ReadLine());

                //if version number and token is equal to the const declared above.
                if ((ver == fileVersionToken) && (vernum == fileVersionNr))
                {
                    int count = int.Parse(reader.ReadLine());
                    for (int i = 0; i < count; i++)
                    {
                        Task task = new Task();
                        task.Description = reader.ReadLine();
                        task.Priority = (PriorityType)Enum.Parse(typeof(PriorityType), reader.ReadLine());

                        int year = 0, month = 0, day = 0;
                        int hour = 0, minute = 0, second = 0;

                        year = int.Parse(reader.ReadLine());
                        month = int.Parse(reader.ReadLine());
                        day = int.Parse(reader.ReadLine());
                        hour = int.Parse(reader.ReadLine());
                        minute = int.Parse(reader.ReadLine());
                        second = int.Parse(reader.ReadLine());
                       
                        
                        task.DateAndTime = new DateTime(year, month, day, hour, minute, second);
                        listOfTasks.Add(task);
                    }
                }
                else
                {
                    ok = false;
                }
            }

            catch (Exception ex)//catching errors.
            {
                ok = false;
                Console.WriteLine("Error: " + ex.Message + ex.StackTrace);
            }
            finally
            {
                if ( reader != null)
                {
                    reader.Close();// closing the reader. 
                }
               
            }       
            return ok;
        }
    }
}
