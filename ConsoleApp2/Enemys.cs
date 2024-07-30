using Global;
using Player;
using Utils;

namespace Enemys
{

    public enum EnemyType
    {
        Goblin,
        Ghoul
    }

    public abstract class Enemy // Blueprint for enemys abstract is so that it can be used as a blueprint, so Goblin will be derived from this class (class Golbin : Enemy)
    {
        public int Health { get; protected set; }
        public EnemyType Type { get; protected set; }

        protected Enemy(EnemyType type, int health)
        {
            Health = health;
            Type = type;
        }

        public abstract void AttackPlayer(ref PlayerClass? player);
        public void TakeDamage(int damage)
        {
            Health -= damage;
        }
        public override string ToString()
        {
            switch (Type)
            {
                case EnemyType.Goblin:
                    return "Goblin";
                case EnemyType.Ghoul:
                    return "Ghoul";
                default:
                    return "Invalid enemy";
            }
        }
        public virtual string Name()
        {
            return $"{Type}";
        }

    }
    public class Ghoul : Enemy
    {
        public Ghoul() : base(EnemyType.Ghoul, 100) { }

        public int GetHealth()
        {
            return this.Health;
        }
        public bool IsAlive
        {
            get
            {
                if (Health <= 0) return false;

                return true;
            }
        }

        public override void AttackPlayer(ref PlayerClass? player)
        {
            int damage = Util.RandomDamage(Globals.random, player);
            if ((player?.GetHealth() > 0))
            {
                Console.WriteLine($"{Name()} attacks {player.Name} with its claws dealing {damage} damage!");
                player.TakeDamage(damage);
            }
        }

    }

    public class Goblin : Enemy
    {
        public Goblin() : base(EnemyType.Goblin, 200) { }

        private int GetHealth()
        {
            return this.Health;
        }

        public bool IsAlive
        {
            get
            {
                if (GetHealth() <= 0) return false;

                return true;
            }
        }
        public override void AttackPlayer(ref PlayerClass player)
        {
            int damage = Util.RandomDamage(Globals.random, player);
            if (player.GetHealth() > 0)
            {
                Console.WriteLine($"{Name()} attacks {player.Name} with its dagger dealing {damage} damage!");
                player.TakeDamage(damage);
            }
        }

    }
}