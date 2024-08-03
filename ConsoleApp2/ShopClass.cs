using Player;

namespace ShopClass
{
    public class Shop
    {
        // If you update this dictionary update the switch case below
        private Dictionary<string, int> shopPrices = new Dictionary<string, int> {
            { "Strength upgrade", 3 },
            { "Regular potion", 1 },
            { "Mega Heal Potion!", 4 }
        };

        public void StartShop(ref PlayerClass player) {
            Console.Clear();
            bool leave = false;
            while (!leave) {
                Console.WriteLine($"Available points: {player.Points}");
                Console.WriteLine("Welcome to the Shop! Below you can see what is available:");
                int i = 1;
                foreach (var item in shopPrices)
                {
                    Console.WriteLine($"{i}. {item.Key} costs {item.Value} points");
                    ++i;
                }
                Console.WriteLine($"{i}. Exit");
                string answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        // Add strength
                        break;
                    case "2":
                        // Give player regular potion
                        break;
                    case "3":
                        // Give mega potion
                        break;
                    case "4":
                        // Leave
                        leave = true;
                        break;
                    default:
                        // Something happens not sure
                        break;

                }
                Console.Clear();
            }
        }
    }
}
