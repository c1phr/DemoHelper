using System;
using System.Windows.Forms;

namespace DemoHelper
{
    public partial class MainWindow : Form
    {
        private string[] labels = new string[] { "Clip1", "Clip2" };
        private string[] clips = new string[] {@"		using System;
		using System.Collections.Generic;

		namespace MvcTraining.Models
		{
		    public class Student
		    {
		        public int ID { get; set; }
		        public string LastName { get; set; }
		        public string FirstMidName { get; set; }
		        public DateTime EnrollmentDate { get; set; }
		        
		        public virtual ICollection<Enrollment> Enrollments { get; set; }
		    }
		}"};
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {            
            CodeClips.DataSource = labels;
        }

        private void CodeClips_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.CodeClips.IndexFromPoint(e.Location);
            if (index < clips.Length && index >= 0)
            {
                Clipboard.SetText(clips[index]);
            }
        }
    }
}
