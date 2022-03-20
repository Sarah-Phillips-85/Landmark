using System;
using System.Collections.Generic;
using static Landmark.GridDimensions;

namespace Landmark
{
    public class GameLogic : IGameLogic
    {
        public int currentPosition { get; set; } = 0;
        public int numberOfMoves { get; set; } = 0;
        public List<int> hiddenMines { get; set; } = new List<int>();
        public List<int> foundMines {get;set;} = new List<int>();
        public bool gameEnd { get; set; } = false;

        public void PerformMove(int moveInterval)
        {
            if (IsMoveValid(moveInterval))
            {
                currentPosition += moveInterval;
                numberOfMoves++;
                CheckForActions();
            }
            else
            {
                Console.WriteLine("You can't move in that direction. Please try again");
            }
        }

        public bool IsMoveValid(int moveInterval)
        {
            switch (moveInterval)
            {
                case 1:
                    if ((currentPosition + 1) % Grid.Width != 0)
                    {
                        return true;
                    }
                    break;
                case -1:
                    if (currentPosition % Grid.Width != 0)
                    {
                        return true;
                    }
                    break;
                case Grid.Width:
                    if (currentPosition < Grid.Size - Grid.Width)
                    {
                        return true;
                    }
                    break;
                case -Grid.Width:
                    if (currentPosition >= Grid.Width)
                    {
                        return true;
                    }
                    break;
            }
            return false;
        }

        public void CheckForActions()
        {
            if (hiddenMines.Contains(currentPosition))
            {
                hiddenMines.Remove(currentPosition);
                foundMines.Add(currentPosition);
                if (foundMines.Count > 2)
                {
                    gameEnd = true;
                    Console.WriteLine("You've hit 3 mines. Game over!");
                }
            }
            if ((currentPosition + 1) % Grid.Width == 0)
            {
                gameEnd = true;
                Console.WriteLine("Congratulations! You escaped.");
            }
        }
    }
}
