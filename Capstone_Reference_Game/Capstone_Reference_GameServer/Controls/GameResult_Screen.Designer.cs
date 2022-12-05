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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnl_Chart = new System.Windows.Forms.Panel();
            this.btn_GameStop = new System.Windows.Forms.Button();
            this.grid_Result = new System.Windows.Forms.DataGridView();
            this.StudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Answer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_submitter = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_CorrectAnswer = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_AnswerPercent = new System.Windows.Forms.Label();
            this.lbl_Time = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Result)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_Chart
            // 
            this.pnl_Chart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_Chart.Location = new System.Drawing.Point(15, 15);
            this.pnl_Chart.Name = "pnl_Chart";
            this.pnl_Chart.Size = new System.Drawing.Size(545, 400);
            this.pnl_Chart.TabIndex = 3;
            // 
            // btn_GameStop
            // 
            this.btn_GameStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.btn_GameStop.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_GameStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_GameStop.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_GameStop.ForeColor = System.Drawing.Color.Black;
            this.btn_GameStop.Location = new System.Drawing.Point(440, 515);
            this.btn_GameStop.Name = "btn_GameStop";
            this.btn_GameStop.Size = new System.Drawing.Size(120, 70);
            this.btn_GameStop.TabIndex = 4;
            this.btn_GameStop.Text = "게임 종료";
            this.btn_GameStop.UseVisualStyleBackColor = false;
            this.btn_GameStop.Click += new System.EventHandler(this.btn_GameStop_Click);
            // 
            // grid_Result
            // 
            this.grid_Result.AllowUserToAddRows = false;
            this.grid_Result.AllowUserToDeleteRows = false;
            this.grid_Result.AllowUserToResizeColumns = false;
            this.grid_Result.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.grid_Result.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grid_Result.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(30)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(30)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_Result.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grid_Result.ColumnHeadersHeight = 24;
            this.grid_Result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid_Result.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StudentID,
            this.StudentName,
            this.Answer,
            this.Result});
            this.grid_Result.EnableHeadersVisualStyles = false;
            this.grid_Result.GridColor = System.Drawing.Color.White;
            this.grid_Result.Location = new System.Drawing.Point(575, 15);
            this.grid_Result.MultiSelect = false;
            this.grid_Result.Name = "grid_Result";
            this.grid_Result.ReadOnly = true;
            this.grid_Result.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grid_Result.RowHeadersVisible = false;
            this.grid_Result.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.grid_Result.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.grid_Result.RowTemplate.Height = 25;
            this.grid_Result.RowTemplate.ReadOnly = true;
            this.grid_Result.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.grid_Result.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_Result.Size = new System.Drawing.Size(310, 570);
            this.grid_Result.TabIndex = 5;
            this.grid_Result.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_Result_CellClick);
            this.grid_Result.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_Result_RowEnter);
            // 
            // StudentID
            // 
            this.StudentID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(34)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(34)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.StudentID.DefaultCellStyle = dataGridViewCellStyle3;
            this.StudentID.FillWeight = 35F;
            this.StudentID.HeaderText = "학번";
            this.StudentID.Name = "StudentID";
            this.StudentID.ReadOnly = true;
            this.StudentID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // StudentName
            // 
            this.StudentName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StudentName.FillWeight = 35F;
            this.StudentName.HeaderText = "이름";
            this.StudentName.Name = "StudentName";
            this.StudentName.ReadOnly = true;
            // 
            // Answer
            // 
            this.Answer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Answer.FillWeight = 20F;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(139, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "제출자 : ";
            // 
            // lbl_submitter
            // 
            this.lbl_submitter.AutoSize = true;
            this.lbl_submitter.BackColor = System.Drawing.Color.Transparent;
            this.lbl_submitter.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_submitter.Location = new System.Drawing.Point(217, 23);
            this.lbl_submitter.Name = "lbl_submitter";
            this.lbl_submitter.Size = new System.Drawing.Size(35, 21);
            this.lbl_submitter.TabIndex = 0;
            this.lbl_submitter.Text = "0명";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(139, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "정답자 : ";
            // 
            // lbl_CorrectAnswer
            // 
            this.lbl_CorrectAnswer.AutoSize = true;
            this.lbl_CorrectAnswer.BackColor = System.Drawing.Color.Transparent;
            this.lbl_CorrectAnswer.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_CorrectAnswer.Location = new System.Drawing.Point(217, 67);
            this.lbl_CorrectAnswer.Name = "lbl_CorrectAnswer";
            this.lbl_CorrectAnswer.Size = new System.Drawing.Size(35, 21);
            this.lbl_CorrectAnswer.TabIndex = 0;
            this.lbl_CorrectAnswer.Text = "0명";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(139, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "정답률 : ";
            // 
            // lbl_AnswerPercent
            // 
            this.lbl_AnswerPercent.AutoSize = true;
            this.lbl_AnswerPercent.BackColor = System.Drawing.Color.Transparent;
            this.lbl_AnswerPercent.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_AnswerPercent.Location = new System.Drawing.Point(219, 111);
            this.lbl_AnswerPercent.Name = "lbl_AnswerPercent";
            this.lbl_AnswerPercent.Size = new System.Drawing.Size(33, 21);
            this.lbl_AnswerPercent.TabIndex = 0;
            this.lbl_AnswerPercent.Text = "0%";
            // 
            // lbl_Time
            // 
            this.lbl_Time.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Time.Font = new System.Drawing.Font("웰컴체 Regular", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_Time.Location = new System.Drawing.Point(440, 430);
            this.lbl_Time.Name = "lbl_Time";
            this.lbl_Time.Size = new System.Drawing.Size(120, 70);
            this.lbl_Time.TabIndex = 7;
            this.lbl_Time.Text = "00:00";
            this.lbl_Time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lbl_submitter);
            this.panel1.Controls.Add(this.lbl_CorrectAnswer);
            this.panel1.Controls.Add(this.lbl_AnswerPercent);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(15, 430);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(410, 155);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(0)))), ((int)(((byte)(238)))));
            this.panel2.Location = new System.Drawing.Point(440, 515);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(120, 5);
            this.panel2.TabIndex = 9;
            // 
            // GameResult_Screen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbl_Time);
            this.Controls.Add(this.grid_Result);
            this.Controls.Add(this.btn_GameStop);
            this.Controls.Add(this.pnl_Chart);
            this.Name = "GameResult_Screen";
            this.Size = new System.Drawing.Size(900, 600);
            this.Load += new System.EventHandler(this.GameResult_Screen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_Result)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnl_Chart;
        private Button btn_GameStop;
        private DataGridView grid_Result;
        private Label label1;
        private Label lbl_submitter;
        private Label label2;
        private Label lbl_CorrectAnswer;
        private Label label3;
        private Label lbl_AnswerPercent;
        private Label lbl_Time;
        private System.Windows.Forms.Timer timer;
        private Panel panel1;
        private DataGridViewTextBoxColumn StudentID;
        private DataGridViewTextBoxColumn StudentName;
        private DataGridViewTextBoxColumn Answer;
        private DataGridViewTextBoxColumn Result;
        private Panel panel2;
    }
}
