namespace Landmark
{
    public interface IUserInputs
    {
        string GetUserInput();
        void PerformUserAction(string userInput, IGameLogic game);
    }
}