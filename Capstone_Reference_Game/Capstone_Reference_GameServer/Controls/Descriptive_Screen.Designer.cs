namespace Capstone_Reference_GameServer.Controls
{
    partial class Descriptive_Screen
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
            this.lbl_Title = new System.Windows.Forms.Label();
            this.lbl_ID = new System.Windows.Forms.Label();
            this.btn_Ans = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_Context = new Capstone_Reference_GameServer.Controls.BufferedLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_Title
            // 
            this.lbl_Title.Font = new System.Drawing.Font("웰컴체 Regular", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_Title.Location = new System.Drawing.Point(0, 0);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(545, 56);
            this.lbl_Title.TabIndex = 2;
            this.lbl_Title.Text = "제목";
            this.lbl_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_ID
            // 
            this.lbl_ID.Font = new System.Drawing.Font("웰컴체 Regular", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_ID.Location = new System.Drawing.Point(21, 56);
            this.lbl_ID.Name = "lbl_ID";
            this.lbl_ID.Size = new System.Drawing.Size(143, 23);
            this.lbl_ID.TabIndex = 5;
            this.lbl_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_Ans
            // 
            this.btn_Ans.Location = new System.Drawing.Point(221, 351);
            this.btn_Ans.Name = "btn_Ans";
            this.btn_Ans.Size = new System.Drawing.Size(80, 33);
            this.btn_Ans.TabIndex = 7;
            this.btn_Ans.Text = "정답처리";
            this.btn_Ans.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.lbl_Context);
            this.panel1.Location = new System.Drawing.Point(34, 143);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(488, 184);
            this.panel1.TabIndex = 8;
            // 
            // lbl_Context
            // 
            this.lbl_Context.AutoSize = true;
            this.lbl_Context.Font = new System.Drawing.Font("웰컴체 Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_Context.Location = new System.Drawing.Point(0, 0);
            this.lbl_Context.MaximumSize = new System.Drawing.Size(460, 0);
            this.lbl_Context.Name = "lbl_Context";
            this.lbl_Context.Size = new System.Drawing.Size(234, 19);
            this.lbl_Context.TabIndex = 9;
            this.lbl_Context.Text = "내용을 확인할 학생을 선택해 주세요!";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("웰컴체 Regular", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(21, 110);
            this.label1.MaximumSize = new System.Drawing.Size(480, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 7;
            // 
            // lbl_Name
            // 
            this.lbl_Name.Font = new System.Drawing.Font("웰컴체 Regular", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_Name.Location = new System.Drawing.Point(21, 79);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(143, 23);
            this.lbl_Name.TabIndex = 5;
            this.lbl_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Descriptive_Screen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_Ans);
            this.Controls.Add(this.lbl_Name);
            this.Controls.Add(this.lbl_ID);
            this.Controls.Add(this.lbl_Title);
            this.Name = "Descriptive_Screen";
            this.Size = new System.Drawing.Size(545, 400);
            this.Load += new System.EventHandler(this.MultipleChart_Screen_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lbl_Title;
        private Label lbl_ID;
        private Panel panel1;
        public Button btn_Ans;
        private Label label1;
        private Label lbl_Name;
        private BufferedLabel lbl_Context;
    }
}
