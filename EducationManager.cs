namespace WestcoastEducation;

public class EducationManager : Teacher
{
    public EducationManager(string firstName, string lastName, string phone, string email, string personalNumber, string adress, string postalCode, string city, DateTime employmentDate, string knowledgeArea) : base(firstName, lastName, phone, personalNumber, adress, postalCode, city, employmentDate, knowledgeArea)
    {
    }

    public override string ToString()
    {
        return
        $"Utbildningsledare | " +
        $"För-Efternamn: {FirstName} {LastName} | " +
        $"Telefon: {Phone} | " +
        $"Personnummer: {PersonalNumber} | " +
        $"Adress: {Adress} | " +
        $"Postnummer: {PostalCode} | " +
        $"Stad: {City} | " +
        $"Kunskapsområde: {KnowledgeArea} | " +
        $"Anställd: {EmploymentDate:yyyy-MM-dd}";
    }
}
