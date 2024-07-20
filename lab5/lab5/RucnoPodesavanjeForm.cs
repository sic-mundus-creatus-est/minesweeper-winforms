using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab5
{
    public partial class RucnoPodesavanjeForm : Form
    {
        #region ATRIBUTI
        //========================================
        private bool okButtonClicked = false;
        private MinesweeperForm _minesweeperForm;
        //========================================
        #endregion

        #region KONSTRUKTORI
        public RucnoPodesavanjeForm(MinesweeperForm forma)
        {
            InitializeComponent();

            this._minesweeperForm = forma;
        }
        #endregion

        #region DOGADJAJI
        private void btnOK_Click(object sender, EventArgs e)
        {

            int visina = (int)nudVisina.Value;
            int sirina = (int)nudSirina.Value;
            int br_mina = (int)nudBrMina.Value;

            if(visina > 24)
            {
                visina = 24;
            }

            if(sirina > 30)
            {
                sirina = 30;
            }

            if(br_mina > (visina-1)*(sirina-1))
            {
                br_mina = (visina - 1) * (sirina - 1);
            }

            _minesweeperForm.Visina = visina;
            _minesweeperForm.Sirina = sirina;
            _minesweeperForm.BrojMina = br_mina;

            okButtonClicked = true;

            this.Close();
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region METODE
        public bool WasOKButtonClicked()
        {
            return okButtonClicked;
        }
        #endregion
    }
}
