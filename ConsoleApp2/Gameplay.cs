using CharacterNamespace;
using Enemys;
using Global;
using Player;
using Utils;

namespace Gameplay
{
    public class GameManager
    {
        private PlayerClass? _player;
        public bool _isGameRunning { get; protected set; }

        public void Initialize()
        {
            _isGameRunning = true;
            Console.Title = "Simple dungeon game";
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Welcome to the simple dungeon game!\nPlease enter the name you would like (if you do not want to give yourself a name press ENTER): ");
            string? name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Now what weapon would you like to use:\n1.Sword\n2.Hammer\n3.Knife\nSelection (Enter the name not number): ");
            Weapon weapon = Util.ConverWeaponType(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Now please enter the type of Character you would like to play with:\n1.Knight\n2.Thief\n3.Monk\nSelection (Enter the name not number): ");
            Character character = Util.ConverCharacter(Console.ReadLine());
            Console.Clear();

            _player = new(name ?? "", weapon, character);
            StartGame();
        }

        public void StartGame()
        {
            List<Enemy> list = EnemyGeneration();
            Console.WriteLine("The game will start now!");
            while (_isGameRunning)
            {
                if (list.Count > 0)
                {
                    Console.WriteLine($"A {list[0].Name()} appears!");
                    HandleInput(ref list);
                    if (_isGameRunning && list.Count > 0) // check if player fled or defeated the enemy
                    {
                        list[0].AttackPlayer(ref _player);
                    }
                }
                else
                {
                    _isGameRunning = false;
                }
            }
            Console.WriteLine($"Game ended! You had {_player?.Points} points");
        }

        public void HandleInput(ref List<Enemy> EnemyList)
        {
            string? input = null;
            while (input != "1" && input != "2" && input != "3")
            {
                Console.WriteLine("What would you like to do against the enemy or to yourself:\n1. Attack Enemy!\n2. Heal yourself\n3. Flee from the enemy\nSelection (1, 2 or 3)");
                input = Console.ReadLine();
                if (input != "1" && input != "2" && input != "3")
                {
                    Console.WriteLine($"Invalid input: {input}. Please enter 1, 2, or 3.");
                }
            }

            switch (input)
            {
                case "1":
                    _player?.AttackEnemy(EnemyList[0]);
                    if (EnemyList[0].Health <= 0)
                    {
                        Console.WriteLine($"You have defeated the {EnemyList[0].Name()}!");
                        EnemyList.RemoveAt(0);
                    }
                    break;
                case "2":
                    _player?.Heal();
                    break;
                case "3":
                    _player?.AttemptFlee(EnemyList);
                    break;
            }
        }

        public static List<Enemy> EnemyGeneration()
        {
            List<Enemy> charList = new();
            int EnemyAmount = Globals.random.Next(3, 10);
            for (int i = 0; i < EnemyAmount; i++)
            {
                int newRand = Globals.random.Next(1, 1000);
                if (newRand % 2 == 0)
                {
                    charList.Add(new Ghoul());
                }
                else
                {
                    charList.Add(new Goblin());
                }
            }
            return charList;
        }
    }
}
