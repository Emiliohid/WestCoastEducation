namespace WestcoastEducation;

public class Menu
{
    private readonly EducationSystem _system;
    private readonly ICourseRepository _repository;

    public Menu(
        EducationSystem system,
        ICourseRepository repository)
    {
        _system = system;
        _repository = repository;
    }


    // =========================
    // HUVUDMENY
    // =========================

    public void Run()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("VÄLKOMMEN TILL WESTCOAST EDUCATION!");
            Console.WriteLine("====================================");
            Console.WriteLine("1. Lägg till Student");
            Console.WriteLine("2. Lägg till Lärare");
            Console.WriteLine("3. Lägg till Kurs");
            Console.WriteLine("4. Koppla Student till Kurs");
            Console.WriteLine("5. Koppla Lärare till Kurs");
            Console.WriteLine("6. Ta bort Student från Kurs");
            Console.WriteLine("7. Ta bort Lärare från Kurs");
            Console.WriteLine("8. Visa UtbildningsLedare");
            Console.WriteLine("9. Visa Administratörer");
            Console.WriteLine("10. Visa Studenter");
            Console.WriteLine("11. Visa Lärare");
            Console.WriteLine("12. Visa Kurser");
            Console.WriteLine("13. Spara Kurser till JSON");
            Console.WriteLine("14. Läs Kurser från JSON");
            Console.WriteLine("0. Avsluta");
            Console.WriteLine();

            string choice = ReadInput("Välj ett alternativ: ");

