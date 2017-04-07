using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using System.Xml;
using System.Xml.Xsl;

namespace NewsFeedCreation
{
    [TestClass]
    public class RSSFeedCreation
    {
        [TestMethod]
        public void CheckRssFeedCreation()
        {
            var xsl = new XslCompiledTransform();
            xsl.Load("RSSCreator.xslt");
            var xslParams = new XsltArgumentList();
            xslParams.AddParam("Date", "", DateTime.Now);


            xsl.Transform("Content//Books.xml", xslParams, Console.Out);
        }
    }
}
