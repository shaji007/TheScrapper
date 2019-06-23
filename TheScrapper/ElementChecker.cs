using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using OpenQA.Selenium;

namespace TheScrapper
{
    public class UniqueData
    {
        public object type;
        public object value;
    }

    public class ElementChecker
    {
        private HtmlDocument dom;
        private readonly IWebDriver driver;
        private List<string> single;
        private List<string> singletext;
        private List<string> doub;
        private List<string> doubtext;
        private List<string> parnt;
        private enum LocatoryType
        {
            Id,
            Name,
            Class,
            Text,
            XPath,
            CSS
        }

        public ElementChecker(IWebDriver driver, string src)
        {
            this.driver = driver;
            dom = new HtmlDocument();
            dom.LoadHtml(src);
        }

        public UniqueData CheckUniqueness(WrappedElement elm)
        {
            string retData = null;
            UniqueData ud = new UniqueData();
            if(!String.IsNullOrEmpty(elm.Id) && IsUnique(LocatoryType.Id, elm.Tag, elm.Id, out retData))
            {
                ud.type = "id";
                ud.value = elm.Id;
            }
            else if(!String.IsNullOrEmpty(elm.Name) && IsUnique(LocatoryType.Name, elm.Tag, elm.Name, out retData))
            {
                ud.type = "name";
                ud.value = elm.Name;
            }
            else if(!String.IsNullOrEmpty(elm.ClassName) && IsUnique(LocatoryType.Class, elm.Tag, elm.ClassName, out retData))
            {
                if (String.IsNullOrEmpty(retData))
                {
                    ud.type = "class";
                    ud.value = elm.ClassName;
                }
                else
                {
                    ud.type = "xpath";
                    ud.value = retData;
                }
            }
            else if(!String.IsNullOrEmpty(elm.Text) && IsUnique(LocatoryType.Text, elm.Tag, elm.Text, out retData))
            {
                if (String.IsNullOrEmpty(retData))
                {
                    ud.type = "text";
                    ud.value = elm.Text;
                }
                else
                {
                    ud.type = "xpath";
                    ud.value = retData;
                }
            }
            else
            {
                string xp = CheckXpathWithSingleAttribute(elm);
                if (!String.IsNullOrEmpty(xp))
                {
                    ud.type = "xpath";
                    ud.value = xp;
                }
                else
                {
                    xp = CheckXpathWithSingleAttributeAndText(elm);
                    if (!String.IsNullOrEmpty(xp))
                    {
                        ud.type = "xpath";
                        ud.value = xp;
                    }
                    else
                    {
                        xp = CheckXpathWithDoubleAttribute(elm);
                        if (!String.IsNullOrEmpty(xp))
                        {
                            ud.type = "xpath";
                            ud.value = xp;
                        }
                        else
                        {
                            xp = CheckXpathWithDoubleAttributeAndText(elm);
                            if (!String.IsNullOrEmpty(xp))
                            {
                                ud.type = "xpath";
                                ud.value = xp;
                            }
                            else
                            {
                                xp = CheckXpathWithParent(elm);
                                if (!String.IsNullOrEmpty(xp))
                                {
                                    ud.type = "xpath";
                                    ud.value = xp;
                                }
                                else
                                {
                                    xp = CheckXPathWithGrandParent(elm);
                                    if (!String.IsNullOrEmpty(xp))
                                    {
                                        ud.type = "xpath";
                                        ud.value = xp;
                                    }
                                    else
                                    {
                                        xp = CheckXPathWithFollowingSibling(elm);
                                        if (!String.IsNullOrEmpty(xp))
                                        {
                                            ud.type = "xpath";
                                            ud.value = xp;
                                        }
                                        else
                                        {
                                            xp = CheckXPathWithPrecedingSibling(elm);
                                            if (!String.IsNullOrEmpty(xp))
                                            {
                                                ud.type = "xpath";
                                                ud.value = xp;
                                            }
                                            else
                                            {

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (single != null)
                {
                    if (single.Count > 0)
                        single.Clear();
                }
                if (singletext != null)
                {
                    if (singletext.Count > 0)
                        singletext.Clear();
                }
                if (doub != null)
                {
                    if (doub.Count > 0)
                        doub.Clear();
                }
                if (doubtext != null)
                {
                    if (doubtext.Count > 0)
                        doub.Clear();
                }
                if (parnt != null)
                {
                    if (parnt.Count > 0)
                        parnt.Clear();
                }
            }
            return ud;
        }

        private bool IsUnique(LocatoryType lt, string tag, string data, out string retdata)
        {
            retdata = null;
            bool bFlag = false;
            string xpath = "";
            switch(lt)
            {
                case LocatoryType.Id:
                    xpath = "//" + tag + "[@id='" + data + "']";
                    bFlag = CheckUniqueness(xpath);
                    break;
                case LocatoryType.Name:
                    xpath = "//" + tag + "[@name='" + data + "']";
                    bFlag = CheckUniqueness(xpath);
                    break;
                case LocatoryType.Class:
                    if(data.Contains(" "))
                    {
                        xpath = "/" + MakeXPath(tag, data, ' ', "@class");
                        retdata = xpath;
                    }
                    else
                        xpath = "//" + tag + "[@class='" + data + "']";
                    bFlag = CheckUniqueness(xpath);
                    break;
                case LocatoryType.Text:
                    bool check = false;
                    if (data.Contains("'"))
                    {
                        check = true;
                        xpath = "/" + MakeXPath(tag, data, '\'', "text()");
                        retdata = xpath;
                    }
                    else
                        xpath = "//" + tag + "[text()='" + data + "']";
                    if (tag != "a" || check)
                        retdata = xpath;
                    bFlag = CheckUniqueness(xpath);
                    break;
                case LocatoryType.XPath:
                    bFlag = CheckUniqueness(data);
                    break;
                case LocatoryType.CSS:
                    break;
            }
            return bFlag;
        }

        private bool CheckUniqueness(string xpath)
        {
            bool bFlag = false;
            if (!String.IsNullOrEmpty(xpath))
            {
                HtmlNodeCollection nodes = dom.DocumentNode.SelectNodes(xpath);
                if (nodes != null && nodes.Count == 1)
                    bFlag = true;
            }
            return bFlag;
        }

        private string MakeXPath(string tag, string data, char splitter, string type)
        {
            string xpath = "";
            string[] parts = data.Split(splitter);
            for (int i = 0; i < parts.Length; i++)
            {
                xpath += "contains(" + type + ",'" + parts[i] + "')";
                if (i != parts.Length - 1)
                {
                    xpath += " and ";
                }
            }
            return xpath = "/" + tag + "[" + xpath + "]";
        }

        private string CheckXpathWithSingleAttribute(WrappedElement elm)
        {
            string retdata = null;
            single = new List<string>();
            string xpath = "";
            if (elm.Attributes.Count > 0)
            {
                foreach (var attr in elm.Attributes)
                {
                    if (attr.Value.ToString().Contains("'"))
                    {
                        xpath = MakeXPath(elm.Tag, attr.Value.ToString(), '\'', "@" + attr.Key);
                    }
                    else
                        xpath = "/" + elm.Tag + "[@" + attr.Key + "='" + attr.Value.ToString() + "']";
                    if (!IsUnique(LocatoryType.XPath, "", "/" + xpath, out retdata))
                    {
                        single.Add(xpath);
                        xpath = "";
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                single.Add("/" + elm.Tag);
            }
            if(!String.IsNullOrEmpty(xpath))
                xpath = "/" + xpath;
            return xpath;
        }

        private string CheckXpathWithSingleAttributeAndText(WrappedElement elm)
        {
            string retdata = null;
            singletext = new List<string>();
            string xpath = "";
            if (elm.Attributes.Count > 0)
            {
                foreach (var attr in elm.Attributes)
                {
                    if(!elm.Text.Contains("'") && !String.IsNullOrEmpty(elm.Text))
                        xpath = "/" + elm.Tag + "[@" + attr.Key + "='" + attr.Value.ToString() + "' and text()='" + elm.Text + "']";
                    // if contains apostrophe
                    if (!IsUnique(LocatoryType.XPath, "", "/" + xpath, out retdata))
                    {
                        singletext.Add(xpath);
                        xpath = "";
                    }
                    else
                        break;
                }
            }
            else
            {
                singletext.Add("/" + elm.Tag);
            }
            if (!String.IsNullOrEmpty(xpath))
                xpath = "/" + xpath;
            return xpath;
        }

        private string CheckXpathWithDoubleAttribute(WrappedElement elm)
        {
            string retdata = null;
            doub = new List<string>();
            string xpath = "";
            int max = elm.Attributes.Count;
            if (max > 0)
            {
                if (max > 1)
                {
                    for (int i = 0; i < max - 1; i++)
                    {
                        for (int j = 1; j < max; j++)
                        {
                            if (!elm.Text.Contains("'") && !String.IsNullOrEmpty(elm.Text))
                            {
                                if (!elm.Attributes.ElementAt(i).Value.ToString().Contains("'") || !elm.Attributes.ElementAt(j).Value.ToString().Contains("'"))
                                    xpath = "/" + elm.Tag + "[@" + elm.Attributes.ElementAt(i).Key + "='" + elm.Attributes.ElementAt(i).Value.ToString() + "' and @" + elm.Attributes.ElementAt(j).Key + "='" + elm.Attributes.ElementAt(j).Value.ToString() + "']";
                                if (!IsUnique(LocatoryType.XPath, "", "/" + xpath, out retdata))
                                {
                                    doub.Add(xpath);
                                    xpath = "";
                                }
                                else
                                {
                                    j = max;
                                    i = max;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                doub.Add("/" + elm.Tag);
            }
            if (!String.IsNullOrEmpty(xpath))
                xpath = "/" + xpath;
            return xpath;
        }

        private string CheckXpathWithDoubleAttributeAndText(WrappedElement elm)
        {
            string retdata = null;
            doubtext = new List<string>();
            string xpath = "";
            int max = elm.Attributes.Count;
            if (max > 0)
            {
                if (max > 1)
                {
                    for (int i = 0; i < max - 1; i++)
                    {
                        for (int j = 1; j < max; j++)
                        {
                            if (!elm.Text.Contains("'") && !String.IsNullOrEmpty(elm.Text))
                            {
                                xpath = "/" + elm.Tag + "[@" + elm.Attributes.ElementAt(i).Key + "='" + elm.Attributes.ElementAt(i).Value.ToString() + "' and @" + elm.Attributes.ElementAt(j).Key + "='" + elm.Attributes.ElementAt(j).Value.ToString() + "' and text()='" + elm.Text + "']";
                                if (!IsUnique(LocatoryType.XPath, "", "/" + xpath, out retdata))
                                {
                                    doubtext.Add(xpath);
                                    xpath = "";
                                }
                                else
                                {
                                    j = max;
                                    i = max;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                doubtext.Add("/" + elm.Tag);
            }
            if (!String.IsNullOrEmpty(xpath))
                xpath = "/" + xpath;
            return xpath;
        }


        private string CheckXpathWithParent(WrappedElement elm)
        {
            bool flag = false;
            parnt = new List<string>();
            string retdata = null;
            string xpath = "";
            if (elm.Parent != null)
            {
                WrappedElement parent = new WrappedElement(driver, elm.Parent);
                if (parent.Attributes.Count > 0)
                {
                    foreach (var p in parent.Attributes)
                    {
                        foreach (var item in single)
                        {
                            xpath = "/" + parent.Tag + "[@" + p.Key + "='" + p.Value.ToString() + "']" + item;
                            if (!IsUnique(LocatoryType.XPath, "", "/" + xpath, out retdata))
                            {
                                parnt.Add(xpath);
                                xpath = "";
                            }
                            else
                            {
                                flag = true;
                                break;
                            }
                        }
                        if (flag)
                            break;
                    }
                    foreach (var p in parent.Attributes)
                    {
                        foreach (var item in singletext)
                        {
                            xpath = "/" + parent.Tag + "[@" + p.Key + "='" + p.Value.ToString() + "']" + item;
                            if (!IsUnique(LocatoryType.XPath, "", "/" + xpath, out retdata))
                            {
                                parnt.Add(xpath);
                                xpath = "";
                            }
                            else
                            {
                                flag = true;
                                break;
                            }
                        }
                        if (flag)
                            break;
                    }
                }
                else
                {
                    foreach (var item in single)
                    {
                        xpath = "/" + parent.Tag + item;
                        if (!IsUnique(LocatoryType.XPath, "", "/" + xpath, out retdata))
                        {
                            parnt.Add(xpath);
                            xpath = "";
                        }
                        else
                        {
                            break;
                        }
                    }
                    foreach (var item in singletext)
                    {
                        xpath = "/" + parent.Tag + item;
                        if (!IsUnique(LocatoryType.XPath, "", "/" + xpath, out retdata))
                        {
                            parnt.Add(xpath);
                            xpath = "";
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            if (!String.IsNullOrEmpty(xpath))
                xpath = "/" + xpath;
            return xpath;
        }

        private string CheckXPathWithGrandParent(WrappedElement elm)
        {
            bool flag = false;
            string retdata = null;
            string xpath = "";
            if (elm.GrandParent != null)
            {
                WrappedElement grandparent = new WrappedElement(driver, elm.GrandParent);
                if (grandparent.Attributes.Count > 0)
                {
                    foreach (var p in grandparent.Attributes)
                    {
                        foreach (var item in parnt)
                        {
                            xpath = "/" + grandparent.Tag + "[@" + p.Key + "='" + p.Value.ToString() + "']" + item;
                            if (IsUnique(LocatoryType.XPath, "", "/" + xpath, out retdata))
                            {
                                flag = true;
                                break;
                            }
                            else
                                xpath = "";
                        }
                        if (flag)
                            break;
                    }
                }
                else
                {
                    foreach (var item in parnt)
                    {
                        xpath = "/" + grandparent.Tag + item;
                        if (IsUnique(LocatoryType.XPath, "", "/" + xpath, out retdata))
                        {
                            break;
                        }
                        else
                            xpath = "";
                    }
                }
            }
            if (!String.IsNullOrEmpty(xpath))
                xpath = "/" + xpath;
            return xpath;
        }

        private string CheckXPathWithFollowingSibling(WrappedElement elm)
        {
            bool flag = false;
            string retdata = null;
            string xpath = "";
            if (elm.FollowingSibling != null)
            {
                WrappedElement fs = new WrappedElement(driver, elm.FollowingSibling);
                if (fs.Attributes.Count > 0)
                {
                    foreach (var p in fs.Attributes)
                    {
                        foreach (var item in elm.Attributes)
                        {
                            xpath = "/" + fs.Tag + "[@" + p.Key + "='" + p.Value.ToString() + "']" + "/preceding-sibling::" + elm.Tag + "[@"+ item.Key + "='" + item.Value.ToString() + "']";
                            if (IsUnique(LocatoryType.XPath, "", "/" + xpath, out retdata))
                            {
                                flag = true;
                                break;
                            }
                        }
                        if (flag)
                            break;
                    }
                }
                else
                {
                    foreach (var item in elm.Attributes)
                    {
                        xpath = "/" + fs.Tag + "/preceding-sibling::" + elm.Tag + "[@" + item.Key + "='" + item.Value.ToString() + "']";
                        if (IsUnique(LocatoryType.XPath, "", "/" + xpath, out retdata))
                        {
                            break;
                        }
                        else
                            xpath = "";
                    }
                    foreach (var item in elm.Attributes)
                    {
                        xpath = "/" + fs.Tag + "[text()='" + fs.Text + "']" +"/preceding-sibling::" + elm.Tag + "[@" + item.Key + "='" + item.Value.ToString() + "']";
                        if (IsUnique(LocatoryType.XPath, "", "/" + xpath, out retdata))
                        {
                            break;
                        }
                        else
                            xpath = "";
                    }
                }
            }
            if (!String.IsNullOrEmpty(xpath))
                xpath = "/" + xpath;
            return xpath;
        }

        private string CheckXPathWithPrecedingSibling(WrappedElement elm)
        {
            bool flag = false;
            string retdata = null;
            string xpath = "";
            if (elm.PrecedingSibling != null)
            {
                WrappedElement ps = new WrappedElement(driver, elm.FollowingSibling);
                if (ps.Attributes.Count > 0)
                {
                    foreach (var p in ps.Attributes)
                    {
                        foreach (var item in elm.Attributes)
                        {
                            xpath = "/" + ps.Tag + "[@" + p.Key + "='" + p.Value.ToString() + "']" + "/following-sibling::" + elm.Tag + "[@" + item.Key + "='" + item.Value.ToString() + "']";
                            if (IsUnique(LocatoryType.XPath, "", "/" + xpath, out retdata))
                            {
                                flag = true;
                                break;
                            }
                            else
                                xpath = "";
                        }
                        if (flag)
                            break;
                    }
                }
                else
                {
                    foreach (var item in elm.Attributes)
                    {
                        xpath = "/" + ps.Tag + "/following-sibling::" + elm.Tag + "[@" + item.Key + "='" + item.Value.ToString() + "']";
                        if (IsUnique(LocatoryType.XPath, "", "/" + xpath, out retdata))
                        {
                            break;
                        }
                        else
                            xpath = "";
                    }
                    foreach (var item in elm.Attributes)
                    {
                        xpath = "/" + ps.Tag + "[text()='" + ps.Text + "']" + "/following-sibling::" + elm.Tag + "[@" + item.Key + "='" + item.Value.ToString() + "']";
                        if (IsUnique(LocatoryType.XPath, "", "/" + xpath, out retdata))
                        {
                            break;
                        }
                        else
                            xpath = "";
                    }
                }
            }
            return xpath;
        }
    }
}
