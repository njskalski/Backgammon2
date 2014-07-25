using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Backgammon2
{
    [Serializable]
    public class Band : AbstractField
    {
        private Band(PColor _Color, Rectangle _Rect, int _Number) : base(_Rect, _Number)
        {
            this.Color = _Color;
        }

        public static Band MakeBand(PColor _Color)
        {
            Rectangle r;
            int num;
            if (_Color == PColor.White) //dół
            {
                r = new Rectangle(6 * C.FieldSize, 7 * C.FieldSize, 2 * C.FieldSize, 5 * C.FieldSize);
                num = C.WhiteBand;
            }
            else
            {
                r = new Rectangle(6 * C.FieldSize, 0, 2 * C.FieldSize, 5 * C.FieldSize);
                num = C.BlackBand;
            }

            return new Band(_Color, r, num);
        }

        public override bool IsAccessibleFor(PColor Color)
        {
            return (this.Color == Color);
        }

        private PColor Color;

        public override void Draw(Graphics g)
        {
            DrawStones(g);
        }

        public override void DrawWithLight(Graphics g, Color l)
        {
            DrawLight(g, l);
            DrawStones(g);
        }

        public void DrawStones(Graphics g)
        {
            if (Color == PColor.White) //dół
            {
                if (WhiteStones <= 6)
                {
                    for (int i = 0; i < WhiteStones; ++i)
                    {
                        int x = (1 - (i % 2)) * C.FieldSize;
                        int y = (2 - (i / 2)) * C.FieldSize;

                        g.FillEllipse(C.WhiteStoneBrush, Rect.X + x, Rect.Y + y, C.FieldSize, C.FieldSize);
                    }
                }
                else
                {
                    g.DrawString(WhiteStones.ToString(), C.StoneFont, C.WhiteStoneBrush, Rect.X + Rect.Width - C.FieldSize, Rect.Y + Rect.Height - C.FieldSize);
                }
            }
            else
            {
                if (BlackStones <= 6)
                {
                    for (int i = 0; i < BlackStones; ++i)
                    {
                        int x = (2 - (i % 2)) * C.FieldSize;
                        int y = (3 - (i / 2)) * C.FieldSize;

                        g.FillEllipse(C.BlackStoneBrush, Rect.X + Rect.Width - x, Rect.Y + Rect.Height - y, C.FieldSize, C.FieldSize);
                    }
                }
                else
                {
                    g.DrawString(BlackStones.ToString(), C.StoneFont, C.BlackStoneBrush, Rect.Location);
                }
            }
        }

        public void DrawLight(Graphics g, Color l)
        {
            Pen p = new Pen(l);
            g.DrawRectangle(p, Rect);
        }

    }
}
