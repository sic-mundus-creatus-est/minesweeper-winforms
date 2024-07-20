namespace lab5
{
    partial class MinesweeperForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MinesweeperForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmIgra = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmNovaIgra = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmPocetnik = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAmater = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEkspert = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRucnoPodeseno = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSacuvajTrenutnoStanje = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmUcitaj = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmZavrsiIgru = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlOkvir = new System.Windows.Forms.Panel();
            this.lblMine = new System.Windows.Forms.Label();
            this.lblTajmer = new System.Windows.Forms.Label();
            this.gbxStats = new System.Windows.Forms.GroupBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.gbxStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Cornsilk;
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmIgra,
            this.toolStripMenuItem2,
            this.tsmSacuvajTrenutnoStanje,
            this.tsmUcitaj,
            this.toolStripMenuItem1,
            this.tsmZavrsiIgru});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(384, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmIgra
            // 
            this.tsmIgra.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmNovaIgra,
            this.toolStripSeparator1,
            this.tsmPocetnik,
            this.tsmAmater,
            this.tsmEkspert,
            this.tsmRucnoPodeseno,
            this.toolStripSeparator2});
            this.tsmIgra.Name = "tsmIgra";
            this.tsmIgra.Size = new System.Drawing.Size(53, 20);
            this.tsmIgra.Text = "Opcije";
            // 
            // tsmNovaIgra
            // 
            this.tsmNovaIgra.Name = "tsmNovaIgra";
            this.tsmNovaIgra.Size = new System.Drawing.Size(180, 22);
            this.tsmNovaIgra.Text = "Nova Igra";
            this.tsmNovaIgra.Click += new System.EventHandler(this.tsmNovaIgra_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // tsmPocetnik
            // 
            this.tsmPocetnik.Name = "tsmPocetnik";
            this.tsmPocetnik.Size = new System.Drawing.Size(180, 22);
            this.tsmPocetnik.Text = "Pocetnik";
            this.tsmPocetnik.Click += new System.EventHandler(this.tsmPocetnik_Click);
            // 
            // tsmAmater
            // 
            this.tsmAmater.Name = "tsmAmater";
            this.tsmAmater.Size = new System.Drawing.Size(180, 22);
            this.tsmAmater.Text = "Amater";
            this.tsmAmater.Click += new System.EventHandler(this.tsmAmater_Click);
            // 
            // tsmEkspert
            // 
            this.tsmEkspert.Name = "tsmEkspert";
            this.tsmEkspert.Size = new System.Drawing.Size(180, 22);
            this.tsmEkspert.Text = "Ekspert";
            this.tsmEkspert.Click += new System.EventHandler(this.tsmEkspert_Click);
            // 
            // tsmRucnoPodeseno
            // 
            this.tsmRucnoPodeseno.Name = "tsmRucnoPodeseno";
            this.tsmRucnoPodeseno.Size = new System.Drawing.Size(180, 22);
            this.tsmRucnoPodeseno.Text = "Rucno Podešeno";
            this.tsmRucnoPodeseno.Click += new System.EventHandler(this.tsmRucnoPodeseno_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Enabled = false;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(22, 20);
            this.toolStripMenuItem2.Text = "|";
            // 
            // tsmSacuvajTrenutnoStanje
            // 
            this.tsmSacuvajTrenutnoStanje.Name = "tsmSacuvajTrenutnoStanje";
            this.tsmSacuvajTrenutnoStanje.Size = new System.Drawing.Size(144, 20);
            this.tsmSacuvajTrenutnoStanje.Text = "Sačuvaj Trenutno Stanje";
            this.tsmSacuvajTrenutnoStanje.Click += new System.EventHandler(this.tsmSacuvajTrenutnoStanje_Click);
            // 
            // tsmUcitaj
            // 
            this.tsmUcitaj.Name = "tsmUcitaj";
            this.tsmUcitaj.Size = new System.Drawing.Size(49, 20);
            this.tsmUcitaj.Text = "Učitaj";
            this.tsmUcitaj.Click += new System.EventHandler(this.tsmUcitaj_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Enabled = false;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(22, 20);
            this.toolStripMenuItem1.Text = "|";
            // 
            // tsmZavrsiIgru
            // 
            this.tsmZavrsiIgru.Name = "tsmZavrsiIgru";
            this.tsmZavrsiIgru.Size = new System.Drawing.Size(74, 20);
            this.tsmZavrsiIgru.Text = "Završi Igru";
            this.tsmZavrsiIgru.Click += new System.EventHandler(this.tsmZavrsiIgru_Click);
            // 
            // pnlOkvir
            // 
            this.pnlOkvir.BackColor = System.Drawing.Color.SeaGreen;
            this.pnlOkvir.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlOkvir.Cursor = System.Windows.Forms.Cursors.Help;
            this.pnlOkvir.Location = new System.Drawing.Point(12, 83);
            this.pnlOkvir.Name = "pnlOkvir";
            this.pnlOkvir.Size = new System.Drawing.Size(360, 339);
            this.pnlOkvir.TabIndex = 1;
            this.pnlOkvir.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlOkvir_MouseDown);
            this.pnlOkvir.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlOkvir_MouseUp);
            // 
            // lblMine
            // 
            this.lblMine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMine.BackColor = System.Drawing.Color.Black;
            this.lblMine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMine.Cursor = System.Windows.Forms.Cursors.Cross;
            this.lblMine.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblMine.ForeColor = System.Drawing.Color.Red;
            this.lblMine.Location = new System.Drawing.Point(56, 15);
            this.lblMine.Name = "lblMine";
            this.lblMine.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblMine.Size = new System.Drawing.Size(56, 23);
            this.lblMine.TabIndex = 3;
            this.lblMine.Text = "0";
            this.lblMine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTajmer
            // 
            this.lblTajmer.BackColor = System.Drawing.Color.Black;
            this.lblTajmer.Cursor = System.Windows.Forms.Cursors.Cross;
            this.lblTajmer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTajmer.ForeColor = System.Drawing.Color.Red;
            this.lblTajmer.Location = new System.Drawing.Point(249, 15);
            this.lblTajmer.Name = "lblTajmer";
            this.lblTajmer.Size = new System.Drawing.Size(56, 23);
            this.lblTajmer.TabIndex = 4;
            this.lblTajmer.Text = "0";
            this.lblTajmer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbxStats
            // 
            this.gbxStats.BackColor = System.Drawing.Color.Cornsilk;
            this.gbxStats.Controls.Add(this.btnStart);
            this.gbxStats.Controls.Add(this.lblMine);
            this.gbxStats.Controls.Add(this.lblTajmer);
            this.gbxStats.Cursor = System.Windows.Forms.Cursors.NoMove2D;
            this.gbxStats.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gbxStats.Location = new System.Drawing.Point(12, 27);
            this.gbxStats.Name = "gbxStats";
            this.gbxStats.Size = new System.Drawing.Size(360, 50);
            this.gbxStats.TabIndex = 5;
            this.gbxStats.TabStop = false;
            // 
            // btnStart
            // 
            this.btnStart.BackgroundImage = global::lab5.Properties.Resources.doge;
            this.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStart.Location = new System.Drawing.Point(165, 11);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(33, 33);
            this.btnStart.TabIndex = 2;
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            this.btnStart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnStart_MouseDown);
            this.btnStart.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnStart_MouseUp);
            // 
            // MinesweeperForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(384, 434);
            this.Controls.Add(this.gbxStats);
            this.Controls.Add(this.pnlOkvir);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MinesweeperForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Minesweeper";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbxStats.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmIgra;
        private System.Windows.Forms.ToolStripMenuItem tsmNovaIgra;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmPocetnik;
        private System.Windows.Forms.ToolStripMenuItem tsmAmater;
        private System.Windows.Forms.ToolStripMenuItem tsmEkspert;
        private System.Windows.Forms.ToolStripMenuItem tsmRucnoPodeseno;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Label lblMine;
        private System.Windows.Forms.Label lblTajmer;
        private System.Windows.Forms.GroupBox gbxStats;
        public System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ToolStripMenuItem tsmZavrsiIgru;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem tsmSacuvajTrenutnoStanje;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmUcitaj;
        public System.Windows.Forms.Panel pnlOkvir;
    }
}

