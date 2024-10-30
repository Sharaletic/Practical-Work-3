using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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
            int count = line.Count(x => x == '"');
            if (count == 2 && line != string.Empty)
                return true;
            return false;
        }

        public static Tasks createTask(string text)
        {
            if (!checkLine(text))
                throw new Exception("Неверный формат строки");
            string name = text.Substring(text.IndexOf('"') + 1, text.LastIndexOf('"') - (text.IndexOf('"') + 1));
            string[] line = text.Substring(text.LastIndexOf('"') + 1).Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (line.Length != 2)
                throw new Exception("Неверное количество полей");
            return new Tasks(name, line[0], parseDate(line[1]));
        }

        public static Tasks createMathematicsTask(string text)
        {
            if (!checkLine(text))
                throw new Exception("Неверный формат строки");
            string name = text.Substring(text.IndexOf('"') + 1, text.LastIndexOf('"') - (text.IndexOf('"') + 1));
            string[] line = text.Substring(text.LastIndexOf('"') + 1).Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (line.Length != 3)
                throw new Exception("Неверное количество полей");
            return new MathematicsTask(name, line[0], parseDate(line[1]), parseMark(line[2]));
        }

        public static Tasks createPhysicsTask(string text)
        {
            if (!checkLine(text))
                throw new Exception("Неверный формат строки");
            string name = text.Substring(text.IndexOf('"') + 1, text.LastIndexOf('"') - (text.IndexOf('"') + 1));
            string[] line = text.Substring(text.LastIndexOf('"') + 1).Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (line.Length != 4)
                throw new Exception("Неверное количество полей");
            return new PhysicsTask(name, line[0], parseDate(line[1]), parseInt(line[2]), parseDate(line[3]));
        }

        public static bool checkType(string type)
        {
            if (type == "Задача" || type == "Математика" || type == "Физика")
                return true;
            return false;
        }

        public static DateTime parseDate(string date)
        {
            if (!DateTime.TryParse(date, out DateTime dt))
                throw new Exception("Дата имеет неверный формат");
            return DateTime.Parse(date);
        }

        public static int parseInt(string number)
        {
            if (!int.TryParse(number, out int nb))
                throw new Exception("Число имеет неверный формат");
            return Convert.ToInt16(number);
        }

        public static double parseMark(string mark)
        {
            if (double.TryParse(mark, out double d) && (d >= 0 && d <= 10))
                return Double.Parse(mark);
            throw new Exception("Оценка имеет неверный формат");
        }

        public static Tasks createObjects(string text)
        {
            if (!checkType(text.Split(' ')[0]))
                throw new Exception($"Неверный тип объекта");
            string type = text.Split(' ')[0];
            if (type == "Задача")
                return createTask(text);
            if (type == "Математика")
                return createMathematicsTask(text);
            if (type == "Физика")
                return createPhysicsTask(text);
            else
                throw new Exception("Не удалось создать объект");
        }
    }
}
