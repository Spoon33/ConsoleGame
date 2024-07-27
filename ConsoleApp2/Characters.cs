using Player;
using System.Security.Cryptography.X509Certificates;

namespace CharacterNamespace
{
    public enum Weapon
    {
        Sword,
        Hammer,
        Knife,
        None
    }
    public enum CharacterTypes
    {
        Knight,
        Thief,
        Monk
    }
    public abstract class Character
    {
        public int Health { get; set; }
        public int HealthPotions { get; protected set; }
        public CharacterTypes CharType { get; protected set; }
        public double DamageMultiplier { get; protected set; }
        public Character(int health, int healthPotions, CharacterTypes charType, double Multiplier)
        {
            Health = health;
            HealthPotions = healthPotions;
            CharType = charType;
            DamageMultiplier = Multiplier;
        }

        public virtual int CurrentHealth()
        {
            return Health;
        }

        public virtual int CurrentHealthPotions()
        {
            return HealthPotions;
        }
        public virtual void UsePotion(PlayerClass x)
        {
            HealthPotions--;
            Health += 20;
            Console.WriteLine($"Healed, health is now: {Health}");
        }
        public string CharacterToString()
        {
            switch (CharType)
            {
                case CharacterTypes.Knight:
                    return "Knight";
                case CharacterTypes.Thief:
                    return "Thief";
                case CharacterTypes.Monk:
                    return "Monk";
                default:
                    return "Invalid character";
            }
        }
    }

    public class Knight : Character
    {
        public Knight() : base(200, 3, CharacterTypes.Knight, 0.7)
        {

        }
    }

    public class Thief : Character
    {
        public Thief() : base(100, 5, CharacterTypes.Thief, 0.4)
        {

        }
    }

    public class Monk : Character
    {
        public Monk() : base(75, 8, CharacterTypes.Monk, 0.2)
        {

        }
    }
}