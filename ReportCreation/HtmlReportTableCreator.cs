using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportCreation
{
    public class ReportRow
    {
        public string Author { get; set; }
        public string Name { get; set; }
        public string PublishDate {get;set;}
        public string RegistrationDate { get; set; }
        public string Genre { get; set; }
}
    public class HtmlReportTableCreator
    {
        public string htmlFileName;
        string creationDate;
        List<ReportRow> reports;

        public HtmlReportTableCreator(string htmlFileName)
        {
            this.htmlFileName = htmlFileName;
            reports = new List<ReportRow>();
        }

        public void AddReportRow(string genre, string author, string name, string publishDate, string registrationDate)
        {
            reports.Add(new ReportRow()
            {
                Author = author,
                Name = name,
                PublishDate = publishDate,
                RegistrationDate = registrationDate,
                Genre = genre
            });
        }

        private void StartFileWriting()
        {
            creationDate = System.DateTime.Now.ToString();
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(htmlFileName, false))
            {
                file.WriteLine("<!DOCTYPE html>");
                file.WriteLine("<html>");
                file.WriteLine("<head>");
                file.WriteLine("<title>Books Library Report " + creationDate + "</title>");
                file.WriteLine("</head>");
                file.WriteLine("<body>");
                file.WriteLine("<h1>Books Library Report " + creationDate  + "</h1>");
                file.Close();
            }
        }

        private void FinishFileWriting()
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(htmlFileName, true))
            {
                file.WriteLine("</body>");
                file.WriteLine("</html>");
                file.Close();
            }
        }

        private void WriteCommonStatistics()
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(htmlFileName, true))
            {
                file.WriteLine("<h4>Total (all books): ");
                file.WriteLine(reports.Count);
                file.WriteLine("</h4>");
                file.Close();
            }
        }

        private string GetGenreStatistics(List<ReportRow> rows)
        {
            var result = new StringBuilder();
            result.Append("<h2>");
            result.Append(rows.FirstOrDefault().Genre);
            result.Append("</h2>");
            result.Append("<table>");
            result.Append("<tr>");
            result.Append("<th style=\"width:20%\">Author</th>");
            result.Append("<th style=\"width:20%\">Name</th>");
            result.Append("<th style=\"width:20%\">Publish Date</th>");
            result.Append("<th style=\"width:20%\">Registration Date</th>");
            result.Append("</tr>");
            for (int i = 0; i < rows.Count; i++)
            {
                result.Append("<tr>");
                result.Append("<td>");
                result.Append(rows[i].Author);
                result.Append("</td>");
                result.Append("<td>");
                result.Append(rows[i].Name);
                result.Append("</td>");
                result.Append("<td>");
                result.Append(rows[i].PublishDate);
                result.Append("</td>");
                result.Append("<td>");
                result.Append(rows[i].RegistrationDate);
                result.Append("</td>");
                result.Append("</tr>");
            }

            result.Append("</table>");
            result.Append("<h3>Total (");
            result.Append(rows.FirstOrDefault().Genre);
            result.Append("): ");
            result.Append(rows.Count);
            result.Append("</h3>");
            return result.ToString();
        }

        public void Generate()
        {
            StartFileWriting();
            var groupedReports = reports.GroupBy(r => r.Genre);
            for(int i = 0; i < groupedReports.Count(); i++)
            {
                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(htmlFileName, true))
                {
                    file.WriteLine(GetGenreStatistics(groupedReports.ElementAt(i).ToList()));
                }
            }
            WriteCommonStatistics();
            FinishFileWriting();
        }
    }
}
