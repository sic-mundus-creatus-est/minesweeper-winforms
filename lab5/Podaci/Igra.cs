using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Media;

namespace Podaci
{
	[XmlRoot("Igra")]
	[Serializable]
	public class Igra
    {
		#region ATRIBUTI
		//=============================================================================================
		public event EventHandler KrajIgreEvent;
		public event EventHandler SumnjeEvent;
		public event EventHandler TickEvent;

		private int _mine;
		private int _otkrivenihMina; // mine koje su zaista ispod polja sa zastavicama
		private int _neotkrivenihMina; // polja na koja su stavljene zastavice, ali ne sadrze mine

		private Panel _panel;

		private Polje[,] _polja;

		private Timer _tajmer;

		private int _visina;
		private int _sirina;

		private int _vreme;
		//=============================================================================================
		#endregion

		#region KONSTRUKTORI
		public Igra() { }
        public Igra(Panel panel, int width, int height, int mines)
		{
			_panel = panel;
			_sirina = width;
			_visina = height;
			_mine = mines;
		}

		public void setPanel(Panel panel)
        {
			_panel = panel;
        }
		#endregion

		#region SVOJSTVA

		//[XmlElementAttribute("Panel")]
		public Panel Panel
		{
			get { return (this._panel); }
			//set { this._panel = value; }
		}

		[XmlElementAttribute("Visina")]
		public int Visina
		{
			get { return (this._visina); }
			set { this._visina = value; }
		}
		[XmlElementAttribute("Sirina")]
		public int Sirina
		{
			get { return (this._sirina); }
			set { this._sirina = value; }
		}

		[XmlElementAttribute("Mine")]
		public int Mine
		{
			get { return (this._mine); }
			set { this._mine = value; }
		}

		[XmlElementAttribute("OtkrivenihMina")]
		public int OtkrivenihMina
        {
			get { return _otkrivenihMina; }
			set { _otkrivenihMina = value; }
        }

		[XmlElementAttribute("NeotkrivenihMina")]
		public int NeotkrivenihMina
        {
			get { return _neotkrivenihMina; }
			set { _neotkrivenihMina = value; }
        }

		[XmlElementAttribute("OtkriveneINeotkriveneMine")]
		public int OtkriveneINeotkriveneMine
		{
			get { return _otkrivenihMina + _neotkrivenihMina; }
			set { _otkrivenihMina = value; }
		}

		[XmlElementAttribute("Vreme")]
		public int Vreme
        {
			get { return _vreme;}
			set { _vreme = value; }
        }

		public Timer Tajmer
		{
			get { return _tajmer; }
		}

		public Polje[][] Polja
		{
			get
			{
				int width = _polja.GetLength(0);
				int height = _polja.GetLength(1);
				Polje[][] serializedArray = new Polje[width][];
				for (int i = 0; i < width; i++)
				{
					serializedArray[i] = new Polje[height];
					for (int j = 0; j < height; j++)
					{
						serializedArray[i][j] = _polja[i, j];
					}
				}
				return serializedArray;
			}
			set
			{
				int width = value.GetLength(0);
				int height = value[0].GetLength(0);
				_polja = new Polje[width, height];
				for (int i = 0; i < width; i++)
				{
					for (int j = 0; j < height; j++)
					{
						_polja[i, j] = value[i][j];
					}
				}
			}
		}
		#endregion

		#region TAJMER
		protected void TickUpdate()
		{
			if (TickEvent != null)
			{
				TickEvent(this, new EventArgs());
			}
		}

		private void TajmerTick(object sender, EventArgs e)
		{
			_vreme++;
			TickUpdate();
		}

		public void PokreniTajmer()
		{
			_tajmer = new Timer();
			_tajmer.Interval = 1000; // 1000ms = 1s
			_tajmer.Tick += new EventHandler(TajmerTick);
			_tajmer.Enabled = true;
		}
		#endregion

