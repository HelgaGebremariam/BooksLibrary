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

            settings.Schemas.Add("http://library.by/catalog", "Books.xsd");
            settings.ValidationEventHandler +=
                delegate (object sender, ValidationEventArgs e)
                {
                    throw new Exception(String.Format("[{0}:{1}] {2}", e.Exception.LineNumber, e.Exception.LinePosition, e.Message));
                };

            settings.ValidationFlags = settings.ValidationFlags | XmlSchemaValidationFlags.ReportValidationWarnings;
            settings.ValidationType = ValidationType.Schema;
        }

        public void Check()
        {
            XmlReader reader = XmlReader.Create("F:\\books.xml", settings);
           
            while (reader.Read())
            {
            };
        }
    }
}
