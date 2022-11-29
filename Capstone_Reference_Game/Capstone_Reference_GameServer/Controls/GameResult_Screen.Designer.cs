namespace Capstone_Reference_GameServer.Controls
{
    partial class GameResult_Screen
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_GameStop = new System.Windows.Forms.Button();
            this.grid_Result = new System.Windows.Forms.DataGridView();
            this.StudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Answer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_submitter = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_CorrectAnswer = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_AnswerPercent = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Result)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(408, 228);
            this.panel1.TabIndex = 3;
            // 
            // btn_GameStop
            // 
            this.btn_GameStop.Location = new System.Drawing.Point(283, 246);
            this.btn_GameStop.Name = "btn_GameStop";
            this.btn_GameStop.Size = new System.Drawing.Size(137, 142);
            this.btn_GameStop.TabIndex = 4;
            this.btn_GameStop.Text = "게임 종료";
            this.btn_GameStop.UseVisualStyleBackColor = true;
            this.btn_GameStop.Click += new System.EventHandler(this.btn_GameStop_Click);
            // 
            // grid_Result
            // 
            this.grid_Result.BackgroundColor = System.Drawing.Color.White;
            this.grid_Result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_Result.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StudentID,
            this.Answer,
            this.Result});
            this.grid_Result.GridColor = System.Drawing.Color.White;
            this.grid_Result.Location = new System.Drawing.Point(426, 12);
            this.grid_Result.MultiSelect = false;
            this.grid_Result.Name = "grid_Result";
            this.grid_Result.ReadOnly = true;
            this.grid_Result.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grid_Result.RowHeadersVisible = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.grid_Result.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grid_Result.RowTemplate.Height = 25;
            this.grid_Result.RowTemplate.ReadOnly = true;
            this.grid_Result.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.grid_Result.Size = new System.Drawing.Size(312, 376);
            this.grid_Result.TabIndex = 5;
            // 
            // StudentID
            // 
            this.StudentID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StudentID.FillWeight = 40F;
            this.StudentID.HeaderText = "학번";
            this.StudentID.Name = "StudentID";
            this.StudentID.ReadOnly = true;
            this.StudentID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Answer
            // 
            this.Answer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Answer.FillWeight = 40F;
            this.Answer.HeaderText = "정답";
            this.Answer.Name = "Answer";
            this.Answer.ReadOnly = true;
            this.Answer.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Result
            // 
            this.Result.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Result.FillWeight = 20F;
            this.Result.HeaderText = "결과";
            this.Result.Name = "Result";
            this.Result.ReadOnly = true;
            this.Result.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_submitter, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbl_CorrectAnswer, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbl_AnswerPercent, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 246);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(265, 142);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "제출자 : ";
            // 
            // lbl_submitter
            // 
            this.lbl_submitter.AutoSize = true;
            this.lbl_submitter.Location = new System.Drawing.Point(63, 0);
            this.lbl_submitter.Name = "lbl_submitter";
            this.lbl_submitter.Size = new System.Drawing.Size(26, 15);
            this.lbl_submitter.TabIndex = 0;
            this.lbl_submitter.Text = "0명";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "정답자 : ";
            // 
            // lbl_CorrectAnswer
            // 
            this.lbl_CorrectAnswer.AutoSize = true;
            this.lbl_CorrectAnswer.Location = new System.Drawing.Point(63, 15);
            this.lbl_CorrectAnswer.Name = "lbl_CorrectAnswer";
            this.lbl_CorrectAnswer.Size = new System.Drawing.Size(26, 15);
            this.lbl_CorrectAnswer.TabIndex = 0;
            this.lbl_CorrectAnswer.Text = "0명";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "정답률 : ";
            // 
            // lbl_AnswerPercent
            // 
            this.lbl_AnswerPercent.AutoSize = true;
            this.lbl_AnswerPercent.Location = new System.Drawing.Point(63, 30);
            this.lbl_AnswerPercent.Name = "lbl_AnswerPercent";
            this.lbl_AnswerPercent.Size = new System.Drawing.Size(24, 15);
            this.lbl_AnswerPercent.TabIndex = 0;
            this.lbl_AnswerPercent.Text = "0%";
            // 
            // GameResult_Screen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.grid_Result);
            this.Controls.Add(this.btn_GameStop);
            this.Controls.Add(this.panel1);
            this.Name = "GameResult_Screen";
            this.Size = new System.Drawing.Size(750, 400);
            ((System.ComponentModel.ISupportInitialize)(this.grid_Result)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Button btn_GameStop;
        private DataGridView grid_Result;
        private DataGridViewTextBoxColumn StudentID;
        private DataGridViewTextBoxColumn Answer;
        private DataGridViewTextBoxColumn Result;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label lbl_submitter;
        private Label label2;
        private Label lbl_CorrectAnswer;
        private Label label3;
        private Label lbl_AnswerPercent;
    }
}
