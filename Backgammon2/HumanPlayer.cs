using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backgammon2
{

    public class HumanPlayer : Player
    {
        private Form1 Window;

        public HumanPlayer(PColor Color, Form1 Window)
            : base(Player.PlayerType.Human, Color)
        {
            this.Window = Window;
        }

        private GameStateController currentGame;

        public override void AskForMove(GameStateController game)
        {
            currentGame = game;
            if (currentGame.GameState.PossibleMoves.Length > 0)
            {
                Window.EnableInputFor(this);
            }
            else
            {
                Window.ShowMessage("Dla tych kości nie istnieje dozwolony ruch. Tracisz kolejkę.");
                MoveResult r = currentGame.RegisterMove(Move.EmptyMove(this.Color));
                if (r.Result != MoveResult.ResultType.Positive)
                    Window.ShowMessage("Wewnętrzny błąd programu!");
            }
        }

        public override void AskForRoll(GameStateController game)
        {
            currentGame = game;
            Window.EnableRoll(this);
        }

        public void ReceiveMove(Move m)
        {
            MoveResult r = currentGame.RegisterMove(m);
            if (r.Result == MoveResult.ResultType.Negative)
                Window.ShowMessage(r.Description);
            //else Window.ShowMessage("OK");
        }
    }
}
