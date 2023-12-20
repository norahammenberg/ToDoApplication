using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApplication
{
    internal class Task
    {
        //instance variables
        private string description;
        private DateTime dateAndTime;
        private PriorityType priority;

        //constractor:
        /// <summary>
        /// default constructor calling setting the instance variables to different values: 
        /// </summary>
        public Task()
        {
            description = string.Empty;
            dateAndTime = DateTime.Now;
            priority = PriorityType.Normal;
            Console.WriteLine(dateAndTime);
        }
        
        //properties:

        /// <summary>
        /// getter and setter for the Description.
        /// If the string provided by the user is not nyll or empty the save the users input to the variable. 
        /// </summary>
        public string Description 
        { 
            get { return description; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    description = value;
                }
            }              
        }

        /// <summary>
        /// getter and setter for the time and date providid by the user. 
        /// </summary>
        public DateTime DateAndTime
        {
            get { return dateAndTime; }
            set { dateAndTime = value; }
        }
        
        public PriorityType Priority 
        { 
            get { return priority; } 
            set { priority = value; }
        }
        //methods:

        public override string ToString()
        {
            
            string selectedPriority = priority.ToString();
            string choosenDateAndTime = dateAndTime.ToString();
            string createdTask = string.Format("{0, -25} {1, -8} {2, -10}", choosenDateAndTime, description, selectedPriority);
            return createdTask;
        }





        /// <summary>
        /// Test method for debuging reasons.
        /// </summary>
        public void testOut()
        {
            description = "We need to do this";
            ToString();
            Console.WriteLine(dateAndTime);
            Console.WriteLine(ToString());
            Console.ReadLine();
        }
    }
}
