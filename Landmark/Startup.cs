using System;
using System.Collections.Generic;
using static Landmark.GridDimensions;

namespace Landmark
{
    public class Startup : IStartup
    {
        public void LoadingMessage()
        {
            Console.WriteLine(
                "Welcome to the Landmark Technical Test \r\n" +
                "You begin in the bottom left. \r\n" +
                "Reach the right edge before loosing 3 lives to win. \r\n" +
                "You may move up, down, left or right.\r\n" +
                "Enter a direction to start...\r\n"
                );
        }

        public IGameLogic InitalizeMines()
        {
            var newGame = new GameLogic();
            newGame.hiddenMines.AddRange(GenerateMines());

            return newGame;
        }

        public List<int> GenerateMines()
        {
            int position;
            List<int> mines = new List<int>();

            Random rnd = new Random();
            int numberOfMines = rnd.Next(1, Grid.Size - 1); //as an extension, this number of mines could be limited to ensure a winning path is always possible

            for (int i = 0; i < numberOfMines; i++)
            {
                do
                {
                    position = rnd.Next(1, Grid.Size - 1);
                }
                while (mines.Contains(position));

                mines.Add(position);
            }

            return mines;
        }
    }
}
