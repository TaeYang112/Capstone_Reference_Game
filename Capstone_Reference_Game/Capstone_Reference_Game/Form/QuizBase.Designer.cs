namespace Capstone_Reference_Game
{
    partial class QuizBase
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
            this.timer_CountDown = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timer_CountDown
            // 
            this.timer_CountDown.Interval = 1000;
            this.timer_CountDown.Tick += new System.EventHandler(this.timer_CountDown_Tick);
            // 
            // QuizBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "QuizBase";
            this.Size = new System.Drawing.Size(1024, 600);
            this.Load += new System.EventHandler(this.QuizForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer_CountDown;
    }
}