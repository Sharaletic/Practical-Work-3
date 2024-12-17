// This is a personal academic project. Dear PVS-Studio, please check it.// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;

namespace Logic
{
    public class MathematicsTask : Tasks
    {
        private double _mark;

        public double Mark {
            get
            {
                return _mark;
            }
            set
            {
                if (value < 0 || value > 10)
                    throw new Exception("Оценка должна быть в диапазоне от 0 до 10");
                else if (value >= 0 && value <= 10)
                    _mark = value;
            }
            
        }

        public MathematicsTask(string nameStudent, string typeOfTask, DateTime dateGet, double mark)
            : base(nameStudent, typeOfTask, dateGet)
        {
            Mark = mark;
        }

        public override bool Equals(object obj)
        {
            if (obj is MathematicsTask task)
                return NameStudent == task.NameStudent && TypeOfTask == task.TypeOfTask && DateGet == task.DateGet && Mark == task.Mark;
            return false;
        }

        public override int GetHashCode()
        {
            return (NameStudent, TypeOfTask, DateGet, Mark).GetHashCode();
        }

        public override string ToString()
        {
            return $"Задача по математике: {NameStudent}, {TypeOfTask}, {DateGet:dd.MM.yyy}, {Mark}";
        }
    }
}
