namespace Capstone_Reference_Game.Form
{
    partial class DescriptiveQuiz
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
            this.tb_MyAnswer = new System.Windows.Forms.TextBox();
            this.btn_SendAnswer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_MyAnswer
            // 
            this.tb_MyAnswer.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tb_MyAnswer.Location = new System.Drawing.Point(259, 188);
            this.tb_MyAnswer.Multiline = true;
            this.tb_MyAnswer.Name = "tb_MyAnswer";
            this.tb_MyAnswer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_MyAnswer.Size = new System.Drawing.Size(481, 228);
            this.tb_MyAnswer.TabIndex = 0;
            // 
            // btn_SendAnswer
            // 
            this.btn_SendAnswer.Location = new System.Drawing.Point(460, 461);
            this.btn_SendAnswer.Name = "btn_SendAnswer";
            this.btn_SendAnswer.Size = new System.Drawing.Size(92, 52);
            this.btn_SendAnswer.TabIndex = 1;
            this.btn_SendAnswer.Text = "전송";
            this.btn_SendAnswer.UseVisualStyleBackColor = true;
            this.btn_SendAnswer.Click += new System.EventHandler(this.btn_SendAnswer_Click);
            // 
            // DescriptiveQuiz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Capstone_Reference_Game.Properties.Resources.MultipleQuizeBackground;
            this.Controls.Add(this.btn_SendAnswer);
            this.Controls.Add(this.tb_MyAnswer);
            this.Name = "DescriptiveQuiz";
            this.Size = new System.Drawing.Size(1024, 600);
            this.Load += new System.EventHandler(this.DescriptiveQuiz_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox tb_MyAnswer;
        private Button btn_SendAnswer;
    }

}
