namespace WinFormProject
{
    public partial class Form1 : Form
    {
        bool Add_or_Update = true; // true는 Add 
        //List<string> partList = new List<string>();
        List<string> stNumList = new List<string>();
        List<PartInfo> partInfos = new List<PartInfo>();
        List<MemberInfo> memberInfos = new List<MemberInfo>();
        List<DayInfo> dayInfos = new List<DayInfo>();

        string tempStNum; // 원활한 편집을 위해...

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MemberEnableControl(false);
        }

        // 멤버
        // 추가
        private void BtnAdd_Mem_Click(object sender, EventArgs e)
        {
            MemberEnableControl(true);
            EnableControl(groupBox3, false);
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
            switch (Add_or_Update) // Add면 정보 추가를, Update면 정보 수정을
            {
                case true:
                    AddMemberNode(TxtName.Text, TxtPart.Text, TxtStNum.Text, TxtBirth.Text, (int)TxtAbsence.Value);
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
            stNumList.Remove(TxtStNum.Text);

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
                    }
                }
                partInfos.RemoveAt(index);
                // 이러면 멤버 객체가 허공에 남아있긴 한데... 여유되면 없애는 작업 ㄱㄱ
                // 여유 되면이 아니라 무조건 해야 할 듯
            }
            else // 멤버 삭제
            {
                int index = memberInfos.FindIndex(i => i.Name.Contains(target.Text));
                int removePart = partInfos.FindIndex(i => i.Part.Contains(memberInfos[index].Part));
                stNumList.Remove(memberInfos[index].StNum);
                partInfos[removePart].Member.Remove(memberInfos[index].StNum);
                memberInfos.RemoveAt(index);
            }
            LsvMember.Nodes.Remove(target); // 리스트에서 삭제
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
                tempStNum = TxtStNum.Text;
            }
            else
            { // 파트를 선택했을 때
                tempStNum = string.Empty;

                TxtPart.Text = target.Text;
            }
        }

        private void DeleteMemberInfo()
        {
            tempStNum = string.Empty;

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
            // 해당 인덱스 제거하고 다시 추가하는 방식이 확실할 듯
            if (target.Parent != null) // 사람을 선택했으면
            { 
                //if (target.Parent.Text == TxtPart.Text)
                //{ // 파트 변경이 없다면
                //    //target.Text = TxtName.Text;

                //}
                //else // 파트 변경 시
                //{
                //}
            }
            else
            {
                //target.Text = TxtPart.Text;
            }
            string tempName = TxtName.Text;
            string tempPart = TxtPart.Text;
            string tempUpdateStNum = TxtStNum.Text;
            string tempBirth = TxtBirth.Text;
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
                        if (BoxInBox is not Label && BoxInBox != TxtDate_In)
                        {
                            BoxInBox.Enabled = FT;
                        }
                    }
                }
                if (controlInGroupBox == BtnUpdate_Mem) // 편집버튼 살리기
                {
                    controlInGroupBox.Enabled = !FT;
                }
            } // 그룹박스내 라벨 제외한 컨트롤만 제어
        }

        private void LsvMember_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ViewMemberInfo();
        }
    }
}
