namespace WestcoastEducation;

class Program
{
    static void Main()
    {
        EducationSystem system = new();

        ICourseRepository repository =
            new JsonCourseRepository("courses.json");

        AddStartData(system);

        Menu menu = new(system, repository);

        menu.Run();
    }

    private static void AddStartData(EducationSystem system)
    {
        // =========================
        // LÄRARE
        // =========================

        Administrator administrator1 = new("Lennart", "Karlsson", "0708789882", "Lennart.Karlsson@westcoast.se", "197601068972", "Kungsgatan 10", "48937", "Göteborg", new DateTime(2024, 4, 7), "Systemadministration");

        EducationManager educationManager1 = new("Peter", "Svensson", "0701234567", "Peter.Svensson@westcoast.se", "198001018972", "Storgatan 20", "25220", "Helsingborg", new DateTime(2020, 1, 1), "Utbildningsledare");

        Teacher teacher1 = new(
            "Anna",
            "Andersson",
            "0701112233",
            "19800101-1234",
            "Kungsgatan 10",
            "41101",
            "Göteborg",
            new DateTime(2020, 8, 15),
            "Systemutveckling"
        );

        Teacher teacher2 = new(
            "Erik",
            "Johansson",
            "0702223344",
            "19820202-1234",
            "Storgatan 20",
            "25220",
            "Helsingborg",
            new DateTime(2019, 5, 10),
            "Databasteknik"
        );

        Teacher teacher3 = new(
            "Maria",
            "Svensson",
            "0703334455",
            "19850303-1234",
            "Skolgatan 5",
            "21120",
            "Malmö",
            new DateTime(2021, 1, 15),
            "Systemutveckling"
        );


        // =========================
        // KURSER
        // =========================

        Course course1 = new(
            "C# Grundkurs",
            20,
            new DateTime(2026, 10, 15),
            CourseType.Classroom
        );

        Course course2 = new(
            "C# Fortsättning",
            20,
            new DateTime(2026, 11, 15),
            CourseType.Classroom
        );

        Course course3 = new(
            "Databasteknik",
            20,
            new DateTime(2026, 12, 15),
            CourseType.Distance
        );

        system.AddAdministrator(administrator1);

        system.AddEducationManager(educationManager1);

        system.AddTeacher(teacher1);
        system.AddTeacher(teacher2);
        system.AddTeacher(teacher3);

        system.AddCourse(course1);
        system.AddCourse(course2);
        system.AddCourse(course3);
    }
}
