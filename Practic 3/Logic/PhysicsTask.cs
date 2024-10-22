using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class PhysicsTask : Tasks
    {
        public int Quantity { get; set; }
        public DateTime DateOfCompletion { get; set; }

        public PhysicsTask(string nameStudent, string typeOfTask, DateTime dateGet, int quantity, DateTime dateOfCompletion)
            : base(nameStudent, typeOfTask, dateGet)
        {
            Quantity = quantity;
            DateOfCompletion = dateOfCompletion;
        }

        public override void print()
        {
            Console.WriteLine($"Задача по физике: {NameStudent}, {TypeOfTask}, {DateGet:dd.MM.yyy}, {Quantity}, {DateOfCompletion:dd.MM.yyy}");
        }
    }
}
