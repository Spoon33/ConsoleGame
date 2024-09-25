using CharacterNamespace;
using Enemys;
using Global;
using ShopClass;
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
        public int megaHealPotions { get; protected set; }
        public double strength { get; protected set; }
        public int enemysDefeated{ get; set; }
        public bool IsAlive
        {
            get
            {
                if (Health <= 0) return false;

                return true;
            }
        }


        public PlayerClass(string PlayerName, Weapon PlayerWeapon, Character charType)
        {
            Name = string.IsNullOrEmpty(PlayerName) ? $"Player{Globals.randomForPlayer.Next(1, 1000)}" : PlayerName;
            Weapon = PlayerWeapon;
            character = charType;
            Health = charType.Health;
            healthPotions = charType.HealthPotions;
            megaHealPotions = 0;
            strength = 1;
        }

        public void AttackEnemy(Enemy enemy)
        {
            int damage = (int)(Util.RandomDamage(Globals.randomForPlayer, this, false) * strength);
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
        public void Heal(bool restingHeal = false)
        {
            
            if (restingHeal && healthPotions > 0)
            {
                Health += 100;
                Console.WriteLine($"Healed for 100hp while resting. Health now is: {GetHealth()}");
                healthPotions--;
                return;
            }
            else if (healthPotions > 0)
            {
                Health += 50;
                Console.WriteLine($"Healed for 50hp. Health now is: {GetHealth()}");
                healthPotions--;
                return;
            }
            Console.WriteLine("No Health potions left! Turn missed.");
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
            if (randomInt > 1 && randomInt < 30)
            {
                Console.WriteLine("You have fleed the enemy! Moving on.");
                Thread.Sleep(2000);
                EnemyList.RemoveAt(0);
            }
            Console.WriteLine("Flee attempt failed!");
        }

        public bool RemovePoints(string upgrade)
        {
            Shop shop = new();
            int upgradeCost = shop.shopPrices[upgrade];
            if(Points >= upgradeCost)
            {
                Points -= upgradeCost;
                return true;
            }
            else
                Console.WriteLine("Not enough points!");
            return false;
        }

        public void AddRegularPotion()
        {
            if(RemovePoints("Regular potion"))
                healthPotions++;
        }

        public void AddMegaPotion() 
        {
            if(RemovePoints("Mega Heal Potion"))
                megaHealPotions++;
            
        }

        public void IncreaseStrength()
        {
            if (RemovePoints("Strength upgrade"))
            {
                strength += 0.15;
            }
                
        }

        public void MegaHeal()
        {
            if (megaHealPotions > 0)
            {
                Health += 125;
                megaHealPotions--;
                Console.WriteLine("Healed for 125hp!");
            }else
                Console.WriteLine("No Mega Potions left! Missed turn.");
            
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