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


        public PlayerClass(string PlayerName, Weapon PlayerWeapon, Character charType)
        {
            Name = string.IsNullOrEmpty(PlayerName) ? $"Player{Globals.random.Next(1, 1000)}" : PlayerName;
            Weapon = PlayerWeapon;
            character = charType;
            Health = charType.Health;
        }

        public void AttackEnemy(Enemy enemy)
        {
            int damage = Util.RandomDamage(Globals.random, this);
            if (enemy.Health > 0) {
                if (damage == 0) {
                    Console.WriteLine($"{Name} missed their attack against the {enemy}!");
                }
                Console.WriteLine($"{Name} attacks a {enemy} with {Weapon} dealing {damage} damage!");
                enemy.TakeDamage(damage);
            }
            // enemy is dead move on
        }
        public void TakeDamage(int damage)
        {
            Health -= damage;
        }

        public void AddPoints(EnemyType enemy)
        {
            Dictionary<EnemyType, int> pointsTable = new()
            {
                { EnemyType.Goblin, 20 },
                { EnemyType.Ghoul, 10 }
            };

            if (pointsTable.TryGetValue(enemy, out int points))
            {
                Points += points;
            }
            else
            {
                throw new Exception($"No such value {enemy} in pointsTable, error at AddPoints Method in Player Class");
            }
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



        //public bool IsPlayerDead() { 

        //}

    }

}