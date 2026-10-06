namespace WestcoastEducation;

public class EducationSystem
{
    private readonly List<Course> _courses = new();
    private readonly List<Student> _students = new();
    private readonly List<Teacher> _teachers = new();
    private readonly List<EducationManager> _educationManagers = new();
    private readonly List<Administrator> _administrators = new();

    public void AddCourse(Course course)
    {
        if (!_courses.Contains(course))
        {
            _courses.Add(course);
        }
    }

    public void ReplaceCourses(List<Course> courses)
    {
        _courses.Clear();

        foreach (Course course in courses)
        {
            _courses.Add(course);
        }
    }


    public void AddStudent(Student student)
    {
        if (!_students.Contains(student))
        {
            _students.Add(student);
        }
    }


    public void AddTeacher(Teacher teacher)
    {
        if (!_teachers.Contains(teacher))
        {
            _teachers.Add(teacher);
        }
    }


    public void AddEducationManager(EducationManager manager)
    {
        if (!_educationManagers.Contains(manager))
        {
            _educationManagers.Add(manager);
        }
    }


    public void AddAdministrator(Administrator administrator)
    {
        if (!_administrators.Contains(administrator))
        {
            _administrators.Add(administrator);
        }
    }

    public List<Course> GetCourses()
    {
        return new List<Course>(_courses);
    }

    public List <Student> GetStudents()
    {
        return new List<Student>(_students);
    }

    public List <Teacher> GetTeachers()
    {
        return new List<Teacher>(_teachers);
    }
    

    public void ListCourses()
    {
        PrintList("KURSER", _courses);
    }


    public void ListStudents()
    {
        PrintList("STUDENTER", _students);
    }


    public void ListTeachers()
    {
        PrintList("LÄRARE", _teachers);
    }


    public void ListEducationManagers()
    {
        PrintList("UTBILDNINGSLEDARE", _educationManagers);
    }


    public void ListAdministrators()
    {
        PrintList("ADMINISTRATÖRER", _administrators);
    }


    private void PrintList<T>(string title, IEnumerable<T> items)
    {
        Console.WriteLine();
        Console.WriteLine("==========================================");
        Console.WriteLine(title);
        Console.WriteLine("==========================================");

        foreach (T item in items)
        {
            Console.WriteLine(item);
            Console.WriteLine("------------------------------------------");
        }
    }
}
