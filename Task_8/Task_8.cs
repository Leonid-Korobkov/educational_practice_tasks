using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_8
{
    internal class Task_8
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Введите координаты двух фигур (x1y1 x2y2):");
                string input = Console.ReadLine();

                if (input.Length == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Вы ввели некорректные координаты");
                    continue;
                }

                string[] coordinates = input.Split(' ');

                if (coordinates.Length != 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Вы ввели некорректные координаты");
                    continue;
                }

                char x1 = coordinates[0][0];
                char y1 = coordinates[0][1];
                char x2 = coordinates[1][0];
                char y2 = coordinates[1][1];

                // Проверяем корректность введенных координат
                if (!IsValidCoordinate(x1, y1) || !IsValidCoordinate(x2, y2))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Вы ввели некорректные координаты");
                    continue;
                }

                // Проверяем, являются ли поля одного цвета
                bool sameColor = CheckSameColor(x1, y1, x2, y2);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Поля {x1}{y1} и {x2}{y2} являются полями {(sameColor ? "одного" : "разного")} цвета.");

                // Рисуем шахматную доску
                DrawChessboard(x1, y1, x2, y2);
            }
        }

        // Метод для проверки корректности координат
        static bool IsValidCoordinate(char x, char y)
        {
            return x >= 'a' && x <= 'h' && y >= '1' && y <= '8';
        }

        // Метод для проверки, являются ли поля одного цвета
        static bool CheckSameColor(char x1, char y1, char x2, char y2)
        {
            // Получаем числовые координаты полей
            int x1Num = GetNumberFromLetter(x1);
            int y1Num = int.Parse(y1.ToString());
            int x2Num = GetNumberFromLetter(x2);
            int y2Num = int.Parse(y2.ToString());

            // Вычисляем сумму числовых координат
            int sum1 = x1Num + y1Num;
            int sum2 = x2Num + y2Num;

            // Поля одного цвета, если сумма числовых координат одинакова для обоих полей
            return sum1 % 2 == sum2 % 2;
        }

        // Метод для преобразования буквенной координаты в числовую
        static int GetNumberFromLetter(char letter)
        {
            return letter - 'a' + 1;
        }

        // Метод для отрисовки шахматной доски
        static void DrawChessboard(char x1, char y1, char x2, char y2)
        {
            Console.ResetColor();
            Console.WriteLine("   a b c d e f g h");
            for (int i = 8; i >= 1; i--)
            {
                Console.Write($" {i} ");
                for (int j = 1; j <= 8; j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }
                    else
                    {
                        Console.ResetColor();
                    }
                    if ((char)(j + 96) == x1 && i == (int)Char.GetNumericValue(y1))
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta; // Цвет первой фигуры
                        Console.Write("1 ");
                    }
                    else if ((char)(j + 96) == x2 && i == (int)Char.GetNumericValue(y2))
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta; // Цвет второй фигуры
                        Console.Write("2 ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }
                Console.WriteLine();
                Console.ResetColor();
            }
        }
    
    }
}
