using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Schema;
using System.Collections;
using System.Linq;

namespace XMLSchemaVerification
{
    [TestClass]
    public class SchemaVirificationTests
    {
        [TestMethod]
        public void TestValidSchema_AreCorrectResults()
        {
            BooksSchemaVerificator sv = new BooksSchemaVerificator("books.xsd", "http://library.by/catalog");
            var validationResults = sv.Validate("Content\\Books.xml");
            Assert.AreEqual(0, validationResults.Count);
        }

        [TestMethod]
        public void TestIValidSchema_IfWrongDate_IsExceptionThrowing()
        {
            BooksSchemaVerificator sv = new BooksSchemaVerificator("books.xsd", "http://library.by/catalog");
            var validationResults = sv.Validate("Content\\Books_wrongDate.xml");
            Assert.AreEqual(true, validationResults.Any(s => s.Item1.Id == "bk110"));
        }

        [TestMethod]
        public void TestIValidSchema_IfWrongGenre_IsExceptionThrowing()
        {
            BooksSchemaVerificator sv = new BooksSchemaVerificator("books.xsd", "http://library.by/catalog");
            var validationResults = sv.Validate("Content\\Books_wrongGenre.xml");

            Assert.AreEqual(true, validationResults.Any(s=>s.Item1.Id == "bk110"));
        }

        [TestMethod]
        public void TestIValidSchema_IfWrongIsbn_IsExceptionThrowing()
        {
            BooksSchemaVerificator sv = new BooksSchemaVerificator("books.xsd", "http://library.by/catalog");
            var validationResults = sv.Validate("Content\\Books_wrongIsbn.xml");
            Assert.AreEqual(true, validationResults.Any(s => s.Item1.Id == "bk102"));
        }

        [TestMethod]
        public void TestIValidSchema_IfNonUniqueId_IsExceptionThrowing()
        {
            BooksSchemaVerificator sv = new BooksSchemaVerificator("books.xsd", "http://library.by/catalog");
            var validationResults = sv.Validate("Content\\Books_nonUniqueId.xml");
            Assert.AreEqual(true, validationResults.Any(s => s.Item1.Id == "bk101"));
        }
    }
}
