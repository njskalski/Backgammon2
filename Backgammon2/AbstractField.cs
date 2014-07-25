using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Backgammon2
{
    [Serializable]
    public abstract class AbstractField : Drawable 
    {
        protected AbstractField(Rectangle _Rect, int _Number)
            : base(_Rect)
        {
            BlackStones = 0;
            WhiteStones = 0;
            Number = _Number;
        }

        public int BlackStones;
        public int WhiteStones;

        abstract public bool IsAccessibleFor(PColor Color);

        abstract public void DrawWithLight(Graphics g, Color l);

        public int SumStones
        {
            get { return BlackStones + WhiteStones; }
        }

        public int StonesOfColor(PColor Color)
        {
            if (Color == PColor.Black)
                return BlackStones;
            else return WhiteStones;
        }

        public bool AddStone(PColor Color)
        {
            if (IsAccessibleFor(Color) == false) return false;

            if (Color == PColor.White)
                WhiteStones++;
            else BlackStones++;

            return true;
        }

        public bool RemoveStone(PColor Color)
        {
            if (Color == PColor.White)
            {
                if (WhiteStones <= 0) return false;
                WhiteStones--;
                return true;
            }
            else
            {
                if (BlackStones <= 0) return false;
                BlackStones--;
                return true;
            }
        }

        public readonly int Number;
    }
}
