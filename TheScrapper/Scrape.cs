using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.CheckedListBox;

namespace TheScrapper
{
    public partial class Scrape : Form
    {
        public Scrape()
        {
            InitializeComponent();
            LoadListBoxContent();
        }

        public void LoadListBoxContent()
        {
            clbScrape.Items.Add("a");
            clbScrape.Items.Add("input");
            clbScrape.Items.Add("div");
            clbScrape.Items.Add("label");
            clbScrape.Items.Add("span");
            clbScrape.Items.Add("img");
            clbScrape.Items.Add("button");
            clbScrape.Items.Add("select");
            clbScrape.Items.Add("ul");
            clbScrape.Items.Add("table");
        }

        public List<string> GetCheckedItems()
        {
            List<string> checkedItem = new List<string>();
            CheckedItemCollection col = clbScrape.CheckedItems;
            foreach(var item in col)
            {
                checkedItem.Add(item.ToString());
            }
            return checkedItem;
        }

        private void Scrape_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
