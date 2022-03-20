using System;
using static Landmark.GridDimensions;

namespace Landmark
{
    public class UserInputs : IUserInputs
    {
        public string GetUserInput()
        {
            string userInput = Console.ReadLine();
            Console.Clear();
            return userInput.ToLower();
        }

        public void PerformUserAction(string userInput, IGameLogic game)
        {
            switch (userInput.ToLower())
            {
                case "u":
                    game.PerformMove(Grid.Width);
                    break;
                case "d":
                    game.PerformMove(-Grid.Width);
                    break;
                case "l":
                    game.PerformMove(-1);
                    break;
                case "r":
                    game.PerformMove(1);
                    break;
                default:
                    Console.WriteLine("That input is not valid. Please try again.");
                    break;
            }
        }
    }
}
