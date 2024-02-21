using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5
{
    internal class Task_5
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите координаты коня x1y1 и координаты фигуры x2y2:");
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

            // Проверяем, бьет ли конь фигуру
            if (IsKnightMove(x1, y1, x2, y2))
            {
                Console.WriteLine("Конь сможет побить фигуру");
            }
            else
            {
                Console.WriteLine("Конь не сможет побить фигуру");
            }
            ExitTheProgram();
        }
        static bool IsValidCoordinate(char x, char y)
        {
            return x >= 'a' && x <= 'h' && y >= '1' && y <= '8';
        }

        static bool IsKnightMove(char x1, char y1, char x2, char y2)
        {
            int dx = Math.Abs(x1 - x2);
            int dy = Math.Abs(y1 - y2);
            return (dx == 2 && dy == 1) || (dx == 1 && dy == 2);
        }

        static void ExitTheProgram()
        {
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
