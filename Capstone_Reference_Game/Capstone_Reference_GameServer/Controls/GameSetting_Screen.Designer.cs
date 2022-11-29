namespace Capstone_Reference_GameServer.Controls
{
    partial class GameSetting_Screen
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
            this.tb_Time = new System.Windows.Forms.TextBox();
            this.tb_Title = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_Question1 = new System.Windows.Forms.TextBox();
            this.tb_Question2 = new System.Windows.Forms.TextBox();
            this.tb_Question3 = new System.Windows.Forms.TextBox();
            this.tb_Question4 = new System.Windows.Forms.TextBox();
            this.tb_Question5 = new System.Windows.Forms.TextBox();
            this.btn_GameStart = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_Time
            // 
            this.tb_Time.Location = new System.Drawing.Point(160, 132);
            this.tb_Time.Name = "tb_Time";
            this.tb_Time.Size = new System.Drawing.Size(100, 23);
            this.tb_Time.TabIndex = 0;
            // 
            // tb_Title
            // 
            this.tb_Title.Location = new System.Drawing.Point(160, 184);
            this.tb_Title.Name = "tb_Title";
            this.tb_Title.Size = new System.Drawing.Size(100, 23);
            this.tb_Title.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "타이머";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(111, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "문제";
            // 
            // tb_Question1
            // 
            this.tb_Question1.Location = new System.Drawing.Point(488, 101);
            this.tb_Question1.Name = "tb_Question1";
            this.tb_Question1.Size = new System.Drawing.Size(100, 23);
            this.tb_Question1.TabIndex = 3;
            // 
            // tb_Question2
            // 
            this.tb_Question2.Location = new System.Drawing.Point(488, 130);
            this.tb_Question2.Name = "tb_Question2";
            this.tb_Question2.Size = new System.Drawing.Size(100, 23);
            this.tb_Question2.TabIndex = 3;
            // 
            // tb_Question3
            // 
            this.tb_Question3.Location = new System.Drawing.Point(488, 159);
            this.tb_Question3.Name = "tb_Question3";
            this.tb_Question3.Size = new System.Drawing.Size(100, 23);
            this.tb_Question3.TabIndex = 3;
            // 
            // tb_Question4
            // 
            this.tb_Question4.Location = new System.Drawing.Point(488, 188);
            this.tb_Question4.Name = "tb_Question4";
            this.tb_Question4.Size = new System.Drawing.Size(100, 23);
            this.tb_Question4.TabIndex = 3;
            // 
            // tb_Question5
            // 
            this.tb_Question5.Location = new System.Drawing.Point(488, 217);
            this.tb_Question5.Name = "tb_Question5";
            this.tb_Question5.Size = new System.Drawing.Size(100, 23);
            this.tb_Question5.TabIndex = 3;
            // 
            // btn_GameStart
            // 
            this.btn_GameStart.Location = new System.Drawing.Point(364, 274);
            this.btn_GameStart.Name = "btn_GameStart";
            this.btn_GameStart.Size = new System.Drawing.Size(91, 74);
            this.btn_GameStart.TabIndex = 4;
            this.btn_GameStart.Text = "시작";
            this.btn_GameStart.UseVisualStyleBackColor = true;
            this.btn_GameStart.Click += new System.EventHandler(this.btn_GameStart_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(303, 123);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(117, 100);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(11, 27);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(95, 19);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "radioButton1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(11, 60);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(95, 19);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "radioButton2";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // GameSetting_Screen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_GameStart);
            this.Controls.Add(this.tb_Question5);
            this.Controls.Add(this.tb_Question4);
            this.Controls.Add(this.tb_Question3);
            this.Controls.Add(this.tb_Question2);
            this.Controls.Add(this.tb_Question1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_Title);
            this.Controls.Add(this.tb_Time);
            this.Name = "GameSetting_Screen";
            this.Size = new System.Drawing.Size(750, 400);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox tb_Time;
        private TextBox tb_Title;
        private Label label1;
        private Label label2;
        private TextBox tb_Question1;
        private TextBox tb_Question2;
        private TextBox tb_Question3;
        private TextBox tb_Question4;
        private TextBox tb_Question5;
        private Button btn_GameStart;
        private GroupBox groupBox1;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
    }
}
