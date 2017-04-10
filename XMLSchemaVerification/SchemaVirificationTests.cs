using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Schema;

namespace XMLSchemaVerification
{
    [TestClass]
    public class SchemaVirificationTests
    {
        [TestMethod]
        public void TestValidSchema_AreCorrectResults()
        {
            BooksSchemaVerificator sv = new BooksSchemaVerificator("books.xsd", "http://library.by/catalog");
            var isValidXml = sv.IsValidXml("Content\\Books.xml");
            Assert.AreEqual(true, isValidXml);
        }

        [TestMethod]
        public void TestIValidSchema_IfWrongDate_IsExceptionThrowing()
        {
            BooksSchemaVerificator sv = new BooksSchemaVerificator("books.xsd", "http://library.by/catalog");
            var isValidXml = sv.IsValidXml("Content\\Books_wrongDate.xml");
            Assert.AreEqual(false, isValidXml);
        }

        [TestMethod]
        public void TestIValidSchema_IfWrongGenre_IsExceptionThrowing()
        {
            BooksSchemaVerificator sv = new BooksSchemaVerificator("books.xsd", "http://library.by/catalog");
            var isValidXml = sv.IsValidXml("Content\\Books_wrongGenre.xml");
            Assert.AreEqual(false, isValidXml);
        }

        [TestMethod]
        public void TestIValidSchema_IfWrongIsbn_IsExceptionThrowing()
        {
            BooksSchemaVerificator sv = new BooksSchemaVerificator("books.xsd", "http://library.by/catalog");
            var isValidXml = sv.IsValidXml("Content\\Books_wrongIsbn.xml");
            Assert.AreEqual(false, isValidXml);
        }

        [TestMethod]
        public void TestIValidSchema_IfNonUniqueId_IsExceptionThrowing()
        {
            BooksSchemaVerificator sv = new BooksSchemaVerificator("books.xsd", "http://library.by/catalog");
            var isValidXml = sv.IsValidXml("Content\\Books_nonUniqueId.xml");
            Assert.AreEqual(false, isValidXml);
        }
    }
}
