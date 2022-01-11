using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Keyword_Search
{
    public partial class GenerateReport : Form
    {
        private string keyword = "";
        private List<SearchResult> results = new List<SearchResult>();

        public GenerateReport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = (FileStream)saveFileDialog1.OpenFile())
                {
                    using (StreamWriter sw = new StreamWriter(fs, Encoding.Default))
                    {
                        Report report = new Report();
                        report.GenerateHeader(textBox1.Text, keyword);
                        report.GenerateBody(results);
                        sw.Write(report.Header + report.Body + report.Footer);
                        sw.Close();
                    }
                    fs.Close();

                    //Save successful, close form
                    this.Close();
                }
            }
        }

        private void GenerateReport_Load(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = "html";
            saveFileDialog1.Filter = "Hyper Text Markup Language file (*.html)|*htm;";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.Title = "Save report";
        }

        public void SetKeyword(string key)
        {
            if (!String.IsNullOrWhiteSpace(key))
            {
                keyword = key;
            }
        }

        public void SetResults(List<SearchResult> results)
        {
            if (results != null)
            {
                this.results = results;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
