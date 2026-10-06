namespace WestcoastEducation;

public class CourseData
{
    public int CourseNumber { get; set; }
    public string Title { get; set; } = "";
    public int DurationDays { get; set; }
    public DateTime StartDate { get; set; }
    public CourseType Type { get; set; }

    public override string ToString()
    {
        return $"{CourseNumber} | {Title} | {Type} | " +
               $"{StartDate:yyyy-MM-dd} | {DurationDays} dagar";
    }
}
