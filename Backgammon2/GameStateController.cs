using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backgammon2
{
    public class GameStateController
    {
        public GameStateController(Player PlayerWhite, Player PlayerBlack)
        {
            _playerBlack = PlayerBlack;
            _playerWhite = PlayerWhite;

            _gameState = GetNewGameState();            
        }

        public GameStateController(Player PlayerWhite, Player PlayerBlack, GameState theGameState)
        {
            _playerBlack = PlayerBlack;
            _playerWhite = PlayerWhite;
            _gameState = theGameState;
            CallOnGamestateUpdate();
        }

        private Player _playerWhite, _playerBlack;
        private GameState _gameState;
        public GameState GameState
        {
            get { return _gameState; }
            private set {
                _gameState = value;
                CallOnGamestateUpdate();
                }
        }
        public Player PlayerWhite
        {
            get { return _playerWhite; }
        }
        public Player PlayerBlack
        {
            get { return _playerBlack; }
        }

        private Dice _dice;

        public Scene GetScene()
        {
            Scene s;
            if (_gameState == null)
                s = new Scene(new List<Drawable>(), new int[0], new Dictionary<int,int[]>());
            else
                s = new Scene(new List<Drawable>(_gameState.CurFields), _gameState.PossibleSources, _gameState.PossibleTargets);

            if(_dice != null)
                s.Items.Add(_dice);
            return s;
        }

        private static GameState GetNewGameState()
        {
            return new GameState(GameState.Phase.PreGame, PColor.White, GameState.GetInitialFields(), null, new GameState.PreGame());
        }

        public MoveResult RegisterMove(Move m)
        {
            if (_gameState.CurTurnType != GameState.TurnType.Move) return new MoveResult(MoveResult.ResultType.Negative, "Musisz najpierw rzucić kośćmi.");

            if (m == null)
                return new MoveResult(MoveResult.ResultType.Negative, "Próba wgrania pustego ruchu.");

            if(_gameState.CurTurn != m.Color)
                return new MoveResult(MoveResult.ResultType.Negative, "Nie Twój ruch!");

            if (m.IsEmpty)
                if (_gameState.PossibleMoves.Length == 0)
                {

                    GameState = new GameState(GameState.CurPhase, GetOpposite(GameState.CurTurn), (AbstractField[])GameState.CurFields.Clone(), null, GameState.CurPreGame);
                    return new MoveResult(MoveResult.ResultType.Positive, null);
                }
                else return new MoveResult(MoveResult.ResultType.Negative, "Próba wgrania pustego ruchu, gdy są możliwe prawdziwe.");


            if (!_gameState.PossibleMoves.Contains<Move>(m))
               return new MoveResult(MoveResult.ResultType.Negative, "Nie ma takiego ruchu.");

            AbstractField[] newFields = (AbstractField[])_gameState.CurFields.Clone();
            PColor newTurn = _gameState.CurTurn;
            DiceState newDiceState = _gameState.CurDiceState.ReducedByOne(m.Length);

            newFields[m.SourceField].RemoveStone(m.Color);
            newFields[m.TargetField].AddStone(m.Color);

            // zbijanie.
            if (newFields[m.TargetField].StonesOfColor(GetOpposite(m.Color)) == 1)
            {
                newFields[m.TargetField].RemoveStone(GetOpposite(m.Color));
                if (GetOpposite(m.Color) == PColor.White)
                    newFields[C.WhiteBand].AddStone(PColor.White);
                else newFields[C.BlackBand].AddStone(PColor.Black);
            }

            if (newDiceState.Pips.Length == 0) // ruch się wyczerpał
            {
                newDiceState = null; //trzeba rzucić
                newTurn = GetOpposite(newTurn); //ale ruch kogo innego
            }

            GameState newGameState = new GameState(_gameState.CurPhase, newTurn, newFields, newDiceState, GameState.CurPreGame);

            /*
             * O ile to możliwe, gracz musi wykonać przesunięcia o liczbę oczek z każdej kostki.
             * Jeśli może wykonać przesunięcie o liczbę oczek tylko z jeden kostki,
             * wykonuje to jedno przesunięcie. Jeśli może wykonać tylko jedno
             * przesunięcie, ale o liczbę oczek z dowolnej z kostek, wykonuje
             * przesunięcie o większą liczbę oczek. Jeśli nie może wykonać żadnego
             * przesunięcia, traci kolejkę.
             */


            if (_gameState.CurDiceState != null)
                if (_gameState.CurDiceState.PrimevalLength == 2 &&
                    _gameState.CurDiceState.Pips.Length == 2) //pierwszy z dwóch
                    if (m.Length == _gameState.CurDiceState.Pips[0]) // i to krótszy
                        if (newGameState.PossibleMoves.Length == 0) // i nie ma potem ruchów
                            return new MoveResult(MoveResult.ResultType.Negative, "Ten ruch sprawiłby, że kostka o większej ilości oczek nie zostałaby wykorzystana. Zasady gry nie pozwalają na jego wykonanie.");

            GameState = newGameState;

            return new MoveResult(MoveResult.ResultType.Positive, null);
        }

        private MoveResult RegisterNewDice()
        {
            if (_gameState.CurPhase == GameState.Phase.One)
            {
                if (_gameState.CurDiceState != null)
                    return new MoveResult(MoveResult.ResultType.Negative, "Rzut niepotrzebny.");

                GameState = new GameState(_gameState.CurPhase, _gameState.CurTurn, (AbstractField[])_gameState.CurFields.Clone(), _dice.GetDiceState(), _gameState.CurPreGame);
                return new MoveResult(MoveResult.ResultType.Positive, null);
            }
            else // pregame
            {
                if (GameState.CurPreGame.PutPreGameDice(GameState.CurTurn, _dice.Sum))
                {
                    if (GameState.CurPreGame.PreGameWinner != null)
                    {
                        GameState = new GameState(GameState.Phase.One, (PColor)GameState.CurPreGame.PreGameWinner, (AbstractField[])GameState.CurFields.Clone(), null, GameState.CurPreGame);
                    }
                    else
                    {
                        GameState = new GameState(GameState.Phase.PreGame, GetOpposite(GameState.CurTurn), (AbstractField[])GameState.CurFields.Clone(), null, GameState.CurPreGame);
                    }
                    return new MoveResult(MoveResult.ResultType.Positive, null);
                }
                else
                    return new MoveResult(MoveResult.ResultType.Negative, "PreGame już się skończyła!");
            }

        }

        public MoveResult RollTheDice(Player p)
        {
            if (GameState.CurTurn != p.Color) return new MoveResult(MoveResult.ResultType.Negative, "Nie twoja kolej!");

            _dice = Dice.GetNewDice();

            MoveResult res = RegisterNewDice();
            CallOnGamestateUpdate();

            return res;
        }

        private PColor GetOpposite(PColor c)
        {
            if (c == PColor.White) return PColor.Black;
            else return PColor.White;
        }

        private List<IGameControllerEvent> _listeners = new List<IGameControllerEvent>();
        public List<IGameControllerEvent> Listeners
        {
            get { return _listeners; }
        }

        public void CallOnGamestateUpdate()
        {
            Proceed();
            foreach (IGameControllerEvent l in _listeners)
                l.OnGamestateUpdate();
        }

        public void Proceed()
        {
            if (GameState.Winner == null)
            {
                if (GameState.CurTurn == PColor.White)
                {
                    if (GameState.CurTurnType == GameState.TurnType.Move)
                        PlayerWhite.AskForMove(this);
                    else
                        PlayerWhite.AskForRoll(this);
                }
                else
                {
                    if (GameState.CurTurnType == GameState.TurnType.Move)
                        PlayerBlack.AskForMove(this);
                    else
                        PlayerBlack.AskForRoll(this);
                }
            }
            else
            {
                foreach (IGameControllerEvent l in _listeners)
                    l.OnGameEnd();
            }
        }

    }
}
