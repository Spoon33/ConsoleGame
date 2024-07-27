namespace Global {
    public class Globals
    {
        public static readonly int seed = Guid.NewGuid().GetHashCode();
        public readonly static Random random = new(seed);
    }
}