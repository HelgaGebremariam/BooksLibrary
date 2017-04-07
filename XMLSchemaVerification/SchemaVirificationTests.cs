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
            BooksSchemaVerification sv = new BooksSchemaVerification();
            sv.Check("Content\\Books.xml");
        }

        [TestMethod]
        [ExpectedException(typeof(XmlSchemaValidationException))]
        public void TestIValidSchema_IfWrongDate_IsExceptionThrowing()
        {
            BooksSchemaVerification sv = new BooksSchemaVerification();
            sv.Check("Content\\Books_wrongDate.xml");
        }

        [TestMethod]
        [ExpectedException(typeof(XmlSchemaValidationException))]
        public void TestIValidSchema_IfWrongGenre_IsExceptionThrowing()
        {
            BooksSchemaVerification sv = new BooksSchemaVerification();
            sv.Check("Content\\Books_wrongGenre.xml");
        }

        [TestMethod]
        [ExpectedException(typeof(XmlSchemaValidationException))]
        public void TestIValidSchema_IfWrongIsbn_IsExceptionThrowing()
        {
            BooksSchemaVerification sv = new BooksSchemaVerification();
            sv.Check("Content\\Books_wrongIsbn.xml");
        }

        [TestMethod]
        [ExpectedException(typeof(XmlSchemaValidationException))]
        public void TestIValidSchema_IfNonUniqueId_IsExceptionThrowing()
        {
            BooksSchemaVerification sv = new BooksSchemaVerification();
            sv.Check("Content\\Books_nonUniqueId.xml");
        }
    }
}
