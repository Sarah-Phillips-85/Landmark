using System;
using static Landmark.GridDimensions;

namespace Landmark
{
    public class DisplayGrid : IDisplayGrid
    {
        public void DisplayPosition(IGameLogic game)
        {            
            Console.WriteLine("Lives Lost: " + game.foundMines.Count.ToString() + "/3");
            Console.WriteLine("Moves Made: " + game.numberOfMoves);
            Console.WriteLine("Current Position: " + DisplayCoordiantes(game.currentPosition) + Environment.NewLine);

            for (int y = Grid.Size - Grid.Width; y >= 0; y -= Grid.Width)
            {
                for (int x = 0; x < Grid.Width; x++)
                {
                    if (y + x == game.currentPosition && game.foundMines.Contains(y + x))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("[@]");
                    }
                    else if (y + x == game.currentPosition)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("[O]");
                    }
                    else if (game.foundMines.Contains(y + x))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("[X]");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("[ ]");
                    }
                }
                Console.WriteLine();
            }
        }

        public string DisplayCoordiantes(int position)
        {
            if (position > Grid.Size || position < 0)
            {
                return "Outside of bounds";
            }

            int xPosition, yPosition;
            yPosition = Math.DivRem(position, 8, out xPosition);

            return (char)(65 + xPosition) + (yPosition + 1).ToString();
        }
    }
}
