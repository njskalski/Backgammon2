using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backgammon2
{
    public interface IGameBoardEvent
    {
        void OnMouseOverChange(Drawable d);
        void OnMouseClick(Drawable d);
    }
}
