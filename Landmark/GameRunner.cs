using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landmark
{
    public class GameRunner : IGameRunner
    {
        public IGameLogic InitializeGame(IDisplayGrid display)
        {
            var loadGame = new Startup();    

            var game = loadGame.InitalizeMines();
            loadGame.LoadingMessage();
            display.DisplayPosition(game);

            return game;
        }

        public void ExecuteGame(IGameLogic game, IDisplayGrid display)
        {
            var gameInputs = new UserInputs();            

            while (!game.gameEnd)
            {
                gameInputs.PerformUserAction(gameInputs.GetUserInput(), game);
                display.DisplayPosition(game);
            }
        }
    }
}
