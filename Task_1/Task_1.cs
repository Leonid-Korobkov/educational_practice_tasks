using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Task_1
{
    internal class Task_1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите координаты ладьи x1y1 и координаты фигуры x2y2:");
            string input = Console.ReadLine();

            if  (input.Length == 0 )
            {
                Console.WriteLine("Вы ввели некорректные координаты");
                ExitTheProgram();
                return;
            }

            string[] coordinates = input.Split(' ');

            if (coordinates.Length != 2)
            {
                Console.WriteLine("Вы ввели некорректные координаты");
                ExitTheProgram();
                return;
            }

            char x1 = coordinates[0][0];
            char y1 = coordinates[0][1];
            char x2 = coordinates[1][0];
            char y2 = coordinates[1][1];

            // Проверяем корректность введенных координат
            if (!IsValidCoordinate(x1, y1) || !IsValidCoordinate(x2, y2))
            {
                Console.WriteLine("Вы ввели некорректные координаты");
                ExitTheProgram();
                return;
            }

            // Проверяем, бьет ли ладья фигуру
            if (x1 == x2 || y1 == y2)
            {
                Console.WriteLine("Ладья сможет побить фигуру");
            }
            else
            {
                Console.WriteLine("Ладья не сможет побить фигуру");
            }

            ExitTheProgram();
        }

        static bool IsValidCoordinate(char x, char y)
        {
            return x >= 'a' && x <= 'h' && y >= '1' && y <= '8';
        }

        static void ExitTheProgram()
        {
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
