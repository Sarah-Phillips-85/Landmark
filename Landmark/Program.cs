using System;

namespace Landmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var newGame = new GameRunner();
            var gameDisplay = new DisplayGrid();

            newGame.ExecuteGame(newGame.InitializeGame(gameDisplay), gameDisplay);
        }
    }   
}
