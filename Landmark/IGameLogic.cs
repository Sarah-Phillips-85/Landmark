using System.Collections.Generic;

namespace Landmark
{
    public interface IGameLogic
    {
        void CheckForActions();
        bool IsMoveValid(int moveInterval);
        void PerformMove(int moveInterval);
        public int currentPosition { get; set; }
        public int numberOfMoves { get; set; }
        public List<int> hiddenMines { get; set; }
        public List<int> foundMines { get; set; }
        public bool gameEnd { get; set; }
    }
}