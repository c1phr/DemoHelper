namespace DemoHelper
{
    partial class MainWindow
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
            this.CodeClips = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // CodeClips
            // 
            this.CodeClips.FormattingEnabled = true;
            this.CodeClips.Location = new System.Drawing.Point(13, 13);
            this.CodeClips.Name = "CodeClips";
            this.CodeClips.Size = new System.Drawing.Size(259, 238);
            this.CodeClips.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.CodeClips);
            this.Name = "MainWindow";
            this.Text = "Demo Helper";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox CodeClips;
    }
}

