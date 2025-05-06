using System.Xml.Linq;
using System;
using System.Reflection;

namespace WinFormProject
{
    public partial class Form1 : Form
    {
        bool Add_or_Update = true; // true�� Add 
        List<string> stNumList = new List<string>();
        List<PartInfo> partInfos = new List<PartInfo>();
        // ��Ʈ ������ ���� �ʿ��Ѱ�?
        // -> ������ �ʿ� ���� �ѵ� ���� ���׷��̵带 �Ѵٸ� �ʿ�������...? 
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

        // ���
        // �߰�
        private void BtnAdd_Mem_Click(object sender, EventArgs e)
        {
            MemberEnableControl(true);
            EnableControl(groupBox3, false);
            DeleteMemberInfo();

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
            if (TxtName.Text.Trim() == "" || TxtPart.Text.Trim() == "" ||
                !TxtStNum.MaskFull || !TxtBirth.MaskFull)
            {
                MessageBox.Show("������ ��� �Է����ּ���", "�Է� ����", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }  
            switch (Add_or_Update) // Add�� ���� �߰���, Update�� ���� ������
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
            stNumList.Remove(TxtStNum.Text.Trim());

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
                        int memberIndex = memberInfos.FindIndex(i => i.StNum.Contains(stNum));
                        memberInfos.RemoveAt(memberIndex);
                    }
                }
                partInfos.RemoveAt(index);
            }
            else // ��� ����
            {
                int index = memberInfos.FindIndex(i => i.Name.Contains(target.Text));
                int removePart = partInfos.FindIndex(i => i.Part.Contains(memberInfos[index].Part));
                stNumList.Remove(memberInfos[index].StNum);
                partInfos[removePart].Member.Remove(memberInfos[index].StNum);
                memberInfos.RemoveAt(index);
            }
            //LsvMember.Nodes.Remove(target); // ����Ʈ���� ����
            target.Remove();
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
                //tempStNum = TxtStNum.Text;
            }
            else
            { // ��Ʈ�� �������� ��
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
            BtnUpdate_Date.Enabled = !FT;

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
                        if (BoxInBox is not Label && controlInGroupBox != groupBox5)
                        {
                            BoxInBox.Enabled = FT;
                        }
                    }
                }
                if (box == groupBox2 && controlInGroupBox == BtnUpdate_Mem) // ������ư �츮��
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
                MessageBox.Show("������ ��� �Է����ּ���", "�Է� ����",
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
                MessageBox.Show("������ ������ �����ϼ���.", "���� ����",
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
                MessageBox.Show("������ ������ �����ϼ���.", "���� ����",
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
                MessageBox.Show("������ ��� �Է����ּ���", "�Է� ����",
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
