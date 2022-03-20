using NUnit.Framework;
using System;
using System.IO;
using static Landmark.GridDimensions;

namespace Landmark.Tests
{
    public class DisplayGridTests
    {
        [Test]
        public void DrawGrid()
        {
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            IDisplayGrid testDisplay = new DisplayGrid();
            IGameLogic testGame = new GameLogic();

            testDisplay.DisplayPosition(testGame);
            Assert.True(consoleOutput.ToString().Contains("[O]"));
            Assert.True(consoleOutput.ToString().Contains("[ ]"));
            Assert.False(consoleOutput.ToString().Contains("[X]"));
            Assert.False(consoleOutput.ToString().Contains("[@]"));
        }

        [Test]
        public void GetCoordinates()
        {
            DisplayGrid testDisplay = new DisplayGrid();
            int position = 0;

            var coordiantes = testDisplay.DisplayCoordiantes(position);
            Assert.True(coordiantes.Contains("A"));
            Assert.True(coordiantes.Contains("1"));
        }

        [Test]
        public void GetCoordinates_WhenInvalidPosition()
        {
            DisplayGrid testDisplay = new DisplayGrid();
            int position = Grid.Size +1;

            var coordiantes = testDisplay.DisplayCoordiantes(position);
            Assert.True(coordiantes.Contains("Outside of bounds"));            
        }

        [Test]
        public void DisplayMines()
        {
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            IDisplayGrid testDisplay = new DisplayGrid();
            IGameLogic testGame = new GameLogic();

            testGame.hiddenMines.Add(0);
            testGame.hiddenMines.Add(1);

            testGame.currentPosition = 0;
            testGame.CheckForActions();
            testDisplay.DisplayPosition(testGame);

            Assert.True(consoleOutput.ToString().Contains("[@]"));
            Assert.False(consoleOutput.ToString().Contains("[O]"));

            testGame.currentPosition = 1;
            testGame.CheckForActions();
            testDisplay.DisplayPosition(testGame);

            Assert.True(consoleOutput.ToString().Contains("[X]"));
        }
    }
}