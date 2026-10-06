namespace WestcoastEducation;

public abstract class Employee : Person
{
    public DateTime EmploymentDate {get; private set;}

    protected Employee(string firstName, string lastName, string phone, string personalNumber, string adress, string postalCode, string city, DateTime employmentDate) : base(firstName, lastName, phone, personalNumber, adress, postalCode, city)
    {
        EmploymentDate = employmentDate;
    }

    public override string ToString()
    {
        return $"{base.ToString()} |" + 
        $"Anställd: Employment Date: {EmploymentDate:yyyy-MM-dd}";
    }
}
