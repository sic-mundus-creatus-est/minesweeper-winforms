using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Podaci;
using Serijalizacija;

namespace lab5
{
    public partial class MinesweeperForm : Form
    {
        #region ATRIBUTI
        //=======================
        private Igra _game;
        private int _visina;
        private int _sirina;
        private int _brojMina;
        //=======================
        #endregion

        #region KONSTRUKTORI
        public MinesweeperForm()
        {
            InitializeComponent();
            btnStart.FlatStyle = FlatStyle.Popup;
            btnStart.FlatAppearance.BorderSize = 0;

            _visina = 9;
            _sirina = 9;
            _brojMina = 10;

            KreniIspocetka(_visina, _sirina, _brojMina);
        }
        #endregion

        #region DOGADJAJI
        private void btnStart_Click(object sender, EventArgs e)
        {
            KreniIspocetka(_visina, _sirina, _brojMina);

            lblTajmer.Text = _game.Vreme.ToString();
        }

        private void tsmNovaIgra_Click(object sender, EventArgs e)
        {
            KreniIspocetka(_visina, _sirina, _brojMina);

            lblTajmer.Text = _game.Vreme.ToString();
        }

        #region STATS
        private void Tajmer(object sender, EventArgs e)
        {
            lblTajmer.Text = _game.Vreme.ToString();
        }

        private void PreostaloMinaPoSumnjamaIgraca(object sender, EventArgs e)
        {
            lblMine.Text = (_game.Mine - _game.OtkriveneINeotkriveneMine).ToString();
        }
        #endregion

        #region TEZINE_IGRE
        private void tsmPocetnik_Click(object sender, EventArgs e)
        {
            this._visina = 9;
            this._sirina = 9;
            this._brojMina = 10;
            ResizeForm(398, 477);
            KreniIspocetka(_visina, _sirina, _brojMina);
        }

        private void tsmAmater_Click(object sender, EventArgs e)
        {
            //404, 477
            this._visina = 16;
            this._sirina = 16;
            this._brojMina = 40;
            ResizeForm(398, 477);
            KreniIspocetka(_visina, _sirina, _brojMina);
        }

        private void tsmEkspert_Click(object sender, EventArgs e)
        {
            this._visina = 16;
            this._sirina = 30;
            this._brojMina = 99;
            ResizeForm(564, 657);
            KreniIspocetka(_visina, _sirina, _brojMina);
        }

        private void tsmRucnoPodeseno_Click(object sender, EventArgs e)
        {
            var frm = new RucnoPodesavanjeForm(this);
            //frm.Show();
            DialogResult dlg = frm.ShowDialog(); // ne dozvoljava pristup roditeljskoj formi za vreme postojanja

            if (frm.WasOKButtonClicked())
            {
                if (_visina > 16 || _sirina > 16)
                {
                    ResizeForm(564, 657);
                }
                else
                {
                    ResizeForm(404, 477);
                }

                KreniIspocetka(_visina, _sirina, _brojMina);
            }
        }
        #endregion

