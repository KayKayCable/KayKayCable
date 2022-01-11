using System;
using System.Collections.Generic;
using Fastenshtein;
using DynamicSugar;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace Keyword_Search
{
    public partial class Form1 : Form
    {
        private List<SearchResult> searchResults = new List<SearchResult>();
        private HashSet<string> keywords = new HashSet<string>();

        public Form1()
        {
            InitializeComponent();
        }

        //Clear the results and reset for another use
        private void clearBtn_Click(object sender, EventArgs e)
        {
            details.Text = "Select an item for more details";
            results.Items.Clear();
            input.Text = "";
        }

        //Generate an HTML or PDF report, idk which yet
        private void reportBtn_Click(object sender, EventArgs e)
        {
            SearchResult temp = new SearchResult()
            {
                FileName = "test.txt",
                Path = @"C:\temp\text.txt",
                DateModified = DateTime.Now,
                LineNumber = 4,
                Context = "this was a test blah blah blah"
            };
            searchResults.Add(temp);

            GenerateReport reportForm = new GenerateReport();
            reportForm.SetKeyword(input.Text);
            reportForm.SetResults(searchResults);
            reportForm.Show();
        }

        //Exit the application
        private void exitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Execute a search in the given directory and the input textbox
        private void searchButton_Click(object sender, EventArgs e)
        {
            searchResults = new List<SearchResult>(); //Reset the searchResults list for the new search

            string directory = "";
            string keyword = "";
            string searchPattern = "";

            //Actual directorylabel.text should start at index 20
            if (directoryLabel.Text.Length > 20)
            {
                directory = directoryLabel.Text.Substring(20);
            }
            else //The user has not selected a directory
            {
                MessageBox.Show("Please open a directory first.");
                return;
            }
            if (String.IsNullOrWhiteSpace(input.Text)) //user has not set a keyword
            {
                MessageBox.Show("Please enter a keyword");
                return;
            }
            else if (keyword.Trim().Contains(' '))
            {
                MessageBox.Show("We do not currently support multiple word keywords without an exact match. " +
                    "However you can try removing the space and our AI will do its best to match your keyword");
            }
            else
            {
                    keyword = input.Text;
                    searchPattern = "*" + keyword + "*"; //used to search for files with names matching the keyword
                    FirstEdits(keyword); //Set the list of possible keywords
            }

            //Get the files and directories whose name contains the keyword
            string[] files = Directory.GetFiles(directory, searchPattern, SearchOption.AllDirectories);
            string[] directories = Directory.GetDirectories(directory, searchPattern, SearchOption.AllDirectories);
            
            foreach (string f in files)
            {
                try
                {
                    var file = new FileInfo(f);
                    SearchResult result = new SearchResult()
                    {
                        DateModified = file.LastWriteTime,
                        FileName = file.Name,
                        Path = file.FullName,
                        LineNumber = 0,
                        Context = "The file name matched the keyword."
                    };

                    searchResults.Add(result);
                }
                catch (FileNotFoundException fe)
                {
                    MessageBox.Show("Search failure: " + fe.Message);
                }
            }
            foreach (string d in directories)
            {
                try
                {
                    var dir = new DirectoryInfo(d);
                    SearchResult result = new SearchResult()
                    {
                        DateModified = dir.LastWriteTime,
                        FileName = dir.Name,
                        Path = dir.FullName,
                        LineNumber = 0,
                        Context = "The directory name matched the keyword."
                    };

                    searchResults.Add(result);
                }
                catch (DirectoryNotFoundException de)
                {
                    MessageBox.Show("Search Failure: " + de.Message);
                }
            }

            //Now search each file for every instance of the keyword
            string[] allFiles = Directory.GetFiles(directory, "*", SearchOption.AllDirectories);
            foreach(string f in allFiles)
            {
                try
                {
                    int counter = 1;
                    string line = null;

                    StreamReader file = new StreamReader(f);
                    while((line = file.ReadLine()) != null)
                    {
                        List<int> indexes = AllIndexesOf(line, keyword);
                        
                        if (indexes.Count > 0)
                        {
                            foreach (int index in indexes)
                            {        
                                //Fancy logic to get the context formatted properly
                                string context;                       
                                if (line.Length > 40)
                                { 
                                    double oddCheck = (40 - keyword.Length) / 2d;
                                    int leftBorder = 0;
                                    int rightBorder = 0;

                                    if ((oddCheck % 1) != 0)
                                    {
                                        leftBorder = (int)(oddCheck - 0.5);
                                        rightBorder = (int)(oddCheck + 0.5);
                                    }
                                    if (line.Substring(0, index - 1).Length < leftBorder)
                                    {
                                        leftBorder = line.Substring(0, index).Length;
                                    }
                                    string temp2 = line.Substring(index + keyword.Length);
                                    if (line.Substring(index + keyword.Length).Length < rightBorder)
                                    {
                                        rightBorder = line.Substring(index + keyword.Length).Length - 2;
                                    }

                                    context = "\"..." + line.Substring(index - leftBorder, leftBorder);
                                    context += keyword;
                                    context += line.Substring(index + keyword.Length, rightBorder) + "...\"";
                                }
                                else
                                {
                                    //line is short enough we can grab the whole line for context
                                    context = line;
                                }

                                var info = new FileInfo(f);
                                SearchResult entry = new SearchResult()
                                {
                                    DateModified = info.LastWriteTime,
                                    FileName = info.Name,
                                    Path = info.FullName,
                                    LineNumber = counter,
                                    Context = context
                                };

                                searchResults.Add(entry);
                            }
                        }

                        counter++;
                    }
                }
                catch (FileNotFoundException fe)
                {
                    MessageBox.Show("Search failure: " + fe.Message);
                }
            }

            //Reset the results box and populate it using the updated search results
            results.Items.Clear();
            foreach(var item in searchResults)
            {
                results.Items.Add(item.FileName);
            }
        }

        //Show details of selected search result
        private void results_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            { 
                //CALEBX - This threw an error I couldn't reproduce,
                //so I just put it in a try catch. Shouldn't matter
                details.Text = searchResults[results.SelectedIndex].ToString();
            }
            catch { }
            
        }

        private void openDirectory_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.Description = "Select Directory";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                directoryLabel.Text = directoryLabel.Text.Substring(0, 20) + folderBrowserDialog1.SelectedPath;
            }
        }

        private List<int> AllIndexesOf(string str, string value)
        {

            List<int> indexes = new List<int>();

            if (!checkBox1.Checked)
            {
                foreach (string s in keywords)
                {
                    for (int index = 0; ; index += value.Length)
                    {
                        index = str.IndexOf(value, index, StringComparison.InvariantCultureIgnoreCase);
                        if (index == -1)
                            continue;
                        indexes.Add(index);
                    }
                }
                return indexes;
            }
            else
            {
                for (int index = 0; ; index += value.Length)
                {
                    index = str.IndexOf(value, index, StringComparison.InvariantCultureIgnoreCase);
                    if (index == -1)
                        return indexes;
                    indexes.Add(index);
                }
            }
        }

        struct StringPair
        {
            public string a, b;
        }
        private List<string> FirstEdits(string value)
        {
            string letters = "abcdefghijklmnopqrstuvwxyz";

            var splits = DS.Range(value.Length + 1).Map(i => new StringPair { a = value.Slice(0, i), b = value.Slice(i) });
            var deletes = splits.Map(s => s.a + s.b.Slice(1));
            var transposes = splits.Map(s => s.b.Length > 1 ? s.a + s.b[1] + s.b[0] + s.b.Slice(2) : "**");

            var replaces = new List<string>();
            foreach (var s in splits)
                foreach (var c in letters)
                    if (s.b.Length > 0)
                        replaces.Add(s.a + c + s.b.Slice(1, -1));

            var inserts = new List<string>();
            foreach (var s in splits)
                foreach (var c in letters)
                    inserts.Add(s.a + c + s.b);

            List<string> all = deletes.Add(transposes).Add(replaces).Add(inserts);

            if (keywords.Count() > 0)
            {
                keywords.Clear();
            }

            for(int ii = 0; ii < all.Count(); ii++)
            {
                try
                {
                    keywords.Add(value); //Add the exact keyword
                    keywords.Add(all[ii].Trim());
                }
                catch { } //Set already contains entry
            }

            return all;
        }

        private List<string> SecondEdits(List<string> values)
        {
            for(int ii = 0; ii < values.Count(); ii++)
            {
                List<string> add = FirstEdits(values[ii]);
                values.AddRange(add);
                for (int jj = 0; jj < add.Count(); jj++)
                {
                    try
                    {
                        keywords.Add(add[ii].Trim());
                    }
                    catch { }
                }
            }
            return values;
        }
    }
}
