using System.Text.Json;

namespace WestcoastEducation;

public class JsonCourseRepository : ICourseRepository
{
    private readonly string _filePath;

    public JsonCourseRepository(string filePath)
    {
        _filePath = filePath;
    }

    public void Save(List<Course> courses)
    {
        List<CourseData> courseData = new();
        
        foreach (Course course in courses)
        {
            CourseData data = new()
            {
                CourseNumber = course.CourseNumber,
                Title = course.Title,
                DurationDays = course.DurationDays,
                StartDate = course.StartDate,
                Type = course.Type
            };
            courseData.Add(data);
        }

        JsonSerializerOptions options = new()
        {
            WriteIndented = true
        };
        string json = JsonSerializer.Serialize(courseData, options);
        
        File.WriteAllText(_filePath, json);
    }

    public List<Course> Load()
    {
        List<Course> courses = new();

        if(!File.Exists(_filePath))
        {
            return courses;
        }

        string json = File.ReadAllText(_filePath);
        List<CourseData>? courseData = JsonSerializer.Deserialize<List<CourseData>>(json);

        if (courseData == null)
        {
            return courses;
        }
        
        foreach (CourseData data in courseData)
        {
            Course course = new(data.Title, data.DurationDays, data.StartDate, data.Type);
            courses.Add(course);
        }

        return courses;
    }

}
