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
                        break;
                }
            }
            Console.WriteLine("Weapon provided was null");
            return Weapon.None;
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
                        break;
                }
            }
            Console.WriteLine("Character provided was null, defaulting to knight class");
            return new Knight();
        }
        public static int RandomDamage(Random x, PlayerClass? player, bool enemy)
        {
            int damage;
            if (enemy)
            {
                damage = x.Next(1, 30);
                return damage;
            }
            damage = x.Next(1, 75);
            return damage;

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
    }

}
