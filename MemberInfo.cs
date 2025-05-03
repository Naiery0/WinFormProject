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
            this.Name = name;
            this.Part = part;
            this.Birth = birth;
            this.Absence = absence;
            this.StNum = stnum;
        }

        public string Part { get; set; }
        public string Birth { get; set; }
        public string Name {  get; set; }
        public string StNum {  get; set; }
        public int Absence { get; set; }
    }
}
