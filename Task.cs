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
        
        /// <summary>
        /// getter and setter for the Prioretytype. 
        /// </summary>
        public PriorityType Priority 
        { 
            get { return priority; } 
            set { priority = value; }
        }
        //methods:

        /// <summary>
        /// Thes method returns the time in a string format so that it can be written out in the application. 
        /// </summary>
        /// <returns></returns>
        private string timeToString()
        {
            string time = string.Format("{0}:{1}", dateAndTime.Hour.ToString("00"), dateAndTime.Minute.ToString("00"));
            return time;
        }
        /// <summary>
        /// Method that takes the choosen enum and return it as a string with out the _ and wit a space instead to make the application looking nicer. 
        /// </summary>
        /// <returns></returns>
        private string enumToString()
        {
            string prioString = Enum.GetName(typeof(PriorityType), priority);
            prioString = prioString.Replace("_", " ");
            return prioString;
        }

        /// <summary>
        /// This method creates one string of all the inputs that the user is given the application and returns it to be able to write it out in the listbox. . 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string createdTask = $"{dateAndTime.ToLongDateString(),-25} {timeToString(),12} {" ",6} {enumToString(),-16} {description,-20}";
            return createdTask;
        }
    }
}
