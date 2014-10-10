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
        public static Dictionary<string, string> clips = new Dictionary<string, string>()
        {
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
            {
                "Step 4",
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
		}"
            },
            {
                "Step 5",

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
		}"
            },

            {
                "Step 6",
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
		}"
            },

            {
                "Step 7",

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
		}"
            },

            {
                "Step 8",

                @"	    <contexts>
	      <context type=""MvcTraining.DAL.SchoolContext, MvcTraining"">
	        <databaseInitializer type=""MvcTraining.DAL.SchoolInitializer, MvcTraining"" />
	      </context>
	    </contexts>"
            },

            {
                "Step 9",
                @"<connectionStrings>
    <add name=""SchoolContext"" connectionString=""Data Source=(LocalDB)\v11.0;Initial Catalog=MvcTraining;Integrated Security=SSPI;"" providerName=""System.Data.SqlClient""/>
  </connectionStrings>"
            },

            {
                "Step 14",

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
        </dd>"
            },
            {
                "Step 15",
                @"return RedirectToAction(""Index"");"
            },
            {
                "Step 16",
                @"try
    {
        if (ModelState.IsValid)
        {
            db.Students.Add(student);
            db.SaveChanges();
            return RedirectToAction(""Index"");
        }
    }
    catch (DataException /* dex */)
    {
        //Log the error (uncomment dex variable name and add a line here to write a log.
        ModelState.AddModelError("", ""Unable to save changes. Try again, and if the problem persists see your system administrator."");
    }"
            },

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
            },
            {
                "Step 18 Index.cshtml",
                @"@using (Html.BeginForm())
		{
		    <p>
		        Find by name: @Html.TextBox(""SearchString"")  
		        <input type=""submit"" value=""Search"" />
	        </p>
		}"
            },
            {
                "Step 18 Index()",
                @"var students = from s in db.Students select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                students =
                    students.Where(
                        s =>
                            s.LastName.ToUpper().Contains(searchString.ToUpper()) ||
                            s.FirstMidName.ToUpper().Contains(searchString.ToUpper()));
            }
            return View(students.ToList());"
            },
            {
                "Step 19",
                @"using System;
		using System.ComponentModel.DataAnnotations;

		namespace MvcTraining.ViewModels
		{
		    public class EnrollmentDateGroup
		    {
		        [DataType(DataType.Date)]
		        public DateTime? EnrollmentDate { get; set; }

		        public int StudentCount { get; set; }
		    }
		}"
            },
            {
                "Step 20 Usings",
                @"using MvcTraining.DAL;
		  using MvcTraining.ViewModels;"
            },
            {
                "Step 20 Class Prop",
                @"private SchoolContext db = new SchoolContext();"
            },
            {
                "Step 20 About()",
                @"public ActionResult About()
		{
		    IQueryable<EnrollmentDateGroup> data = from student in db.Students
		               group student by student.EnrollmentDate into dateGroup
		               select new EnrollmentDateGroup()
		               {
		                   EnrollmentDate = dateGroup.Key,
		                   StudentCount = dateGroup.Count()
		               };
		    return View(data.ToList());
		}"
            },
            {
                "Step 20 Dispose()",
                @"protected override void Dispose(bool disposing)
		{
			db.Dispose();
			base.Dispose(disposing);
		}"
            },
            {
                "Step 21",
                @"@model IEnumerable<MvcTraining.ViewModels.EnrollmentDateGroup>

		@{
		    ViewBag.Title = ""Student Body Statistics"";
		}

		<h2>Student Body Statistics</h2>

		<table>
		    <tr>
		        <th>
		            Enrollment Date
		        </th>
		        <th>
		            Students
		        </th>
		    </tr>

		    @foreach (var item in Model)
		    {
		        <tr>
		            <td>
		                @Html.DisplayFor(modelItem => item.EnrollmentDate)
		            </td>
		            <td>
		                @item.StudentCount
		            </td>
		        </tr>
		    }
		</table>"
            },
            {
                "Step 24",
                @"namespace MvcTraining.Migrations
		{
		    using MvcTraining.Models;
		    using System;
		    using System.Collections.Generic;
		    using System.Data.Entity;
		    using System.Data.Entity.Migrations;
		    using System.Linq;

		    internal sealed class Configuration : DbMigrationsConfiguration<MvcTraining.DAL.SchoolContext>
		    {
		        public Configuration()
		        {
		            AutomaticMigrationsEnabled = false;
		        }

		        protected override void Seed(MvcTraining.DAL.SchoolContext context)
		        {
		            var students = new List<Student>
		            {
		                new Student { FirstMidName = ""Zaragoza"",   LastName = ""Saenz"", 
		                    EnrollmentDate = DateTime.Parse(""2010-09-01"") },
		                new Student { FirstMidName = ""Raymond"", LastName = ""DeLaRosa"",    
		                    EnrollmentDate = DateTime.Parse(""2012-09-01"") },
		                new Student { FirstMidName = ""Christopher"",   LastName = ""Wong"",     
		                    EnrollmentDate = DateTime.Parse(""2013-09-01"") },
		                new Student { FirstMidName = ""Andrew"",    LastName = ""Adams"", 
		                    EnrollmentDate = DateTime.Parse(""2012-09-01"") },
		                new Student { FirstMidName = ""Robert"",      LastName = ""Delfs"",        
		                    EnrollmentDate = DateTime.Parse(""2012-09-01"") },
		                new Student { FirstMidName = ""Ryan"",    LastName = ""Batchelder"",   
		                    EnrollmentDate = DateTime.Parse(""2011-09-01"") },
		                new Student { FirstMidName = ""Adam"",    LastName = ""Cook"",    
		                    EnrollmentDate = DateTime.Parse(""2013-09-01"") },
		                new Student { FirstMidName = ""Daniel"",     LastName = ""Garcia Briseno"",  
		                    EnrollmentDate = DateTime.Parse(""2005-08-11"") },
		                new Student { FirstMidName = ""Adam"",    LastName = ""Thomas"",    
		                    EnrollmentDate = DateTime.Parse(""2013-09-01"") },
		                new Student { FirstMidName = ""Herbie"",    LastName = ""Duah"",    
		                    EnrollmentDate = DateTime.Parse(""2013-09-01"") },
		                new Student { FirstMidName = ""Duke"",    LastName = ""Ayers"",    
		                    EnrollmentDate = DateTime.Parse(""2013-09-01"") },
		                new Student { FirstMidName = ""Justin"",    LastName = ""Valenzuela"",    
		                    EnrollmentDate = DateTime.Parse(""2013-09-01"") }
		            };
		            students.ForEach(s => context.Students.AddOrUpdate(p => p.LastName, s));
		            context.SaveChanges();

		            var courses = new List<Course>
		            {
		                new Course {CourseID = 1050, Title = ""Chemistry"",      Credits = 3, },
		                new Course {CourseID = 4022, Title = ""Microeconomics"", Credits = 3, },
		                new Course {CourseID = 4041, Title = ""Macroeconomics"", Credits = 3, },
		                new Course {CourseID = 1045, Title = ""Calculus"",       Credits = 4, },
		                new Course {CourseID = 3141, Title = ""Trigonometry"",   Credits = 4, },
		                new Course {CourseID = 2021, Title = ""Composition"",    Credits = 3, },
		                new Course {CourseID = 2042, Title = ""Literature"",     Credits = 4, }
		            };
		            courses.ForEach(s => context.Courses.AddOrUpdate(p => p.Title, s));
		            context.SaveChanges();

		            var enrollments = new List<Enrollment>
		            {
		                new Enrollment { 
		                    StudentID = students.Single(s => s.LastName == ""Saenz"").ID, 
		                    CourseID = courses.Single(c => c.Title == ""Chemistry"" ).CourseID, 
		                    Grade = Grade.A 
		                },
		                 new Enrollment { 
		                    StudentID = students.Single(s => s.LastName == ""DeLaRosa"").ID,
		                    CourseID = courses.Single(c => c.Title == ""Microeconomics"" ).CourseID, 
		                    Grade = Grade.C 
		                 },                            
		                 new Enrollment { 
		                    StudentID = students.Single(s => s.LastName == ""Wong"").ID,
		                    CourseID = courses.Single(c => c.Title == ""Macroeconomics"" ).CourseID, 
		                    Grade = Grade.B
		                 },
		                 new Enrollment { 
		                     StudentID = students.Single(s => s.LastName == ""Adams"").ID,
		                    CourseID = courses.Single(c => c.Title == ""Calculus"" ).CourseID, 
		                    Grade = Grade.B 
		                 },
		                 new Enrollment { 
		                     StudentID = students.Single(s => s.LastName == ""Delfs"").ID,
		                    CourseID = courses.Single(c => c.Title == ""Trigonometry"" ).CourseID, 
		                    Grade = Grade.B 
		                 },
		                 new Enrollment {
		                    StudentID = students.Single(s => s.LastName == ""Batchelder"").ID,
		                    CourseID = courses.Single(c => c.Title == ""Composition"" ).CourseID, 
		                    Grade = Grade.B 
		                 },
		                 new Enrollment { 
		                    StudentID = students.Single(s => s.LastName == ""Cook"").ID,
		                    CourseID = courses.Single(c => c.Title == ""Chemistry"" ).CourseID
		                 },
		                 new Enrollment { 
		                    StudentID = students.Single(s => s.LastName == ""Garcia Briseno"").ID,
		                    CourseID = courses.Single(c => c.Title == ""Microeconomics"").CourseID,
		                    Grade = Grade.B         
		                 },
		                new Enrollment { 
		                    StudentID = students.Single(s => s.LastName == ""Thomas"").ID,
		                    CourseID = courses.Single(c => c.Title == ""Chemistry"").CourseID,
		                    Grade = Grade.B         
		                 },
		                 new Enrollment { 
		                    StudentID = students.Single(s => s.LastName == ""Duah"").ID,
		                    CourseID = courses.Single(c => c.Title == ""Composition"").CourseID,
		                    Grade = Grade.B         
		                 },
		                 new Enrollment { 
		                    StudentID = students.Single(s => s.LastName == ""Ayers"").ID,
		                    CourseID = courses.Single(c => c.Title == ""Literature"").CourseID,
		                    Grade = Grade.B         
		                 },
		                 new Enrollment { 
		                    StudentID = students.Single(s => s.LastName == ""Valenzuela"").ID,
		                    CourseID = courses.Single(c => c.Title == ""Literature"").CourseID,
		                    Grade = Grade.A         
		                 }
		            };

		            foreach (Enrollment e in enrollments)
		            {
		                var enrollmentInDataBase = context.Enrollments.Where(
		                    s =>
		                         s.Student.ID == e.StudentID &&
		                         s.Course.CourseID == e.CourseID).SingleOrDefault();
		                if (enrollmentInDataBase == null)
		                {
		                    context.Enrollments.Add(e);
		                }
		            }
		            context.SaveChanges();
		        }
		    }
			}"
            },
            {
                "Step 27",
                @"[DataType(DataType.Date)]
	    [DisplayFormat(DataFormatString = ""{0:yyyy-MM-dd}"", ApplyFormatInEditMode = true)]"
            },
            {
                "Step 28",
                @"[StringLength(20, ErrorMessage = ""First name is too long"")]
        [RegularExpression(@""^[A-Z]+[a-zA-Z''-'\s]*$"")]"
            },
            {
                "Step 30",
                @"using System;
		using System.Collections.Generic;
		using System.ComponentModel.DataAnnotations;
		using System.ComponentModel.DataAnnotations.Schema;

		namespace MvcTraining.Models
		{
		    public class Student
		    {
		        public int ID { get; set; }
		        [Required]
		        [StringLength(50)]
		        [Display(Name = ""Last Name"")]
		        public string LastName { get; set; }
		        [Required]
		        [StringLength(50, ErrorMessage = ""First name cannot be longer than 50 characters."")]
		        [Column(""FirstName"")]
		        [Display(Name = ""First Name"")]
		        public string FirstMidName { get; set; }
		        [DataType(DataType.Date)]
		        [DisplayFormat(DataFormatString = ""{0:yyyy-MM-dd}"", ApplyFormatInEditMode = true)]
		        [Display(Name = ""Enrollment Date"")]
		        public DateTime EnrollmentDate { get; set; }

		        [Display(Name = ""Full Name"")]
		        public string FullName
		        {
		            get
		            {
		                return LastName + "", "" + FirstMidName;
		            }
		        }

		        public virtual ICollection<Enrollment> Enrollments { get; set; }
		    }
		}"
            },
            {
                "Step 31",
                @"using System;
		using System.Collections.Generic;
		using System.ComponentModel.DataAnnotations;
		using System.ComponentModel.DataAnnotations.Schema;

		namespace MvcTraining.Models
		{
		    public class Instructor
		    {
		        public int ID { get; set; }

		        [Required]
		        [Display(Name = ""Last Name"")]
		        [StringLength(50)]
		        public string LastName { get; set; }

		        [Required]
		        [Column(""FirstName"")]
		        [Display(Name = ""First Name"")]
		        [StringLength(50)]
		        public string FirstMidName { get; set; }

		        [DataType(DataType.Date)]
		        [DisplayFormat(DataFormatString = ""{0:yyyy-MM-dd}"", ApplyFormatInEditMode = true)]
		        [Display(Name = ""Hire Date"")]
		        public DateTime HireDate { get; set; }

		        [Display(Name = ""Full Name"")]
		        public string FullName
		        {
		            get { return LastName + "", "" + FirstMidName; }
		        }

		        public virtual ICollection<Course> Courses { get; set; }
		        public virtual OfficeAssignment OfficeAssignment { get; set; }
		    }
		}"
            },
            {
                "Step 32",
                @"using System.ComponentModel.DataAnnotations;
		using System.ComponentModel.DataAnnotations.Schema;

		namespace MvcTraining.Models
		{
		    public class OfficeAssignment
		    {
		        [Key, ForeignKey(""Instructor"")]        
		        public int InstructorID { get; set; }
		        
		        [Display(Name = ""Office Location""), StringLength(50)]
		        public string Location { get; set; }

		        public virtual Instructor Instructor { get; set; }
		    }
		}"
            },
            {
                "Step 33",
                @"[DisplayFormat(NullDisplayText = ""No grade"")]"
            },
            {
                "Step 34",
                @"using System;
		using System.Collections.Generic;
		using System.ComponentModel.DataAnnotations;
		using System.ComponentModel.DataAnnotations.Schema;

		namespace MvcTraining.Models
		{
		    public class Department
		    {
		        public int DepartmentID { get; set; }

		        [StringLength(50, MinimumLength = 3)]
		        public string Name { get; set; }

		        [DataType(DataType.Currency)]
		        [Column(TypeName = ""money"")]
		        public decimal Budget { get; set; }

		        [DataType(DataType.Date)]
		        [DisplayFormat(DataFormatString = ""{0:yyyy-MM-dd}"", ApplyFormatInEditMode = true)]
		        [Display(Name = ""Start Date"")]
		        public DateTime StartDate { get; set; }

		        public int? InstructorID { get; set; }

		        public virtual Instructor Administrator { get; set; }
		        public virtual ICollection<Course> Courses { get; set; }
		    }
		}"
            },
            {
                "Step 35",
                @"using System.Collections.Generic;
		using System.ComponentModel.DataAnnotations;
		using System.ComponentModel.DataAnnotations.Schema;

		namespace MvcTraining.Models
		{
		    public class Course
		    {
		        [DatabaseGenerated(DatabaseGeneratedOption.None)]
		        [Display(Name = ""Number"")]
		        public int CourseID { get; set; }

		        [StringLength(50, MinimumLength = 3)]
		        public string Title { get; set; }

		        [Range(0, 5)]
		        public int Credits { get; set; }

		        public int DepartmentID { get; set; }

		        public virtual Department Department { get; set; }
		        public virtual ICollection<Enrollment> Enrollments { get; set; }
		        public virtual ICollection<Instructor> Instructors { get; set; }
		    }
		}"
            },
            {
                "Step 36",
                @"public DbSet<Department> Departments { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Instructors).WithMany(i => i.Courses)
                .Map(t => t.MapLeftKey(""CourseID"")
                    .MapRightKey(""InstructorID"")
                    .ToTable(""CourseInstructor""));
        }"
            },
            {
                "Step 37",
                @"using MvcTraining.DAL;

		namespace MvcTraining.Migrations
		{
		    using MvcTraining.Models;
		    using System;
		    using System.Collections.Generic;
		    using System.Data.Entity;
		    using System.Data.Entity.Migrations;
		    using System.Linq;

		    internal sealed class Configuration : DbMigrationsConfiguration<MvcTraining.DAL.SchoolContext>
		    {
		        public Configuration()
		        {
		            AutomaticMigrationsEnabled = false;
		        }

		        protected override void Seed(MvcTraining.DAL.SchoolContext context)
		        {
		            var students = new List<Student>
		            {
		                new Student { FirstMidName = ""Zaragoza"",   LastName = ""Saenz"", 
		                    EnrollmentDate = DateTime.Parse(""2010-09-01"") },
		                new Student { FirstMidName = ""Raymond"", LastName = ""DeLaRosa"",    
		                    EnrollmentDate = DateTime.Parse(""2012-09-01"") },
		                new Student { FirstMidName = ""Christopher"",   LastName = ""Wong"",     
		                    EnrollmentDate = DateTime.Parse(""2013-09-01"") },
		                new Student { FirstMidName = ""Andrew"",    LastName = ""Adams"", 
		                    EnrollmentDate = DateTime.Parse(""2012-09-01"") },
		                new Student { FirstMidName = ""Robert"",      LastName = ""Delfs"",        
		                    EnrollmentDate = DateTime.Parse(""2012-09-01"") },
		                new Student { FirstMidName = ""Ryan"",    LastName = ""Batchelder"",   
		                    EnrollmentDate = DateTime.Parse(""2011-09-01"") },
		                new Student { FirstMidName = ""Adam"",    LastName = ""Cook"",    
		                    EnrollmentDate = DateTime.Parse(""2013-09-01"") },
		                new Student { FirstMidName = ""Daniel"",     LastName = ""Garcia Briseno"",  
		                    EnrollmentDate = DateTime.Parse(""2005-08-11"") },
		                new Student { FirstMidName = ""Adam"",    LastName = ""Thomas"",    
		                    EnrollmentDate = DateTime.Parse(""2013-09-01"") },
		                new Student { FirstMidName = ""Herbie"",    LastName = ""Duah"",    
		                    EnrollmentDate = DateTime.Parse(""2013-09-01"") },
		                new Student { FirstMidName = ""Duke"",    LastName = ""Ayers"",    
		                    EnrollmentDate = DateTime.Parse(""2013-09-01"") },
		                new Student { FirstMidName = ""Justin"",    LastName = ""Valenzuela"",    
		                    EnrollmentDate = DateTime.Parse(""2013-09-01"") }
		            };
		            students.ForEach(s => context.Students.AddOrUpdate(p => p.LastName, s));
		            context.SaveChanges();

		            var instructors = new List<Instructor>
		            {
		                new Instructor { FirstMidName = ""Kim"",     LastName = ""Abercrombie"", 
		                    HireDate = DateTime.Parse(""1995-03-11"") },
		                new Instructor { FirstMidName = ""Fadi"",    LastName = ""Fakhouri"",    
		                    HireDate = DateTime.Parse(""2002-07-06"") },
		                new Instructor { FirstMidName = ""Roger"",   LastName = ""Harui"",       
		                    HireDate = DateTime.Parse(""1998-07-01"") },
		                new Instructor { FirstMidName = ""Candace"", LastName = ""Kapoor"",      
		                    HireDate = DateTime.Parse(""2001-01-15"") },
		                new Instructor { FirstMidName = ""Roger"",   LastName = ""Zheng"",      
		                    HireDate = DateTime.Parse(""2004-02-12"") }
		            };
		            instructors.ForEach(s => context.Instructors.AddOrUpdate(p => p.LastName, s));
		            context.SaveChanges();

		            var departments = new List<Department>
		            {
		                new Department { Name = ""English"",     Budget = 350000, 
		                    StartDate = DateTime.Parse(""2007-09-01""), 
		                    InstructorID  = instructors.Single( i => i.LastName == ""Abercrombie"").ID },
		                new Department { Name = ""Mathematics"", Budget = 100000, 
		                    StartDate = DateTime.Parse(""2007-09-01""), 
		                    InstructorID  = instructors.Single( i => i.LastName == ""Fakhouri"").ID },
		                new Department { Name = ""Engineering"", Budget = 350000, 
		                    StartDate = DateTime.Parse(""2007-09-01""), 
		                    InstructorID  = instructors.Single( i => i.LastName == ""Harui"").ID },
		                new Department { Name = ""Economics"",   Budget = 100000, 
		                    StartDate = DateTime.Parse(""2007-09-01""), 
		                    InstructorID  = instructors.Single( i => i.LastName == ""Kapoor"").ID }
		            };
		            departments.ForEach(s => context.Departments.AddOrUpdate(p => p.Name, s));
		            context.SaveChanges();

		            var courses = new List<Course>
		            {
		                new Course {CourseID = 1050, Title = ""Chemistry"",      Credits = 3,
		                  DepartmentID = departments.Single( s => s.Name == ""Engineering"").DepartmentID,
		                  Instructors = new List<Instructor>() 
		                },
		                new Course {CourseID = 4022, Title = ""Microeconomics"", Credits = 3,
		                  DepartmentID = departments.Single( s => s.Name == ""Economics"").DepartmentID,
		                  Instructors = new List<Instructor>() 
		                },
		                new Course {CourseID = 4041, Title = ""Macroeconomics"", Credits = 3,
		                  DepartmentID = departments.Single( s => s.Name == ""Economics"").DepartmentID,
		                  Instructors = new List<Instructor>() 
		                },
		                new Course {CourseID = 1045, Title = ""Calculus"",       Credits = 4,
		                  DepartmentID = departments.Single( s => s.Name == ""Mathematics"").DepartmentID,
		                  Instructors = new List<Instructor>() 
		                },
		                new Course {CourseID = 3141, Title = ""Trigonometry"",   Credits = 4,
		                  DepartmentID = departments.Single( s => s.Name == ""Mathematics"").DepartmentID,
		                  Instructors = new List<Instructor>() 
		                },
		                new Course {CourseID = 2021, Title = ""Composition"",    Credits = 3,
		                  DepartmentID = departments.Single( s => s.Name == ""English"").DepartmentID,
		                  Instructors = new List<Instructor>() 
		                },
		                new Course {CourseID = 2042, Title = ""Literature"",     Credits = 4,
		                  DepartmentID = departments.Single( s => s.Name == ""English"").DepartmentID,
		                  Instructors = new List<Instructor>() 
		                },
		            };
		            courses.ForEach(s => context.Courses.AddOrUpdate(p => p.CourseID, s));
		            context.SaveChanges();

		            var officeAssignments = new List<OfficeAssignment>
		            {
		                new OfficeAssignment { 
		                    InstructorID = instructors.Single( i => i.LastName == ""Fakhouri"").ID, 
		                    Location = ""Smith 17"" },
		                new OfficeAssignment { 
		                    InstructorID = instructors.Single( i => i.LastName == ""Harui"").ID, 
		                    Location = ""Gowan 27"" },
		                new OfficeAssignment { 
		                    InstructorID = instructors.Single( i => i.LastName == ""Kapoor"").ID, 
		                    Location = ""Thompson 304"" },
		            };
		            officeAssignments.ForEach(s => context.OfficeAssignments.AddOrUpdate(p => p.InstructorID, s));
		            context.SaveChanges();

		            AddOrUpdateInstructor(context, ""Chemistry"", ""Kapoor"");
		            AddOrUpdateInstructor(context, ""Chemistry"", ""Harui"");
		            AddOrUpdateInstructor(context, ""Microeconomics"", ""Zheng"");
		            AddOrUpdateInstructor(context, ""Macroeconomics"", ""Zheng"");

		            AddOrUpdateInstructor(context, ""Calculus"", ""Fakhouri"");
		            AddOrUpdateInstructor(context, ""Trigonometry"", ""Harui"");
		            AddOrUpdateInstructor(context, ""Composition"", ""Abercrombie"");
		            AddOrUpdateInstructor(context, ""Literature"", ""Abercrombie"");

		            context.SaveChanges();

		            var enrollments = new List<Enrollment>
		            {
		                new Enrollment { 
		                    StudentID = students.Single(s => s.LastName == ""Saenz"").ID, 
		                    CourseID = courses.Single(c => c.Title == ""Chemistry"" ).CourseID, 
		                    Grade = Grade.A 
		                },
		                 new Enrollment { 
		                    StudentID = students.Single(s => s.LastName == ""DeLaRosa"").ID,
		                    CourseID = courses.Single(c => c.Title == ""Microeconomics"" ).CourseID, 
		                    Grade = Grade.C 
		                 },                            
		                 new Enrollment { 
		                    StudentID = students.Single(s => s.LastName == ""Wong"").ID,
		                    CourseID = courses.Single(c => c.Title == ""Macroeconomics"" ).CourseID, 
		                    Grade = Grade.B
		                 },
		                 new Enrollment { 
		                     StudentID = students.Single(s => s.LastName == ""Adams"").ID,
		                    CourseID = courses.Single(c => c.Title == ""Calculus"" ).CourseID, 
		                    Grade = Grade.B 
		                 },
		                 new Enrollment { 
		                     StudentID = students.Single(s => s.LastName == ""Delfs"").ID,
		                    CourseID = courses.Single(c => c.Title == ""Trigonometry"" ).CourseID, 
		                    Grade = Grade.B 
		                 },
		                 new Enrollment {
		                    StudentID = students.Single(s => s.LastName == ""Batchelder"").ID,
		                    CourseID = courses.Single(c => c.Title == ""Composition"" ).CourseID, 
		                    Grade = Grade.B 
		                 },
		                 new Enrollment { 
		                    StudentID = students.Single(s => s.LastName == ""Cook"").ID,
		                    CourseID = courses.Single(c => c.Title == ""Chemistry"" ).CourseID
		                 },
		                 new Enrollment { 
		                    StudentID = students.Single(s => s.LastName == ""Garcia Briseno"").ID,
		                    CourseID = courses.Single(c => c.Title == ""Microeconomics"").CourseID,
		                    Grade = Grade.B         
		                 },
		                new Enrollment { 
		                    StudentID = students.Single(s => s.LastName == ""Thomas"").ID,
		                    CourseID = courses.Single(c => c.Title == ""Chemistry"").CourseID,
		                    Grade = Grade.B         
		                 },
		                 new Enrollment { 
		                    StudentID = students.Single(s => s.LastName == ""Duah"").ID,
		                    CourseID = courses.Single(c => c.Title == ""Composition"").CourseID,
		                    Grade = Grade.B         
		                 },
		                 new Enrollment { 
		                    StudentID = students.Single(s => s.LastName == ""Ayers"").ID,
		                    CourseID = courses.Single(c => c.Title == ""Literature"").CourseID,
		                    Grade = Grade.B         
		                 },
		                 new Enrollment { 
		                    StudentID = students.Single(s => s.LastName == ""Valenzuela"").ID,
		                    CourseID = courses.Single(c => c.Title == ""Literature"").CourseID,
		                    Grade = Grade.A         
		                 }
		            };

		            foreach (Enrollment e in enrollments)
		            {
		                var enrollmentInDataBase = context.Enrollments.Where(
		                    s =>
		                         s.Student.ID == e.StudentID &&
		                         s.Course.CourseID == e.CourseID).SingleOrDefault();
		                if (enrollmentInDataBase == null)
		                {
		                    context.Enrollments.Add(e);
		                }
		            }
		            context.SaveChanges();
		        }

		        void AddOrUpdateInstructor(SchoolContext context, string courseTitle, string instructorName)
		        {
		            var crs = context.Courses.SingleOrDefault(c => c.Title == courseTitle);
		            var inst = crs.Instructors.SingleOrDefault(i => i.LastName == instructorName);
		            if (inst == null)
		                crs.Instructors.Add(context.Instructors.Single(i => i.LastName == instructorName));
		        }
		    }
		}"
            },
            {
                "Step 42 Before <th>",
                @"<th>
            @Html.DisplayNameFor(model => model.CourseID)
        </th>"
            },
            {
                "Step 42 After <th>",
                @"<th>
    		Department
		</th>"
            },
            {
                "Step 43 before <td>",
                @"<td>
            @Html.DisplayFor(modelItem => item.CourseID)
        </td>"
            },
            {
                "Step 43 after <td>",
                @"<td>
            @Html.DisplayFor(modelItem => item.Department.Name)
        </td>"
            },
            {
                "Step 44",
                @"using System.Collections.Generic;
		using MvcTraining.Models;

		namespace MvcTraining.ViewModels
		{
		    public class InstructorIndexData
		    {
		        public IEnumerable<Instructor> Instructors { get; set; }
		        public IEnumerable<Course> Courses { get; set; }
		        public IEnumerable<Enrollment> Enrollments { get; set; }
		    }
		}"
            },
            {
                "Step 45 Using",
                @"using MvcTraining.ViewModels;"
            },
            {
                "Step 46",
                @"public ActionResult Index(int? id, int? courseID)
        {
            var viewModel = new InstructorIndexData();
            viewModel.Instructors = db.Instructors
                .Include(i => i.OfficeAssignment)
                .Include(i => i.Courses.Select(c => c.Department))
                .OrderBy(i => i.LastName);

            if (id != null)
            {
                ViewBag.InstructorID = id.Value;
                viewModel.Courses = viewModel.Instructors.Where(
                    i => i.ID == id.Value).Single().Courses;
            }

            if (courseID != null)
            {
                ViewBag.CourseID = courseID.Value;
                viewModel.Enrollments = viewModel.Courses.Where(
                    x => x.CourseID == courseID).Single().Enrollments;
            }

            return View(viewModel);
        }"
            },
            {
                "Step 47",
                @"@model MvcTraining.ViewModels.InstructorIndexData

		@{
		    ViewBag.Title = ""Instructors"";
		}

		<h2>Instructors</h2>

		<p>
		    @Html.ActionLink(""Create New"", ""Create"")
		</p>
		<table class=""table"">
		    <tr>
		        <th>Last Name</th>
		        <th>First Name</th>
		        <th>Hire Date</th>
		        <th>Office</th>
		        <th></th>
		    </tr>

		    @foreach (var item in Model.Instructors)
		    {
		        string selectedRow = """";
		        if (item.ID == ViewBag.InstructorID)
		        {
		            selectedRow = ""success"";
		        }
		        <tr class=""@selectedRow"">
		            <td>
		                @Html.DisplayFor(modelItem => item.LastName)
		            </td>
		            <td>
		                @Html.DisplayFor(modelItem => item.FirstMidName)
		            </td>
		            <td>
		                @Html.DisplayFor(modelItem => item.HireDate)
		            </td>
		            <td>
		                @if (item.OfficeAssignment != null)
		                {
		                    @item.OfficeAssignment.Location
		                }
		            </td>
		            <td>
		                @Html.ActionLink(""Select"", ""Index"", new { id = item.ID }) |
		                @Html.ActionLink(""Edit"", ""Edit"", new { id = item.ID }) |
		                @Html.ActionLink(""Details"", ""Details"", new { id = item.ID }) |
		                @Html.ActionLink(""Delete"", ""Delete"", new { id = item.ID })
		            </td>
		        </tr>
		    }

		</table>
		@if (Model.Courses != null)
		{
		    <h3>Courses Taught by Selected Instructor</h3>
		    <table class=""table"">
		        <tr>
		            <th></th>
		            <th>Number</th>
		            <th>Title</th>
		            <th>Department</th>
		        </tr>

		        @foreach (var item in Model.Courses)
		        {
		            string selectedRow = """";
		            if (item.CourseID == ViewBag.CourseID)
		            {
		                selectedRow = ""success"";
		            }
		            <tr class=""@selectedRow"">
		                <td>
		                    @Html.ActionLink(""Select"", ""Index"", new { courseID = item.CourseID })
		                </td>
		                <td>
		                    @item.CourseID
		                </td>
		                <td>
		                    @item.Title
		                </td>
		                <td>
		                    @item.Department.Name
		                </td>
		            </tr>
		        }

		    </table>
		}"
            }

        };
    }
}
