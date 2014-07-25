using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backgammon2
{
    [Serializable]
    public class DiceState
    {
        public DiceState(Dice dice)
        {
            if (dice.Left == dice.Right)
            {
                _possibilities = new int[] { dice.Left, dice.Left, dice.Left, dice.Left };
                _primevalLength = 4;
            }
            else
            {
                if (dice.Left < dice.Right)
                    _possibilities = new int[] { dice.Left, dice.Right };
                else
                    _possibilities = new int[] { dice.Right, dice.Left };
                _primevalLength = 2;
            }
        }

        private DiceState(int[] _possibilities, int _primevalLength)
        {
            this._possibilities = _possibilities;
            this._primevalLength = _primevalLength;
        }        

        public DiceState ReducedByOne(int o)
        {
            if (_possibilities.Length == 0)
                throw new Exception("The DiceState is already empty!");

            bool notyet = true;
            int[] new_possibilities = new int[_possibilities.Length - 1];
            int p = 0;
            for (int i = 0; i < _possibilities.Length; ++i)
                if (notyet && o == _possibilities[i])
                {
                    notyet = false;
                    continue;
                }
                else
                    new_possibilities[p++] = _possibilities[i];

            if (!notyet)
            {
                return new DiceState(new_possibilities, _primevalLength);
            }
            else throw new Exception("The DiceState does not contain a number " + o.ToString() + "!");
        }

        private int[] _possibilities;
        private int _primevalLength;
        public int[] Pips
        {
            get { return _possibilities; }
        }
        public int PrimevalLength
        {
            get { return _primevalLength; }
        }
    }
}