		#region DOGADJAJI
		public void NakonSumnje()
		{
			if (SumnjeEvent != null)
			{
				SumnjeEvent(this, new EventArgs());
			}
		}

		private void Eksplozija(object sender, EventArgs e)
		{
			OtkrijSveBombe();
		}

		private void KrajIgre()
		{// sluzi samo da obavesti formu da promeni sliku doge-a u dead
			KrajIgreEvent?.Invoke(this, EventArgs.Empty);
		}
		#endregion

		#region METODE
		public void Start()
		{

			//Panel.SuspendLayout();
			_vreme = 0;
			_otkrivenihMina = 0;
			_neotkrivenihMina = 0;

			Panel.Enabled = true;
			Panel.Controls.Clear();

			//======================================================
			// PRAVLJENJE POLJA
			_polja = new Polje[Sirina, Visina];
			for (int x = 0; x < Sirina; x++)
			{
				for (int y = 0; y < Visina; y++)
				{
					Polje s = new Polje(this, x, y);

					//----------------------------------------------
					// dodela/subscription eventima
					s.Eksplozija += new EventHandler(Eksplozija);
					s.Provera += new EventHandler(JelTacnaSumnja);
					//----------------------------------------------

					_polja[x, y] = s;
				}
			}
			//======================================================

			//======================================================
			// POSTAVLJANJE MINA
			int br_mina = 0;
			Random r = new Random();
			while (br_mina < Mine)
			{
				int x = r.Next(Sirina);
				int y = r.Next(Visina);

				Polje s = _polja[x, y];

				if (!s.SadrziMinu)
				{// ako mina vec nije dodeljena polju, dodeli je
					s.SadrziMinu = true;
					br_mina++;
				}
			}
			//======================================================

			NakonSumnje(); // da bi counter mina u formi dobio br. mina


			//PokreniTajmer();

		}

		public void OtkrijPoljeNaKoord(int x, int y)
		{
			if (x >= 0 && x < Sirina)
			{
				if (y >= 0 && y < Visina)
				{
					_polja[x, y].Otkrij();
				}
			}
		}

		public bool JelMina(int x, int y)
		{
			if (x >= 0 && x < Sirina)
			{
				if (y >= 0 && y < Visina)
				{
					return _polja[x, y].SadrziMinu;
				}
			}

			return false; // van opsega
		}

		private void JelTacnaSumnja(object sender, EventArgs e)
		{
			Polje s = (Polje)sender;
			if (s.Sumnja && s.PovucenaBiloKakvaSumnja==false)
			{
				if (s.SadrziMinu)
				{
					_otkrivenihMina++;
				}
				else
				{
					_neotkrivenihMina++;
				}
			}
			else if (!s.Sumnja && s.PovucenaBiloKakvaSumnja == false)
			{
				if (s.SadrziMinu)
				{
					_otkrivenihMina--;
				}
				else
				{
					_neotkrivenihMina--;
				}
			}

			NakonSumnje(); // update

			if (_otkrivenihMina == Mine && OtkriveneINeotkriveneMine == Mine)
			{
				SystemSounds.Asterisk.Play();

				MessageBox.Show("Čestitamo! Pobedio si!");
				_tajmer.Enabled = false;
				Panel.Enabled = false;
			}
		}

		public void OtkrijSveBombe()
        {
			//Panel.Enabled = false;
			if (_tajmer != null)
			{
				_tajmer.Enabled = false;
			}

			KrajIgre();

			foreach (Polje s in _polja)
			{
				s.Otkrij();
				s.UkloniAkcije();
				if (s.SadrziMinu)
				{
					//s.PoljeValue.Text = "*";
					s.PoljeValue.Text = "";
					string imageFilePath = "evildoge.png";
					try
					{
						s.PoljeValue.BackgroundImageLayout = ImageLayout.Zoom;
						string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, imageFilePath);
						s.PoljeValue.BackgroundImage = Image.FromFile(fullPath);
					}
					catch (Exception ex)
					{
						Console.WriteLine("Error loading image: " + ex.Message);
					}
					s.PoljeValue.Font = new System.Drawing.Font("Arial Black", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
					s.PoljeValue.ForeColor = Color.Black;

				}
				//				if (!s.Sumnja && s.SadrziMinu && s != sender) {
				//
				//					s.PoljeValue.BackColor = Color.Orange;
				//				}
			}

			MessageBox.Show("Boom! Igra je završena.");
		}
        #endregion