            switch (choice)
            {
                case "1":
                    AddStudent();
                    break;

                case "2":
                    AddTeacher();
                    break;

                case "3":
                    AddCourse();
                    break;

                case "4":
                    AddStudentToCourse();
                    break;

                case "5":
                    AddTeacherToCourse();
                    break;

                case "6":
                    RemoveStudentFromCourse();
                    break;

                case "7":
                    RemoveTeacherFromCourse();
                    break;

                case "8":
                    _system.ListEducationManagers();
                    break;

                case "9":
                    _system.ListAdministrators();
                    break;

                case "10":
                    _system.ListStudents();
                    break;

                case "11":
                    _system.ListTeachers();
                    break;

                case "12":
                    _system.ListCourses();
                    break;

                case "13":
                    SaveToJson();
                    break;

                case "14":
                    LoadFromJson();
                    break;

                case "0":
                    running = false;
                    Console.WriteLine("Programmet avslutas.");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Ogiltigt alternativ. Försök igen.");
                    break;
            }
        }
    }


    // =========================
    // LÄGG TILL STUDENT
    // =========================

    private void AddStudent()
    {
        Console.WriteLine();
        Console.WriteLine("LÄGG TILL STUDENT");
        Console.WriteLine("=================");

        string firstName = ReadInput("Förnamn: ");
        string lastName = ReadInput("Efternamn: ");
        string phone = ReadInput("Telefon: ");
        string personalNumber = ReadInput("Personnummer: ");
        string address = ReadInput("Adress: ");
        string postalCode = ReadInput("Postnummer: ");
        string city = ReadInput("Stad: ");

        Student student = new(
            firstName,
            lastName,
            phone,
            personalNumber,
            address,
            postalCode,
            city);

        _system.AddStudent(student);

        Console.WriteLine();
        Console.WriteLine(
            $"{student.FirstName} {student.LastName} har lagts till.");
    }


    // =========================
    // LÄGG TILL LÄRARE
    // =========================

    private void AddTeacher()
    {
        Console.WriteLine();
        Console.WriteLine("LÄGG TILL LÄRARE");
        Console.WriteLine("================");

        string firstName = ReadInput("Förnamn: ");
        string lastName = ReadInput("Efternamn: ");
        string phone = ReadInput("Telefon: ");
        string personalNumber = ReadInput("Personnummer: ");
        string address = ReadInput("Adress: ");
        string postalCode = ReadInput("Postnummer: ");
        string city = ReadInput("Stad: ");

        DateTime employmentDate =
            ReadDate("Anställningsdatum (yyyy-MM-dd): ");

        string knowledgeArea =
            ReadInput("Kunskapsområde: ");

        Teacher teacher = new(
            firstName,
            lastName,
            phone,
            personalNumber,
            address,
            postalCode,
            city,
            employmentDate,
            knowledgeArea);

        _system.AddTeacher(teacher);

        Console.WriteLine();
        Console.WriteLine(
            $"{teacher.FirstName} {teacher.LastName} har lagts till som lärare.");
    }


    // =========================
    // LÄGG TILL KURS
    // =========================

    private void AddCourse()
    {
        Console.WriteLine();
        Console.WriteLine("LÄGG TILL KURS");
        Console.WriteLine("==============");

        string title = ReadInput("Kursnamn: ");

        int durationDays =
            ReadInt("Antal dagar: ");

        DateTime startDate =
            ReadDate("Startdatum (yyyy-MM-dd): ");

        CourseType type =
            ReadCourseType();

        Course course = new(
            title,
            durationDays,
            startDate,
            type);

        _system.AddCourse(course);

        Console.WriteLine();
        Console.WriteLine(
            $"{course.Title} har lagts till.");
    }


    // =========================
    // KOPPLA STUDENT TILL KURS
    // =========================

    private void AddStudentToCourse()
    {
        Console.WriteLine();
        Console.WriteLine("KOPPLA STUDENT TILL KURS");
        Console.WriteLine("========================");

        Student? student = SelectStudent();

        if (student == null)
        {
            return;
        }

        Course? course = SelectCourse();

        if (course == null)
        {
            return;
        }

        course.AddStudent(student);
    }


    // =========================
    // KOPPLA LÄRARE TILL KURS
    // =========================

    private void AddTeacherToCourse()
    {
        Console.WriteLine();
        Console.WriteLine("KOPPLA LÄRARE TILL KURS");
        Console.WriteLine("=======================");

        Course? course = SelectCourse();

        if (course == null)
        {
            return;
        }

        Teacher? teacher = SelectAvailableTeacher();

        if (teacher == null)
        {
            return;
        }

        course.AssignTeacher(teacher);

        Console.WriteLine();
        Console.WriteLine($"{teacher.FirstName} {teacher.LastName} " +
                          $"är nu ansvarig för {course.Title}.");
    }


    // =========================
    // TA BORT STUDENT FRÅN KURS
    // =========================

    private void RemoveStudentFromCourse()
    {
        Console.WriteLine();
        Console.WriteLine("TA BORT STUDENT FRÅN KURS");
        Console.WriteLine("=========================");

        Student? student = SelectStudent();

        if (student == null)
        {
            return;
        }

        Course? course = SelectCourse();

        if (course == null)
        {
            return;
        }

        course.RemoveStudent(student);
    }


    // =========================
    // TA BORT LÄRARE FRÅN KURS
    // =========================

    private void RemoveTeacherFromCourse()
    {
        Console.WriteLine();
        Console.WriteLine("TA BORT LÄRARE FRÅN KURS");
        Console.WriteLine("========================");

        Course? course = SelectCourse();

        if (course == null)
        {
            return;
        }

        if (course.Teacher == null)
        {
            Console.WriteLine(
                $"{course.Title} har ingen lärare.");

            return;
        }

        string teacherName =
            $"{course.Teacher.FirstName} {course.Teacher.LastName}";

        course.RemoveTeacher();

        Console.WriteLine(
            $"{teacherName} har tagits bort från {course.Title}.");
    }

    private Student? SelectStudent()
    {
        List<Student> students =
            _system.GetStudents();

        if (students.Count == 0)
        {
            Console.WriteLine("Det finns inga studenter.");
            return null;
        }

        Console.WriteLine();
        Console.WriteLine("STUDENTER");
        Console.WriteLine("=========");

        for (int i = 0; i < students.Count; i++)
        {
            Console.WriteLine(
                $"{i + 1}. " +
                $"{students[i].FirstName} " +
                $"{students[i].LastName}");
        }

        int choice =
            ReadInt("Välj student: ");

        if (choice < 1 || choice > students.Count)
        {
            Console.WriteLine("Ogiltigt val.");
            return null;
        }

        return students[choice - 1];
    }


    // =========================
    // VÄLJ LÄRARE
    // =========================

    private Teacher? SelectTeacher()
    {
        List<Teacher> teachers =
            _system.GetTeachers();

        if (teachers.Count == 0)
        {
            Console.WriteLine("Det finns inga lärare.");
            return null;
        }

        Console.WriteLine();
        Console.WriteLine("LÄRARE");
        Console.WriteLine("======");

        for (int i = 0; i < teachers.Count; i++)
        {
            Console.WriteLine(
                $"{i + 1}. " +
                $"{teachers[i].FirstName} " +
                $"{teachers[i].LastName}");
        }

        int choice =
            ReadInt("Välj lärare: ");

        if (choice < 1 || choice > teachers.Count)
        {
            Console.WriteLine("Ogiltigt val.");
            return null;
        }

        return teachers[choice - 1];
    }

    private Teacher? SelectAvailableTeacher()
    {
        List<Teacher> teachers =
        _system.GetTeachers();

        if (teachers.Count == 0)
            {
                Console.WriteLine(
                "Det finns inga lärare tillgängliga.");

                return null;
            }

            Console.WriteLine();
            Console.WriteLine("TILLGÄNGLIGA LÄRARE");
            Console.WriteLine("===================");

            for (int i = 0; i < teachers.Count; i++)
            {
                Teacher teacher = teachers[i];

                Console.WriteLine($"{i + 1}. " + $"{teacher.FirstName} {teacher.LastName}");

                Console.WriteLine( $"   Kunskapsområde: {teacher.KnowledgeArea}");

                Console.WriteLine( $"   Ansvariga kurser: {teacher.ResponsibleCourses.Count}");

                Console.WriteLine();
            }

        int choice =
        ReadInt("Välj lärare: ");

        if (choice < 1 || choice > teachers.Count)
        {
            Console.WriteLine("Ogiltigt val.");
            return null;
        }

            return teachers[choice - 1];
    }

    private Course? SelectCourse()
    {
        List<Course> courses =
            _system.GetCourses();

        if (courses.Count == 0)
        {
            Console.WriteLine("Det finns inga kurser.");
            return null;
        }

        Console.WriteLine();
        Console.WriteLine("KURSER");
        Console.WriteLine("======");

        for (int i = 0; i < courses.Count; i++)
        {
            Console.WriteLine(
                $"{i + 1}. {courses[i].Title}");
        }

        int choice =
            ReadInt("Välj kurs: ");

        if (choice < 1 || choice > courses.Count)
        {
            Console.WriteLine("Ogiltigt val.");
            return null;
        }

        return courses[choice - 1];
    }

    private void SaveToJson()
    {
        _repository.Save(
            _system.GetCourses());

        Console.WriteLine();
        Console.WriteLine(
            "Kurserna har sparats till JSON.");
    }

    private void LoadFromJson()
    {
        List<Course> courses = _repository.Load();

            _system.ReplaceCourses(courses);

        Console.WriteLine();
        Console.WriteLine(
            $"{courses.Count} kurser lästes in från JSON.");
    }

    private string ReadInput(string message)
    {
        Console.Write(message);

        return Console.ReadLine() ?? "";
    }


    private int ReadInt(string message)
    {
        while (true)
        {
            string input =
                ReadInput(message);

            if (int.TryParse(input, out int number))
            {
                return number;
            }

            Console.WriteLine(
                "Du måste ange ett heltal.");
        }
    }


    private DateTime ReadDate(string message)
    {
        while (true)
        {
            string input =
                ReadInput(message);

            if (DateTime.TryParse(
                input,
                out DateTime date))
            {
                return date;
            }

            Console.WriteLine(
                "Ogiltigt datum. Försök igen.");
        }
    }


    private CourseType ReadCourseType()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("1. Klassrum");
            Console.WriteLine("2. Distans");

            string choice =
                ReadInput("Välj kurstyp: ");

            switch (choice)
            {
                case "1":
                    return CourseType.Classroom;

                case "2":
                    return CourseType.Distance;

                default:
                    Console.WriteLine(
                        "Ogiltigt val.");
                    break;
            }
        }
    }
}
