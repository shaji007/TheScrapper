using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheScrapper
{
    public static class VariableName
    {
        public static string Name(IWebElement elm)
        {
            string prefix = "";
            string data = "";
            if(elm.FindElements(By.XPath(".//*")).Count == 0)
            {
                data = elm.Text;
                if(data.Contains(" "))
                {
                    string[] d = data.Split(' ');
                    data = d[0];
                }
            }
            switch(elm.TagName.ToLower())
            {
                case "a":
                    prefix = "Lnk";
                    break;
                case "h1":
                case "h2":
                case "h3":
                case "h4":
                case "h5":
                case "h6":
                    prefix = "Hd";
                    break;
                case "span":
                    prefix = "Spn";
                    break;
                case "table":
                    prefix = "Tbl";
                    break;
                case "input":
                    prefix = Input(elm.GetAttribute("type"));
                    break;
                case "img":
                    prefix = "Img";
                    break;
                case "b":
                    prefix = "Bld";
                    break;
                case "blockquote":
                    prefix = "Bq";
                    break;
                case "button":
                    prefix = "Btn";
                    break;
                case "canvas":
                    prefix = "Cv";
                    break;
                case "caption":
                    prefix = "Tc";
                    break;
                case "center":
                    prefix = "Cen";
                    break;
                case "code":
                    prefix = "Cd";
                    break;
                case "footer":
                    prefix = "Ftr";
                    break;
                case "label":
                    prefix = "Lbl";
                    break;
                case "nav":
                    prefix = "Nv";
                    break;
                case "select":
                    prefix = "Sel";
                    break;
                case "strong":
                    prefix = "Stg";
                    break;
                case "textarea":
                    prefix = "Ta";
                    break;
                case "title":
                    prefix = "Tl";
                    break;
                case "time":
                    prefix = "Time";
                    break;
                case "i":
                    prefix = "Icn";
                    break;
                default:
                    prefix = "Other";
                    break;
            }
            return prefix + data;
        }

        private static string Input(string type)
        {
            string retval = "";
            if (String.IsNullOrEmpty(type))
                return retval;
            switch(type)
            {
                case "button":
                    retval = "Btn";
                    break;
                case "text":
                    retval = "Tb";
                    break;
                case "checkbox":
                    retval = "Chkb";
                    break;
                case "radio":
                    retval = "Rad";
                    break;
                case "date":
                    retval = "Date";
                    break;
                case "time":
                    retval = "Time";
                    break;
                case "number":
                    retval = "Num";
                    break;
                case "hidden":
                    retval = "Hn";
                    break;
                case "email":
                    retval = "Em";
                    break;
                case "file":
                    retval = "Fl";
                    break;
                case "image":
                    retval = "Img";
                    break;
                case "reset":
                    retval = "Rst";
                    break;
                case "range":
                    retval = "Rng";
                    break;
                case "submit":
                    retval = "Sub";
                    break;
                case "tel":
                    retval = "Tel";
                    break;
                case "url":
                    retval = "Url";
                    break;
                case "password":
                    retval = "Pwd";
                    break;
            }
            return retval;
        }
    }
}
