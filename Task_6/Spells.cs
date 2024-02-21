using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_6
{

    // Класс для заклинания "Конгён"
    public class Kongyon : Spell
    {
        // Конструктор
        public Kongyon(string name, int damageToBoss) : base(name, damageToBoss)
        {
        }
    }

    // Класс для заклинания "Поиджи анын сарам"
    public class PoidjiAnynSaram : Spell
    {
        public int costAttackForPlayer = 126;

        // Конструктор
        public PoidjiAnynSaram() : base("Поиджи анын сарам", 0)
        {
        }

        // Переопределение метода PrintDamage
        public override void printInfoSpell(Player player)
        {
            Console.WriteLine($"Переход в невидимость - потрачено {costAttackForPlayer} единиц");
        }
    }

    // Класс для заклинания "Хёнгванэ кассо"
    public class Hyongvanekasso : Spell
    {
        public int costAttackForPlayer = 20;
        // Конструктор
        public Hyongvanekasso() : base("Хёнгванэ кассо", 0)
        {
        }

        // Переопределение метода PrintDamage
        public override void printInfoSpell(Player player)
        {
            if (player.invisibleTurnsLeft > 0)
            {
                Console.WriteLine("Нельзя ввойти в портал невидимым. Вы пропустили ход!");
            }
            else
            {
                Console.WriteLine($"Переход в портал - потрачено {costAttackForPlayer} единиц");
            }
        }
    }

    // Класс для заклинания "Хёнгванэсо торавассо"
    public class HyongvanesoToravasso : Spell
    {
        // Конструктор
        public HyongvanesoToravasso() : base("Хёнгванэсо торавассо", 0)
        {
        }
        // Переопределение метода PrintDamage
        public override void printInfoSpell(Player player)
        {
            Console.WriteLine($"Выход из портала");
        }
    }

    // Класс для заклинания "Орэ ккынын хвэбок"
    public class OreKkynynHvebok : Spell
    {
        public int costAttackForPlayer = 56;
        // Конструктор
        public OreKkynynHvebok() : base("Орэ ккынын хвэбок", 50)
        {
        }

        // Переопределение метода PrintDamage
        public override void printInfoSpell(Player player)
        {
            Console.WriteLine($"Переход в длительное восстановление - потрачено {costAttackForPlayer} единиц");
        }
    }
}
