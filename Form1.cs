namespace WinFormProject
{
    public partial class Form1 : Form
    {
        bool Add_or_Update = true; // true는 Add 
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
            Add_or_Update = true;
        }

        // 취소
        private void BtnCancle_AddMem_Click(object sender, EventArgs e)
        {
            MemberEnableControl(false);
            EnableControl(groupBox3, true);
        }

        // 저장
        private void BtnOk_MemAdd_Click(object sender, EventArgs e)
        {
            switch (Add_or_Update) // Add면 정보 추가를, Update면 정보 수정을
            {
                case true:
                    AddMemberNode(TxtName.Text, TxtPart.Text);
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
            MemberEnableControl(true);
            EnableControl(groupBox3, false);
            Add_or_Update = false;
        }


        // 삭제
        private void BtnDelete_Mem_Click(object sender, EventArgs e)
        {
            LsvMember.Nodes.Remove(LsvMember.SelectedNode);
        }

        // 멤버 선택 시
        private void LsvMember_AfterSelect(object sender, TreeViewEventArgs e)
        {
            BtnUpdate_Mem.Visible = true;
        } //... 선택 해제하면 다시 숨기기 어케함?


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

            BtnOk_MemAdd.Visible = FT;
            BtnCancle_MemAdd.Visible = FT;
            BtnAdd_Mem.Visible = !FT;
            BtnDelete_Mem.Visible = !FT;

            if (FT == false)// 내용 지우기
            {
                TxtAbsence.Value = 0;
                TxtBirth.Text = string.Empty;
                TxtPart.Text = string.Empty;
                TxtStNum.Text = string.Empty;
                TxtName.Text = string.Empty;
                BtnAdd_Mem.Visible = !FT;
                BtnDelete_Mem.Visible = !FT;
            }
        }

        // 멤버 목록 노드 추가 함수
        private void AddMemberNode(string name, string part)
        {
            int lstLen = LsvMember.Nodes.Count;
            for (int i = 0; i < lstLen; i++)
            {
                if (part.Equals(LsvMember.Nodes[i].Text) == true) // 파트가 있으면 파트에 멤버를
                {
                    LsvMember.Nodes[i].Nodes.Add(name);
                    return;
                }
            }
            LsvMember.Nodes.Add(part); // 파트 없으면 만들어
            LsvMember.Nodes[lstLen].Nodes.Add(name);
        }

        // 멤버 정보 편집 함수
        private void UpdateMemberNode(TreeNode target)
        {
            if (target.Parent != null) { // 사람을 선택했으며
                if (target.Parent.Text == TxtPart.Text) { // 파트 변경이 없다면
                    target.Text = TxtName.Text;
                } 
            }
            else
            {
                target.Text = TxtPart.Text;
            }
        }


        private void TxtBirth_MouseClick(object sender, MouseEventArgs e)
        {
            //TxtBirth.Text = string.Empty;

            //TxtBirth.SelectionStart = 0;
            //TxtBirth.ScrollToCaret();

            // 생일이랑 학번 입력 시 커서위치 바로잡기
        }

        // 
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
                        if (BoxInBox is not Label)
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
    }
}
