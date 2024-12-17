// This is a personal academic project. Dear PVS-Studio, please check it.// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Xml.Linq;

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

        public override bool Equals(object obj)
        {
            if (obj is PhysicsTask task)
                return NameStudent == task.NameStudent && TypeOfTask == task.TypeOfTask && DateGet == task.DateGet && Quantity == task.Quantity && 
                    DateOfCompletion == task.DateOfCompletion;
            return false;
        }

        public override int GetHashCode()
        {
            return (NameStudent, TypeOfTask, DateGet, Quantity, DateOfCompletion).GetHashCode();
        }

        public override string ToString()
        {
            return $"Задача по физике: {NameStudent}, {TypeOfTask}, {DateGet:dd.MM.yyy}, {Quantity}, {DateOfCompletion:dd.MM.yyy}";
        }
    }
}
