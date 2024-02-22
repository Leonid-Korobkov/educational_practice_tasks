using System;
using System.IO;

namespace Task_7
{
    class Program
    {
        const int columnRightPosition = 35;
        static void Main(string[] args)
        {
            bool isPlaying = true; // Флаг продолжения игры
            bool repeatedVisit = false; // Флаг повторного посещения комнаты
            int pacmanX, pacmanY; // Позиция посетителя
            int pacmanDX = 0, pacmanDY = 0; // Направление движения посетителя
            int totalMoves = 0; // Общее количество ходов
            string correctPath = ""; // Правильный маршрут для посещения комнат

            // Устанавливаем видимость курсора в false
            Console.CursorVisible = false;
            // Загружаем карту из файла
            char[,] map = LoadMap("level01", out pacmanX, out pacmanY);

            // Устанавливаем размер окна консоли и выводим инструкции
            SetConsole(100, 40); // Ширина 100 символов и высота 40 строк
            DrawMap(map);

            while (isPlaying)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Escape)
                {
                    // Если нажата клавиша Escape, завершаем игру
                    Console.SetCursorPosition(columnRightPosition, 17);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Игра завершена");
                    isPlaying = false;
                }
                else if (key.Key == ConsoleKey.F1)
                {
                    // Если нажата клавиша F1, пройти по правильному маршруту
                    correctPath = "AAASSSSSSSSSSSSSDWWWWWWWWWWWWWD" +
                        "SSSSSSSSSSSSSDWWWWWWWWWWWWWD" +
                        "SSSSSSSSSSSSSDWWWWWWWWWWWWWD" +
                        "SSSSSSSSSSSSSDWWWWWWWWWWWWWD" +
                        "SSSSSSSSSSSSSDWWWWWWWWWWWWWD" +
                        "SSSSSSSSSSSSSDWWWWWWWWWWWWWD" +
                        "SSSSSSSSSSSSSDWWWWWWWWWWWWWD" +
                        "SSSSSSSSSSSSSAAA";
                    FollowPath(map, correctPath, ref pacmanX, ref pacmanY, ref pacmanDX,
                                ref pacmanDY, ref totalMoves);
                    isPlaying = false;
                }
                else
                {
                    // Изменяем направление движения посетителя в соответствии с нажатой клавишей
                    ChangeDirection(key, ref pacmanDX, ref pacmanDY);

                    // Перемещаем посетителя и проверяем на повторное посещение комнаты
                    repeatedVisit = MovePacman(map, ref pacmanX, ref pacmanY, pacmanDX,
                                                pacmanDY, ref totalMoves);
                    if (repeatedVisit)
                    {
                        break;
                    }
                }
            }
            Console.SetCursorPosition(columnRightPosition, 17);
            Console.WriteLine();
            Console.SetCursorPosition(columnRightPosition, 19);
        }

        /// <summary>
        /// Проход по правильному маршруту.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="correctPath"></param>
        /// <param name="pacmanX"></param>
        /// <param name="pacmanY"></param>
        /// <param name="DX"></param>
        /// <param name="DY"></param>
        /// <param name="totalMoves"></param>
        static void FollowPath(char[,] map, string correctPath, ref int pacmanX,
                               ref int pacmanY, ref int DX, ref int DY,
                               ref int totalMoves)
        {
            for (int i = 0; i < correctPath.Length; i++)
            {
                switch (correctPath[i])
                {
                    case 'A':
                        DX = 0;
                        DY = -2;
                        break;
                    case 'S':
                        DX = 2;
                        DY = 0;
                        break;
                    case 'D':
                        DX = 0;
                        DY = 2;
                        break;
                    case 'W':
                        DX = -2;
                        DY = 0;
                        break;
                }
                MovePacman(map, ref pacmanX, ref pacmanY, DX, DY, ref totalMoves);
                System.Threading.Thread.Sleep(20);
            }
        }

        /// <summary>
        /// Изменение направления движения посетителя.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="DX"></param>
        /// <param name="DY"></param>
        static void ChangeDirection(ConsoleKeyInfo key, ref int DX, ref int DY)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    DX = -2;
                    DY = 0;
                    break;
                case ConsoleKey.DownArrow:
                    DX = 2;
                    DY = 0;
                    break;
                case ConsoleKey.LeftArrow:
                    DX = 0;
                    DY = -2;
                    break;
                case ConsoleKey.RightArrow:
                    DX = 0;
                    DY = 2;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Перемещение посетителя на новую позицию с учетом проверки на наличие препятствий и повторных посещений комнат.
        /// </summary>
        /// <param name="map">Карта музея</param>
        /// <param name="X">Текущая позиция посетителя по оси X</param>
        /// <param name="Y">Текущая позиция посетителя по оси Y</param>
        /// <param name="DX">Изменение координаты по оси X</param>
        /// <param name="DY">Изменение координаты по оси Y</param>
        /// <param name="totalMoves">Общее количество сделанных ходов</param>
        /// <returns>Возвращает true, если посетитель повторно посетил комнату, иначе false</returns>
        static bool MovePacman(char[,] map, ref int X, ref int Y, int DX, int DY, ref int totalMoves)
        {
            bool trafficPermit = false; // Флаг разрешения на перемещение

            // Проверка на наличие препятствий и выход за границы карты
            trafficPermit = map[X + DX / 2, Y + DY / 2] != '║' &&
                            map[X + DX / 2, Y + DY / 2] != '═' &&
                            map[X + DX / 2, Y + DY / 2] != '╠' &&
                            map[X + DX / 2, Y + DY / 2] != '╣' &&
                            map[X + DX / 2, Y + DY / 2] != '╦' &&
                            map[X + DX / 2, Y + DY / 2] != '╩' &&
                            map[X + DX / 2, Y + DY / 2] != '╬' &&
                            (X + DX / 2) < map.GetLength(0) - 1 && (X + DX / 2) > 0 &&
                            (Y + DY / 2) < map.GetLength(1) - 1 && (Y + DY / 2) > 0;

            if (trafficPermit)
            {
                // Проверка на повторное посещение комнаты
                if (map[X + DX, Y + DY] != '¤')
                {
                    // Если комната еще не посещена, перемещаем посетителя на новую позицию
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(Y, X);
                    Console.Write('¤');
                    map[X, Y] = '¤';
                    X += DX;
                    Y += DY;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.SetCursorPosition(Y, X);
                    Console.Write('■');

                    // Увеличиваем счетчик сделанных ходов
                    totalMoves++;
                    Console.SetCursorPosition(columnRightPosition, 30);
                    Console.WriteLine($"Осталось ходов - {Convert.ToString(202 - totalMoves),3:N0} из 202");
                    return false; // Посетитель продолжает движение
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    // Если комната уже посещена, выводим сообщение об этом
                    Console.SetCursorPosition(columnRightPosition, 15);
                    Console.Write("Вы уже проходили в данном месте");
                    Console.SetCursorPosition(columnRightPosition, 16);
                    Console.Write("Увы, вы проиграли и игра закончена");
                    return true; // Посетитель повторно посетил комнату, игра завершается
                }
            }
            return false; // Посетитель не может двигаться из-за препятствия или выхода за границы карты
        }


        /// <summary>
        /// Установка параметров консоли и вывод инструкций.
        /// </summary>
        /// <param name="length"></param>
        /// <param name="height"></param>
        static void SetConsole(int length, int height)
        {
            Console.SetWindowSize(length, height);
            Console.SetCursorPosition(columnRightPosition, 0);
            Console.WriteLine("ПРОГУЛКА ПО МУЗЕЮ");
            Console.SetCursorPosition(columnRightPosition, 1);
            Console.WriteLine();
            Console.SetCursorPosition(columnRightPosition, 2);
            Console.WriteLine("В музее 195 комнат. Составьте маршрут для посетителей:");
            Console.SetCursorPosition(columnRightPosition, 3);
            Console.WriteLine("надо побывать в каждой комнате, но так, чтобы не заходить");
            Console.SetCursorPosition(columnRightPosition, 4);
            Console.WriteLine("дважды ни в одну из них. И еще одно условие: в маршрут");
            Console.SetCursorPosition(columnRightPosition, 5);
            Console.WriteLine("надо включить ту часть его, которая нанесена пунктиром.");
            Console.SetCursorPosition(columnRightPosition , 6);
            Console.WriteLine("Пройденный участок отмечается символом ¤");
            Console.SetCursorPosition(columnRightPosition, 7);
            Console.WriteLine();
            Console.SetCursorPosition(columnRightPosition, 8);
            Console.WriteLine("Маршрут можно пройти за 202 шага");
            Console.SetCursorPosition(columnRightPosition, 9);
            Console.WriteLine();
            Console.SetCursorPosition(columnRightPosition, 10);
            Console.WriteLine("Стрелки - сделать шаг в указанном стрелкой направлении");
            Console.SetCursorPosition(columnRightPosition, 11);
            Console.WriteLine("F1 - подсказка по прохождению");
            Console.SetCursorPosition(columnRightPosition, 12);
            Console.WriteLine("ESC - выход из игры");
            Console.SetCursorPosition(0, 0);
        }

        /// <summary>
        /// Вывод карты на консоль.
        /// </summary>
        /// <param name="map"></param>
        static void DrawMap(char[,] map)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Загрузка карты из файла.
        /// </summary>
        /// <param name="mapName"></param>
        /// <param name="pacmanX"></param>
        /// <param name="pacmanY"></param>
        /// <returns></returns>
        static char[,] LoadMap(string mapName, out int pacmanX, out int pacmanY)
        {
            pacmanX = 0;
            pacmanY = 0;

            string[] mapData = File.ReadAllLines($"maps/{mapName}.txt");
            char[,] map = new char[mapData.Length, mapData[0].Length];

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = mapData[i][j];

                    if (map[i, j] == '■')
                    {

                        pacmanX = i;
                        pacmanY = j;
                    }
                }
            }
            return map;
        }
    }
}