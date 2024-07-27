using CharacterNamespace;
using Player;
using Enemys;
using Utils;

namespace Gameplay
{
    public class GameManager
    {
        private PlayerClass? _player;
        private bool _isGameRunning;

        public void Initialize()
        {
            _isGameRunning = true;
            Console.Title = "Simple dungeon game";
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Welcome to the simple dungeon game!\nPlease enter the name you would like (if you do not want to give yourself a name press ENTER): ");
            string? name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Now what wepon would you like to use:\n1.Sword\n2.Hammer\n3.Knife\nSelection (Enter the name not number): ");
            Weapon weapon = Util.ConverWeaponType(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Now please enter the type of Character you would like to play with:\n1.Knight\n2.Thief\n3.Monk\nSelection (Enter the name not number): ");
            Character character = Util.ConverCharacter(Console.ReadLine());
            Console.Clear();

            _player = new(name is not null ? name : "", weapon, character);
            StartGame();
        }
        public void StartGame()
        {
            if (_isGameRunning)
            {
                Ghoul ghoul = new();
                _player?.AttackEnemy(ghoul);
                ghoul.AttackPlayer(_player);
            }   
        }
        public void StopGame()
        {

        }
    }
}
