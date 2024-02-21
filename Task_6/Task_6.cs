using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_6
{
    internal class Task_6
    {

        static void Main(string[] args)
        {
            Random random = new Random();
            int bossHealth = random.Next(350, 500);
            int maxBossHealth = random.Next(500, 1000);

            int playerHealth = random.Next(350, 500);
            int maxPlayerHealth = random.Next(500, 1000);

            Player player = new Player(maxPlayerHealth, playerHealth);
            Boss boss = new Boss(maxBossHealth, bossHealth);

            // Вывод информации об игре
            Console.WriteLine("Игра - Победи БОССА\n\nУсловия:");
            Console.WriteLine("Максимальный уровень жизни у БОССА: " + maxBossHealth);
            Console.WriteLine("Максимальный уровень жизни у игрока: " + maxPlayerHealth + "\n");
            Console.WriteLine("Случайным образом выбирается игрок, делающий первый ход\n" +
                "Величина урона, наносимого БОССОМ, для каждого хода случайна\n");

            // Вывод списка заклинаний
            Console.WriteLine("1. конгён - атака, может наноситься урон от 60 единиц. Сила атаки в дальнейшем может увеличиваться." + Environment.NewLine);

            Console.WriteLine("2. поиджи анын сарам - призыв духа Невидимости. Тратится 126 единиц здоровья. Невидимость держится 5 игровых тактов" + Environment.NewLine);

            Console.WriteLine("3. хёнгванэ кассо - переход в портал. Тратится 20 единиц здоровья" +
                "\r\n\t БОСС не может наносить удары по игроку, который спрятался в портале" +
                "\r\n\t В портал нельзя уйти невидимым" +
                "\r\n\t В портале нельзя стать невидимым" +
                "\r\n\t Из портала нельзя атаковать БОССА" +
                "\r\n\t Каждый игровой такт увеличивает здоровье на 40 единиц" +
                "\r\n\t Каждый игровой такт усиливает силу атаки на 20 единиц" + Environment.NewLine);

            Console.WriteLine("4. хёнгванэсо торавассо - возвращение из портала" + Environment.NewLine);

            Console.WriteLine("5. орэ ккынын хвэбок - длительное восстановление. Тратится 56 единиц здоровья, но следующие 12 игровых тактов восстанавливается по 40 единиц здоровья за такт" + Environment.NewLine);

            int countGameTact = 1;
            bool isPlayerMove = random.Next(2) == 1;

            Console.WriteLine($"Начальное значение здоровья у игрока: {player.health} единиц");
            Console.WriteLine($"Начальное значение здоровья у босса: {boss.health} единиц\n");

            while (player.health > 0 && boss.health > 0)
            {
                Console.WriteLine($"Игровой такт № - {countGameTact}");
                player.PerformPortalEffects(); // Применяем эффекты портала
                player.PerformRecovery(); // Выполняем восстановление здоровья

                if (player.invisibleTurnsLeft > 0)
                {
                    Console.WriteLine("Игрок невидим.");
                    player.DecreaseInvisibleTurns();
                    Console.WriteLine($"Осталось невидимых тактов: {player.invisibleTurnsLeft}");
                }

                if (isPlayerMove) // Ход игрока
                {
                    Console.WriteLine("Атакует игрок");
                    // Проверяем, находится ли игрок в портале
                    if (player.isInPortal)
                    {
                        Console.WriteLine("Игрок находится в портале");
                        Console.WriteLine($"Увеличение здоровья игрока на {40} и силы атаки на {20}");
                    }
                    ShowAvailableSpells(); // Показываем список доступных заклинаний

                    Spell spell = player.ChooseSpell();
                    if (spell != null)
                    {
                        player.Attack(boss, spell);
                    }

                    if (boss.health <= 0)
                    {
                        Console.WriteLine("Босс повержен! Победа игрока!");
                        break;
                    }
                    //}
                    //else
                    //{
                    //    Console.WriteLine("Игрок находится в портале и не может атаковать БОССА.");
                    //}
                }
                else // Ход БОССА
                {
                    // Проверяем, находится ли игрок в портале
                    if (!player.isInPortal)
                    {
                        Console.WriteLine("Атакует БОСС");
                        boss.Attack(player);

                        if (player.health <= 0)
                        {
                            Console.WriteLine("Игрок повержен! Победа босса!");
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Игрок находится в портале и БОСС не может его атаковать.");
                        Console.WriteLine($"Увеличение здоровья игрока на {40} и силы атаки на {20}");
                    }
                }

                Console.WriteLine($"Осталось здоровья у игрока: {player.health} единиц");
                Console.WriteLine($"Осталось здоровья у босса: {boss.health} единиц");

                countGameTact++;
                isPlayerMove = !isPlayerMove;
                Console.WriteLine();
            }

            Console.WriteLine("Игра окончена.");
        }

        public static void ShowAvailableSpells()
        {
            Console.WriteLine("Доступные заклинания:");
            Console.WriteLine("1. Конгён");
            Console.WriteLine("2. Поиджи анын сарам");
            Console.WriteLine("3. Хёнгванэ кассо");
            Console.WriteLine("4. Хёнгванэсо торавассо");
            Console.WriteLine("5. Орэ ккынын хвэбок");
            Console.WriteLine();
        }
    }
}
