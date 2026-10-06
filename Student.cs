

namespace WestcoastEducation;

public class Student : Person
{
    private readonly List<Course> _courses = new();

    public IReadOnlyList<Course> Courses
    {
        get { return _courses; }
    }

    public Student (string firstName, string lastName, string phone, string personalNumber, string adress, string postalCode, string city) : base(firstName, lastName, phone, personalNumber, adress, postalCode, city)
    {
    }

    public void AddCourse(Course course)
    {
        if(!_courses.Contains(course))
        {
            _courses.Add(course);
        }
    }

    public void RemoveCourse(Course course)
    {
        _courses.Remove(course);
    }

    public override string ToString()
    {
        return $"Student | {base.ToString()}";
    }
}
