using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace XMLSchemaVerification
{
    [TestClass]
    public class SchemaVirificationTests
    {
        [TestMethod]
        public void TestValidSchema_AreCorrectResults()
        {
            BooksSchemaVerification sv = new BooksSchemaVerification();
            sv.Check();
        }
    }
}
