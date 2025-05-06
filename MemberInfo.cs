using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormProject
{
    internal class MemberInfo
    {
        public MemberInfo(string name, string part, string stnum, string birth, int absence) { 
            Name = name;
            Part = part;
            Birth = birth;
            Absence = absence;
            StNum = stnum;
        }
        public string Part { get; set; }
        public string Birth { get; set; }
        public string Name {  get; set; }
        public string StNum {  get; set; }
        public int Absence { get; set; }
    }
}
