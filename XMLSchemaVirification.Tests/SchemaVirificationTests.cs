using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XMLSchemaVerification;

namespace XMLSchemaVirification.Tests
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
