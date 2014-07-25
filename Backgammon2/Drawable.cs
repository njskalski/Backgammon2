using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Backgammon2
{
    [Serializable]
    public abstract class Drawable
    {
        public Drawable(Rectangle _Rect)
        {
            Rect = _Rect;
            OverRect = new Rectangle(Rect.X - 1, Rect.Y - 1, Rect.Width + 2, Rect.Height + 2);
        }

        public readonly Rectangle Rect;
        public readonly Rectangle OverRect;
        abstract public void Draw(Graphics g);       
        //abstract public void Click();

        public bool TestAgainst(Point p)
        {
            return Rect.Contains(p);
        }
    }
}
