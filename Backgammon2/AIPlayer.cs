using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backgammon2
{
    class AIPlayer : Player
    {
        public AIPlayer(PColor Color)
            : base(PlayerType.AI, Color)
        {                        
        }

        public override void AskForMove(GameStateController game)
        {
            if (game.GameState.PossibleMoves.Length == 0)
                game.RegisterMove(null);
            else
            {
                Random r = new Random();

                int nextmove = r.Next(game.GameState.PossibleMoves.Length);
                game.RegisterMove(game.GameState.PossibleMoves[nextmove]);

            }
        }

        public override void AskForRoll(GameStateController game)
        {
            game.RollTheDice(this);
        }
    }
}
