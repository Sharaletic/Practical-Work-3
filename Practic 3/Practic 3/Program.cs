using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace Practic_3
{
    public class Program
    {
        static void Main(string[] args)
        {
            string text = "Задача \"Алексей Иванов\"     Контрольная     16.09.2024\n" +
            "Задача \"Алексей Иванов\"    Контрольная     16.09.2024\n" +
            "Математика \"Александр Борисов\"       Практическая     10.15.2024     4,7\n" +
            "Математика \"Ирина Николаевна\"     Лабораторная    07.09.2024        5,5\n" +
            "Физика \"Дмитрий Иванов\"       Курсовая   04.09.2024    5       25.09.2024\n" +
            "Физика \"Петр Петров\"    Итоговая    14.09.2024     5     25.09.2024";

            while (true)
            {
                Console.WriteLine("Нужно ли считать с текстового файла\n1 - да\n2 - нет");
                int.TryParse(Console.ReadLine(), out int selectedNumber);
                if (selectedNumber == 1)
                {
                    createObjectForTextFromFile();
                }
                if (selectedNumber == 2)
                {
                    cresteObjectForTextFromString(text);
                }
                Console.WriteLine();
            }
        }

        private static void cresteObjectForTextFromString(string text)
        {
            foreach (var item in Factory.getLines(text))
            {
                try
                {
                    Factory.createObjects(item).print();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void createObjectForTextFromFile()
        {
            string path = "text.txt";
            if (File.Exists(path))
            {
                foreach (var item in Factory.readFile(path))
                {
                    try
                    {
                        Factory.createObjects(item).print();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            else
                Console.WriteLine("Не найден файл");
        }
    }
}
