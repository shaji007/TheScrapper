using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListView;

namespace TheScrapper.Save
{
    public abstract class Save
    {
        protected string pagename;
        private string path;
        private string content;
        protected ListViewItemCollection lvCol;
        protected TreeNodeCollection tvcol;
        protected Save(string pagename, ref ListView lv, ref TreeView tv )
        {
            path = ConfigurationManager.AppSettings["SavePath"].ToString();
            if(String.IsNullOrEmpty(path))
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }
            path = Path.Combine(path, "TheScrapper");
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            this.pagename = pagename;
            lvCol = lv.Items;
            tvcol = tv.Nodes;
            content = Prepare();
        }

        protected abstract string Prepare();
        public void SaveFile(string extension)
        {
            string filetype = "";
            SaveFileDialog sfd = new SaveFileDialog();
            switch(extension)
            {
                case "xml":
                    filetype = "XML";
                    break;
                case "c#":
                    filetype = "C-Sharp";
                    break;
                case "java":
                    filetype = "JAVA";
                    break;
            }
            sfd.Filter = filetype + "|*." + extension;
            sfd.Title = "Save a " + filetype + "file";
            sfd.InitialDirectory = path;
            sfd.FileName = pagename;
            sfd.ShowDialog();
            if(sfd.FileName != "")
            {
                FileStream fs = (FileStream)sfd.OpenFile();
                Byte[] data = new UTF8Encoding(true).GetBytes(content);
                fs.Write(data, 0, data.Length);
            }
            MessageBox.Show("File of type " + filetype + " Saved");
        }
    }
}
