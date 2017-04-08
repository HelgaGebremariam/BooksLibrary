using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Xml.Xsl;

namespace NewsFeedCreation
{
    [TestClass]
    public class AtomFeedCreation
    {
        [TestMethod]
        public void CheckRssFeedCreation()
        {
            var xsl = new XslCompiledTransform();
            var settings = new XsltSettings { EnableScript = true };
            xsl.Load("AtomCreator.xslt", settings, null);

            xsl.Transform("Content//Books.xml", null, Console.Out);
        }
    }
}
