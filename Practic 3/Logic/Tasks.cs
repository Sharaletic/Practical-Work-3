// This is a personal academic project. Dear PVS-Studio, please check it.// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
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
    }
}
