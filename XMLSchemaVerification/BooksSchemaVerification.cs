using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace XMLSchemaVerification
{
    public class BooksSchemaVerification
    {
        XmlReaderSettings settings;
        public BooksSchemaVerification()
        {
            settings = new XmlReaderSettings();

            settings.Schemas.Add("http://library.by/catalog", "books.xsd");
            settings.ValidationEventHandler +=
                delegate (object sender, ValidationEventArgs e)
                {
                    throw new XmlSchemaValidationException(string.Format("[{0}:{1}] {2}", e.Exception.LineNumber, e.Exception.LinePosition, e.Message));
                };

            settings.ValidationFlags = settings.ValidationFlags | XmlSchemaValidationFlags.ReportValidationWarnings;
            settings.ValidationType = ValidationType.Schema;
        }

        public void Check(string docPath)
        {
            XmlReader reader = XmlReader.Create(docPath, settings);
           
            while (reader.Read())
            {
            };
        }
    }
}
