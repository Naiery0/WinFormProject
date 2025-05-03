namespace WinFormProject
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TreeNode treeNode1 = new TreeNode("연습");
            TreeNode treeNode2 = new TreeNode("공연");
            TreeNode treeNode3 = new TreeNode("기타 행사");
            groupBox1 = new GroupBox();
            BtnDelete_Mem = new Button();
            BtnAdd_Mem = new Button();
            LsvMember = new TreeView();
            groupBox2 = new GroupBox();
            BtnUpdate_Mem = new Button();
            TxtAbsence = new NumericUpDown();
            TxtStNum = new MaskedTextBox();
            TxtBirth = new MaskedTextBox();
            TxtPart = new TextBox();
            TxtName = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label6 = new Label();
            label2 = new Label();
            label1 = new Label();
            BtnCancle_MemAdd = new Button();
            BtnOk_MemAdd = new Button();
            menuStrip1 = new MenuStrip();
            불러오기ToolStripMenuItem = new ToolStripMenuItem();
            저장ToolStripMenuItem = new ToolStripMenuItem();
            다른이름으로저장ToolStripMenuItem = new ToolStripMenuItem();
            만든이ToolStripMenuItem = new ToolStripMenuItem();
            Calendar = new MonthCalendar();
            groupBox3 = new GroupBox();
            BtnDelete_Date = new Button();
            groupBox5 = new GroupBox();
            BtnCancle_DateUpdate = new Button();
            TxtHappening_View = new TextBox();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            CboType_View = new ComboBox();
            TxtDate_View = new TextBox();
            BtnUpdate_Date = new Button();
            BtnOk_DateUpdate = new Button();
            groupBox4 = new GroupBox();
            BtnCancle_AddDate = new Button();
            BtnAdd_Date = new Button();
            TxtHappening_In = new TextBox();
            label8 = new Label();
            label7 = new Label();
            label5 = new Label();
            CboType_In = new ComboBox();
            TxtDate_In = new TextBox();
            LsvDate = new TreeView();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TxtAbsence).BeginInit();
            menuStrip1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(BtnDelete_Mem);
            groupBox1.Controls.Add(BtnAdd_Mem);
            groupBox1.Controls.Add(LsvMember);
            groupBox1.Location = new Point(11, 40);
            groupBox1.Margin = new Padding(4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4);
            groupBox1.Size = new Size(321, 347);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "멤버 명단";
            // 
            // BtnDelete_Mem
            // 
            BtnDelete_Mem.Location = new Point(249, -1);
            BtnDelete_Mem.Name = "BtnDelete_Mem";
            BtnDelete_Mem.Size = new Size(66, 34);
            BtnDelete_Mem.TabIndex = 2;
            BtnDelete_Mem.Text = "삭제";
            BtnDelete_Mem.UseVisualStyleBackColor = true;
            BtnDelete_Mem.Click += BtnDelete_Mem_Click;
            // 
            // BtnAdd_Mem
            // 
            BtnAdd_Mem.Location = new Point(177, -1);
            BtnAdd_Mem.Name = "BtnAdd_Mem";
            BtnAdd_Mem.Size = new Size(66, 34);
            BtnAdd_Mem.TabIndex = 1;
            BtnAdd_Mem.Text = "추가";
            BtnAdd_Mem.UseVisualStyleBackColor = true;
            BtnAdd_Mem.Click += BtnAdd_Mem_Click;
            // 
            // LsvMember
            // 
            LsvMember.Location = new Point(7, 35);
            LsvMember.Name = "LsvMember";
            LsvMember.Size = new Size(307, 306);
            LsvMember.TabIndex = 3;
            LsvMember.AfterSelect += LsvMember_AfterSelect;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(BtnUpdate_Mem);
            groupBox2.Controls.Add(TxtAbsence);
            groupBox2.Controls.Add(TxtStNum);
            groupBox2.Controls.Add(TxtBirth);
            groupBox2.Controls.Add(TxtPart);
            groupBox2.Controls.Add(TxtName);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(BtnCancle_MemAdd);
            groupBox2.Controls.Add(BtnOk_MemAdd);
            groupBox2.Location = new Point(12, 393);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(320, 264);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "멤버 정보";
            // 
            // BtnUpdate_Mem
            // 
            BtnUpdate_Mem.Location = new Point(247, -1);
            BtnUpdate_Mem.Name = "BtnUpdate_Mem";
            BtnUpdate_Mem.Size = new Size(66, 34);
            BtnUpdate_Mem.TabIndex = 6;
            BtnUpdate_Mem.Text = "편집";
            BtnUpdate_Mem.UseVisualStyleBackColor = true;
            BtnUpdate_Mem.Click += BtnUpdate_Mem_Click;
            // 
            // TxtAbsence
            // 
            TxtAbsence.Location = new Point(93, 206);
            TxtAbsence.Name = "TxtAbsence";
            TxtAbsence.Size = new Size(86, 34);
            TxtAbsence.TabIndex = 8;
            TxtAbsence.TextAlign = HorizontalAlignment.Center;
            // 
            // TxtStNum
            // 
            TxtStNum.Location = new Point(93, 126);
            TxtStNum.Mask = "9999999999";
            TxtStNum.Name = "TxtStNum";
            TxtStNum.Size = new Size(199, 34);
            TxtStNum.TabIndex = 6;
            TxtStNum.ValidatingType = typeof(int);
            // 
            // TxtBirth
            // 
            TxtBirth.Location = new Point(93, 166);
            TxtBirth.Mask = "0000년 90월 90일";
            TxtBirth.Name = "TxtBirth";
            TxtBirth.Size = new Size(199, 34);
            TxtBirth.TabIndex = 7;
            TxtBirth.ValidatingType = typeof(DateTime);
            TxtBirth.MouseClick += TxtBirth_MouseClick;
            // 
            // TxtPart
            // 
            TxtPart.Location = new Point(93, 86);
            TxtPart.Name = "TxtPart";
            TxtPart.Size = new Size(199, 34);
            TxtPart.TabIndex = 5;
            // 
            // TxtName
            // 
            TxtName.Location = new Point(93, 46);
            TxtName.Name = "TxtName";
            TxtName.Size = new Size(199, 34);
            TxtName.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(23, 89);
            label4.Name = "label4";
            label4.Size = new Size(64, 28);
            label4.TabIndex = 4;
            label4.Text = "파트 :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 129);
            label3.Name = "label3";
            label3.Size = new Size(64, 28);
            label3.TabIndex = 4;
            label3.Text = "학번 :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(23, 206);
            label6.Name = "label6";
            label6.Size = new Size(64, 28);
            label6.TabIndex = 4;
            label6.Text = "결석 :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 169);
            label2.Name = "label2";
            label2.Size = new Size(64, 28);
            label2.TabIndex = 4;
            label2.Text = "생일 :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 49);
            label1.Name = "label1";
            label1.Size = new Size(64, 28);
            label1.TabIndex = 4;
            label1.Text = "이름 :";
            // 
            // BtnCancle_MemAdd
            // 
            BtnCancle_MemAdd.Location = new Point(176, -1);
            BtnCancle_MemAdd.Name = "BtnCancle_MemAdd";
            BtnCancle_MemAdd.Size = new Size(66, 34);
            BtnCancle_MemAdd.TabIndex = 9;
            BtnCancle_MemAdd.Text = "취소";
            BtnCancle_MemAdd.UseVisualStyleBackColor = true;
            BtnCancle_MemAdd.Visible = false;
            BtnCancle_MemAdd.Click += BtnCancle_AddMem_Click;
            // 
            // BtnOk_MemAdd
            // 
            BtnOk_MemAdd.Location = new Point(247, -1);
            BtnOk_MemAdd.Name = "BtnOk_MemAdd";
            BtnOk_MemAdd.Size = new Size(66, 34);
            BtnOk_MemAdd.TabIndex = 8;
            BtnOk_MemAdd.Text = "저장";
            BtnOk_MemAdd.UseVisualStyleBackColor = true;
            BtnOk_MemAdd.Visible = false;
            BtnOk_MemAdd.Click += BtnOk_MemAdd_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { 불러오기ToolStripMenuItem, 저장ToolStripMenuItem, 다른이름으로저장ToolStripMenuItem, 만든이ToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1002, 33);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // 불러오기ToolStripMenuItem
            // 
            불러오기ToolStripMenuItem.Name = "불러오기ToolStripMenuItem";
            불러오기ToolStripMenuItem.Size = new Size(64, 29);
            불러오기ToolStripMenuItem.Text = "열기";
            // 
            // 저장ToolStripMenuItem
            // 
            저장ToolStripMenuItem.Name = "저장ToolStripMenuItem";
            저장ToolStripMenuItem.Size = new Size(64, 29);
            저장ToolStripMenuItem.Text = "저장";
            // 
            // 다른이름으로저장ToolStripMenuItem
            // 
            다른이름으로저장ToolStripMenuItem.Name = "다른이름으로저장ToolStripMenuItem";
            다른이름으로저장ToolStripMenuItem.Size = new Size(184, 29);
            다른이름으로저장ToolStripMenuItem.Text = "다른 이름으로 저장";
            // 
            // 만든이ToolStripMenuItem
            // 
            만든이ToolStripMenuItem.Name = "만든이ToolStripMenuItem";
            만든이ToolStripMenuItem.Size = new Size(82, 29);
            만든이ToolStripMenuItem.Text = "만든이";
            // 
            // Calendar
            // 
            Calendar.Location = new Point(14, 39);
            Calendar.Name = "Calendar";
            Calendar.TabIndex = 5;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(BtnDelete_Date);
            groupBox3.Controls.Add(groupBox5);
            groupBox3.Controls.Add(groupBox4);
            groupBox3.Controls.Add(LsvDate);
            groupBox3.Controls.Add(Calendar);
            groupBox3.Location = new Point(339, 40);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(651, 617);
            groupBox3.TabIndex = 6;
            groupBox3.TabStop = false;
            groupBox3.Text = "일정 관리";
            // 
            // BtnDelete_Date
            // 
            BtnDelete_Date.Location = new Point(236, 304);
            BtnDelete_Date.Name = "BtnDelete_Date";
            BtnDelete_Date.Size = new Size(66, 34);
            BtnDelete_Date.TabIndex = 12;
            BtnDelete_Date.Text = "삭제";
            BtnDelete_Date.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(BtnCancle_DateUpdate);
            groupBox5.Controls.Add(TxtHappening_View);
            groupBox5.Controls.Add(label9);
            groupBox5.Controls.Add(label10);
            groupBox5.Controls.Add(label11);
            groupBox5.Controls.Add(CboType_View);
            groupBox5.Controls.Add(TxtDate_View);
            groupBox5.Controls.Add(BtnUpdate_Date);
            groupBox5.Controls.Add(BtnOk_DateUpdate);
            groupBox5.Location = new Point(324, 307);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(311, 290);
            groupBox5.TabIndex = 9;
            groupBox5.TabStop = false;
            groupBox5.Text = "일정 정보";
            // 
            // BtnCancle_DateUpdate
            // 
            BtnCancle_DateUpdate.Location = new Point(167, -1);
            BtnCancle_DateUpdate.Name = "BtnCancle_DateUpdate";
            BtnCancle_DateUpdate.Size = new Size(66, 34);
            BtnCancle_DateUpdate.TabIndex = 12;
            BtnCancle_DateUpdate.Text = "취소";
            BtnCancle_DateUpdate.UseVisualStyleBackColor = true;
            BtnCancle_DateUpdate.Visible = false;
            // 
            // TxtHappening_View
            // 
            TxtHappening_View.Enabled = false;
            TxtHappening_View.Location = new Point(6, 155);
            TxtHappening_View.Multiline = true;
            TxtHappening_View.Name = "TxtHappening_View";
            TxtHappening_View.Size = new Size(299, 128);
            TxtHappening_View.TabIndex = 11;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(16, 124);
            label9.Name = "label9";
            label9.Size = new Size(92, 28);
            label9.TabIndex = 10;
            label9.Text = "특이사항";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(16, 85);
            label10.Name = "label10";
            label10.Size = new Size(64, 28);
            label10.TabIndex = 10;
            label10.Text = "구분 :";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(16, 45);
            label11.Name = "label11";
            label11.Size = new Size(64, 28);
            label11.TabIndex = 10;
            label11.Text = "날짜 :";
            // 
            // CboType_View
            // 
            CboType_View.DropDownStyle = ComboBoxStyle.DropDownList;
            CboType_View.Enabled = false;
            CboType_View.FormattingEnabled = true;
            CboType_View.ImeMode = ImeMode.NoControl;
            CboType_View.Items.AddRange(new object[] { "연습", "공연", "기타 행사" });
            CboType_View.Location = new Point(82, 82);
            CboType_View.Name = "CboType_View";
            CboType_View.Size = new Size(179, 36);
            CboType_View.TabIndex = 9;
            // 
            // TxtDate_View
            // 
            TxtDate_View.Enabled = false;
            TxtDate_View.Location = new Point(82, 42);
            TxtDate_View.Name = "TxtDate_View";
            TxtDate_View.Size = new Size(179, 34);
            TxtDate_View.TabIndex = 8;
            // 
            // BtnUpdate_Date
            // 
            BtnUpdate_Date.Location = new Point(239, -1);
            BtnUpdate_Date.Name = "BtnUpdate_Date";
            BtnUpdate_Date.Size = new Size(66, 34);
            BtnUpdate_Date.TabIndex = 7;
            BtnUpdate_Date.Text = "편집";
            BtnUpdate_Date.UseVisualStyleBackColor = true;
            // 
            // BtnOk_DateUpdate
            // 
            BtnOk_DateUpdate.Location = new Point(239, -1);
            BtnOk_DateUpdate.Name = "BtnOk_DateUpdate";
            BtnOk_DateUpdate.Size = new Size(66, 34);
            BtnOk_DateUpdate.TabIndex = 13;
            BtnOk_DateUpdate.Text = "저장";
            BtnOk_DateUpdate.UseVisualStyleBackColor = true;
            BtnOk_DateUpdate.Visible = false;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(BtnCancle_AddDate);
            groupBox4.Controls.Add(BtnAdd_Date);
            groupBox4.Controls.Add(TxtHappening_In);
            groupBox4.Controls.Add(label8);
            groupBox4.Controls.Add(label7);
            groupBox4.Controls.Add(label5);
            groupBox4.Controls.Add(CboType_In);
            groupBox4.Controls.Add(TxtDate_In);
            groupBox4.Location = new Point(324, 15);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(311, 277);
            groupBox4.TabIndex = 9;
            groupBox4.TabStop = false;
            groupBox4.Text = "일정 추가";
            // 
            // BtnCancle_AddDate
            // 
            BtnCancle_AddDate.Location = new Point(167, 0);
            BtnCancle_AddDate.Name = "BtnCancle_AddDate";
            BtnCancle_AddDate.Size = new Size(66, 34);
            BtnCancle_AddDate.TabIndex = 14;
            BtnCancle_AddDate.Text = "취소";
            BtnCancle_AddDate.UseVisualStyleBackColor = true;
            BtnCancle_AddDate.Visible = false;
            // 
            // BtnAdd_Date
            // 
            BtnAdd_Date.Location = new Point(239, 0);
            BtnAdd_Date.Name = "BtnAdd_Date";
            BtnAdd_Date.Size = new Size(66, 34);
            BtnAdd_Date.TabIndex = 7;
            BtnAdd_Date.Text = "추가";
            BtnAdd_Date.UseVisualStyleBackColor = true;
            // 
            // TxtHappening_In
            // 
            TxtHappening_In.Location = new Point(6, 155);
            TxtHappening_In.Multiline = true;
            TxtHappening_In.Name = "TxtHappening_In";
            TxtHappening_In.Size = new Size(299, 116);
            TxtHappening_In.TabIndex = 11;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(16, 124);
            label8.Name = "label8";
            label8.Size = new Size(92, 28);
            label8.TabIndex = 10;
            label8.Text = "특이사항";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(16, 85);
            label7.Name = "label7";
            label7.Size = new Size(64, 28);
            label7.TabIndex = 10;
            label7.Text = "구분 :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 45);
            label5.Name = "label5";
            label5.Size = new Size(64, 28);
            label5.TabIndex = 10;
            label5.Text = "날짜 :";
            // 
            // CboType_In
            // 
            CboType_In.DropDownStyle = ComboBoxStyle.DropDownList;
            CboType_In.FormattingEnabled = true;
            CboType_In.Items.AddRange(new object[] { "연습", "공연", "기타 행사" });
            CboType_In.Location = new Point(82, 82);
            CboType_In.Name = "CboType_In";
            CboType_In.Size = new Size(179, 36);
            CboType_In.TabIndex = 9;
            // 
            // TxtDate_In
            // 
            TxtDate_In.Enabled = false;
            TxtDate_In.Location = new Point(82, 42);
            TxtDate_In.Name = "TxtDate_In";
            TxtDate_In.PlaceholderText = "달력에서 선택";
            TxtDate_In.Size = new Size(179, 34);
            TxtDate_In.TabIndex = 8;
            // 
            // LsvDate
            // 
            LsvDate.Location = new Point(14, 320);
            LsvDate.Name = "LsvDate";
            treeNode1.Name = "DayPractice";
            treeNode1.Text = "연습";
            treeNode2.Name = "DayConcert";
            treeNode2.Text = "공연";
            treeNode3.Name = "DayEvent";
            treeNode3.Text = "기타 행사";
            LsvDate.Nodes.AddRange(new TreeNode[] { treeNode1, treeNode2, treeNode3 });
            LsvDate.Size = new Size(298, 276);
            LsvDate.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(12F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1002, 669);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(menuStrip1);
            Font = new Font("맑은 고딕", 10F, FontStyle.Bold, GraphicsUnit.Point, 129);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4);
            Name = "Form1";
            Text = "멤버 관리 프로그램";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TxtAbsence).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label2;
        private Label label1;
        private Label label4;
        private Label label3;
        private Label label6;
        private TextBox TxtPart;
        private TextBox TxtName;
        private MaskedTextBox TxtStNum;
        private MaskedTextBox TxtBirth;
        private TreeView LsvMember;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem 불러오기ToolStripMenuItem;
        private ToolStripMenuItem 저장ToolStripMenuItem;
        private ToolStripMenuItem 다른이름으로저장ToolStripMenuItem;
        private ToolStripMenuItem 만든이ToolStripMenuItem;
        private MonthCalendar Calendar;
        private NumericUpDown TxtAbsence;
        private Button BtnDelete_Mem;
        private Button BtnAdd_Mem;
        private GroupBox groupBox3;
        private TreeView LsvDate;
        private Button BtnUpdate_Mem;
        private GroupBox groupBox4;
        private ComboBox CboType_In;
        private TextBox TxtDate_In;
        private GroupBox groupBox5;
        private TextBox TxtHappening_View;
        private Label label9;
        private Label label10;
        private Label label11;
        private ComboBox CboType_View;
        private TextBox TxtDate_View;
        private TextBox TxtHappening_In;
        private Label label8;
        private Label label7;
        private Label label5;
        private Button BtnOk_MemAdd;
        private Button BtnDelete_Date;
        private Button BtnCancle_DateUpdate;
        private Button BtnUpdate_Date;
        private Button BtnAdd_Date;
        private Button BtnOk_DateUpdate;
        private Button BtnCancle_MemAdd;
        private Button BtnCancle_AddDate;
    }
}
