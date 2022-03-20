using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landmark.Tests
{
    class GameRunnerTests
    {
        [Test]
        public void InitializeGame()
        {
            var testDisplay = new DisplayGrid();
            var testGame = new GameRunner();

            var initializedGame = testGame.InitializeGame(testDisplay);

            Assert.True(initializedGame.hiddenMines.Count() > 0);
        }
    }
}
