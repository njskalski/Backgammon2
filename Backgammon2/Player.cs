using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backgammon2
{
    abstract public class Player
    {
        public enum PlayerType
        {
            AI,
            Human
        }

        public Player(PlayerType Type, PColor Color)
        {
            this.Type = Type;
            this.Color = Color;
        }

        public readonly PlayerType Type;
        public readonly PColor Color;

        abstract public void AskForRoll(GameStateController game);
        abstract public void AskForMove(GameStateController game);
    }
}
