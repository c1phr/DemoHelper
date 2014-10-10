using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DemoHelper
{
    public partial class MainWindow : Form
    {
        private string[] clips_array = Snippets.clips.Values.ToArray();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {            
            CodeClips.DataSource = Snippets.clips.Keys.ToArray();
        }

        private void CodeClips_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.CodeClips.IndexFromPoint(e.Location);
            if (index < Snippets.clips.Count && index >= 0)
            {
                Clipboard.SetText(clips_array[index]);
            }
        }
    }
}
