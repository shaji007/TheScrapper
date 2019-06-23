﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.ListView;

namespace TheScrapper
{
    public partial class TheScrapperForm : Form
    {
        private static IWebDriver driver;
        private IWebElement SelectedElm;
        bool bFlag;
        private List<string> tags;
        private string SaveMethod;
        private bool bSupport;
        private ListViewItem delItem;
        private int delIndex;

        public TheScrapperForm()
        {
            InitializeComponent();
            OnLoad();
            SaveMethod = "C#";
            bSupport = false;
            delIndex = -1;
        }

        private void OnLoad()
        {
            LvLocators.Columns.Add("Name", 100, HorizontalAlignment.Left);
            LvLocators.Columns.Add("Tag", 60, HorizontalAlignment.Left);
            LvLocators.Columns.Add("L. Type", 60, HorizontalAlignment.Left);
            LvLocators.Columns.Add("Value", 250, HorizontalAlignment.Left);
        }

        private void BtnLaunch_Click(object sender, EventArgs e)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--silent");
            options.AddArgument("disable-infobars");
            options.AddArgument("--allow-file-access");
            options.AddArgument("start-maximized");
            //options.AddAdditionalCapability("useAutomationExtension", "false");
            driver = new ChromeDriver(options);
            driver.Url = "https://www.google.co.in";
            BtnLaunch.Enabled = false;
            BtnFrames.Enabled = true;
        }

        private void BtnFrames_Click(object sender, EventArgs e)
        {
            BtnScrape.Enabled = true;
            TvFrames.Nodes.Clear();
            TreeNode root = TvFrames.Nodes.Add("Main");
            TvFrames.SelectedNode = root;
            TvFrames.Focus();
            IReadOnlyCollection<IWebElement> frames = driver.FindElements(By.TagName("iframe"));
            if(frames != null || frames.Count > 0)
            {
                foreach(var frame in frames)
                {
                    root.Nodes.Add(frame.GetAttribute("src"));
                }
            }
        }

        private void BtnScrape_Click(object sender, EventArgs e)
        {
            if (BtnLaunch.Enabled)
                return;
            if (LvLocators.Items.Count > 0)
                LvLocators.Items.Clear();
            ElementChecker ec = new ElementChecker(driver, driver.PageSource);
            Scrape scrape = new Scrape();
            scrape.ShowDialog();
            if(scrape.DialogResult == DialogResult.OK)
            {
                tags = scrape.GetCheckedItems();
            }
            foreach (var tag in tags)
            {
                IReadOnlyCollection<IWebElement> elms = driver.FindElements(By.TagName(tag));
                foreach (var elm in elms)
                {
                    if (elm.Displayed)
                    {
                        UniqueData ud = ec.CheckUniqueness(new WrappedElement(driver, elm));
                        if (ud.type != null)
                        {
                            ListViewItem item = new ListViewItem();
                            string[] data = { "", tag, ud.type.ToString(), ud.value.ToString() };
                            ListViewItem lvi = new ListViewItem(data);
                            LvLocators.Items.Add(lvi);
                        }
                    }
                }
            }
            //this.TopMost = true;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.SetData(SaveMethod, bSupport);
            settings.ShowDialog();
            if(settings.DialogResult == DialogResult.OK)
            {
                Tuple<string, bool> data = settings.GetData();
                SaveMethod = data.Item1;
                bSupport = data.Item2;
            }
        }

        private void TheScrapperForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (driver != null)
            {
                driver.Close();
                driver.Quit();
            }
        }

        private void LvLocators_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem clickedItem = LvLocators.GetItemAt(e.X, e.Y);
            if(clickedItem != null)
            {
                clickedItem.BeginEdit();
            }
        }

        private void LvLocators_MouseClick(object sender, MouseEventArgs e)
        {

            ListViewItem clickedItem = LvLocators.GetItemAt(e.X, e.Y);
            if(e.Button == MouseButtons.Left)
            {
                if (clickedItem != null)
                {
                    HighlightElement(clickedItem);
                }
            }
            else if(e.Button == MouseButtons.Right)
            {
                delIndex = clickedItem.Index;
                delItem = clickedItem;
                clickedItem.Remove();
            }
        }

        private void LvLocators_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bFlag)
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].setAttribute('style', 'border: none');", SelectedElm);
                bFlag = false;
            }
        }

        private void LvLocators_Leave(object sender, EventArgs e)
        {
            if (bFlag)
            {
                if (SelectedElm.Displayed)
                {
                    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                    js.ExecuteScript("arguments[0].setAttribute('style', 'border: none');", SelectedElm);
                    bFlag = false;
                }
            }
        }

        private void LvLocators_KeyUp(object sender, KeyEventArgs e)
        {
            SelectedListViewItemCollection items = LvLocators.SelectedItems;
            if (e.KeyCode == System.Windows.Forms.Keys.Down)
            {
                if (items.Count == 1)
                {
                    HighlightElement(items[0]);
                }
            }
            else if (e.KeyCode == System.Windows.Forms.Keys.Up)
            {
                if (items.Count == 1)
                {
                    if (items.Count == 1)
                    {
                        HighlightElement(items[0]);
                    }
                }
            }
            else if (e.Control && e.KeyCode == System.Windows.Forms.Keys.Z)
            {
                if (delIndex != -1)
                    LvLocators.Items.Insert(delIndex, delItem);
            }
            else if (e.Control && e.KeyCode == System.Windows.Forms.Keys.Y)
            {
                delIndex = delItem.Index;
                LvLocators.Items.Remove(delItem);
            }
            else if (e.Control && e.KeyCode == System.Windows.Forms.Keys.C)
            {
                string cbText = "";
                if (items.Count == 1)
                {
                    ListViewItem item = items[0];
                    string value = item.SubItems[3].Text;
                    if (String.IsNullOrEmpty(item.SubItems[0].Text))
                    {
                        switch(item.SubItems[2].Text)
                        {
                            case "id":
                                cbText = "#" + value;
                                break;
                            case "name":
                                cbText = "[name='"+ value +"']";
                                break;
                            case "text":
                                cbText = value;
                                break;
                            case "xpath":
                                cbText = value;
                                break;
                            case "class":
                                cbText = "." + value;
                                break;
                        }
                    }
                    else
                    {
                        // Handle language specific locator string
                    }
                    Clipboard.SetText(cbText);
                }
            }
        }

        private void HighlightElement(ListViewItem item)
        {
            string type = item.SubItems[2].Text;
            string value = item.SubItems[3].Text;
            By BySelectedItem = null;
            switch (type.ToLower())
            {
                case "id":
                    BySelectedItem = By.Id(value);
                    break;
                case "name":
                    BySelectedItem = By.Name(value);
                    break;
                case "class":
                    BySelectedItem = By.ClassName(value);
                    break;
                case "css":
                    BySelectedItem = By.CssSelector(value);
                    break;
                case "text":
                    BySelectedItem = By.LinkText(value);
                    break;
                case "xpath":
                    BySelectedItem = By.XPath(value);
                    break;
            }
            SelectedElm = driver.FindElement(BySelectedItem);
            Actions actions = new Actions(driver);
            actions.MoveToElement(SelectedElm);
            actions.Perform();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].setAttribute('style', 'border: 2px solid red;');", SelectedElm);
            bFlag = true;
        }
    }
}
