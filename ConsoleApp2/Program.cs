using Gameplay;

/*
 * TODO
 * . Add points to user when killing enemy 
 * . Display health information for both player and enemy when fighting 
 * . Need to fix logic with player getting attacked after killing an enemy as the enemy attack logic is straight after the handleINput function
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