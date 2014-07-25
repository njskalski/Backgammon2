using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Backgammon2
{
    public class Dice : Drawable
    {        
        private Dice(Rectangle _Rect) : base(_Rect)
        {
            Random myRandom = new Random();
            _left = myRandom.Next(6) + 1;
            _right = myRandom.Next(6) + 1;
        }

        public static Dice GetNewDice()
        {
            Rectangle r = GetDiceRect(C.DicePoint);
            return new Dice(r);
        }

        private int _left, _right;        

        public int Left
        {
            get { return _left; }
        }
        public int Right
        {
            get { return _right; }
        }
        public int Sum
        {
            get { return _left + _right; }
        }
        
        private static Rectangle GetDiceRect(Point at)
        {
            return new Rectangle(at.X - C.DiceSize / 2, at.Y - C.DiceSize / 2,
                2*C.DiceSize, C.DiceSize);
        }
        
        private void DrawSingleDiceAt(Graphics g, int number, Point at)
        {
            Rectangle dr = new Rectangle(at.X - C.DiceSize / 2, at.Y - C.DiceSize / 2,
                C.DiceSize, C.DiceSize);

            Brush b = new SolidBrush(Color.Cyan);
            g.FillRectangle(b, dr);

            Pen p = new Pen(Color.Coral, 4.5f);
            g.DrawRectangle(p, dr);

            Brush black = Brushes.Black;

            int middlex = at.X;
            int middley = at.Y;
            int leftx = at.X - C.DiceSize / 4;
            int rightx = at.X + C.DiceSize / 4;
            int lowery = at.Y - C.DiceSize / 4;
            int uppery = at.Y + C.DiceSize / 4;

            switch (number)
            {
                case 1:
                    g.FillEllipse(black, middlex - C.DiceDotSize / 2, middley - C.DiceDotSize / 2, C.DiceDotSize, C.DiceDotSize);
                    break;
                case 2:
                    g.FillEllipse(black, leftx - C.DiceDotSize / 2, uppery - C.DiceDotSize / 2, C.DiceDotSize, C.DiceDotSize);
                    g.FillEllipse(black, rightx - C.DiceDotSize / 2, lowery - C.DiceDotSize / 2, C.DiceDotSize, C.DiceDotSize);
                    break;
                case 3:
                    g.FillEllipse(black, middlex - C.DiceDotSize / 2, middley - C.DiceDotSize / 2, C.DiceDotSize, C.DiceDotSize);
                    g.FillEllipse(black, leftx - C.DiceDotSize / 2, uppery - C.DiceDotSize / 2, C.DiceDotSize, C.DiceDotSize);
                    g.FillEllipse(black, rightx - C.DiceDotSize / 2, lowery - C.DiceDotSize / 2, C.DiceDotSize, C.DiceDotSize);
                    break;
                case 4:
                    g.FillEllipse(black, leftx - C.DiceDotSize / 2, uppery - C.DiceDotSize / 2, C.DiceDotSize, C.DiceDotSize);
                    g.FillEllipse(black, rightx - C.DiceDotSize / 2, uppery - C.DiceDotSize / 2, C.DiceDotSize, C.DiceDotSize);
                    g.FillEllipse(black, leftx - C.DiceDotSize / 2, lowery - C.DiceDotSize / 2, C.DiceDotSize, C.DiceDotSize);
                    g.FillEllipse(black, rightx - C.DiceDotSize / 2, lowery - C.DiceDotSize / 2, C.DiceDotSize, C.DiceDotSize);
                    break;
                case 5:
                    g.FillEllipse(black, leftx - C.DiceDotSize / 2, uppery - C.DiceDotSize / 2, C.DiceDotSize, C.DiceDotSize);
                    g.FillEllipse(black, rightx - C.DiceDotSize / 2, uppery - C.DiceDotSize / 2, C.DiceDotSize, C.DiceDotSize);
                    g.FillEllipse(black, leftx - C.DiceDotSize / 2, lowery - C.DiceDotSize / 2, C.DiceDotSize, C.DiceDotSize);
                    g.FillEllipse(black, rightx - C.DiceDotSize / 2, lowery - C.DiceDotSize / 2, C.DiceDotSize, C.DiceDotSize);
                    g.FillEllipse(black, middlex - C.DiceDotSize / 2, middley - C.DiceDotSize / 2, C.DiceDotSize, C.DiceDotSize);
                    break;
                case 6:
                    g.FillEllipse(black, leftx - C.DiceDotSize / 2, uppery - C.DiceDotSize / 2, C.DiceDotSize, C.DiceDotSize);
                    g.FillEllipse(black, rightx - C.DiceDotSize / 2, uppery - C.DiceDotSize / 2, C.DiceDotSize, C.DiceDotSize);
                    g.FillEllipse(black, leftx - C.DiceDotSize / 2, lowery - C.DiceDotSize / 2, C.DiceDotSize, C.DiceDotSize);
                    g.FillEllipse(black, rightx - C.DiceDotSize / 2, lowery - C.DiceDotSize / 2, C.DiceDotSize, C.DiceDotSize);
                    g.FillEllipse(black, leftx - C.DiceDotSize / 2, middley - C.DiceDotSize / 2, C.DiceDotSize, C.DiceDotSize);
                    g.FillEllipse(black, rightx - C.DiceDotSize / 2, middley - C.DiceDotSize / 2, C.DiceDotSize, C.DiceDotSize);
                    break;
            }
        }

        public override void Draw(Graphics g)
        {
            DrawSingleDiceAt(g, _left, C.DicePoint);
            DrawSingleDiceAt(g, _right, new Point(C.DicePoint.X + C.DiceSize, C.DicePoint.Y));
        }

        public DiceState GetDiceState()
        {
            return new DiceState(this);
        }
    }
}
