using NUnit.Framework;
using System;
using System.IO;
using static Landmark.GridDimensions;

namespace Landmark.Tests
{
    public class UserInputsTests
    {
        [Test]
        public void ValidMove()
        {
            IUserInputs testInput = new UserInputs();
            IGameLogic testGame = new GameLogic();
            int startingPosition = 0;
            
            testInput.PerformUserAction("u", testGame);            
            Assert.True(testGame.currentPosition == startingPosition + Grid.Width);
        }
        [Test]
        public void InvalidMove()
        {
            IUserInputs testInput = new UserInputs();
            IGameLogic testGame = new GameLogic();
            int startingPosition = 0;

            testInput.PerformUserAction("d", testGame);
            Assert.True(testGame.currentPosition == startingPosition);
        }
        [Test]
        public void InvalidInput()
        {
            IUserInputs testInput = new UserInputs();
            IGameLogic testGame = new GameLogic();            

            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            
            testInput.PerformUserAction("m", testGame);

            Assert.True(consoleOutput.ToString().Contains("That input is not valid. Please try again."));
        }
    }
}