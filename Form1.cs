using System.Xml.Linq;
using System;
using System.Reflection;

namespace WinFormProject
{
    public partial class Form1 : Form
    {
        bool Add_or_Update = true; // true는 Add 
        List<string> stNumList = new List<string>();
        List<PartInfo> partInfos = new List<PartInfo>();
        // 파트 인포는 정녕 필요한가?
        // -> 당장은 필요 없긴 한데 추후 업그레이드를 한다면 필요할지도...? 
        List<MemberInfo> memberInfos = new List<MemberInfo>();
        List<DateInfo> dateInfos = new List<DateInfo>();

        bool dateSelectMode = true; // true == add , false == update

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MemberEnableControl(false);
            BtnUpdate_Date.Enabled = true;
            BtnUpdate_Mem.Enabled = true;

            Calendar.MaxSelectionCount = 1;
            CboType_In.SelectedIndex = 0;
            DeleteDateText();
        }

        // 멤버
        // 추가
        private void BtnAdd_Mem_Click(object sender, EventArgs e)
        {
            MemberEnableControl(true);
            EnableControl(groupBox3, false);
            DeleteMemberInfo();

            BtnUpdate_Mem.Visible = false;
            Add_or_Update = true;
        }

        // 취소
        private void BtnCancle_AddMem_Click(object sender, EventArgs e)
        {
            MemberEnableControl(false);
            EnableControl(groupBox3, true);
            BtnUpdate_Mem.Visible = true;
        }