        #region DOGE
        private void btnStart_MouseDown(object sender, MouseEventArgs e)
        {
            btnStart.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.dogeG));
        }

        private void btnStart_MouseUp(object sender, MouseEventArgs e)
        {
            btnStart.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.doge));
        }

        private void pnlOkvir_MouseDown(object sender, MouseEventArgs e)
        {
            if (!ImageEquals(btnStart.BackgroundImage, Properties.Resources.dogeD))
            {
                btnStart.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.dogeG));
                btnStart.Refresh();
            }
        }

        private void pnlOkvir_MouseUp(object sender, MouseEventArgs e)
        {
            if (!ImageEquals(btnStart.BackgroundImage, Properties.Resources.dogeD))
            {
                btnStart.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.doge));
                btnStart.Refresh();
            }
        }

        private void DogeNakonKrajaIgre(object sender, EventArgs e)
        {
            btnStart.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.dogeD));

            _game.KrajIgreEvent -= DogeNakonKrajaIgre;
        }
        #endregion

        private void tsmZavrsiIgru_Click(object sender, EventArgs e)
        {
            _game.OtkrijSveBombe();
        }

        private void tsmSacuvajTrenutnoStanje_Click(object sender, EventArgs e)
        {
            SacuvajStanje();
        }

        private void tsmUcitaj_Click(object sender, EventArgs e)
        {
            btnStart.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.doge));

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "xml files (*.xml)|*.xml";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Igra tmp = new Igra(pnlOkvir, 9, 9, 10);
                tmp = tmp.Deserialize(ofd.FileName);

                //pnlOkvir.Controls.Add(_game.Panel);

                _game.Visina = tmp.Visina;
                _game.Sirina = tmp.Sirina;
                _game.Mine = tmp.Mine;
                _game.Vreme = tmp.Vreme;
                _game.NeotkrivenihMina = tmp.NeotkrivenihMina;
                _game.OtkrivenihMina = tmp.OtkrivenihMina;
                _game.OtkriveneINeotkriveneMine = tmp.OtkriveneINeotkriveneMine;
                _game.NakonSumnje();

                _game.KrajIgreEvent += DogeNakonKrajaIgre;
                _game.TickEvent += new EventHandler(Tajmer);
                _game.SumnjeEvent += new EventHandler(PreostaloMinaPoSumnjamaIgraca);

                lblTajmer.Text = _game.Vreme.ToString();

                pnlOkvir.Controls.Clear();
                _game.IskopirajPoljaUMatricu(tmp);

                ////pnlOkvir.Controls.Clear();
                //pnlOkvir.Controls.Add(tmp.Panel);

                //_game = tmp;
            }
        }

        #endregion

        #region SVOJSTVA
        public int Visina
        {
            get { return _visina; }
            set { _visina = value; }
        }

        public int Sirina
        {
            get { return _sirina; }
            set { _sirina = value; }
        }

        public int BrojMina
        {
            get { return _brojMina; }
            set { _brojMina = value; }
        }
        #endregion

        #region METODE

        public void KreniIspocetka(int a, int b, int c)
        {
            Cursor.Current = Cursors.WaitCursor;
            _game = new Igra(this.pnlOkvir, a, b, c);
            _game.TickEvent += new EventHandler(Tajmer);
            _game.SumnjeEvent += new EventHandler(PreostaloMinaPoSumnjamaIgraca);
            _game.KrajIgreEvent += DogeNakonKrajaIgre;

            _game.Start();
        }
        private bool ImageEquals(Image image1, Image image2)
        {// Helper metoda za poredjenje slika
            if (image1 == null && image2 == null)
                return true;

            if (image1 == null || image2 == null)
                return false;

            using (MemoryStream ms1 = new MemoryStream())
            using (MemoryStream ms2 = new MemoryStream())
            {
                image1.Save(ms1, image1.RawFormat);
                image2.Save(ms2, image2.RawFormat);
                return ms1.ToArray().SequenceEqual(ms2.ToArray());
            }
        }

        public void SacuvajStanje()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "xml files (*.xml)|*.xml";

            sfd.FileName = "auto.xml";
            // moze da se doda promenljiva koja ce da pamti koliko ima sacuvanih fajlova sa "auto" nickname-om,
            // pa svaki put kada se pokrene program da se ucitava fajl koji sadrzi taj broj i da se append-uje sl. br. na auto

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                _game.Serialize(sfd.FileName);
            }
        }

        #region RESIZE
        private void ResizeForm(int width, int height)
        {
            float scaleX = (float)width / this.ClientSize.Width;
            float scaleY = (float)height / this.ClientSize.Height;

            // Resize and reposition the GroupBox
            gbxStats.Width = (int)(gbxStats.Width * scaleX);
            gbxStats.Height = (int)(gbxStats.Height * scaleY);
            gbxStats.Location = new Point((int)(gbxStats.Location.X * scaleX), (int)(gbxStats.Location.Y * scaleY));

            // Resize and reposition the Button within the GroupBox
            btnStart.Width = (int)(btnStart.Width * scaleX);
            btnStart.Height = (int)(btnStart.Height * scaleY);
            btnStart.Location = new Point((int)(btnStart.Location.X * scaleX), (int)(btnStart.Location.Y * scaleY));

            // Resize and reposition the Panel
            pnlOkvir.Width = (int)(pnlOkvir.Width * scaleX);
            pnlOkvir.Height = (int)(pnlOkvir.Height * scaleY);
            pnlOkvir.Location = new Point((int)(pnlOkvir.Location.X * scaleX), (int)(pnlOkvir.Location.Y * scaleY));

            // Calculate new position and size of lblMine within gbxStats
            lblMine.Width = (int)(lblTajmer.Width * scaleX);
            lblMine.Height = (int)(lblMine.Height * scaleY);
            lblMine.Location = new Point((int)(lblMine.Location.X * scaleX), (int)(lblMine.Location.Y * scaleY));

            // Calculate new position and size of lblTajmer within gbxStats
            lblTajmer.Width = (int)(lblTajmer.Width * scaleX);
            lblTajmer.Height = (int)(lblTajmer.Height * scaleY);
            lblTajmer.Location = new Point((int)(lblTajmer.Location.X * scaleX), (int)(lblTajmer.Location.Y * scaleY));


            // Adjust the form size
            this.ClientSize = new Size(width, height);
        }
        #endregion

        #endregion

    }
}

/*
 GroupBox (gbxStats):
Location (12, 27)
Size (360, 50)

 Button (btnStart):
Location (165, 11)
Size (33, 33)

 Panel (pnlOkvir):
Location (12, 83)
Size (360, 339)

 Labels (lblTajmer and lblMine):
lblMine Location (56, 15)
lblTajmer Location (249, 15)
lblMine Size (56, 23)
lblTajmer Size (56, 23)

 Form size: (404, 477)
 */
