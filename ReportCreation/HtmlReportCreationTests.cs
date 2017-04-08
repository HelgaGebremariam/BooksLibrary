using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;
using System.Diagnostics;
using System.Xml.XPath;
using System.Xml;

namespace ReportCreation
{
    [TestClass]
    public class HtmlReportCreationTests
    {
        [TestMethod]
        public void TestHtmlReportCreator_IsCorrectHtml()
        {
            var xsl = new XslCompiledTransform();
            var args = new XsltArgumentList();

            var reportCreator = new HtmlReportTableCreator("report.html");
            args.AddExtensionObject("http://epam.com/xsl/ext", reportCreator);

            xsl.Load("HtmlReportCreation.xslt");

            xsl.Transform("Content//Books.xml", args, Console.Out);

            reportCreator.Generate();
        }
    }
}
