using NUnit.Framework;
using System;
using System.IO;
using static Landmark.GridDimensions;

namespace Landmark.Tests
{
    public class GameLogicTests
    {
        [Test]
        public void ValidMove()
        {
            IGameLogic testGame = new GameLogic();
            testGame.currentPosition = 0;

            Assert.True(testGame.IsMoveValid(1));
        }

        [Test]
        public void InvalidMove()
        {
            IGameLogic testGame = new GameLogic();
            testGame.currentPosition = 0;

            Assert.False(testGame.IsMoveValid(-1));
        }

        [Test]
        public void MoveToMine()
        {
            IGameLogic testGame = new GameLogic();
            testGame.currentPosition = 0;

            testGame.hiddenMines.Add(0);
            testGame.CheckForActions();

            Assert.False(testGame.hiddenMines.Contains(0));
            Assert.True(testGame.foundMines.Contains(0));
        }

        [Test]
        public void MoveToWin()
        {
            IGameLogic testGame = new GameLogic();

            testGame.currentPosition = Grid.Size-1;
            testGame.CheckForActions();

            Assert.True(testGame.gameEnd);
        }

        [Test]
        public void EndGameAfterThreeMines()
        {
            IGameLogic testGame = new GameLogic();

            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            testGame.hiddenMines.Add(0);
            testGame.hiddenMines.Add(1);
            testGame.hiddenMines.Add(2);

            testGame.currentPosition = 0;
            testGame.CheckForActions();

            testGame.currentPosition = 1;
            testGame.CheckForActions();

            testGame.currentPosition = 2;
            testGame.CheckForActions();

            Assert.True(testGame.gameEnd);
            Assert.True(consoleOutput.ToString().Contains("You've hit 3 mines. Game over!"));            
        }
    }
}