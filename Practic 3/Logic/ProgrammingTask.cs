using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ProgrammingTask : Tasks
    {

        public ProgrammingTask(string Name, string TypeOfTask, DateTime DateGet) : base(Name, TypeOfTask, DateGet) { }

        public override bool Equals(object obj)
        {
            if (obj is ProgrammingTask task)
                return NameStudent == task.NameStudent && TypeOfTask == task.TypeOfTask && DateGet == task.DateGet;
            return false;
        }

        public override int GetHashCode()
        {
            return (NameStudent, TypeOfTask, DateGet).GetHashCode();
        }

        public override string ToString()
        {
            return $"Задача по программированию: {NameStudent}, {TypeOfTask}, {DateGet:dd.MM.yyy}";
        }
    }
}
