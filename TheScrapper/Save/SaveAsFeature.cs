using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheScrapper.Save
{
    public class SaveAsFeature : Save
    {
        public SaveAsFeature(string pagename, ref ListView lv, ref TreeView tv) : base(pagename, ref lv, ref tv) { }

        protected override string Prepare()
        {
            return "";
        }
    }
}
 