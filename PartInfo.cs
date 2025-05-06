using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormProject
{
    internal class PartInfo
    {
        public string Part { get; set; }
        public List<string> Member { get; set; }// 파트에 속한 멤버 저장(학번)
        public PartInfo(string part, string stNum)
        {
            Part = part;
            Member = new List<string>();
            AddMember(stNum);
        }

        // 멤버 추가 메서드
        public void AddMember(string stNum)
        {
            Member.Add(stNum);
        }

        // 멤버 삭제 메서드
        //public void RemoveMember(string stNum) 
        //{ 
        //    Member.Remove(stNum); 
        //}

    }
}

