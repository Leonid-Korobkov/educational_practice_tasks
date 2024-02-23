using System;
using System.Linq;

namespace Task_10
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] figures = { "ладья", "слон", "король", "ферзь" };
            while (true)
            {
                // Генерация случайных координат для первого поля
                Random rnd = new Random();
                char x1 = (char)('a' + rnd.Next(8));
                char y1 = (char)('1' + rnd.Next(8));
                char x2;
                char y2;

                // Определение фигуры на первом поле (x1y1)
                Console.Write("Введите фигуру, расположенную на поле " + x1 + y1 + ":");
                string figure = Console.ReadLine().Trim().ToLower();

                if (figure == "")
                {
                    Console.WriteLine("Вы ввели пустую строку!");
                    continue;
                } else if (!figures.Contains(figure))
                {
                    Console.WriteLine("Такой фигуры не существуют");
                    Console.Write("Вот список существующих фигур: ");
                    for (int i = 0; i <= figures.Length - 1; i++)
                    {
                        Console.Write(figures[i] + ", ");
                    }
                    Console.WriteLine();
                    continue;
                }

                bool isValidPosition;
                // Генерация случайных координат для второго поля, удовлетворяющих условиям
                while (true)
                {
                    x2 = (char)('a' + rnd.Next(8));
                    y2 = (char)('1' + rnd.Next(8));
                    isValidPosition = CheckSafety(figure, x1, y1, x2, y2);
                    if (isValidPosition)
                        break;
                }

                // Определение случайного типа фигуры для второго поля
                string randomFigure = GetRandomFigure(figures);

                // Отрисовка шахматной доски с указанием фигур на полях
                DrawChessboard(x1, y1, x2, y2, figure, randomFigure, isValidPosition);
            }
        }

        // Метод для определения случайной фигуры на втором поле
        static string GetRandomFigure(string[] figures)
        {
            Random rnd = new Random();
            string randomFigure = figures[rnd.Next(figures.Length)];
            return randomFigure;
        }

        // Метод для проверки условий, соответствующих типу фигуры на первом поле
        static bool CheckSafety(string figure, char x1, char y1, char x2, char y2)
        {
            switch (figure)
            {
                case "ладья":
                    return x1 != x2 && y1 != y2;
                case "слон":
                    return Math.Abs(x1 - x2) != Math.Abs(y1 - y2);
                case "король":
                    return Math.Abs(x1 - x2) <= 1 && Math.Abs(y1 - y2) <= 1; // Король может ходить на соседние клетки
                case "ферзь":
                    return x1 != x2 && y1 != y2 && Math.Abs(x1 - x2) != Math.Abs(y1 - y2);
                default:
                    return true;
            }
        }

        // Метод для отрисовки шахматной доски с указанием фигур на полях
        static void DrawChessboard(char x1, char y1, char x2, char y2, string figure1, string figure2, bool isValidPosition)
        {
            Console.WriteLine("Первая фигура: " + figure1 + ", Вторая фигура: " + figure2);
            Console.WriteLine("   a b c d e f g h");
            for (int i = 8; i >= 1; i--)
            {
                Console.Write($" {i} ");
                for (int j = 1; j <= 8; j++)
                {
                    if ((i + j) % 2 == 0)
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    else
                        Console.ResetColor();

                    if (i == y1 - '0' && j == x1 - 'a' + 1)
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    else if (i == y2 - '0' && j == x2 - 'a' + 1)
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    else
                        Console.ForegroundColor = ConsoleColor.White;

                    if ((i == y1 - '0' && j == x1 - 'a' + 1))
                        Console.Write("1" + figure1.Substring(0, 1).ToUpper());
                    else if ((i == y2 - '0' && j == x2 - 'a' + 1))
                        Console.Write("2" + figure2.Substring(0, 1).ToUpper());
                    else
                        Console.Write("  ");
                }
                Console.WriteLine();
                Console.ResetColor();
            }

            if (isValidPosition)
            {
                if (figure1 == "король")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Фигура {figure1} на поле {x2}{y2} угрожает фигуре {figure2}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Фигура {figure1} на поле {x2}{y2} не угрожает фигуре {figure2}");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Фигура {figure1} на поле {x2}{y2} угрожает фигуре {figure2}");
            }
            Console.ResetColor();
        }
    }
}
