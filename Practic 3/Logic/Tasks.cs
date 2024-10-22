using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public virtual void print()
        {
            Console.WriteLine($"Задача: {NameStudent}, {TypeOfTask}, {DateGet:dd.MM.yyy}");
        }
    }
}
