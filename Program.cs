using System.Runtime.InteropServices;

namespace ConsoleApp1
{
    class instructor
    {
        public int instructorId;
        public string name;
        public string specializatian;

        public instructor(int instructorId, string name, string specializatian)
        {
            this.instructorId = instructorId;
            this.name = name;
            this.specializatian = specializatian;
        }
        public string printDetails()
        {
            return $"Instructor ID : {instructorId} the name : {name} the specialization : {specializatian} \n";
        }
    }


    class course
    {
        public int courseId;
        public string title;
        public instructor instructor;

        public course(int courseId, string title, instructor instructor)
        {
            this.courseId = courseId;
            this.title = title;
            this.instructor = instructor;
        }
        public string printDetails()
        {
            return $"Course ID : {courseId}  the title : {title} the instructor name : {instructor.name} \n";
        }

    }

    class student
    {
        public int studentId;
        public string name;
        public int Age;
        public List<course> courses= new List<course>();

        public student(int studentId, string name, int age, List<course> courses)
        {
            this.studentId = studentId;
            this.name = name;
            this.Age = age;
            this.courses = courses;
        }
        bool enroll(course course)
        {
            if(courses.Count==0)
            {
                courses.Add(course);
                return true;
            }
            else
            {
                bool flag = false;
                for (int i = 0; i < courses.Count; i++)
                {
                    if (courses[i] == course)
                        flag = true;    
                }
                if(flag)
                {
                    return false;
                }
                courses.Add (course);
                return true;
            }
            return false;
        }
        public string printDetails()
        {
            string details = $"Student ID : {studentId} , name : {name} , age : {Age} \n";
            if(courses.Count==0)
                return details ;
            else
            {
                for (int i = 0;i < courses.Count;i++)
                {
                    details += courses[i].printDetails()+"\n";
                }
            }
            return details ;
        }
    }
    class school
    {
        public List<course> courses;
        public List<student> students;
        public List<instructor> instructors;

