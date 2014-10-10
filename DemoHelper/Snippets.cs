using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoHelper
{
    static class Snippets
    {
        public static Dictionary<string, string> clips = new Dictionary<string, string>() {
{"Step 3", @"		using System;
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
		}"},
          {"Step 4",
        @"using System;
		using System.Collections.Generic;
		using System.Linq;
		using System.Web;

		namespace MvcTraining.Models
		{
		    public enum Grade
		    {
		        A, B, C, D, F
		    }

		    public class Enrollment
		    {
		        public int EnrollmentID { get; set; }
		        public int CourseID { get; set; }
		        public int StudentID { get; set; }
		        public Grade? Grade { get; set; }

		        public virtual Course Course { get; set; }
		        public virtual Student Student { get; set; }
		    }
		}"},
          {"Step 5",

        @"		using System.Collections.Generic;
		using System.ComponentModel.DataAnnotations.Schema;

		namespace MvcTraining.Models
		{
		    public class Course
		    {
		        [DatabaseGenerated(DatabaseGeneratedOption.None)]
		        public int CourseID { get; set; }
		        public string Title { get; set; }
		        public int Credits { get; set; }

		        public virtual ICollection<Enrollment> Enrollments { get; set; }
		    }
		}"},

        {"Step 6",
        @"		using MvcTraining.Models;
		using System.Data.Entity;
		using System.Data.Entity.ModelConfiguration.Conventions;

		namespace MvcTraining.DAL
		{
		    public class SchoolContext : DbContext
		    {
		    
		        public SchoolContext() : base(""SchoolContext"")
		        {
		        }
		        
		        public DbSet<Student> Students { get; set; }
		        public DbSet<Enrollment> Enrollments { get; set; }
		        public DbSet<Course> Courses { get; set; }
		    }
		}"},

          {"Step 7", 
        
        @"		using System;
		using System.Collections.Generic;
		using System.Linq;
		using System.Web;
		using System.Data.Entity;
		using MvcTraining.Models;

		namespace MvcTraining.DAL
		{
		    public class SchoolInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SchoolContext>
		    {
		        protected override void Seed(SchoolContext context)
		        {
		            var students = new List<Student>
		            {
		            new Student{FirstMidName=""Zaragoza"",LastName=""Saenz"",EnrollmentDate=DateTime.Parse(""2005-09-01"")},
		            new Student{FirstMidName=""Raymond"",LastName=""DeLaRosa"",EnrollmentDate=DateTime.Parse(""2002-09-01"")},
		            new Student{FirstMidName=""Christopher"",LastName=""Wong"",EnrollmentDate=DateTime.Parse(""2003-09-01"")},
		            new Student{FirstMidName=""Andrew"",LastName=""Adams"",EnrollmentDate=DateTime.Parse(""2002-09-01"")},
		            new Student{FirstMidName=""Robert"",LastName=""Delfs"",EnrollmentDate=DateTime.Parse(""2002-09-01"")},
		            new Student{FirstMidName=""Ryan"",LastName=""Batchelder"",EnrollmentDate=DateTime.Parse(""2001-09-01"")},
		            new Student{FirstMidName=""Adam"",LastName=""Cook"",EnrollmentDate=DateTime.Parse(""2003-09-01"")},
		            new Student{FirstMidName=""Daniel"",LastName=""Garcia Briseno"",EnrollmentDate=DateTime.Parse(""2005-09-01"")},
		            new Student{FirstMidName=""Adam"",LastName=""Thomas"",EnrollmentDate=DateTime.Parse(""2003-09-01"")},
		            new Student{FirstMidName=""Herbie"",LastName=""Duah"",EnrollmentDate=DateTime.Parse(""2003-09-01"")},
		            new Student{FirstMidName=""Duke"",LastName=""Ayers"",EnrollmentDate=DateTime.Parse(""2003-09-01"")},
		            new Student{FirstMidName=""Justin"",LastName=""Valenzuela"",EnrollmentDate=DateTime.Parse(""2003-09-01"")}
		            };

		            students.ForEach(s => context.Students.Add(s));
		            context.SaveChanges();
		            var courses = new List<Course>
		            {
		            new Course{CourseID=1050,Title=""Computer Science"",Credits=3,},
		            new Course{CourseID=4022,Title=""Microeconomics"",Credits=3,},
		            new Course{CourseID=4041,Title=""Macroeconomics"",Credits=3,},
		            new Course{CourseID=1045,Title=""Calculus"",Credits=4,},
		            new Course{CourseID=3141,Title=""Trigonometry"",Credits=4,},
		            new Course{CourseID=2021,Title=""Engineering"",Credits=3,},
		            new Course{CourseID=2042,Title=""Literature"",Credits=4,}
		            };
		            courses.ForEach(s => context.Courses.Add(s));
		            context.SaveChanges();
		            var enrollments = new List<Enrollment>
		            {
		            new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A},
		            new Enrollment{StudentID=1,CourseID=4022,Grade=Grade.C},
		            new Enrollment{StudentID=1,CourseID=4041,Grade=Grade.B},
		            new Enrollment{StudentID=2,CourseID=1045,Grade=Grade.B},
		            new Enrollment{StudentID=2,CourseID=3141,Grade=Grade.F},
		            new Enrollment{StudentID=2,CourseID=2021,Grade=Grade.F},
		            new Enrollment{StudentID=3,CourseID=1050},
		            new Enrollment{StudentID=4,CourseID=1050,},
		            new Enrollment{StudentID=4,CourseID=4022,Grade=Grade.F},
		            new Enrollment{StudentID=5,CourseID=4041,Grade=Grade.C},
		            new Enrollment{StudentID=6,CourseID=1045},
		            new Enrollment{StudentID=7,CourseID=3141,Grade=Grade.A},
		            new Enrollment{StudentID=8,CourseID=3141,Grade=Grade.A},
		            new Enrollment{StudentID=9,CourseID=3141,Grade=Grade.A},
		            new Enrollment{StudentID=10,CourseID=3141,Grade=Grade.A},
		            new Enrollment{StudentID=11,CourseID=3141,Grade=Grade.A},
		            };
		            enrollments.ForEach(s => context.Enrollments.Add(s));
		            context.SaveChanges();
		        }
		    }
		}"},

          {"Step 8",

          @"	    <contexts>
	      <context type=""MvcTraining.DAL.SchoolContext, MvcTraining"">
	        <databaseInitializer type=""MvcTraining.DAL.SchoolInitializer, MvcTraining"" />
	      </context>
	    </contexts>"},

          {"Step 14", 

        @"        <dt>
            @Html.DisplayNameFor(model => model.Enrollments)
        </dt>
        <dd>
            <table class=""table"">
                <tr>
                    <th>Course Title</th>
                    <th>Grade</th>
                </tr>
                @foreach (var item in Model.Enrollments)
                {
                    <tr>
                        <td>
                            @Html.DisplayFor(modelItem => item.Course.Title)
                        </td>
                        <td>
                            @Html.DisplayFor(modelItem => item.Grade)
                        </td>
                    </tr>
                }
            </table>
        </dd>"},
              {"Step 15",
        @"return RedirectToAction(""Index"");"
        },
        {"Step 16",
        @"		try{ ModelState.IsValid }
		catch (DataException ex)
		{
			ModelState.AddModelError("""", ""Message"");
		}"},

            {
                "Step 17 Delete Args",
                @"bool? saveChangesError=false"
            },
            {
                "Step 17 after if (id == null){}",
                @"if (saveChangesError.GetValueOrDefault())
			{
				ViewBag.ErrorMessage = ""Delete failed"";
			}"
            },

            {
                "Step 17 POST Delete",
                @"RedirectToAction(""Delete"", new { id = id, saveChangesError = true });"
            },
            {
                "Step 17 Under h2",
                @"<p class=""error"">@ViewBag.ErrorMessage</p>"
            }
        
        };

        public static List<string> steps
        {
            get
            {
                List<string> _steps = new List<string>();
                for (int i = 0; i < clips.Length; i++)
                {
                    _steps.Add("Step " + i);
                }
                return _steps;
            }
        }
    }
}
