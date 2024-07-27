using Player;
using System.Diagnostics.CodeAnalysis;
using CharacterNamespace;
using Gameplay;
using Utils;

/*
 * TODO
 * . Start game logic
 * . Stop game logic
 * . 
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
        GameManager _gameManger = new GameManager();

        _gameManger.Initialize();

        return 1;
    }
}