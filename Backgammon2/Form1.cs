using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

using System.IO;

namespace Backgammon2
{
    public partial class Form1 : Form, IGameControllerEvent
    {
        private GameStateController Game;
        private HumanPlayer CurrentPlayer;

        public Form1()
        {
            InitializeComponent();
            Game = null;
        }

        private void dwóchGraczyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenGame(new GameStateController(new HumanPlayer(PColor.White, this),
                new HumanPlayer(PColor.Black, this)));
        }

        private void OpenGame(GameStateController theGame)
        {
            Game = theGame;
            Game.Listeners.Add(this);
            Game.CallOnGamestateUpdate();
        }

        public void EnableRoll(HumanPlayer p)
        {
            CurrentPlayer = p;
            button1.Enabled = true;
        }

        public void DisableRoll()
        {
            //CurrentPlayer = null;
            button1.Enabled = false;
        }

        public void EnableInputFor(HumanPlayer p)
        {
            GamePanel.EnableInputFor(p);
        }
        
        public void OnGamestateUpdate()
        {
            if (Game.GameState.CurTurn == PColor.White)
                label1.Text = "Ruch gracza białego.";
            else label1.Text = "Ruch gracza czarnego.";

            GamePanel.DrawScene = Game.GetScene();

            int l2 = Game.GameState.PlayerNeeds(Game.GameState.CurTurn);

            if (l2 != -1)
            {
                label2.Text = "Potrzebujesz " + l2.ToString() + " oczek by zakończyć grę.";
            }
            else
            {
                label2.Text = "Wprowadź zbite kamienie do gry.";
            }


            GamePanel.Invalidate();
        }

        public void OnGameEnd()
        {
            String s = "Gra zakończona zwycięstwem gracza o kolorze ";
            if(Game.GameState.Winner == PColor.Black)
                s = s + "czarnym.";
            else s = s + "białym.";
            ShowMessage(s);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DisableRoll();
            MoveResult res = Game.RollTheDice(CurrentPlayer);
            if (res.Result == MoveResult.ResultType.Negative)
            {
                MessageBox.Show("Nie udało się rzucić, z powodu: " + res.Description);
            }            
        }

        public void ShowMessage(string s)
        {
            MessageBox.Show(s);
        }

        private void gramBiałymiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenGame(new GameStateController(new HumanPlayer(PColor.White, this), new AIPlayer(PColor.Black)));
        }

        private void gramCzarnymiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenGame(new GameStateController(new AIPlayer(PColor.White), new HumanPlayer(PColor.Black, this)));
        }

        private void StopGame()
        {
            Game = null;
            CurrentPlayer = null;
            GamePanel.DrawScene = null;
            GamePanel.Invalidate();
            label1.Text = "";
            button1.Enabled = false;
            label2.Text = "";
        }

        private void zakończGręToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopGame();
        }

        private void zamknijProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveToFile(GameState gs, string filename)
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fStream = new FileStream(filename, FileMode.Create,
                FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, gs);
            }
        }

        private void zapiszGręToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Game != null)
            {
                SaveFileDialog sd = saveFileDialog1;
                if (sd.ShowDialog() == DialogResult.OK)
                    SaveToFile(Game.GameState, sd.FileName);
            }
            else
                MessageBox.Show("Nie można zapisać gry, ponieważ ta nie została rozpoczęta.");

        }

        private GameState LoadFromFile(string filename)
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fStream = new FileStream(filename, FileMode.Open,
                FileAccess.Read, FileShare.None))
            {
                try
                {
                    GameState gs = (GameState)binFormat.Deserialize(fStream);
                    return gs;
                }
                catch (System.Runtime.Serialization.SerializationException e)
                {
                    ShowMessage("Nie można czytać z pliku źródłowego - nie zawiera poprawnego zapisu stanu gry.");
                    return null;
                }
            }
        }

        private GameState LoadFromUser()
        {
            OpenFileDialog od = openFileDialog1;
            if (od.ShowDialog() == DialogResult.OK)
            {
                return LoadFromFile(od.FileName);
            }
            return null;
        }

        private void wczytajGręToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dwóchGraczyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GameState gs = LoadFromUser();
            if (gs == null) return;
            StopGame();
            OpenGame(new GameStateController(new HumanPlayer(PColor.White, this),
                new HumanPlayer(PColor.Black, this), gs));
        }

        private void gramBiałymiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GameState gs = LoadFromUser();
            if (gs == null) return;
            StopGame();
            OpenGame(new GameStateController(new HumanPlayer(PColor.White, this),
                new AIPlayer(PColor.Black), gs));
        }

        private void gramCzarnymiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GameState gs = LoadFromUser();
            if (gs == null) return;
            StopGame();
            OpenGame(new GameStateController(new AIPlayer(PColor.White),
                new HumanPlayer(PColor.Black, this), gs));
        }

        private void oProgramieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox x = new AboutBox();            
            x.Show();
        }
    }
}

