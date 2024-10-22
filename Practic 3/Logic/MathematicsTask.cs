using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class MathematicsTask : Tasks
    {
        public double Mark { get; set; }

        public MathematicsTask(string nameStudent, string typeOfTask, DateTime dateGet, double mark)
            : base(nameStudent, typeOfTask, dateGet)
        {
            Mark = mark;
        }

        public override void print()
        {
            Console.WriteLine($"Задача по математике: {NameStudent}, {TypeOfTask}, {DateGet:dd.MM.yyy}, {Mark}");
        }
    }
}
