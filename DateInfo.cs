using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormProject
{
    internal class DateInfo
    {
        public DateInfo(string title, string date, string type, string memo) {
            Title = title;
            Date = date;
            Type = type;  
            Memo = memo;   
        }
        public string Title { get; set; }
        public string Date{ get; set; }
        public string Type { get; set; }
        public string Memo { get; set; }
    }
}
