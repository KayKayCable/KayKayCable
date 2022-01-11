using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Keyword_Search
{
    public class SearchResult
    {
        public DateTime DateModified { get; set; }
        public string FileName { get; set; } //Calebx - File name WITH extension I think would be best
        public string Path { get; set; }
        public int LineNumber { get; set; }
        public string Context { get; set; }

        public override string ToString()
        {
            return FileName + ":"
                + "\nPath: " + Path
                + "\nDate Modified: " + DateModified.ToString() //Calebx - We might want to format the date beyond the default
                + "\nLine Number: " + LineNumber.ToString()
                + "\nContext: " + Context;
        }
    }
}
