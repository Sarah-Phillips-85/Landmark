namespace Landmark
{
    interface IGameRunner
    {
        void ExecuteGame(IGameLogic game, IDisplayGrid display);
        public IGameLogic InitializeGame(IDisplayGrid display);
    }
}