        #region ZA_DESERIJALIZACIJU
        public void IskopirajPoljaUMatricu(Igra tmp)
		{
			int width = tmp.Polja.Length;
			int height = tmp.Polja[0].Length;
			this._polja = new Polje[width, height];

			for (int i = 0; i < width; i++)
			{
				for (int j = 0; j < height; j++)
				{
					Polje poljeTmp = tmp.Polja[i][j];
					Polje poljeGame = new Polje(this, poljeTmp.X, poljeTmp.Y);

					poljeGame.SadrziMinu = poljeTmp.SadrziMinu;
					poljeGame.Otkriveno = poljeTmp.Otkriveno;
					poljeGame.Sumnja = poljeTmp.Sumnja;
					poljeGame.PovucenaBiloKakvaSumnja = poljeTmp.PovucenaBiloKakvaSumnja;
					poljeGame.PoljeValue.Text = poljeTmp.PoljeValue.Text;
					poljeGame.PoljeValue.BackColor = poljeTmp.PoljeValue.BackColor;

					if (poljeGame.Otkriveno)
					{
						poljeGame.PoljeValue.Text = poljeTmp.PoljeValue.Text;
						if(int.TryParse(poljeGame.PoljeValue.Text, out int number))
                        {
							poljeGame.PoljeValue.BackColor = Color.SeaGreen;

						    switch (number)
							{
								case 1:
									poljeGame.PoljeValue.ForeColor = Color.Blue;
									break;
								case 2:
									poljeGame.PoljeValue.ForeColor = Color.LimeGreen;
									break;
								case 3:
									poljeGame.PoljeValue.ForeColor = Color.Red;
									break;
								case 4:
									poljeGame.PoljeValue.ForeColor = Color.DarkBlue;
									break;
								case 5:
									poljeGame.PoljeValue.ForeColor = Color.DarkRed;
									break;
								case 6:
									poljeGame.PoljeValue.ForeColor = Color.LightBlue;
									break;
								case 7:
									poljeGame.PoljeValue.ForeColor = Color.Orange;
									break;
								case 8:
									poljeGame.PoljeValue.ForeColor = Color.Ivory;
									break;
							}
							
						}
						else if(poljeGame.PoljeValue.Text == "")
                        {
							poljeGame.PoljeValue.BackColor = Color.Tan;
						}
					}
					else if(!poljeGame.Otkriveno)
                    {
						poljeGame.PoljeValue.BackColor = Color.SeaGreen;
                    }

					if(poljeGame.Sumnja)
                    {
						poljeGame.PoljeValue.Text = "";
						string imageFilePath = "flag.png";
						try
						{
							poljeGame.PoljeValue.BackgroundImageLayout = ImageLayout.Zoom;
							string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, imageFilePath);
							poljeGame.PoljeValue.BackgroundImage = Image.FromFile(fullPath);
						}
						catch (Exception ex)
						{
							Console.WriteLine("Error loading image: " + ex.Message);
						}

						poljeGame.PoljeValue.BackColor = Color.DarkGreen;
					}

					poljeGame.Eksplozija += new EventHandler(Eksplozija);
					poljeGame.Provera += new EventHandler(JelTacnaSumnja);
					this._polja[i, j] = poljeGame;
					this._panel.Controls.Add(poljeGame.PoljeValue);
				}
			}
		}
		#endregion
	}
}
