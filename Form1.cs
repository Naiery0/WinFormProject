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
        }

        // ���
        // �߰�
        private void BtnAdd_Mem_Click(object sender, EventArgs e)
        {
            MemberEnableControl(true);
        }

        // ���
        private void BtnCancle_AddMem_Click(object sender, EventArgs e)
        {
            MemberEnableControl(false);
            Add_or_Update = true;
        }

        // ����
        private void BtnOk_MemAdd_Click(object sender, EventArgs e)
        {
            switch (Add_or_Update) // Add�� ���� �߰���, Update�� ���� ������
            {
                case true:
                    BtnCancle_AddMem_Click (sender, e); 
                    break;
                case false:
                    BtnCancle_AddMem_Click (sender, e);
                    break;
            }
        }

        // ����
        private void BtnUpdate_Mem_Click(object sender, EventArgs e)
        {
            MemberEnableControl(true);
            Add_or_Update= false;
        }

        private void MemberEnableControl(bool FT)
        {
            TxtName.Enabled = FT;
            TxtBirth.Enabled = FT;
            TxtPart.Enabled = FT;
            TxtStNum.Enabled = FT;
            TxtAbsence.Enabled = FT;

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

        private void TxtBirth_MouseClick(object sender, MouseEventArgs e)
        {
            //TxtBirth.Text = string.Empty;

            //TxtBirth.SelectionStart = 0;
            //TxtBirth.ScrollToCaret();

            // �����̶� �й� �Է� �� Ŀ����ġ �ٷ����
        }

    }
}
