namespace WinFormProject
{
    public partial class Form1 : Form
    {
        bool Add_or_Update = true; // true�� Add 
        //List<string> partList = new List<string>();
        List<string> stNumList = new List<string>();
        List<PartInfo> partInfos = new List<PartInfo>();
        List<MemberInfo> memberInfos = new List<MemberInfo>();
        List<DayInfo> dayInfos = new List<DayInfo>();

        string tempStNum; // ��Ȱ�� ������ ����...

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
            BtnUpdate_Mem.Visible = false;
            Add_or_Update = true;
        }

        // ���
        private void BtnCancle_AddMem_Click(object sender, EventArgs e)
        {
            MemberEnableControl(false);
            EnableControl(groupBox3, true);
            BtnUpdate_Mem.Visible = true;
        }

        // ����
        private void BtnOk_MemAdd_Click(object sender, EventArgs e)
        {
            switch (Add_or_Update) // Add�� ���� �߰���, Update�� ���� ������
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

        // ����
        private void BtnUpdate_Mem_Click(object sender, EventArgs e)
        {
            if (LsvMember.SelectedNode == null)
            {
                MessageBox.Show("������ ����� �����ϼ���.", "���� ����",
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


        // ����
        private void BtnDelete_Mem_Click(object sender, EventArgs e)
        {
            if (LsvMember.SelectedNode == null)
            {
                MessageBox.Show("������ ����� �����ϼ���.", "���� ����",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //LsvMember.Nodes.Remove(LsvMember.SelectedNode);
            RemoveMember(LsvMember.SelectedNode);
            DeleteMemberInfo();

        }

        private void RemoveMember(TreeNode target)
        {
            if (target.Parent == null) // ��Ʈ ����
            {
                int index = partInfos.FindIndex(i => i.Part.Contains(target.Text));
                //stNumList�� �ִ� �͵� ��Ʈ����.��� ��ȸ�ϸ鼭 �����
                foreach (string stNum in partInfos[index].Member)
                {
                    if (stNumList.Contains(stNum))
                    {
                        stNumList.Remove(stNum);
                    }
                }
                partInfos.RemoveAt(index);
                // �̷��� ��� ��ü�� ����� �����ֱ� �ѵ�... �����Ǹ� ���ִ� �۾� ����
                // ���� �Ǹ��� �ƴ϶� ������ �ؾ� �� ��
            }
            else // ��� ����
            {
                int index = memberInfos.FindIndex(i => i.Name.Contains(target.Text));
                int removePart = partInfos.FindIndex(i => i.Part.Contains(memberInfos[index].Part));
                stNumList.Remove(memberInfos[index].StNum);
                partInfos[removePart].Member.Remove(memberInfos[index].StNum);
                memberInfos.RemoveAt(index);
            }
            LsvMember.Nodes.Remove(target); // ����Ʈ���� ����
            LsvMember.SelectedNode = null;
        }

        private void ViewMemberInfo()
        {
            DeleteMemberInfo();
            TreeNode target = LsvMember.SelectedNode;
            if (target.Parent != null)
            { // ����� �������� ��

                TxtName.Text = target.Text;
                TxtPart.Text = target.Parent.Text;
                int index = memberInfos.FindIndex(i => i.Name.Contains(target.Text));
                TxtBirth.Text = memberInfos[index].Birth;
                TxtStNum.Text = memberInfos[index].StNum;
                TxtAbsence.Value = memberInfos[index].Absence;
                tempStNum = TxtStNum.Text;
            }
            else
            { // ��Ʈ�� �������� ��
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

            LsvMember.Enabled = !FT;
            
            BtnOk_MemAdd.Visible = FT;
            BtnCancle_MemAdd.Visible = FT;
            BtnAdd_Mem.Visible = !FT;
            BtnDelete_Mem.Visible = !FT;

            if (FT == false)// ���� �����
            {
                DeleteMemberInfo();
                BtnAdd_Mem.Visible = !FT;
                BtnDelete_Mem.Visible = !FT;
            }
        }

        // ��� ��� ��� �߰� �Լ�
        private void AddMemberNode(string name, string part, string stNum, string birth, int absence)
        {
            if (stNumList.Contains(stNum))
            {
                MessageBox.Show("�̹� ��ϵ� ����Դϴ�.", "�й� �ߺ� ����",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //MessageBox.Show($"{part}");
                int lstLen = LsvMember.Nodes.Count;
                // ��� Ŭ���� ����
                memberInfos.Add(new MemberInfo(name, part, stNum, birth, absence));
                stNumList.Add(stNum);
                for (int i = 0; i < lstLen; i++)
                {
                    if (part.Equals(LsvMember.Nodes[i].Text) == true) // ��Ʈ�� ������ ��Ʈ�� �����
                    {
                        // ��Ʈ Ŭ������ ��� �߰�
                        int index = partInfos.FindIndex(i => i.Part.Contains(part)); // ��Ʈ �´� Ŭ���� ã��
                        partInfos[index].Member.Add(stNum);
                        // ��忡 �߰�
                        LsvMember.Nodes[i].Nodes.Add(name);
                        return;
                    }
                }
                LsvMember.Nodes.Add(part); // ��Ʈ ������ �����
                partInfos.Add(new PartInfo(part, stNum));  // ��Ʈ�� ������ ��Ʈ ����

                LsvMember.Nodes[lstLen].Nodes.Add(name);
            }
        }

        // ��� ���� ���� �Լ�
        private void UpdateMemberNode(TreeNode target) // target = ������ ���
        {
            // �ش� �ε��� �����ϰ� �ٽ� �߰��ϴ� ����� Ȯ���� ��
            if (target.Parent != null) // ����� ����������
            { 
                //if (target.Parent.Text == TxtPart.Text)
                //{ // ��Ʈ ������ ���ٸ�
                //    //target.Text = TxtName.Text;

                //}
                //else // ��Ʈ ���� ��
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

            // �����̶� �й� �Է� �� Ŀ����ġ �ٷ����
        }

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
                        if (BoxInBox is not Label && BoxInBox != TxtDate_In)
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

        private void LsvMember_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ViewMemberInfo();
        }
    }
}
