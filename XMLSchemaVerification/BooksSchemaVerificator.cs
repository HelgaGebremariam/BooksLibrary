using System.Text;
using System.Xml;
using System.Xml.Schema;
using NLog;

namespace XMLSchemaVerification
{
    public class BooksSchemaVerificator
    {
        string xmlNamespace;
        string xsdPath;
        Logger logger = LogManager.GetCurrentClassLogger();
        bool isNoErrors;

        public BooksSchemaVerificator(string filePath, string xmlNamespace)
        {
            this.xmlNamespace = xmlNamespace;
            this.xsdPath = filePath;
        }

        void settings_ValidationEventHandler(object sender, System.Xml.Schema.ValidationEventArgs e)
        {
            isNoErrors = false;
            var exception = e.Exception as XmlSchemaValidationException;
            var error = new StringBuilder();
            
            var sourceObject = exception.SourceObject as XmlElement;
            error.AppendLine(e.Message);
            error.AppendLine(sourceObject.OuterXml);
            
            if (e.Severity == XmlSeverityType.Warning)
            {
                
                logger.Warn(error);
            }
            else if (e.Severity == XmlSeverityType.Error)
            {
                logger.Error(error);
            }
        }

        public bool IsValidXml(string xmlPath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlPath);
            if (doc.Schemas.Count == 0)
            {
                XmlSchema schema = getSchema(xsdPath);
                doc.Schemas.Add(schema);
            }
            isNoErrors = true;
            doc.Validate(settings_ValidationEventHandler);
            return isNoErrors;

        }

        private XmlSchema getSchema(string filePath)
        {
            XmlSchemaSet xs = new XmlSchemaSet();
            XmlSchema schema;
            schema = xs.Add(xmlNamespace, filePath);
            return schema;
        }
    }
}
