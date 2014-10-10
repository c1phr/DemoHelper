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
            this.CodeClips.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CodeClips.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CodeClips.FormattingEnabled = true;
            this.CodeClips.ItemHeight = 18;
            this.CodeClips.Location = new System.Drawing.Point(-1, 0);
            this.CodeClips.Name = "CodeClips";
            this.CodeClips.Size = new System.Drawing.Size(161, 112);
            this.CodeClips.TabIndex = 0;
            this.CodeClips.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.CodeClips_MouseDoubleClick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(160, 116);
            this.Controls.Add(this.CodeClips);
            this.Name = "MainWindow";
            this.Text = "Demo Helper";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox CodeClips;
    }
}