        // 저장
        private void BtnOk_MemAdd_Click(object sender, EventArgs e)
        {
            if (TxtName.Text.Trim() == "" || TxtPart.Text.Trim() == "" ||
                !TxtStNum.MaskFull || !TxtBirth.MaskFull)
            {
                MessageBox.Show("정보를 모두 입력해주세요", "입력 오류", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }  
            switch (Add_or_Update) // Add면 정보 추가를, Update면 정보 수정을
            {
                case true:
                    AddMemberNode(TxtName.Text.Trim(), 
                                  TxtPart.Text.Trim(), 
                                  TxtStNum.Text.Trim(), 
                                  TxtBirth.Text.Trim(),
                                  (int)TxtAbsence.Value);
                    BtnCancle_AddMem_Click(sender, e);
                    break;
                case false:
                    UpdateMemberNode(LsvMember.SelectedNode);
                    BtnCancle_AddMem_Click(sender, e);
                    break;
            }
        }

        // 편집
        private void BtnUpdate_Mem_Click(object sender, EventArgs e)
        {
            if (LsvMember.SelectedNode == null)
            {
                MessageBox.Show("편집할 사람을 선택하세요.", "편집 오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ViewMemberInfo();
            stNumList.Remove(TxtStNum.Text.Trim());

            MemberEnableControl(true);
            EnableControl(groupBox3, false);
            Add_or_Update = false;
            BtnUpdate_Mem.Visible = false;
        }


        // 삭제
        private void BtnDelete_Mem_Click(object sender, EventArgs e)
        {
            if (LsvMember.SelectedNode == null)
            {
                MessageBox.Show("삭제할 사람을 선택하세요.", "삭제 오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //LsvMember.Nodes.Remove(LsvMember.SelectedNode);
            RemoveMember(LsvMember.SelectedNode);
            DeleteMemberInfo();

        }

        private void RemoveMember(TreeNode target)
        {
            if (target.Parent == null) // 파트 삭제
            {
                int index = partInfos.FindIndex(i => i.Part.Contains(target.Text));
                //stNumList에 있는 것들 파트인포.멤버 순회하면서 지우기
                foreach (string stNum in partInfos[index].Member)
                {
                    if (stNumList.Contains(stNum))
                    {
                        stNumList.Remove(stNum);
                        int memberIndex = memberInfos.FindIndex(i => i.StNum.Contains(stNum));
                        memberInfos.RemoveAt(memberIndex);
                    }
                }
                partInfos.RemoveAt(index);
            }
            else // 멤버 삭제
            {
                int index = memberInfos.FindIndex(i => i.Name.Contains(target.Text));
                int removePart = partInfos.FindIndex(i => i.Part.Contains(memberInfos[index].Part));
                stNumList.Remove(memberInfos[index].StNum);
                partInfos[removePart].Member.Remove(memberInfos[index].StNum);
                memberInfos.RemoveAt(index);
            }
            //LsvMember.Nodes.Remove(target); // 리스트에서 삭제
            target.Remove();
            LsvMember.SelectedNode = null;
        }

        private void ViewMemberInfo()
        {
            DeleteMemberInfo();
            TreeNode target = LsvMember.SelectedNode;
            if (target.Parent != null)
            { // 사람을 선택했을 때

                TxtName.Text = target.Text;
                TxtPart.Text = target.Parent.Text;
                int index = memberInfos.FindIndex(i => i.Name.Contains(target.Text));
                TxtBirth.Text = memberInfos[index].Birth;
                TxtStNum.Text = memberInfos[index].StNum;
                TxtAbsence.Value = memberInfos[index].Absence;
                //tempStNum = TxtStNum.Text;
            }
            else
            { // 파트를 선택했을 때
                //tempStNum = string.Empty;

                TxtPart.Text = target.Text;
            }
        }

        private void DeleteMemberInfo()
        {
            //tempStNum = string.Empty;

            TxtAbsence.Value = 0;
            TxtBirth.Text = string.Empty;
            TxtPart.Text = string.Empty;
            TxtStNum.Text = string.Empty;
            TxtName.Text = string.Empty;
        }

        // 멤버 버튼/텍스트 컨트롤
        private void MemberEnableControl(bool FT)
        {
            //TxtName.Enabled = FT;
            //TxtBirth.Enabled = FT;
            //TxtPart.Enabled = FT;
            //TxtStNum.Enabled = FT;
            //TxtAbsence.Enabled = FT;
            //groupBox2.Enabled = FT; // 이게 되네... 바보짓했다
            EnableControl(groupBox2, FT); // 윗줄은 라벨도 투명해져서 만든 함수
            BtnUpdate_Date.Enabled = !FT;

            LsvMember.Enabled = !FT;

            BtnOk_MemAdd.Visible = FT;
            BtnCancle_MemAdd.Visible = FT;
            BtnAdd_Mem.Visible = !FT;
            BtnDelete_Mem.Visible = !FT;

            if (FT == false)// 내용 지우기
            {
                DeleteMemberInfo();
                BtnAdd_Mem.Visible = !FT;
                BtnDelete_Mem.Visible = !FT;
            }
        }

        // 멤버 목록 노드 추가 함수
        private void AddMemberNode(string name, string part, string stNum, string birth, int absence)
        {
            if (stNumList.Contains(stNum))
            {
                MessageBox.Show("이미 등록된 멤버입니다.", "학번 중복 감지",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //MessageBox.Show($"{part}");
                int lstLen = LsvMember.Nodes.Count;
                // 멤버 클래스 생성
                memberInfos.Add(new MemberInfo(name, part, stNum, birth, absence));
                stNumList.Add(stNum);
                for (int i = 0; i < lstLen; i++)
                {
                    if (part.Equals(LsvMember.Nodes[i].Text) == true) // 파트가 있으면 파트에 멤버를
                    {
                        // 파트 클래스에 멤버 추가
                        int index = partInfos.FindIndex(i => i.Part.Contains(part)); // 파트 맞는 클래스 찾기
                        partInfos[index].Member.Add(stNum);
                        // 노드에 추가
                        LsvMember.Nodes[i].Nodes.Add(name);
                        return;
                    }
                }
                LsvMember.Nodes.Add(part); // 파트 없으면 만들어
                partInfos.Add(new PartInfo(part, stNum));  // 파트가 없으면 파트 생성

                LsvMember.Nodes[lstLen].Nodes.Add(name);
            }
        }

        // 멤버 정보 편집 함수
        private void UpdateMemberNode(TreeNode target) // target = 선택한 노드
        {
            string tempName = TxtName.Text.Trim();
            string tempPart = TxtPart.Text.Trim();
            string tempUpdateStNum = TxtStNum.Text.Trim();
            string tempBirth = TxtBirth.Text.Trim();
            int tempAbsence = (int)TxtAbsence.Value;
            RemoveMember(target);
            AddMemberNode(tempName, tempPart, tempUpdateStNum, tempBirth, tempAbsence);
        }

        private void TxtBirth_MouseClick(object sender, MouseEventArgs e)
        {
            //TxtBirth.Text = string.Empty;

            //TxtBirth.SelectionStart = 0;
            //TxtBirth.ScrollToCaret();

            // 생일이랑 학번 입력 시 커서위치 바로잡기
        }

        private void EnableControl(GroupBox box, bool FT)
        {
            foreach (Control controlInGroupBox in box.Controls.OfType<Control>())
            {
                if (controlInGroupBox is not Label)
                {
                    controlInGroupBox.Enabled = FT;
                }

                // 그룹박스 안의 그룹박스는 걍 비활성화되서 특별조치
                if (controlInGroupBox is GroupBox)
                {
                    controlInGroupBox.Enabled = true;
                    foreach (Control BoxInBox in controlInGroupBox.Controls.OfType<Control>())
                    {
                        if (BoxInBox is not Label && controlInGroupBox != groupBox5)
                        {
                            BoxInBox.Enabled = FT;
                        }
                    }
                }
                if (box == groupBox2 && controlInGroupBox == BtnUpdate_Mem) // 편집버튼 살리기
                {
                    controlInGroupBox.Enabled = !FT;
                }
            }
        }

        private void LsvMember_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ViewMemberInfo();
        }


        private void BtnAdd_Date_Click(object sender, EventArgs e)
        {
            string title = TxtDateTitle_In.Text.Trim();
            string date = TxtDate_In.Text.Trim();
            string type = CboType_In.Text;
            string happening = TxtHappening_In.Text.Trim();
            int lstLen = LsvDate.Nodes.Count;
            if (title == "" || date == ""|| type == "")
            {
                MessageBox.Show("정보를 모두 입력해주세요", "입력 오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            AddDate(title, date, type, happening);
        }
        private void AddDate(string title, string date, string type, string happening)
        {
            dateInfos.Add(new DateInfo(title, date, type, happening));

            for (int i = 0; i < LsvDate.Nodes.Count; i++)
            {
                if (type == LsvDate.Nodes[i].Text)
                {
                    LsvDate.Nodes[i].Nodes.Add(title);
                    DeleteDateText();
                    return;
                }
            }
        }
        private void BtnCancle_AddDate_Click(object sender, EventArgs e)
        {
            DeleteDateText();
        }
        private void DeleteDateText()
        {
            TxtDate_In.Text = string.Empty;
            TxtHappening_In.Text = string.Empty;
            TxtDateTitle_In.Text = string.Empty;
            CboType_In.SelectedIndex = 0;
        }

        private void Calendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (dateSelectMode == true)
            {
                TxtDate_In.Text = e.End.ToShortDateString();
                TxtDateTitle_In.Text = e.End.ToShortDateString() + " " + CboType_In.Text;
            }
            else if (dateSelectMode == false)
            {
                TxtDate_View.Text = e.End.ToShortDateString();
            }
        }

        private void CboType_In_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Calendar.SelectionEnd.ToShortDateString() != null)
            {
                TxtDateTitle_In.Text = Calendar.SelectionEnd.ToShortDateString() + " " + CboType_In.Text;
            }
            else TxtDateTitle_In.Text = CboType_In.Text;
        }

        private void BtnDelete_Date_Click(object sender, EventArgs e)
        {
            if (LsvDate.SelectedNode == null || LsvDate.SelectedNode.Parent == null)
            {
                MessageBox.Show("삭제할 일정을 선택하세요.", "삭제 오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            RemoveDate(LsvDate.SelectedNode);
        }
        private void RemoveDate(TreeNode target)
        {
            int index = dateInfos.FindIndex(i => i.Title.Contains(target.Text));
            dateInfos.RemoveAt(index);
            target.Remove();
            LsvDate.SelectedNode = null;
        }

        private void LsvDate_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ViewDateInfo();
        }

        private void ViewDateInfo()
        {
            TreeNode target = LsvDate.SelectedNode;
            if (target.Parent != null)
            {
                TxtDateTitle_View.Text = target.Text;
                int index = dateInfos.FindIndex(i => i.Title.Contains(target.Text));
                TxtDate_View.Text = dateInfos[index].Date;
                TxtHappening_View.Text = dateInfos[index].Memo;
                //CboType_In.Text = dateInfos[index].Type;
                CboType_View.Text = dateInfos[index].Type;
            }
            else
            {
                DeleteDateInfo();
            }
        }
        private void DeleteDateInfo()
        {
            TxtDateTitle_View.Text = string.Empty;
            TxtDate_View.Text = string.Empty;
            TxtHappening_View.Text = string.Empty;
            CboType_View.SelectedItem = null;

            LsvDate.SelectedNode = null;
        }

        private void BtnUpdate_Date_Click(object sender, EventArgs e)
        {
            if (LsvDate.SelectedNode == null || LsvDate.SelectedNode.Parent == null)
            {
                MessageBox.Show("편집할 일정을 선택하세요.", "편집 오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DateEnableControl(false);
        }

        private void BtnCancle_DateUpdate_Click(object sender, EventArgs e)
        {
            DeleteDateInfo();
            DateEnableControl(true);
        }
        private void BtnOk_DateUpdate_Click(object sender, EventArgs e)
        {
            string tempTitle = TxtDateTitle_View.Text.Trim();
            string tempDate = TxtDate_View.Text.Trim();
            string tempType = CboType_View.Text;
            string tempHappening = TxtHappening_View.Text.Trim();
            if (tempDate == "" || tempTitle == "" || tempType == "")
            {
                MessageBox.Show("정보를 모두 입력해주세요", "입력 오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            RemoveDate(LsvDate.SelectedNode);
            AddDate(tempTitle, tempDate, tempType, tempHappening);

            DeleteDateInfo();
            DateEnableControl(true);
        }

        private void DateEnableControl(bool FT)
        {
            dateSelectMode = FT;

            EnableControl(groupBox1, FT);
            EnableControl(groupBox3, FT);
            BtnUpdate_Mem.Enabled = FT;

            BtnUpdate_Date.Visible = FT;
            BtnOk_DateUpdate.Visible = !FT;
            BtnCancle_DateUpdate.Visible = !FT;

            TxtDateTitle_View.Enabled = !FT;
            CboType_View.Enabled = !FT;
            TxtHappening_View.Enabled = !FT;
            TxtDate_View.Enabled = !FT;

            Calendar.Enabled = !FT;
        }

    }
}
