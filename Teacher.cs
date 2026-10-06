namespace WestcoastEducation;

public class Teacher : Employee
{
    private readonly List<Course> _responsibleCourses = new();

    public string KnowledgeArea { get; private set; }

    public IReadOnlyList<Course> ResponsibleCourses
    {
        get { return _responsibleCourses; }
    }

    public Teacher(string firstName, string lastName, string phone, string personalNumber, string adress, string postalCode, string city, DateTime employmentDate, string knowledgeArea) : base(firstName, lastName, phone, personalNumber, adress, postalCode, city, employmentDate)
    {
        KnowledgeArea = knowledgeArea;
    }

    public void AddResponsibleCourse (Course course)
    {
        if(!_responsibleCourses.Contains(course))
        {
            _responsibleCourses.Add(course);
        }
    }

    public void RemoveResponsibleCourse(Course course)
    {
        _responsibleCourses.Remove(course);
    }

    public override string ToString()
    {
        return $"Lärare | {base.ToString()} | " +
               $"Kunskapsområde: {KnowledgeArea} | " +
               $"Ansvariga kurser: {_responsibleCourses.Count}";
    }
}
