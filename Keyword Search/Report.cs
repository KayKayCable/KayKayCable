using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keyword_Search
{
    public class Report
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public string Footer 
        { 
            get
            {
                return "</body></html>"; //CALEBX - We will need to add other stuff to this too maybe?
            }
        }

        public void GenerateHeader(string investigator, string keyword)
        {
            Header += "<!DOCTYPE html><html>" +
                "<head><style>table, th, td " +
                    "{border: 1px solid black;" +
                    "border-collapse: collapse;" +
                    "padding:0.5em;" +
                    "text-align:center;}" +
                ".header table, th, td {border:none}" +
                ".header table {width:50%}" +
                "</style></head>" +
                "<body>";
            Header += "<div><h2><table style='border:none;margin:0 auto;'><tr style='border:none'>"
                + "<td>" + investigator + "</td><td>-</td>"
                + "<td>" + keyword + "</td><td>-</td>"
                + "<td>" + DateTime.Now.ToString() + "</td>"
                + "</table></h2></div><hr style='width:55%'>"; //CALEBX - for now we will call this good. We may want to improve this later
        }

        public void GenerateBody(List<SearchResult> results)
        {
            Body += "<table style='margin:1.5em auto;'><tr>" +
                "<th>File Name</th>" +
                "<th>Path</th>" +
                "<th>Date</th>" +
                "<th>Line #</th>" +
                "<th>Context</th></tr>";
            
            foreach(SearchResult sr in results)
            {
                Body += "<tr>" +
                    "<td>" + sr.FileName + "</td>" +
                    "<td>" + sr.Path + "</td>" +
                    "<td>" + sr.DateModified.ToString("G") + "</td>" +
                    "<td>" + sr.LineNumber.ToString() + "</td>" +
                    "<td>" + sr.Context + "</td></tr>";
            }

            Body += "</table>";
        }
    }
}
