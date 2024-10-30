using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Logic
{
    public class Tasks
    {
        public string NameStudent { get; set; }
        public string TypeOfTask { get; set; }
        public DateTime DateGet { get; set; }

        public Tasks(string nameStudent, string typeOfTask, DateTime dateGet)
        {
            NameStudent = nameStudent;
            TypeOfTask = typeOfTask;
            DateGet = dateGet;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Tasks task = (Tasks)obj;
            return NameStudent == task.NameStudent && TypeOfTask == task.TypeOfTask && DateGet == task.DateGet;
        }

        public virtual void print()
        {
            Console.WriteLine($"Задача: {NameStudent}, {TypeOfTask}, {DateGet:dd.MM.yyy}");
        }
    }
}
