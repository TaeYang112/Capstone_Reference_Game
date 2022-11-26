namespace Capstone_Reference_Game
{
    partial class QuizBaseForm
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
            this.components = new System.ComponentModel.Container();
            this.lbl_ProblemTitle = new System.Windows.Forms.Label();
            this.timer_CountDown = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lbl_ProblemTitle
            // 
            this.lbl_ProblemTitle.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ProblemTitle.Location = new System.Drawing.Point(0, 18);
            this.lbl_ProblemTitle.Name = "lbl_ProblemTitle";
            this.lbl_ProblemTitle.Size = new System.Drawing.Size(1024, 97);
            this.lbl_ProblemTitle.TabIndex = 1;
            this.lbl_ProblemTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer_CountDown
            // 
            this.timer_CountDown.Interval = 1000;
            this.timer_CountDown.Tick += new System.EventHandler(this.timer_CountDown_Tick);
            // 
            // QuizBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.Controls.Add(this.lbl_ProblemTitle);
            this.Name = "QuizBaseForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.QuizForm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private Label lbl_ProblemTitle;
        private System.Windows.Forms.Timer timer_CountDown;
    }
}