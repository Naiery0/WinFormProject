namespace WinFormProject
{
    public partial class Form1 : Form
    {
        bool Add_or_Update = true; // true�� Add 
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MemberEnableControl(false);
        }

        // ���
        // �߰�
        private void BtnAdd_Mem_Click(object sender, EventArgs e)
        {
            MemberEnableControl(true);
            EnableControl(groupBox3, false);
            Add_or_Update = true;
        }

        // ���
        private void BtnCancle_AddMem_Click(object sender, EventArgs e)
        {
            MemberEnableControl(false);
            EnableControl(groupBox3, true);
        }

        // ����
        private void BtnOk_MemAdd_Click(object sender, EventArgs e)
        {
            switch (Add_or_Update) // Add�� ���� �߰���, Update�� ���� ������
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

        // ����
        private void BtnUpdate_Mem_Click(object sender, EventArgs e)
        {
            MemberEnableControl(true);
            EnableControl(groupBox3, false);
            Add_or_Update = false;
        }


        // ����
        private void BtnDelete_Mem_Click(object sender, EventArgs e)
        {
            LsvMember.Nodes.Remove(LsvMember.SelectedNode);
        }

        // ��� ���� ��
        private void LsvMember_AfterSelect(object sender, TreeViewEventArgs e)
        {
            BtnUpdate_Mem.Visible = true;
        } //... ���� �����ϸ� �ٽ� ����� ������?


        // ��� ��ư/�ؽ�Ʈ ��Ʈ��
        private void MemberEnableControl(bool FT)
        {
            //TxtName.Enabled = FT;
            //TxtBirth.Enabled = FT;
            //TxtPart.Enabled = FT;
            //TxtStNum.Enabled = FT;
            //TxtAbsence.Enabled = FT;
            //groupBox2.Enabled = FT; // �̰� �ǳ�... �ٺ����ߴ�
            EnableControl(groupBox2, FT); // ������ �󺧵� ���������� ���� �Լ�

            BtnOk_MemAdd.Visible = FT;
            BtnCancle_MemAdd.Visible = FT;
            BtnAdd_Mem.Visible = !FT;
            BtnDelete_Mem.Visible = !FT;

            if (FT == false)// ���� �����
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

        // ��� ��� ��� �߰� �Լ�
        private void AddMemberNode(string name, string part)
        {
            int lstLen = LsvMember.Nodes.Count;
            for (int i = 0; i < lstLen; i++)
            {
                if (part.Equals(LsvMember.Nodes[i].Text) == true) // ��Ʈ�� ������ ��Ʈ�� �����
                {
                    LsvMember.Nodes[i].Nodes.Add(name);
                    return;
                }
            }
            LsvMember.Nodes.Add(part); // ��Ʈ ������ �����
            LsvMember.Nodes[lstLen].Nodes.Add(name);
        }

        // ��� ���� ���� �Լ�
        private void UpdateMemberNode(TreeNode target)
        {
            if (target.Parent != null) { // ����� ����������
                if (target.Parent.Text == TxtPart.Text) { // ��Ʈ ������ ���ٸ�
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

            // �����̶� �й� �Է� �� Ŀ����ġ �ٷ����
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
                // �׷�ڽ� ���� �׷�ڽ��� �� ��Ȱ��ȭ�Ǽ� Ư����ġ
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
                if (controlInGroupBox == BtnUpdate_Mem) // ������ư �츮��
                {
                    controlInGroupBox.Enabled = !FT;
                }
            } // �׷�ڽ��� �� ������ ��Ʈ�Ѹ� ����
        }
    }
}