        public school(List<course> courses, List<student> students, List<instructor> instructors)
        {
            this.courses = courses;
            this.students = students;
            this.instructors = instructors;
        }
        public bool AddStudent(student student)
        {
            if (students.Count == 0)
            {
                students.Add(student);
                return true;
            }
            else
            {
                bool flag = true;
                for (int i = 0; i < students.Count; i++)
                {
                    if (students[i] == student)
                        flag = false;
                }
                if (flag)
                {
                    students.Add(student);
                    return true;
                }
                return false;
            }
        }
        public bool AddCourse(course course)
        {
            if (courses.Count == 0)
            {
                courses.Add(course);
                return true;
            }
            else
            {
                bool flag = true;
                for (int i = 0; i < courses.Count; i++)
                {
                    if (courses[i] == course)
                        flag = false;
                }
                bool flag2 = true;
                for(int i = 0;i < courses.Count; i++)
                {

                }
                if (flag)
                {
                    courses.Add(course);
                    return true;
                }
                return false;
            }
        }
        public bool AddInstructor(instructor instructor)
        {
            if (instructors.Count == 0)
            {
                instructors.Add(instructor);
                return true;
            }
            else
            {
                bool flag = true;
                for (int i = 0; i < instructors.Count; i++)
                {
                    if (instructors[i] == instructor)
                        flag = false;
                }
                if (flag)
                {
                    instructors.Add(instructor);
                    return true;
                }
                return false;
            }
        }
        public student FindStudent(int id)
        {
            
            for (int i = 0;i < students.Count;i++)
            {
                if (students[i].studentId== id)
                    return students[i];
            }
            return null;
        }
        public course FindCourse(int id)
        {

            for (int i = 0; i < courses.Count; i++)
            {
                if (courses[i].courseId == id)
                    return courses[i];
            }
            return null;
        }
        public instructor FindInstructor(int id)
        {

            for (int i = 0; i < instructors.Count; i++)
            {
                if (instructors[i].instructorId == id)
                    return instructors[i];
            }
            return null;
        }
        public bool EnrollStudentInCourse(int studentId, int courseId)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if(students[i].studentId == studentId)
                {
                    for(int j = 0;j<courses.Count ; j++)
                    {
                        if (courses[j].courseId==courseId)
                        {
                            students[i].courses.Add(courses[j]);
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {

            int x;
            school school1 = new school(new List<course>(), new List<student>(), new List<instructor>()); ;
            while (true)
            {
                Console.WriteLine("1- Add student\n2- Add instructor\n3- Add course\n4- Enroll student in course\n" +
                    "5- Show all students\n6- Show all courses\n7- Show all instructors\n8- Find student by ID\n" +
                    "9- Find course by ID\n10- Exit\n");
                x=Convert.ToInt32(Console.ReadLine());
                switch (x)
                {
                    case 1:
                        student st = new student(0, "", 0, new List<course>()); 
                        Console.WriteLine("enter the student ID\n");
                        st.studentId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("enter the student name\n");
                        st.name = Console.ReadLine();
                        Console.WriteLine("enter the student age\n");
                        st.Age = Convert.ToInt32(Console.ReadLine());
                        if (school1.AddStudent(st))
                            Console.WriteLine("DONE\n");
                        else Console.WriteLine("the student already exists \n");

                        continue;
                    case 2:
                        instructor instructor1 = new instructor(0, "", "");
                        Console.WriteLine("enter the instructor ID \n");
                        instructor1.instructorId= Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("enter the instructor name \n");
                        instructor1.name = Console.ReadLine();
                        Console.WriteLine("enter the instructor specialization \n");
                        instructor1.specializatian = Console.ReadLine();
                        if (school1.AddInstructor(instructor1))
                            Console.WriteLine("DONE\n");
                        else
                            Console.WriteLine("the instructor already exists\n");
                        continue;
                    case 3:
                        course course1 = new course(0, "", new instructor(0, "", ""));
                        int ID;
                        Console.WriteLine("enter the course ID \n");
                        course1.courseId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("enter the course Title \n");
                        course1.title = Console.ReadLine();
                        Console.WriteLine("enter the instructor ID \n");
                        ID = Convert.ToInt32(Console.ReadLine());
                        course1.instructor = school1.FindInstructor(ID);
                        if (school1.AddCourse(course1))
                            Console.WriteLine("Done\n");
                        else
                            Console.WriteLine("the course already exists \n");
                            continue;
                    case 4:
                        Console.WriteLine("enter the student ID\n");
                        int StId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("enter the course ID\n");
                        int CoId = Convert.ToInt32(Console.ReadLine());
                        school1.FindStudent(StId).courses.Add(school1.FindCourse(CoId));
                        Console.WriteLine("DONE\n");
                        continue;
                    case 5:
                        for (int i = 0;i<school1.students.Count;i++)
                        {
                            Console.WriteLine( school1.students[i].printDetails()+"\n");
                        }
                        continue;
                    case 6:
                        for (int i = 0; i < school1.courses.Count; i++)
                        {
                            Console.WriteLine(school1.courses[i].printDetails() + "\n");
                        }
                        continue;
                    case 7:
                        for (int i = 0; i < school1.instructors.Count; i++)
                        {
                            Console.WriteLine(school1.instructors[i].printDetails() + "\n");
                        }
                        continue;
                    case 8:
                        Console.WriteLine("enter the student Id");
                        int STD = Convert.ToInt32(Console.ReadLine());
                        if (school1.FindStudent(STD) == null)
                            Console.WriteLine("the student does not exist\n");
                        else
                             Console.WriteLine( school1.FindStudent(STD).name+"\n");
                        continue;
                    case 9:
                        Console.WriteLine("enter the student Id");
                        int CTD = Convert.ToInt32(Console.ReadLine());
                        if (school1.FindCourse(CTD) == null)
                            Console.WriteLine("the course does not exist\n ");
                        else
                            Console.WriteLine(school1.FindCourse(CTD).title + "\n");
                        continue;
                    case 10:
                        Console.WriteLine("thank you \n");
                        break;
                    default:
                        Console.WriteLine("incorrect value \n");
                        continue;
                }
                break;

                }
        }
    }
}
