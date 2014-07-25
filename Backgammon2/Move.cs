using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backgammon2
{
    [Serializable]
    public class Move : IComparable<Move>, IEquatable<Move>
    {
        public Move(int _SourceField, int _TargetField, PColor _Color)
        {

            this.SourceField = _SourceField;
            this.TargetField = _TargetField;
            this.Color = _Color;
        }

        public readonly int SourceField;
        public readonly int TargetField;
        public readonly PColor Color;
        public int Length
        {
            get {
                if (SourceField == C.WhiteBand)
                    return SourceField - TargetField - 18;
                if (SourceField == C.BlackBand)
                    return TargetField + 8 - SourceField;

                if (TargetField == C.Nowhere)
                {
                    if (Color == PColor.White)
                    {
                        return 24 - SourceField;
                    }
                    else
                    {
                        return SourceField + 1;
                    }
                }

                return Math.Abs(TargetField - SourceField);            
            }
        }

        int IComparable<Move>.CompareTo(Move m)
        {
            if (SourceField > m.SourceField) return 1;
            if (SourceField < m.SourceField) return -1;
            if (TargetField > m.TargetField) return 1;
            if (TargetField < m.TargetField) return -1;
            if (Color > m.Color) return 1;
            if (Color < m.Color) return -1;
            return 0;
        }
        bool IEquatable<Move>.Equals(Move m)
        {
            return
                (this.Color == m.Color) &&
                (this.SourceField == m.SourceField) &&
                (this.TargetField == m.TargetField);
        }

        public override int GetHashCode()
        {
            int r = 100 * SourceField + TargetField;
            if (Color == PColor.White) r += 30000;
            else r += 50000;
            return r;
        }

        public override bool Equals(object obj)
        {
            if (obj == this) return true;

            Move m = obj as Move;
            if (m == null) return false;

            return
                (this.Color == m.Color) &&
                (this.SourceField == m.SourceField) &&
                (this.TargetField == m.TargetField);
        }

        public static Move EmptyMove(PColor c)
        {
            return new Move(0, 0, c);
        }

        public bool IsEmpty
        {
            get { return SourceField == 0 && TargetField == 0; }
        }

    }
}

/*
górna banda - czerwony
dolna - biały

umieszcza się w "domu przeciwnika", czyli BLIŻEJ SWOJEJ BANDY. 

biała banda, dół:

wb = 24

24 -1 + c = 5
24 -2 + c = 4
24 -3 + c = 3

... 

24 -1 + c = 5
23 + c = 5
18 + c = 0
c = -18



2 oczka:
sourcefield = 24
targetfield = 4

3 oczka:
sourcefield = 24
targetfield = 3

6 oczek:
targetfield = 0

s - o -18 = target
s - t - 18 = o

s = 24
24 - t - 18 = o
24 - 18 - o = t
6 - o = t

testy:

pole 3: (4 na rys)
24 - 3 - 18 = 24 - 21 = 3 ok.
pole 4: (5 na rys)
24 - 4 - 18 = 24 - 22 = 2 ok.



teraz:

Banda czarna (góra)

s = 25;
(+ bo rosną)
s + o + c = pole

25 + 1 + c = 18
25 + 2 + c = 19
25 + 3 + c = 20
25 + 4 + c = 21
25 + 5 + c = 22
25 + 6 + c = 23


25 + 1 + c = 18
c = -8

source + o - 8 = target
source - 8 - target = -o
-source + 8 + target = o







*/