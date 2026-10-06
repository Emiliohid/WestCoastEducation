namespace WestcoastEducation;

public class Course
{
    private readonly List<Student> _students = new();


    public int CourseNumber { get; private set; }

    public string Title { get; private set; }

    public int DurationDays { get; private set; }

    public DateTime StartDate { get; private set; }


    public DateTime EndDate
    {
        get { return StartDate.AddDays(DurationDays); }
    }


    public CourseType Type { get; private set; }

    public Teacher? Teacher { get; private set; }


    public IReadOnlyList<Student> Students
    {
        get { return _students; }
    }


    public Course(
        string title,
        int durationDays,
        DateTime startDate,
        CourseType type)
    {
        CourseNumber = Random.Shared.Next(10000, 100000);
        Title = title;
        DurationDays = durationDays;
        StartDate = startDate;
        Type = type;
    }


    public void AssignTeacher(Teacher teacher)
    {
        if (Teacher == teacher)
        {
            return;
        }

        if (Teacher != null)
        {
            Teacher.RemoveResponsibleCourse(this);
        }

        Teacher = teacher;

        teacher.AddResponsibleCourse(this);
    }


    public void RemoveTeacher()
    {
        if (Teacher == null)
        {
            return;
        }

        Teacher oldTeacher = Teacher;

        Teacher = null;

        oldTeacher.RemoveResponsibleCourse(this);
    }


    public void AddStudent(Student student)
    {
        if (_students.Contains(student))
        {
            Console.WriteLine(
                $"{student.FirstName} är redan registrerad på {Title}");

            return;
        }

        _students.Add(student);

        student.AddCourse(this);

        Console.WriteLine(
            $"{student.FirstName} har registrerats på {Title}");
    }


    public void RemoveStudent(Student student)
    {
        if (!_students.Contains(student))
        {
            Console.WriteLine(
                $"{student.FirstName} är inte registrerad på {Title}");

            return;
        }

        _students.Remove(student);

        student.RemoveCourse(this);

        Console.WriteLine(
            $"{student.FirstName} har tagits bort från {Title}");
    }


    public void ChangeSchedule(
        DateTime newStartDate,
        int newDurationDays)
    {
        if (newDurationDays <= 0)
        {
            Console.WriteLine(
                "Kursens längd måste vara större än 0");

            return;
        }

        StartDate = newStartDate;
        DurationDays = newDurationDays;
    }


    public override string ToString()
    {
        string teacherName =
            Teacher == null
                ? "Ingen lärare tilldelad"
                : $"{Teacher.FirstName} {Teacher.LastName}";

        return
            $"Kursnummer: {CourseNumber}\n" +
            $"Titel: {Title}\n" +
            $"Kurstillfälle: {Type}\n" +
            $"Längd: {DurationDays} dagar\n" +
            $"Start: {StartDate:yyyy-MM-dd}\n" +
            $"Slut: {EndDate:yyyy-MM-dd}\n" +
            $"Lärare: {teacherName}\n" +
            $"Antal studenter: {_students.Count}";
    }
}