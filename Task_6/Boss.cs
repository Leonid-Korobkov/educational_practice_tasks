using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_6
{
    public class Boss
    {
        public int health;
        public int maxBossHealth;
        Random random = new Random();

        public Boss(int maxBossHealth, int health = 400)
        {
            this.maxBossHealth = maxBossHealth;
            this.health = health;
        }

        public void Attack(Player player)
        {
            if (!(player.invisibleTurnsLeft > 0))
            {
                int damageToPlayer = random.Next(50, 150);
                player.health -= damageToPlayer;
                Console.WriteLine($"Сила удара - {damageToPlayer} единиц");
            }
            else
            {
                Console.WriteLine("Игрок в невидимости. Босс не может атаковать его.");
            }
        }
        public void TakeDamage(int damage)
        {
            health -= damage;
        }
    }
}
