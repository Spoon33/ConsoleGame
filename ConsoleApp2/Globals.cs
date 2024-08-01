namespace Global {
    public class Globals
    {
        public static readonly int seed = Guid.NewGuid().GetHashCode();
        public readonly static Random randomForPlayer = new(seed);
        public readonly static Random randomForEnemy = new(seed + 1234);
    }
}