// This is a personal academic project. Dear PVS-Studio, please check it.// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using Logic;

namespace Practic_3
{
    public class Program
    {
        static void Main(string[] args)
        {
            string text = "Программирование \"Алексей Иванов\"     Контрольная     16.09.2024\n" +
            "Программирование \"Юлия Николаевна\"    Контрольная     16.09.2024\n" +
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
                    CreateObject.createObjectForTextFromFile();
                }
                if (selectedNumber == 2)
                {
                    CreateObject.cresteObjectForTextFromString(text);
                }
                Console.WriteLine();
            }
        }
    }
}
