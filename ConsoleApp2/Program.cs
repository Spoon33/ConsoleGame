using Gameplay;

/*
 * TODO
 * . Create some sort of multiplier to damage so that depending on weapon choice you have have extra damage (int)(damage * player multiplier)
 * . Create a shop so you can add to your strength, buy health potions, possibly get different weapons
 * . Test
 * . 
 * .  
 * . 
 * 
 * 
 */


class Entry
{
    public static int Main()
    {
        GameManager _gameManger = new();

        _gameManger.Initialize();

        return 1;
    }
}