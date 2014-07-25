namespace Backgammon2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gRaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nowaGraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graczVsSIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gramBiałymiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gramCzarnymiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dwóchGraczyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.zapiszGręToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wczytajGręToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graczVsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gramBiałymiToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gramCzarnymiToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dwóchGraczyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.zakończGręToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.zamknijProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.oProgramieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GamePanel = new Backgammon2.GameBoard();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gRaToolStripMenuItem,
            this.oProgramieToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(758, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gRaToolStripMenuItem
            // 
            this.gRaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nowaGraToolStripMenuItem,
            this.toolStripMenuItem1,
            this.zapiszGręToolStripMenuItem,
            this.wczytajGręToolStripMenuItem,
            this.toolStripMenuItem2,
            this.zakończGręToolStripMenuItem,
            this.toolStripMenuItem3,
            this.zamknijProgramToolStripMenuItem});
            this.gRaToolStripMenuItem.Name = "gRaToolStripMenuItem";
            this.gRaToolStripMenuItem.Size = new System.Drawing.Size(41, 21);
            this.gRaToolStripMenuItem.Text = "Gra";
            // 
            // nowaGraToolStripMenuItem
            // 
            this.nowaGraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.graczVsSIToolStripMenuItem,
            this.dwóchGraczyToolStripMenuItem});
            this.nowaGraToolStripMenuItem.Name = "nowaGraToolStripMenuItem";
            this.nowaGraToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.nowaGraToolStripMenuItem.Text = "Nowa gra...";
            // 
            // graczVsSIToolStripMenuItem
            // 
            this.graczVsSIToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gramBiałymiToolStripMenuItem,
            this.gramCzarnymiToolStripMenuItem});
            this.graczVsSIToolStripMenuItem.Name = "graczVsSIToolStripMenuItem";
            this.graczVsSIToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.graczVsSIToolStripMenuItem.Text = "Gracz vs. SI";
            // 
            // gramBiałymiToolStripMenuItem
            // 
            this.gramBiałymiToolStripMenuItem.Name = "gramBiałymiToolStripMenuItem";
            this.gramBiałymiToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.gramBiałymiToolStripMenuItem.Text = "Gram białymi";
            this.gramBiałymiToolStripMenuItem.Click += new System.EventHandler(this.gramBiałymiToolStripMenuItem_Click);
            // 
            // gramCzarnymiToolStripMenuItem
            // 
            this.gramCzarnymiToolStripMenuItem.Name = "gramCzarnymiToolStripMenuItem";
            this.gramCzarnymiToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.gramCzarnymiToolStripMenuItem.Text = "Gram czarnymi";
            this.gramCzarnymiToolStripMenuItem.Click += new System.EventHandler(this.gramCzarnymiToolStripMenuItem_Click);
            // 
            // dwóchGraczyToolStripMenuItem
            // 
            this.dwóchGraczyToolStripMenuItem.Name = "dwóchGraczyToolStripMenuItem";
            this.dwóchGraczyToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.dwóchGraczyToolStripMenuItem.Text = "Dwóch graczy";
            this.dwóchGraczyToolStripMenuItem.Click += new System.EventHandler(this.dwóchGraczyToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(204, 6);
            // 
            // zapiszGręToolStripMenuItem
            // 
            this.zapiszGręToolStripMenuItem.Name = "zapiszGręToolStripMenuItem";
            this.zapiszGręToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.zapiszGręToolStripMenuItem.Text = "Zapisz grę";
            this.zapiszGręToolStripMenuItem.Click += new System.EventHandler(this.zapiszGręToolStripMenuItem_Click);
            // 
            // wczytajGręToolStripMenuItem
            // 
            this.wczytajGręToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.graczVsToolStripMenuItem,
            this.dwóchGraczyToolStripMenuItem1});
            this.wczytajGręToolStripMenuItem.Name = "wczytajGręToolStripMenuItem";
            this.wczytajGręToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.wczytajGręToolStripMenuItem.Text = "Wczytaj grę jako...";
            this.wczytajGręToolStripMenuItem.Click += new System.EventHandler(this.wczytajGręToolStripMenuItem_Click);
            // 
            // graczVsToolStripMenuItem
            // 
            this.graczVsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gramBiałymiToolStripMenuItem1,
            this.gramCzarnymiToolStripMenuItem1});
            this.graczVsToolStripMenuItem.Name = "graczVsToolStripMenuItem";
            this.graczVsToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.graczVsToolStripMenuItem.Text = "Gracz vs. SI";
            // 
            // gramBiałymiToolStripMenuItem1
            // 
            this.gramBiałymiToolStripMenuItem1.Name = "gramBiałymiToolStripMenuItem1";
            this.gramBiałymiToolStripMenuItem1.Size = new System.Drawing.Size(182, 22);
            this.gramBiałymiToolStripMenuItem1.Text = "Gram białymi";
            this.gramBiałymiToolStripMenuItem1.Click += new System.EventHandler(this.gramBiałymiToolStripMenuItem1_Click);
            // 
            // gramCzarnymiToolStripMenuItem1
            // 
            this.gramCzarnymiToolStripMenuItem1.Name = "gramCzarnymiToolStripMenuItem1";
            this.gramCzarnymiToolStripMenuItem1.Size = new System.Drawing.Size(182, 22);
            this.gramCzarnymiToolStripMenuItem1.Text = "Gram czarnymi";
            this.gramCzarnymiToolStripMenuItem1.Click += new System.EventHandler(this.gramCzarnymiToolStripMenuItem1_Click);
            // 
            // dwóchGraczyToolStripMenuItem1
            // 
            this.dwóchGraczyToolStripMenuItem1.Name = "dwóchGraczyToolStripMenuItem1";
            this.dwóchGraczyToolStripMenuItem1.Size = new System.Drawing.Size(178, 22);
            this.dwóchGraczyToolStripMenuItem1.Text = "Dwóch graczy";
            this.dwóchGraczyToolStripMenuItem1.Click += new System.EventHandler(this.dwóchGraczyToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(204, 6);
            // 
            // zakończGręToolStripMenuItem
            // 
            this.zakończGręToolStripMenuItem.Name = "zakończGręToolStripMenuItem";
            this.zakończGręToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.zakończGręToolStripMenuItem.Text = "Zakończ grę";
            this.zakończGręToolStripMenuItem.Click += new System.EventHandler(this.zakończGręToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(204, 6);
            // 
            // zamknijProgramToolStripMenuItem
            // 
            this.zamknijProgramToolStripMenuItem.Name = "zamknijProgramToolStripMenuItem";
            this.zamknijProgramToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.zamknijProgramToolStripMenuItem.Text = "Zamknij program";
            this.zamknijProgramToolStripMenuItem.Click += new System.EventHandler(this.zamknijProgramToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(758, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(196, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Rzuć kośćmi";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Zapisy gry|*.sav|Wszystkie pliki|*.*";
            this.openFileDialog1.Title = "Wczytaj grę";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Zapisy gry|*.sav|Wszystkie pliki|*.*";
            this.saveFileDialog1.Title = "Zapisz grę";
            // 
            // oProgramieToolStripMenuItem
            // 
            this.oProgramieToolStripMenuItem.Name = "oProgramieToolStripMenuItem";
            this.oProgramieToolStripMenuItem.Size = new System.Drawing.Size(96, 21);
            this.oProgramieToolStripMenuItem.Text = "O programie";
            this.oProgramieToolStripMenuItem.Click += new System.EventHandler(this.oProgramieToolStripMenuItem_Click);
            // 
            // GamePanel
            // 
            this.GamePanel.Location = new System.Drawing.Point(0, 52);
            this.GamePanel.Name = "GamePanel";
            this.GamePanel.Size = new System.Drawing.Size(750, 600);
            this.GamePanel.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(361, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 17);
            this.label2.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 657);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GamePanel);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Backgammon2 by Andrzej Skalski";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private GameBoard GamePanel;
        private System.Windows.Forms.ToolStripMenuItem gRaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nowaGraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graczVsSIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gramBiałymiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gramCzarnymiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dwóchGraczyToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem zapiszGręToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wczytajGręToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem zakończGręToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem zamknijProgramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graczVsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gramBiałymiToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem gramCzarnymiToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem dwóchGraczyToolStripMenuItem1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem oProgramieToolStripMenuItem;
        private System.Windows.Forms.Label label2;
    }
}

