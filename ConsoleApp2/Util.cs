using CharacterNamespace;
using Enemys;
using Global;
using Player;

namespace Utils
{
    public class Util
    {
        public static Weapon ConverWeaponType(string? wep)
        {
            if (!string.IsNullOrEmpty(wep))
            {
                switch (wep.ToLower())
                {
                    case "sword":
                        return Weapon.Sword;
                    case "hammer":
                        return Weapon.Hammer;
                    case "knife":
                        return Weapon.Knife;
                    default:
                        Console.WriteLine("Invalid Weapon Provided! Restating...");
                        Thread.Sleep(2500);
                        return GetWeapon();
                }
            }
            Console.WriteLine("Weapon provided was null");
            return GetWeapon();
        }
        public static Character ConverCharacter(string? character)
        {
            if (!string.IsNullOrEmpty(character))
            {
                switch (character.ToLower())
                {
                    case "knight":
                        return new Knight();
                    case "thief":
                        return new Thief();
                    case "monk":
                        return new Monk();
                    default:
                        Console.WriteLine("Invalid Character Provided! Restating...");
                        Thread.Sleep(2500);
                        return GetCharacter();
                }
            }
            Console.WriteLine("Character provided was null, defaulting to knight class");
            return GetCharacter();
        }
        public static int RandomDamage(Random x, PlayerClass? player, bool enemy)
        {
            int playerDamage = x.Next(1, 75);
            int enemyDamage = x.Next(1, 40);
            int damageReturned;
            if (enemy)
            {
                damageReturned = enemyDamage;
                return damageReturned;
            }
            else
            {
                damageReturned = (int)(playerDamage * player.strength);
                return damageReturned;
            }
        }
        public static string GeneratePoints(Enemy enemy, PlayerClass? player)
        {
            int chance = Globals.randomForPlayer.Next(1, 100);
            if (enemy.Type == EnemyType.Ghoul)
            {
                player.AddPoints(1);
                return "1";
            }
            if (chance > 0 && chance < 21 && enemy.Type == EnemyType.Goblin)
            {
                player.AddPoints(3);
                return "3";
            }
            else if (chance > 0 && chance < 51 && enemy.Type == EnemyType.Goblin)
            {
                player.AddPoints(2);
                return "2";
            }
            else
            {
                player.AddPoints(1);
                return "1";
            }

            return "ERROR";
        }
        public static Weapon GetWeapon() {
            bool valid = false;
            string? choice = null;
            while (!valid) {
                Console.WriteLine("Please provide a valid input from above: ");
                choice = Console.ReadLine();
                if (choice.ToLower() != "sword" || choice.ToLower() != "hammer" || choice.ToLower() != "knife")
                {
                    valid = true;
                    return Util.ConverWeaponType(choice);
                }
            }
            return Weapon.None;
        }
        public static Character GetCharacter()
        {
            bool valid = false;
            string? choice = null;
            while (!valid)
            {
                Console.WriteLine("Please provide a valid input from above: ");
                choice = Console.ReadLine();
                if (choice.ToLower() != "knight" || choice.ToLower() != "thief" || choice.ToLower() != "monk")
                {
                    valid = true;
                    return Util.ConverCharacter(choice);
                }
            }
            return new Knight();
        }
    }

}
