using CharacterNamespace;
using Enemys;
using Global;
using Utils;

namespace Player
{
    // Player class
    public class PlayerClass
    {
        public string? Name { get; protected set; }
        public Character character { get; protected set; }
        public int Points { get; protected set; }
        public int Health { get; set; }
        public Weapon Weapon { get; private set; }
        public int healthPotions { get; protected set; }


        public PlayerClass(string PlayerName, Weapon PlayerWeapon, Character charType)
        {
            Name = string.IsNullOrEmpty(PlayerName) ? $"Player{Globals.randomForPlayer.Next(1, 1000)}" : PlayerName;
            Weapon = PlayerWeapon;
            character = charType;
            Health = charType.Health;
            healthPotions = charType.HealthPotions;
        }

        public void AttackEnemy(Enemy enemy)
        {
            int damage = Util.RandomDamage(Globals.randomForPlayer, this, false);
            if (enemy.Health > 0)
            {
                if (damage == 0)
                {
                    Console.WriteLine($"{Name} missed their attack against the {enemy}!");
                }
                else
                {
                    Console.WriteLine($"{Name} attacks a {enemy} with {Weapon} dealing {damage} damage!");
                    enemy.TakeDamage(damage);
                }
                
            }
            // enemy is dead move on
        }
        public void Heal()
        {
            healthPotions--;
            Health += 30;
        }
        public void TakeDamage(int damage)
        {
            Health -= damage;
        }

        public void AddPoints(int points)
        {
            Points += points;
        }
        public void AttemptFlee(List<Enemy> EnemyList)
        {
            int randomInt = Globals.randomForPlayer.Next(1, 100);
            if (randomInt > 1 && randomInt < 30) {
                Console.WriteLine("You have fleed the enemy! Moving on.");
                Thread.Sleep(2000);
                EnemyList.RemoveAt(0);
            }
            Console.WriteLine("Flee attempt failed!");
        }

        public int GetHealth()
        {
            return Health;
        }

        public void PlayerInformation()
        {
            Console.WriteLine($"Name: {Name}, Health: {GetHealth()}, Weapon: {Weapon}, Points: {Points}, Character: {character}");
        }

        public static void PlayerRandSeed()
        {
            Console.WriteLine($"Seed for current session: {Globals.seed}");
        }

    }

}