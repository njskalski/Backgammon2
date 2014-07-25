using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backgammon2
{
    [Serializable]
    public class GameState
    {
        public enum Phase
        {
            PreGame,
            One            
        }

        public enum TurnType
        {
            Roll,
            Move
        }

        private AbstractField[] _fields;
        private Phase _phase;
        private DiceState _dicestate;
        private PColor _turn;
        
        public AbstractField[] CurFields
        {
            get { return _fields; }
        }
        public Phase CurPhase
        {
            get { return _phase ; }
        }
        public DiceState CurDiceState
        {
            get { return _dicestate;}
        }
        public PColor CurTurn
        {
            get { return _turn; }
        }

        public PColor? Winner
        {
            get
            {
                if (_fields[C.BlackBand].StonesOfColor(PColor.Black) == 15)
                    return PColor.Black;
                if (_fields[C.WhiteBand].StonesOfColor(PColor.White) == 15)
                    return PColor.White;
                return null;
            }
        }

        public readonly PreGame CurPreGame;

        public TurnType CurTurnType
        {
            get
            {
                if (_phase == Phase.PreGame) return TurnType.Roll;
                if (_dicestate == null) return TurnType.Roll;
                return TurnType.Move;
            }
        }

        public GameState(Phase _phase, PColor _turn, AbstractField[] _fields, DiceState _dicestate, PreGame _preGame)
        {
            this._dicestate = _dicestate;
            this._turn = _turn;
            this._fields = _fields;
            this._phase = _phase;
            this.CurPreGame = _preGame;

            CalculatePossibleMoves();
        }

        public static AbstractField[] GetInitialFields()
        {
            AbstractField[] f = new AbstractField[27];

            for (int i = 0; i < 24; ++i)
                f[i] = Field.MakeField(i);

            f[C.WhiteBand] = Band.MakeBand(PColor.White);
            f[C.BlackBand] = Band.MakeBand(PColor.Black);
            f[C.Nowhere] = Nowhere.GetNowhere();

            f[0].WhiteStones = 2;
            f[5].BlackStones = 5;
            f[7].BlackStones = 3;
            f[11].WhiteStones = 5;
            f[12].BlackStones = 5;
            f[16].WhiteStones = 3;
            f[18].WhiteStones = 5;
            f[23].BlackStones = 2;

            return f;
        }

        private Move[] _possibleMoves;
        public Move[] PossibleMoves
        {
            get { return _possibleMoves; }
        }

        private int[] _possibleSources;
        private Dictionary<int, int[]> _possibleTargets;

        public int[] PossibleSources
        {
            get { return _possibleSources; }
        }

        public Dictionary<int, int[]> PossibleTargets
        {
            get { return _possibleTargets; }
        }

        public bool IsPlayerWhiteHome()
        {
            if (_fields[C.WhiteBand].WhiteStones > 0) return false;
            bool result = true;
            for (int i = 0; i < 18; ++i)
                if (_fields[i].WhiteStones > 0)
                {
                    result = false;
                    break;
                }
            return result;
        }

        public bool IsPlayerBlackHome()
        {
            if (_fields[C.BlackBand].BlackStones > 0) return false;
            bool result = true;
            for (int i = 6; i < 24; ++i)
                if (_fields[i].BlackStones > 0)
                {
                    result = false;
                    break;
                }
            return result;
        }

        void CalculatePossibleMoves()
        {
            DiceState state = _dicestate;

            if (state == null || _phase == Phase.PreGame)
            {
                _possibleMoves = new Move[0];
                _possibleSources = new int[0];
                _possibleTargets = new Dictionary<int, int[]>();
                return;
            }

            Dictionary<Move, object> moves = new Dictionary<Move, object>();
            
            // istotnie rozróżniający IF!
            if (_turn == PColor.White)
            {
                if (_fields[C.WhiteBand].WhiteStones == 0)
                {
                    for (int j = 0; j < state.Pips.Length; ++j)
                    {
                        int p = state.Pips[j];
                        for (int i = 0; i < 24; ++i)
                            if (_fields[i].IsAccessibleFor(PColor.White))
                                if (i - p >= 0)
                                    if (_fields[i - p].WhiteStones > 0)
                                    {
                                        Move m = new Move(i - p, i, _turn);
                                        if (!moves.ContainsKey(m))
                                            moves.Add(m, null);
                                    }
                    }
                }
                else //wyprowadzanie
                {
                    int magic = 6;
                    for (int j = 0; j < state.Pips.Length; ++j)
                    {
                        int p = state.Pips[j];
                        int target = magic - p;
                        if (_fields[target].IsAccessibleFor(PColor.White))
                        {
                            Move m = new Move(C.WhiteBand, target, _turn);
                            if (!moves.ContainsKey(m))
                                moves.Add(m, null);
                        }
                    }
                }

                if (IsPlayerWhiteHome()) // wywalanie
                {

                    for (int j = 0; j < state.Pips.Length; ++j)
                    {
                        int p = state.Pips[j];
                        int source = 24 - p;
                        if(source > 0 && source < 23)
                            if (_fields[source].WhiteStones > 0)
                            {
                                Move m = new Move(source, C.Nowhere, _turn);
                                if (!moves.ContainsKey(m))
                                    moves.Add(m, null);
                            }
                    }
                }
            }
            else // black
            {
                if (_fields[C.BlackBand].BlackStones == 0)
                {
                    for (int j = 0; j < state.Pips.Length; ++j)
                    {
                        int p = state.Pips[j];
                        for (int i = 0; i < 24; ++i)
                            if (_fields[i].IsAccessibleFor(PColor.Black))
                                if (i + p < _fields.Length) //24
                                    if (_fields[i + p].BlackStones > 0)
                                    {
                                        Move m = new Move(i + p, i, _turn);
                                        if (!moves.ContainsKey(m))
                                            moves.Add(m, null);
                                    }
                    }
                }
                else // wyprowadzanie
                {                    
                    for (int j = 0; j < state.Pips.Length; ++j)
                    {
                        int p = state.Pips[j];
                        int target = C.BlackBand + p - 8;
                        if (_fields[target].IsAccessibleFor(PColor.Black))
                        {
                            Move m = new Move(C.BlackBand, target, _turn);
                            if (!moves.ContainsKey(m))
                                moves.Add(m, null);
                        }
                    }
                }

                if (IsPlayerBlackHome()) // wywalanie
                {

                    for (int j = 0; j < state.Pips.Length; ++j)
                    {
                        int p = state.Pips[j];
                        int source = p - 1;
                        if (source > 0 && source < 23)
                            if (_fields[source].BlackStones > 0)
                            {
                                Move m = new Move(source, C.Nowhere, _turn);
                                if (!moves.ContainsKey(m))
                                    moves.Add(m, null);
                            }
                    }
                }

            }

            Move[] result = moves.Keys.ToArray<Move>();

            Dictionary<int, List<int>> pr = new Dictionary<int, List<int>>();

            for (int i = 0; i < result.Length; ++i)
            {
                int source = result[i].SourceField;
                int target = result[i].TargetField;

                if (!pr.ContainsKey(source))
                    pr.Add(source, new List<int>());

                pr[source].Add(target);
            }

            _possibleSources = pr.Keys.ToArray<int>();

            _possibleTargets = new Dictionary<int, int[]>();
            foreach (KeyValuePair<int, List<int>> p in pr)
                _possibleTargets.Add(p.Key, p.Value.ToArray<int>());


            _possibleMoves = result;
        }

        public int WhitePlayerNeeds()
        {
            if (_fields[C.WhiteBand].WhiteStones > 0) return -1;

            int result = 0;
            for (int i = 0; i < 24; ++i)
            {
                result += (_fields[i].WhiteStones) * (24 - i);
            }
            return result;
        }

        public int BlackPlayerNeeds()
        {
            if (_fields[C.BlackBand].BlackStones > 0) return -1;

            int result = 0;
            for (int i = 0; i < 24; ++i)
            {
                result += (_fields[i].BlackStones) * (i + 1);
            }
            return result;
        }

        public int PlayerNeeds(PColor Color)
        {
            if (Color == PColor.White) return WhitePlayerNeeds();
            else return BlackPlayerNeeds();
        }

        [Serializable]
        public class PreGame
        {
            public PreGame()
            {
                PreWhiteSum = 0;
                PreBlackSum = 0;
            }

            private int PreWhiteSum, PreBlackSum;
            public PColor? PreGameWinner
            {
                get
                {
                    if (PreBlackSum == 0 || PreWhiteSum == 0) return null;
                    if (PreBlackSum > PreWhiteSum) return PColor.Black;
                    if (PreWhiteSum > PreBlackSum) return PColor.White;
                    return null;
                }
            }
            public bool PutPreGameDice(PColor Color, int sum)
            {
                if (PreGameWinner != null) return false;

                if (Color == PColor.White)
                    PreWhiteSum = sum;
                else
                {
                    PreBlackSum = sum;
                    if (PreWhiteSum == PreBlackSum)
                    {
                        PreBlackSum = 0;
                        PreWhiteSum = 0;
                    }
                }

                return true;
            }
        }

    }
}
