using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Backgammon2
{
    [Serializable]
    public class Field : AbstractField
    {
        private Field(Rectangle _Rect, int _Number, bool _FieldColor, bool _FieldOrientation) : base(_Rect, _Number)
        {
            this.FieldColor = _FieldColor;
            this.FieldOrientation = _FieldOrientation;

            Triangle = new Point[3];
            Point[] t = Triangle;

            if (FieldOrientation == C.Upper)
            {
                t[0] = new Point(this.Rect.Left, this.Rect.Top);
                t[1] = new Point(this.Rect.Left + C.FieldSize, this.Rect.Top);
                t[2] = new Point(this.Rect.Left + C.FieldSize / 2, this.Rect.Top + this.Rect.Height);
            }
            else
            {
                t[0] = new Point(this.Rect.Left, this.Rect.Top + this.Rect.Height);
                t[1] = new Point(this.Rect.Left + C.FieldSize, this.Rect.Top + this.Rect.Height);
                t[2] = new Point(this.Rect.Left + C.FieldSize / 2, this.Rect.Top);
            }
        }

        public readonly Point[] Triangle;

        public static  Field MakeField(int _Number)
        {
            bool _FieldColor;
            bool _FieldOrientation;

            if (_Number > 11) //góra
                _FieldOrientation = C.Upper;
            else
                _FieldOrientation = C.Lower;

            if (_Number % 2 == 0)
                _FieldColor = C.Black;
            else _FieldColor = C.White;

            Rectangle _Rect;
            if (_Number > 11) // góra            
            {
                int x = (_Number - 12);
                if (_Number > 17) x += 2;
                _Rect = new Rectangle(x * C.FieldSize, 0, C.FieldSize, 5 * C.FieldSize);
            }
            else
            {
                int y = 7;
                int x = (11 - _Number);
                if (_Number < 6) x += 2;
                _Rect = new Rectangle(x * C.FieldSize, y * C.FieldSize, C.FieldSize, 5 * C.FieldSize);
            }

            return new Field(_Rect, _Number, _FieldColor, _FieldOrientation);
        }

        public override void Draw(Graphics g)
        {
            DrawBackground(g);
            DrawStones(g);  
        }

        public override void DrawWithLight(Graphics g, Color l)
        {
            DrawBackground(g);
            DrawLight(g,l);
            DrawStones(g);
        }

        private void DrawLight(Graphics g, Color l)
        {
            Pen p = new Pen(l);
            g.DrawPolygon(p, Triangle);
        }

        private void DrawBackground(Graphics g)
        {
            Brush b;

            if (FieldColor == C.Black) b = Brushes.Black; else b = Brushes.White;

            g.FillPolygon(b, Triangle);
        }

        private void DrawStones(Graphics g)
        {
            if (this.SumStones <= 5)
            {
                int slot = 0;
                if (WhiteStones > BlackStones)
                { // najpierw białe, bo jest ich więcej
                    for (int i = 0; i < WhiteStones; ++i)
                    {
                        g.FillEllipse(C.WhiteStoneBrush, GetFieldSlot(slot));
                        slot++;
                    }
                    for (int i = 0; i < BlackStones; ++i)
                    {
                        g.FillEllipse(C.BlackStoneBrush, GetFieldSlot(slot));
                        slot++;
                    }
                }
                else
                {   // najpierw czarne, bo jest ich więcej
                    for (int i = 0; i < BlackStones; ++i)
                    {
                        g.FillEllipse(C.BlackStoneBrush, GetFieldSlot(slot));
                        slot++;
                    }
                    for (int i = 0; i < WhiteStones; ++i)
                    {
                        g.FillEllipse(C.WhiteStoneBrush, GetFieldSlot(slot));
                        slot++;
                    }
                }
            }
            else
            {
                if (WhiteStones > BlackStones)
                {
                    g.DrawString(WhiteStones.ToString(), C.StoneFont, C.WhiteStoneBrush, GetFieldSlot(0));

                    if (BlackStones > 0)
                        g.DrawString(BlackStones.ToString(), C.StoneFont, C.BlackStoneBrush, GetFieldSlot(1));
                }
                else
                {
                    g.DrawString(BlackStones.ToString(), C.StoneFont, C.BlackStoneBrush, GetFieldSlot(0));

                    if (WhiteStones > 0)
                        g.DrawString(WhiteStones.ToString(), C.StoneFont, C.WhiteStoneBrush, GetFieldSlot(1));
                }
            }  
        }

        private Rectangle GetFieldSlot(int slotnumber)
        {            
            if (FieldOrientation == C.Lower) //dół
            {
                return new Rectangle(Rect.X, Rect.Y + Rect.Height - (slotnumber + 1) * C.FieldSize, C.FieldSize, C.FieldSize);
            }
            else // góra
                return new Rectangle(Rect.X, Rect.Y + slotnumber * C.FieldSize, C.FieldSize, C.FieldSize);
        }

        public override bool IsAccessibleFor(PColor Color)
        {
            if (Color == PColor.White)
            {
                if (BlackStones > 1) return false; else return true;
            }
            else
                if (WhiteStones > 1) return false; else return true;        
        }        

        private bool FieldColor;
        private bool FieldOrientation;        
    }
}
