using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace TheScrapper.Save
{
    public class SaveAsXml : Save
    {
        public SaveAsXml(string pagename, ref ListView lv, ref TreeView tv) : base(pagename, ref lv, ref tv) { }

        protected override string Prepare()
        {
            List<XElement> elms = new List<XElement>();
            foreach(ListViewItem item in lvCol)
            {
                elms.Add(new XElement("object", new XAttribute("variablename", item.SubItems[0].Text), new XAttribute("findby", item.SubItems[2].Text), new XText(item.SubItems[3].Text)));
            }

            //foreach(TreeNode nodes in tvcol)
            //{
            //    elms.Add(new XElement("object", new XAttribute("framename", ""), new XAttribute("findby", "xpath")))
            //}
            var root = new XElement("objRepo", new XElement("pageTitle", new XAttribute("name", pagename), elms.ToArray()));
            return root.ToString();
        }
    }
}
 