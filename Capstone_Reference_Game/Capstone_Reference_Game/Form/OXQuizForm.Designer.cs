namespace Capstone_Reference_Game
{
    partial class OXQuizForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_ProblemTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_ProblemTitle
            // 
            this.lbl_ProblemTitle.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ProblemTitle.Location = new System.Drawing.Point(2, 18);
            this.lbl_ProblemTitle.Name = "lbl_ProblemTitle";
            this.lbl_ProblemTitle.Size = new System.Drawing.Size(1024, 97);
            this.lbl_ProblemTitle.TabIndex = 0;
            this.lbl_ProblemTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OXQuizForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Capstone_Reference_Game.Properties.Resources.OXBackground;
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.Controls.Add(this.lbl_ProblemTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OXQuizForm";
            this.Text = "OXQuizForm";
            this.Load += new System.EventHandler(this.OXQuizForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OXQuizForm_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private Label lbl_ProblemTitle;
    }
}