using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace Podaci
{
	[Serializable]
    public class Polje
    {
		#region ATRIBUTI
		//======================================
		public event EventHandler Provera;
		public event EventHandler Eksplozija;

		private Igra _igra;
		private Button _polje;

		private bool _sumnja = false;
		private bool _sadrziMinu = false;
		private bool _otkriveno = false;
		private bool _povucenaBiloKakvaSumnja = false;

		private int _x;
		private int _y;
		//======================================
		#endregion

		#region KONSTRUKTORI
		public Polje() { _polje = new Button(); }
        public Polje(Igra game, int x, int y)
		{
			_igra = game;
			_x = x;
			_y = y;
			_polje = new Button();
			PoljeValue.Text = "";

			int w = _igra.Panel.Width / _igra.Sirina;
			int h = _igra.Panel.Height / _igra.Visina;

			_polje.Width = w + 1;
			_polje.Height = h + 1;
			_polje.Left = w * X;
			_polje.Top = h * Y;
			_polje.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			_polje.Click += new EventHandler(Click);
			_polje.MouseDown += new MouseEventHandler(StaviZastavicuIliZnakPitanjaClick);

			PoljeValue.FlatStyle = FlatStyle.Flat;

			_igra.Panel.Controls.Add(PoljeValue);
		}
		#endregion

		#region SVOJSTVA

		public int X
		{
			get { return (this._x); }
			set { this._x = value; }
		}

		public int Y
		{
			get { return (this._y); }
			set { this._y = value; }
		}

		public bool Sumnja
		{
			get { return (this._sumnja); }
			set { this._sumnja = value; }
		}

		public bool SadrziMinu
		{
			get { return (this._sadrziMinu); }
			set { this._sadrziMinu = value; }
		}

		public bool Otkriveno
		{
			get { return (this._otkriveno); }
			set { this._otkriveno = value; }
		}

		public Button PoljeValue
		{
			get { return (this._polje); }
		}

		public String PoljeString
        {
			get { return (this._polje.Text.ToString()); }
			set { this._polje.Text = value; }
        }

		public bool PovucenaBiloKakvaSumnja
        {
			get { return _povucenaBiloKakvaSumnja; }
			set { _povucenaBiloKakvaSumnja = value; }
        }

		public Color BackgroundColor
		{
			get { return _polje.BackColor; }
			set { _polje.BackColor = value; }
		}
        #endregion

        #region DOGADJAJI
        private void Click(object sender, System.EventArgs e)
		{
			if (_igra.Tajmer == null)
			{
				_igra.PokreniTajmer();
			}
			if (!Sumnja)
			{// ako se ne sumnja
				if (SadrziMinu)
				{// ako je pogodjeno polje sa minom
					PoljeValue.BackColor = Color.Red;
					UpdateNakonEksplozije();
				}
				else
				{// u suprotnom se otkriva/ju polje/a
					this.Otkrij();
				}
			}
		}

		private void StaviZastavicuIliZnakPitanjaClick(object sender, MouseEventArgs e)
		{
			if (!Otkriveno && e.Button == MouseButtons.Right)
			{
				if (Sumnja)
				{// nesigurno, mozda => [?]
					_povucenaBiloKakvaSumnja = false;
					_sumnja = false;
					PoljeValue.BackColor = Color.SeaGreen;
					this.PoljeValue.BackgroundImage = null;
					PoljeValue.Text = "?";
				}
				else if(!Sumnja && PoljeValue.Text != "?")
				{// pretpostavka da je ovde => [zastavica]
					_povucenaBiloKakvaSumnja = false;
					_sumnja = true;

					this.PoljeValue.Text = "";
					string imageFilePath = "flag.png";
					try
					{
						this.PoljeValue.BackgroundImageLayout = ImageLayout.Zoom;
						string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, imageFilePath);
						this.PoljeValue.BackgroundImage = Image.FromFile(fullPath);
					}
					catch (Exception ex)
					{
						Console.WriteLine("Error loading image: " + ex.Message);
					}

					PoljeValue.BackColor = Color.DarkGreen;
				}
                else
                {// povlacenje sumnji
					_povucenaBiloKakvaSumnja = true;
					_sumnja = false;
					PoljeValue.Text = "";
					PoljeValue.BackColor = Color.SeaGreen;
				}

				UpdateNakonProvere();
			}
		}

		protected void UpdateNakonProvere()
		{
			if (Provera != null)
			{
				Provera(this, new EventArgs());
			}
		}

		protected void UpdateNakonEksplozije()
		{
			if (Eksplozija != null)
			{
				Eksplozija(this, new EventArgs());
			}
		}

		public void UkloniAkcije()
		{// nakon eksplozije se uklanjaju akcije/dogadjaji svim poljima
			_polje.Click -= new EventHandler(Click);
			_polje.MouseDown -= new MouseEventHandler(StaviZastavicuIliZnakPitanjaClick);
		}
		#endregion

		public void Otkrij()
		{
			if (!Otkriveno && !Sumnja)
			{// ukoliko polje nije otkriveno i ukoliko se ne sumnja (nije postaljena zastavica)
				_otkriveno = true;

				// BROJANJE OKOLNIH MINA
				int c = 0;
				if (_igra.JelMina(X - 1, Y - 1)) c++;
				if (_igra.JelMina(X - 0, Y - 1)) c++;
				if (_igra.JelMina(X + 1, Y - 1)) c++;
				if (_igra.JelMina(X - 1, Y - 0)) c++;
				if (_igra.JelMina(X - 0, Y - 0)) c++;
				if (_igra.JelMina(X + 1, Y - 0)) c++;
				if (_igra.JelMina(X - 1, Y + 1)) c++;
				if (_igra.JelMina(X - 0, Y + 1)) c++;
				if (_igra.JelMina(X + 1, Y + 1)) c++;

				if (c > 0)
				{// ako je pogodjeno polje sa minama u okolini
					PoljeValue.Text = c.ToString();
					switch (c)
					{
						case 1:
							PoljeValue.ForeColor = Color.Blue;
							break;
						case 2:
							PoljeValue.ForeColor = Color.LimeGreen;
							break;
						case 3:
							PoljeValue.ForeColor = Color.Red;
							break;
						case 4:
							PoljeValue.ForeColor = Color.DarkBlue;
							break;
						case 5:
							PoljeValue.ForeColor = Color.DarkRed;
							break;
						case 6:
							PoljeValue.ForeColor = Color.LightBlue;
							break;
						case 7:
							PoljeValue.ForeColor = Color.Orange;
							break;
						case 8:
							PoljeValue.ForeColor = Color.Ivory;
							break;
					}
				}
				else
				{// ako je pogodjeno prazno polje, otvori sva prazna polja u okolini do cifara
				 //PoljeValue.BackColor = SystemColors.ControlLight;
					PoljeValue.BackColor = Color.Tan;
					PoljeValue.FlatStyle = FlatStyle.Flat;
					PoljeValue.Enabled = false;

					_igra.OtkrijPoljeNaKoord(X - 1, Y - 1);
					_igra.OtkrijPoljeNaKoord(X - 0, Y - 1);
					_igra.OtkrijPoljeNaKoord(X + 1, Y - 1);
					_igra.OtkrijPoljeNaKoord(X - 1, Y - 0);
					_igra.OtkrijPoljeNaKoord(X - 0, Y - 0);
					_igra.OtkrijPoljeNaKoord(X + 1, Y - 0);
					_igra.OtkrijPoljeNaKoord(X - 1, Y + 1);
					_igra.OtkrijPoljeNaKoord(X - 0, Y + 1);
					_igra.OtkrijPoljeNaKoord(X + 1, Y + 1);
				}
			}
		}

	}
}
