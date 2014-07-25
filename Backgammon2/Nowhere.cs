using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Backgammon2
{
    [Serializable]
    class Nowhere : AbstractField
    {
        private Nowhere(Rectangle _Rect)
            : base(_Rect, C.Nowhere)
        {
        }

        public static Nowhere GetNowhere()
        {
            Rectangle r = new Rectangle(14 * C.FieldSize, 0, C.FieldSize, 12 * C.FieldSize);
            return new Nowhere(r);
        }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(C.BandBrush, Rect);
        }

        public override void DrawWithLight(Graphics g, Color l)
        {
            g.FillRectangle(C.BandBrush, Rect);
            Pen p = new Pen(l);
            g.DrawRectangle(p, Rect);
        }

        public override bool IsAccessibleFor(PColor Color)
        {
            return true;
        }        

    }
}
