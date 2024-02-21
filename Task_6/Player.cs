using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_6
{
    public class Player
    {
        public int health;
        public int invisibleTurnsLeft; // Количество оставшихся тактов невидимости
        public bool isInPortal; // Флаг нахождения игрока в портале
        public int attackPower = 60; // Сила атаки игрока
        public int recoveryTurnsLeft; // Количество оставшихся тактов восстановления здоровья
        public int maxPlayerHealth;

        public Player(int maxPlayerHealth, int health = 400)
        {
            this.maxPlayerHealth = maxPlayerHealth;
            this.health = health;
        }

        public void Attack(Boss boss, Spell spell)
        {
            if (spell is PoidjiAnynSaram saram) // Если выбрано заклинание "Поиджи анын сарам"
            {
                if (!isInPortal)
                {
                    health -= saram.costAttackForPlayer; // Тратится 126 единиц здоровья
                    invisibleTurnsLeft = 5 + 1; // Невидимость длится 5 тактов
                } else
                {
                    Console.WriteLine("Нельзя стать невидимым в портале. Вы пропустили ход!");
                }
            }
            else if (spell is Hyongvanekasso hyongvanekasso) // Если выбрано заклинание "Хёнгванэ кассо"
            {
                if (!(invisibleTurnsLeft > 0))
                {
                    health -= hyongvanekasso.costAttackForPlayer; // Тратится 20 единиц здоровья
                    isInPortal = true;
                } else
                {
                    Console.WriteLine("Нельзя ввойти в портал невидимым. Вы пропустили ход!");
                }
            }
            else if (spell is HyongvanesoToravasso) // Если выбрано заклинание "Хёнгванэсо торавассо"
            {
                isInPortal = false; // Игрок покидает портал
            }
            else if (spell is OreKkynynHvebok oreKkynynHvebok) // Если выбрано заклинание "Орэ ккынын хвэбок"
            {
                health -= oreKkynynHvebok.costAttackForPlayer; // Тратится 56 единиц здоровья
                recoveryTurnsLeft = 12; // Запускается процесс восстановления здоровья
            }
            else // Если выбрано заклинание для атаки
            {
                if (!isInPortal)
                {
                    boss.TakeDamage(spell.damageToBoss);
                }
                else
                {
                    Console.WriteLine("Нельзя атаковать в портале. Вы пропустили ход!");
                }

            }
            spell.printInfoSpell(this);
        }

        public void Heal(int amount)
        {
            health += amount;
            if (health > maxPlayerHealth)
            {
                health = maxPlayerHealth;
            }
        }

        public Spell ChooseSpell()
        {
            Console.Write("Введите название заклинания: ");
            string spellName = Console.ReadLine().Trim().ToLower();

            switch (spellName)
            {
                case "конгён":
                    return new Kongyon("Конгён", attackPower);
                case "поиджи анын сарам":
                    return new PoidjiAnynSaram();
                case "хёнгванэ кассо":
                    return new Hyongvanekasso();
                case "хёнгванэсо торавассо":
                    return new HyongvanesoToravasso();
                case "орэ ккынын хвэбок":
                    return new OreKkynynHvebok();
                default:
                    Console.WriteLine("Такое заклинание не существует.");
                    return null;
            }
        }

        public void DecreaseInvisibleTurns()
        {
            if (invisibleTurnsLeft > 0)
                invisibleTurnsLeft--;
        }

        public void PerformPortalEffects()
        {
            if (isInPortal)
            {
                this.Heal(40); // Каждый такт увеличивает здоровье на 40 единиц
                attackPower += 20; // Каждый такт увеличивает силу атаки на 20 единиц
            }
        }
        public void PerformRecovery()
        {
            if (recoveryTurnsLeft > 0)
            {
                this.Heal(40);  // Восстанавливается 40 единиц здоровья
                recoveryTurnsLeft--; // Уменьшается количество оставшихся тактов восстановления
            }
        }
    }
}
