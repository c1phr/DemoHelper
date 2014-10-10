using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DemoHelper
{
    public partial class MainWindow : Form
    {
        private List<string> steps = Snippets.steps;
        private string[] clips = Snippets.clips; 
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {            
            CodeClips.DataSource = Snippets.steps;
        }

        private void CodeClips_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.CodeClips.IndexFromPoint(e.Location);
            if (index < steps.Count && index >= 0)
            {
                Clipboard.SetText(steps[index]);
            }
        }
    }
}
