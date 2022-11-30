namespace Capstone_Reference_GameServer.Controls
{
    partial class OXChart_Screen
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnl_OChart = new System.Windows.Forms.Panel();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightCoral;
            this.panel1.Location = new System.Drawing.Point(102, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 37);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "O";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(332, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "X";
            // 
            // pnl_OChart
            // 
            this.pnl_OChart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(155)))), ((int)(((byte)(254)))));
            this.pnl_OChart.Location = new System.Drawing.Point(102, 70);
            this.pnl_OChart.Name = "pnl_OChart";
            this.pnl_OChart.Size = new System.Drawing.Size(100, 37);
            this.pnl_OChart.TabIndex = 1;
            // 
            // lbl_Title
            // 
            this.lbl_Title.Font = new System.Drawing.Font("웰컴체 Regular", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_Title.Location = new System.Drawing.Point(0, 0);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(545, 56);
            this.lbl_Title.TabIndex = 3;
            this.lbl_Title.Text = "제목";
            this.lbl_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OXChart_Screen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_Title);
            this.Controls.Add(this.pnl_OChart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "OXChart_Screen";
            this.Size = new System.Drawing.Size(545, 400);
            this.Load += new System.EventHandler(this.OXChart_Screen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label2;
        private Panel pnl_OChart;
        private Label lbl_Title;
    }
}
