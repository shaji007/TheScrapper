using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheScrapper
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        public void SetData(string SaveMethod, bool Support)
        {
            CbSaveMethod.SelectedItem = SaveMethod;
            ChkbSupport.Checked = Support;
        }

        private void BtnSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnSettings_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        public Tuple<string, bool> GetData()
        {
            return new Tuple<string, bool>(CbSaveMethod.GetItemText(CbSaveMethod.SelectedItem), ChkbSupport.Checked);
        }
    }
}
