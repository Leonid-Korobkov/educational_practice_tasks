using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_6
{
    public class Spell
    {
        // Свойства
        public string name;
        public int damageToBoss;

        // Конструктор
        public Spell(string name, int damageToBoss)
        {
            this.name = name;
            this.damageToBoss = damageToBoss;
        }

        // Метод для вывода урона
        public virtual void printInfoSpell(Player player)
        {
            Console.WriteLine($"Сила удара - {this.damageToBoss} единиц");
        }
    }
}
