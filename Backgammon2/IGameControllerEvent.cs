using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backgammon2
{
    public interface IGameControllerEvent
    {
        void OnGamestateUpdate();
        void OnGameEnd();
    }
}
