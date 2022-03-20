using System.Collections.Generic;

namespace Landmark
{
    public interface IStartup
    {
        List<int> GenerateMines();
        IGameLogic InitalizeMines();
        void LoadingMessage();
    }
}