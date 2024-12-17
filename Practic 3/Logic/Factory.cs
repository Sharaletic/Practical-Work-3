// This is a personal academic project. Dear PVS-Studio, please check it.// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.IO;
using System.Linq;

namespace Logic
{
    public class Factory
    {
        public static string[] getLines(string text)
        {
            return text.Trim().Split('\n');
        }

        public static string[] readFile(string path)
        {
            return File.ReadAllText(path).Trim().Split('\n');
        }

        public static bool checkLine(string line)
        {
            if (!string.IsNullOrWhiteSpace(line) && line.Count(x => x == '"') == 2)
                return true;
            return false;
        }

        public static (string, string[]) parseLine(string text)
        {
            if (!checkLine(text))
                throw new Exception("Неверный формат строки");
            else
            {
                string name = text.Substring(text.IndexOf('"') + 1, text.LastIndexOf('"') - (text.IndexOf('"') + 1));
                string[] data = text.Substring(text.LastIndexOf('"') + 1).Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                return (name, data);
            }
        }

        public static Tasks createProgrammingTask(string text)
        {
            var (name, data) = parseLine(text);
            if (data.Length != 2)
                throw new Exception("Неверное количество полей");
            return new ProgrammingTask(name, data[0], parseDate(data[1]));
        }

        public static Tasks createMathematicsTask(string text)
        {
            var (name, data) = parseLine(text);
            if (data.Length != 3)
                throw new Exception("Неверное количество полей");
            return new MathematicsTask(name, data[0], parseDate(data[1]), parseDouble(data[2]));
        }

        public static Tasks createPhysicsTask(string text)
        {
            var (name, data) = parseLine(text);
            if (data.Length != 4)
                throw new Exception("Неверное количество полей");
            return new PhysicsTask(name, data[0], parseDate(data[1]), parseInt(data[2]), parseDate(data[3]));
        }

        public static bool checkType(string type)
        {
            if (type == "Программирование" || type == "Математика" || type == "Физика")
                return true;
            return false;
        }

        public static DateTime parseDate(string date)
        {
            if (!DateTime.TryParse(date, out DateTime dt))
                throw new Exception("Дата имеет неверный формат");
            return dt;
        }

        public static int parseInt(string number)
        {
            if (!int.TryParse(number, out int nb))
                throw new Exception("Число имеет неверный формат");
            return nb;
        }

        public static double parseDouble(string mark)
        {
            if (!double.TryParse(mark, out double mk))
                throw new Exception("Оценка имеет неверный формат");
            return mk;
        }

        public static Tasks createObjects(string text)
        {
            string[] data = text.Split(new char[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);

            if (!checkType(data[0]))
                throw new Exception($"Неверный тип объекта");

            if (data[0] == "Программирование")
                return createProgrammingTask(data[1]);
            if (data[0] == "Математика")
                return createMathematicsTask(data[1]);
            if (data[0] == "Физика")
                return createPhysicsTask(data[1]);
            else
                throw new Exception("Не удалось создать объект");
        }
    }
}