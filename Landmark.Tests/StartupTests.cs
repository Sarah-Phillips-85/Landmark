using NUnit.Framework;
using System;
using System.IO;

namespace Landmark.Tests
{
    public class StartupTests
    {
        [Test]
        public void CheckInitialMessage()
        {
            IStartup testStartup = new Startup();
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            testStartup.LoadingMessage();
            Assert.True(consoleOutput.ToString().Contains("Welcome to the Landmark Technical Test"));
        }

        [Test]
        public void MinesCreated()
        {
            IStartup testStartup = new Startup();
            var testGame = testStartup.InitalizeMines();

            Assert.True(testGame.hiddenMines.Count > 0);
        }
    }
}