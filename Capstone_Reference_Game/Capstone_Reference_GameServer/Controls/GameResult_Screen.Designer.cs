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
            this.pnl_Chart = new System.Windows.Forms.Panel();
            this.btn_GameStop = new System.Windows.Forms.Button();
            this.grid_Result = new System.Windows.Forms.DataGridView();
            this.StudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Answer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlp_statistics = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_submitter = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_CorrectAnswer = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_AnswerPercent = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grid_Result)).BeginInit();
            this.tlp_statistics.SuspendLayout();
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
            this.btn_GameStop.Location = new System.Drawing.Point(440, 520);
            this.btn_GameStop.Name = "btn_GameStop";
            this.btn_GameStop.Size = new System.Drawing.Size(120, 65);
            this.btn_GameStop.TabIndex = 4;
            this.btn_GameStop.Text = "게임 종료";
            this.btn_GameStop.UseVisualStyleBackColor = true;
            this.btn_GameStop.Click += new System.EventHandler(this.btn_GameStop_Click);
            // 
            // grid_Result
            // 
            this.grid_Result.AllowUserToAddRows = false;
            this.grid_Result.AllowUserToDeleteRows = false;
            this.grid_Result.AllowUserToResizeColumns = false;
            this.grid_Result.AllowUserToResizeRows = false;
            this.grid_Result.BackgroundColor = System.Drawing.Color.White;
            this.grid_Result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_Result.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StudentName,
            this.StudentID,
            this.Answer,
            this.Result});
            this.grid_Result.GridColor = System.Drawing.Color.White;
            this.grid_Result.Location = new System.Drawing.Point(575, 15);
            this.grid_Result.MultiSelect = false;
            this.grid_Result.Name = "grid_Result";
            this.grid_Result.ReadOnly = true;
            this.grid_Result.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grid_Result.RowHeadersVisible = false;
            this.grid_Result.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.grid_Result.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grid_Result.RowTemplate.Height = 25;
            this.grid_Result.RowTemplate.ReadOnly = true;
            this.grid_Result.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.grid_Result.Size = new System.Drawing.Size(310, 570);
            this.grid_Result.TabIndex = 5;
            // 
            // StudentName
            // 
            this.StudentName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StudentName.FillWeight = 35F;
            this.StudentName.HeaderText = "이름";
            this.StudentName.Name = "StudentName";
            this.StudentName.ReadOnly = true;
            // 
            // StudentID
            // 
            this.StudentID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StudentID.FillWeight = 35F;
            this.StudentID.HeaderText = "학번";
            this.StudentID.Name = "StudentID";
            this.StudentID.ReadOnly = true;
            this.StudentID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
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
            // tlp_statistics
            // 
            this.tlp_statistics.ColumnCount = 2;
            this.tlp_statistics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlp_statistics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlp_statistics.Controls.Add(this.label1, 0, 0);
            this.tlp_statistics.Controls.Add(this.lbl_submitter, 1, 0);
            this.tlp_statistics.Controls.Add(this.label2, 0, 1);
            this.tlp_statistics.Controls.Add(this.lbl_CorrectAnswer, 1, 1);
            this.tlp_statistics.Controls.Add(this.label3, 0, 2);
            this.tlp_statistics.Controls.Add(this.lbl_AnswerPercent, 1, 2);
            this.tlp_statistics.Location = new System.Drawing.Point(15, 430);
            this.tlp_statistics.Name = "tlp_statistics";
            this.tlp_statistics.RowCount = 3;
            this.tlp_statistics.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp_statistics.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp_statistics.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_statistics.Size = new System.Drawing.Size(410, 155);
            this.tlp_statistics.TabIndex = 6;
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
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("웰컴체 Regular", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(440, 430);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 75);
            this.label4.TabIndex = 7;
            this.label4.Text = "00 : 00";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            // 
            // GameResult_Screen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tlp_statistics);
            this.Controls.Add(this.grid_Result);
            this.Controls.Add(this.btn_GameStop);
            this.Controls.Add(this.pnl_Chart);
            this.Name = "GameResult_Screen";
            this.Size = new System.Drawing.Size(900, 600);
            this.Load += new System.EventHandler(this.GameResult_Screen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_Result)).EndInit();
            this.tlp_statistics.ResumeLayout(false);
            this.tlp_statistics.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnl_Chart;
        private Button btn_GameStop;
        private DataGridView grid_Result;
        private TableLayoutPanel tlp_statistics;
        private Label label1;
        private Label lbl_submitter;
        private Label label2;
        private Label lbl_CorrectAnswer;
        private Label label3;
        private Label lbl_AnswerPercent;
        private DataGridViewTextBoxColumn StudentName;
        private DataGridViewTextBoxColumn StudentID;
        private DataGridViewTextBoxColumn Answer;
        private DataGridViewTextBoxColumn Result;
        private Label label4;
        private System.Windows.Forms.Timer timer;
    }
}
