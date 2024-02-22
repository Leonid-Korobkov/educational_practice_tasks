using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_9
{
    internal class Task_9
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Введите исходные данные (белая_фигура x1y1 черная_фигура x2y2 точка_x3y3):");
                string input = Console.ReadLine();

                if (input.Length == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Вы ввели некорректные данные");
                    continue;
                }

                string[] data = input.Trim().Split(' ');

                if (data.Length != 5)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Вы ввели некорректные данные");
                    continue;
                }

                string whitePiece = data[0];
                char x1 = data[1][0];
                char y1 = data[1][1];
                string blackPiece = data[2];
                char x2 = data[3][0];
                char y2 = data[3][1];
                char x3 = data[4][0];
                char y3 = data[4][1];

                // Проверяем корректность введенных координат
                if (!IsValidCoordinate(x1, y1) || !IsValidCoordinate(x2, y2) || !IsValidCoordinate(x3, y3))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Вы ввели некорректные координаты");
                    continue;
                }

                // Проверяем, может ли белая фигура дойти до указанной точки, не попав при этом под удар черной фигуры
                bool isWhitePieceCanReach = CanWhitePieceReachDestination(whitePiece, x1, y1, x3, y3);
                bool isBlackPieceCanBeatDot = CanDarkPieceBeatDestinationDot(blackPiece, x2, y2, x3, y3);


                if (isWhitePieceCanReach && !isBlackPieceCanBeatDot)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Белая фигура {whitePiece} сможет дойти до точки {x3}{y3}, не попав при этом под удар черной фигуры");
                }
                else if (isWhitePieceCanReach && isBlackPieceCanBeatDot)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Белая фигура {whitePiece} сможет дойти до точки {x3}{y3}, но будет побита черной фигурой");
                }
                else if (!isWhitePieceCanReach && isBlackPieceCanBeatDot)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Белая фигура {whitePiece} не сможет дойти до точки {x3}{y3}, но может быть побита черной фигурой");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Белая фигура {whitePiece} не сможет дойти до точки {x3}{y3}, и не будет побита черной фигурой");
                }

                DrawChessboardWithPoint(x1, y1, x2, y2, x3, y3);
            }
        }

        // Метод для проверки корректности координат
        static bool IsValidCoordinate(char x, char y)
        {
            return x >= 'a' && x <= 'h' && y >= '1' && y <= '8';
        }

        // Метод для проверки, может ли черная фигура побить белую фигуру на конечной точке
        static bool CanDarkPieceBeatDestinationDot(string blackPiece, char x2, char y2, char x3, char y3)
        {
            bool isBlackPieceCanBeatToDestination;
            int deltaBlackX = Math.Abs(x3 - x2);
            int deltaBlackY = Math.Abs(y3 - y2);
            // Проверяем, что черная фигура может побить белую фигуры на позиции точки
            switch (blackPiece.Trim().ToLower())
            {
                case "ладья":
                    // Ладья может ходить по горизонтали и вертикали
                    isBlackPieceCanBeatToDestination = x2 == x3 || y2 == y3;
                    break;
                case "конь":
                    // Конь ходит буквой "Г"
                    isBlackPieceCanBeatToDestination = (deltaBlackX == 1 && deltaBlackY == 2) || (deltaBlackX == 2 && deltaBlackY == 1);
                    break;
                case "слон":
                    // Слон ходит по диагонали
                    isBlackPieceCanBeatToDestination = deltaBlackX == deltaBlackY;
                    break;
                case "ферзь":
                    // Ферзь может ходить по диагоналям и по прямым линиям
                    isBlackPieceCanBeatToDestination = x2 == x3 || y2 == y3 || deltaBlackX == deltaBlackY;
                    break;
                case "король":
                    // Король ходит на одну клетку в любом направлении
                    isBlackPieceCanBeatToDestination = deltaBlackX <= 1 && deltaBlackY <= 1;
                    break;
                default:
                    // Если введена недопустимая фигура, считаем, что она не может дойти до указанной точки
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Введена недопустимая черная фигура");
                    isBlackPieceCanBeatToDestination = false;
                    break;
            }

            return isBlackPieceCanBeatToDestination;
        }

        // Метод для проверки, может ли белая фигура дойти до указанной точки
        static bool CanWhitePieceReachDestination(string whitePiece, char x1, char y1, char x3, char y3)
        {
            bool isWhitePieceCanGoToDestination;
            int deltaX = Math.Abs(x3 - x1);
            int deltaY = Math.Abs(y3 - y1);
            // Проверяем, что белая фигура в списке допустимых фигур, а также она может ходить до точки
            switch (whitePiece.Trim().ToLower())
            {
                case "ладья":
                    // Ладья может ходить по горизонтали и вертикали
                    isWhitePieceCanGoToDestination = x1 == x3 || y1 == y3;
                    break;
                case "конь":
                    // Конь ходит буквой "Г"
                    isWhitePieceCanGoToDestination = (deltaX == 1 && deltaY == 2) || (deltaX == 2 && deltaY == 1);
                    break;
                case "слон":
                    // Слон ходит по диагонали
                    isWhitePieceCanGoToDestination = deltaX == deltaY;
                    break;
                case "ферзь":
                    // Ферзь может ходить по диагоналям и по прямым линиям
                    isWhitePieceCanGoToDestination = x1 == x3 || y1 == y3 || deltaX == deltaY;
                    break;
                case "король":
                    // Король ходит на одну клетку в любом направлении
                    isWhitePieceCanGoToDestination = deltaX <= 1 && deltaY <= 1;
                    break;
                default:
                    // Если введена недопустимая фигура, считаем, что она не может дойти до указанной точки
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Введена недопустимая белая фигура");
                    isWhitePieceCanGoToDestination = false;
                    break;
            }

            return isWhitePieceCanGoToDestination;
        }

        // Метод для отрисовки шахматной доски с указанием точки
        static void DrawChessboardWithPoint(char x1, char y1, char x2, char y2, char x3, char y3)
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
                    else if ((char)(j + 96) == x3 && i == (int)Char.GetNumericValue(y3))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow; // Цвет точки
                        Console.Write("* ");
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
