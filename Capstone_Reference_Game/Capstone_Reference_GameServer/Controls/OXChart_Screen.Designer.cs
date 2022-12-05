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
            this.pnl_underTitle = new System.Windows.Forms.Panel();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.pieGraph1 = new Capstone_Reference_GameServer.Controls.PieGraph();
            this.pnl_OColor = new System.Windows.Forms.Panel();
            this.pnl_XColor = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_xRatio = new System.Windows.Forms.Label();
            this.lbl_oRatio = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_underTitle
            // 
            this.pnl_underTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(255)))));
            this.pnl_underTitle.Location = new System.Drawing.Point(0, 40);
            this.pnl_underTitle.Name = "pnl_underTitle";
            this.pnl_underTitle.Size = new System.Drawing.Size(46, 3);
            this.pnl_underTitle.TabIndex = 12;
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.Font = new System.Drawing.Font("웰컴체 Regular", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_Title.Location = new System.Drawing.Point(0, 12);
            this.lbl_Title.MaximumSize = new System.Drawing.Size(545, 0);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(55, 27);
            this.lbl_Title.TabIndex = 11;
            this.lbl_Title.Text = "제목";
            this.lbl_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Title.SizeChanged += new System.EventHandler(this.lbl_Title_SizeChanged);
            // 
            // pieGraph1
            // 
            this.pieGraph1.ChartMargin = 10;
            this.pieGraph1.Location = new System.Drawing.Point(147, 73);
            this.pieGraph1.Name = "pieGraph1";
            this.pieGraph1.OValue = 0;
            this.pieGraph1.Size = new System.Drawing.Size(250, 250);
            this.pieGraph1.TabIndex = 13;
            this.pieGraph1.XValue = 0;
            // 
            // pnl_OColor
            // 
            this.pnl_OColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_OColor.Location = new System.Drawing.Point(6, 9);
            this.pnl_OColor.Name = "pnl_OColor";
            this.pnl_OColor.Size = new System.Drawing.Size(15, 15);
            this.pnl_OColor.TabIndex = 14;
            // 
            // pnl_XColor
            // 
            this.pnl_XColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_XColor.Location = new System.Drawing.Point(6, 36);
            this.pnl_XColor.Name = "pnl_XColor";
            this.pnl_XColor.Size = new System.Drawing.Size(15, 15);
            this.pnl_XColor.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(27, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "O : ";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(27, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "X : ";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbl_xRatio);
            this.panel1.Controls.Add(this.lbl_oRatio);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pnl_OColor);
            this.panel1.Controls.Add(this.pnl_XColor);
            this.panel1.Location = new System.Drawing.Point(18, 270);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(113, 62);
            this.panel1.TabIndex = 16;
            // 
            // lbl_xRatio
            // 
            this.lbl_xRatio.Font = new System.Drawing.Font("맑은 고딕", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_xRatio.Location = new System.Drawing.Point(56, 33);
            this.lbl_xRatio.Name = "lbl_xRatio";
            this.lbl_xRatio.Size = new System.Drawing.Size(50, 20);
            this.lbl_xRatio.TabIndex = 16;
            this.lbl_xRatio.Text = "50%";
            this.lbl_xRatio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_oRatio
            // 
            this.lbl_oRatio.Font = new System.Drawing.Font("맑은 고딕", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_oRatio.Location = new System.Drawing.Point(56, 6);
            this.lbl_oRatio.Name = "lbl_oRatio";
            this.lbl_oRatio.Size = new System.Drawing.Size(50, 20);
            this.lbl_oRatio.TabIndex = 16;
            this.lbl_oRatio.Text = "50%";
            this.lbl_oRatio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OXChart_Screen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pieGraph1);
            this.Controls.Add(this.pnl_underTitle);
            this.Controls.Add(this.lbl_Title);
            this.Name = "OXChart_Screen";
            this.Size = new System.Drawing.Size(545, 400);
            this.Load += new System.EventHandler(this.OXChart_Screen_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Panel pnl_underTitle;
        private Label lbl_Title;
        private PieGraph pieGraph1;
        private Panel pnl_OColor;
        private Panel pnl_XColor;
        private Label label1;
        private Label label2;
        private Panel panel1;
        private Label lbl_xRatio;
        private Label lbl_oRatio;
    }
}
