using CharacterNamespace;
using Enemys;
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
        public static int RandomDamage(Random x, PlayerClass? player)
        {
            int damage = 0;
            damage = x.Next(1, 50);
            return damage;

        }
    }

}
