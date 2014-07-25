using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Backgammon2
{
    public class GameBoard : Panel
    {
        public GameBoard()
            : base()
        {
            this.DoubleBuffered = true;
            DrawScene = null;
            _lightType = LightTypeEnum.None;
            _clickEven = false;
            _inputEnabled = false;
            _currentPlayer = null;
            _mouseClicked1 = -1;
            _mouseClicked2 = -1;
        }

        public readonly int DesiredHeight = 12 * C.FieldSize;
        public readonly int DesiredWidth = 14 * C.FieldSize;

        private LightTypeEnum _lightType;
        public LightTypeEnum LightType
        {
            get { return _lightType; }
            private set { 
                _lightType = value;
                this.Invalidate();
            }
        }

        private bool _clickEven, _inputEnabled;
        public bool InputEnabled
        {
            get { return _inputEnabled; }
        }
        private bool ClickEven
        {
            get { return _clickEven; }
        }

        public Scene DrawScene;        

        private Drawable _mouseOver;
        public Drawable MouseOver
        {
            get { return _mouseOver; }
            protected set
            {
                _mouseOver = value;
                foreach (IGameBoardEvent l in _listeners)
                    l.OnMouseOverChange(_mouseOver);
            }
        }

        private int _mouseClicked1, _mouseClicked2;        
        private HumanPlayer _currentPlayer;

        private List<IGameBoardEvent> _listeners = new List<IGameBoardEvent>();
        public List<IGameBoardEvent> Listeners
        {
            get { return _listeners; }
        }

        public void EnableInputFor(HumanPlayer p)
        {
            _clickEven = false;
            _inputEnabled = true;
            _currentPlayer = p;
            LightType = LightTypeEnum.Source;
            this.Invalidate();
        }

        public void DisableInput()
        {            
            _inputEnabled = false;            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            g.Clear(C.BackgroundColor);
            //g.FillRectangle(C.BandBrush, new Rectangle(6*C.FieldSize, 0, 2*C.FieldSize, 12*C.FieldSize));

            if (DrawScene != null)
            {
                g.FillRectangle(C.BandBrush, new Rectangle(6 * C.FieldSize, 0, 2 * C.FieldSize, 12 * C.FieldSize));

                switch (LightType)
                {
                    case LightTypeEnum.None:
                        foreach (Drawable d in DrawScene.Items)
                            d.Draw(g);
                        break;
                    case LightTypeEnum.Source:
                        foreach (Drawable d in DrawScene.Items)
                            if (d is AbstractField)
                            {
                                AbstractField dd = d as AbstractField;
                                if (DrawScene.PossibleSources.Contains<int>(dd.Number))
                                    dd.DrawWithLight(g, C.SourceLight);
                                else dd.Draw(g);
                            }
                            else d.Draw(g);
                        break;

                    case LightTypeEnum.Target:
                        {
                            int[] targets;
                            if (DrawScene.PossibleTargets.ContainsKey(_mouseClicked1))
                                targets = DrawScene.PossibleTargets[_mouseClicked1];
                            else targets = new int[0];

                            foreach (Drawable d in DrawScene.Items)
                                if (d is AbstractField)
                                {
                                    AbstractField dd = d as AbstractField;
                                    if (targets.Contains<int>(dd.Number))
                                        dd.DrawWithLight(g, C.TargetLight);
                                    else
                                        dd.Draw(g);
                                }
                                else d.Draw(g);
                        }
                        break;
                }

                if (MouseOver != null)
                {
                    g.DrawRectangle(C.SelectionPen, MouseOver.Rect);
                    Invalidate(MouseOver.OverRect);
                }                
            }
                

            base.OnPaint(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (DrawScene != null)
            {
                if (MouseOver != null)
                {
                    this.Invalidate(MouseOver.OverRect);
                    MouseOver = null;
                }                
                foreach (Drawable d in DrawScene.Items)
                    if(d is AbstractField)
                    if (d.TestAgainst(e.Location))
                    {
                        MouseOver = d;
                        break;
                    }
            }

            base.OnMouseMove(e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (_inputEnabled)
            {
                if (DrawScene != null)
                    foreach (Drawable d in DrawScene.Items)
                        if(d is AbstractField)
                        if (d.TestAgainst(e.Location))
                        {
                            AbstractField dd = d as AbstractField;
                            if (_clickEven)
                            {
                                if (DrawScene.PossibleTargets[_mouseClicked1].Contains<int>(dd.Number))
                                {
                                    _mouseClicked2 = dd.Number;
                                    _clickEven = false;
                                    LightType = LightTypeEnum.None;
                                    SendMoveToPlayer();
                                }
                                else
                                {
                                    _mouseClicked1 = -1;
                                    _mouseClicked2 = -1;
                                    _clickEven = false;
                                    LightType = LightTypeEnum.Source;
                                }
                            }
                            else
                            {
                                if (DrawScene.PossibleSources.Contains<int>(dd.Number))
                                {
                                    _mouseClicked1 = dd.Number;
                                    LightType = LightTypeEnum.Target;
                                    _clickEven = !_clickEven;
                                }
                            }

                            break;
                        }
            }
            base.OnMouseClick(e);
        }

        private void SendMoveToPlayer()
        {
            Move m = new Move(_mouseClicked1, _mouseClicked2, _currentPlayer.Color);
            DisableInput();
            if(_currentPlayer != null)
                _currentPlayer.ReceiveMove(m);
        }

        public enum LightTypeEnum
        {
            None,
            Source,
            Target
        }
    }
}
