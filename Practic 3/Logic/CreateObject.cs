// This is a personal academic project. Dear PVS-Studio, please check it.// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.IO;

namespace Logic
{
    public class CreateObject
    {
        public static void cresteObjectForTextFromString(string text)
        {
            foreach (var item in Factory.getLines(text))
            {
                try
                {
                    Console.WriteLine(Factory.createObjects(item).ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void createObjectForTextFromFile()
        {
            string path = "text.txt";
            if (File.Exists(path))
            {
                foreach (var item in Factory.readFile(path))
                {
                    try
                    {
                        Console.WriteLine(Factory.createObjects(item).ToString());
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
