using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    internal class Task_3
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите координаты ферзя x1y1 и координаты фигуры x2y2:");
            string input = Console.ReadLine();

            if (input.Length == 0)
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

            // Проверяем, бьет ли ферзь фигуру
            if (x1 == x2 || y1 == y2 || Math.Abs(x1 - x2) == Math.Abs(y1 - y2))
            {
                Console.WriteLine("Ферзь сможет побить фигуру");
            }
            else
            {
                Console.WriteLine("Ферзь не сможет побить фигуру");
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
