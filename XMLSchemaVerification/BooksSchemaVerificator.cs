using System;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using NLog;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Collections.Generic;

namespace XMLSchemaVerification
{
    public class Book
    {
        public string Id { get; set;}
        public string Name { get; set; }
        public string Author { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("Id: ");
            sb.AppendLine(Id);
            sb.Append(" Name: ");
            sb.AppendLine(Name);
            sb.Append(" Author: ");
            sb.AppendLine(Author);
            return sb.ToString();
        }
    }

    public class BooksSchemaVerificator
    {
        string xmlNamespace;
        string xsdPath;
        Logger logger = LogManager.GetCurrentClassLogger();
        List<Tuple<Book, string>> booksWithErrors;
        public BooksSchemaVerificator(string filePath, string xmlNamespace)
        {
            this.xmlNamespace = xmlNamespace;
            this.xsdPath = filePath;
        }

        void settings_ValidationEventHandler(object sender, System.Xml.Schema.ValidationEventArgs e)
        {
            var exception = e.Exception as XmlSchemaValidationException;
            var error = new StringBuilder();
            error.AppendLine(exception.Message);

            Book book = GetBookFromXElement(sender as XElement);

            if (book != null)
            {
                error.AppendLine(book.ToString());
                booksWithErrors.Add(Tuple.Create<Book, string>(book, e.Message));
            }

            if (e.Severity == XmlSeverityType.Warning)
            {
                
                logger.Warn(error);
            }
            else if (e.Severity == XmlSeverityType.Error)
            {
                logger.Error(error);
            }
        }

        public List<Tuple<Book, string>> Validate(string xmlPath)
        {
            var xDocument = XDocument.Load(xmlPath);

            var schemas = new XmlSchemaSet();
            schemas.Add(xmlNamespace, "books.xsd");
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(new NameTable());
            nsmgr.AddNamespace("x", xmlNamespace);
            booksWithErrors = new List<Tuple<Book, string>>();
            xDocument.Validate(schemas, settings_ValidationEventHandler);
            return booksWithErrors;
        }

        private Book GetBookFromXElement(XElement element)
        {
            XElement parentBook = element;
            if (element.Name.LocalName.ToLowerInvariant() != "book")
            {
                parentBook = element.Parent;

            }
            Book book = new Book();

            foreach(XAttribute attribute in parentBook.Attributes())
            {
                if (attribute.Name.LocalName == "id")
                    book.Id = attribute.Value;
            }

            foreach (XElement node in parentBook.Nodes())
            {
                if (node.Name.LocalName == "title")
                    book.Name = node.Value;
                if (node.Name.LocalName == "author")
                    book.Author = node.Value;
            }

            return book;
        }
    }
}
