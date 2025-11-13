using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace studentNamespace
{
    public struct StudentInfos
    {
        private string studentId;
        private string studentFName;
        private string studentLname;

        public StudentInfos(string studentId)
        {
            this.studentId = studentId;
            this.studentFName = "Not Provided";
            this.studentLname = "Not Provided";
        }

        public StudentInfos(string studentFname, string studentLname)
        {
            this.studentId = "N/A";
            this.studentFName = studentFname;
            this.studentLname = studentLname;
        }

        public StudentInfos(string studentId, string studentFName, string studentLname)
        {
            this.studentId = studentId;
            this.studentFName = studentFName;
            this.studentLname = studentLname;
        }

        public string StudentId { get { return this.studentId; } set { this.studentId = value; } }
        public string StudentFName { get { return this.studentFName; } set { this.studentFName = value; } }
        public string StudentLname { get { return this.studentLname; } set { this.studentLname = value; } }
    }

    public abstract class frmStudentBasic
    {
        protected StudentInfos[] students;
        protected int studentcout;

        public void Start()
        {
            Console.Write("Input how many infos you will put: ");
            studentcout = Convert.ToInt32(Console.ReadLine());
            students = new StudentInfos[studentcout];
        }
    }

    public class studentIdInput : frmStudentBasic
    {
        public string AskStudentId(int index)
        {
            Console.Write($"Enter student ID for student #{index + 1}: ");
            return Console.ReadLine();
        }
    }

    public class studentNameInput : studentIdInput
    {
        public (string, string) AskStudentNames(int index)
        {
            Console.Write($"Enter First Name for Student #{index + 1}: ");
            string fName = Console.ReadLine();

            Console.Write($"Enter Last Name for Student #{index + 1}: ");
            string lName = Console.ReadLine();

            return (fName, lName);
        }
    }

    public class StudentInfo : studentNameInput
    {
        public void collectStudents()
        {
            Start();

            for (int i = 0; i < studentcout; i++)
            {
                Console.WriteLine($"\nstudent #{i + 1}:");
                Console.Write("Do you want to enter (1) ID only, (2) Name only, or (3) Full info? ");
                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    string id = AskStudentId(i);
                    students[i] = new StudentInfos(id);
                }
                else if (choice == 2)
                {
                    (string fname, string lname) = AskStudentNames(i);
                    students[i] = new StudentInfos(fname, lname);
                }
                else
                {
                    string id = AskStudentId(i);
                    (string fname, string lname) = AskStudentNames(i);
                    students[i] = new StudentInfos(id, fname, lname);
                }
            }

            Console.WriteLine("\n--- STUDENT RECORDS ---");
            for (int i = 0; i < studentcout; i++)
            {
                Console.WriteLine($"[{i + 1}] ID: {students[i].StudentId}, Name: {students[i].StudentFName} {students[i].StudentLname}");
            }
        }
    }
}