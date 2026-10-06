namespace WestcoastEducation;

public interface ICourseRepository
{
    void Save(List<Course> courses);
    List<Course> Load();
}
