namespace WestcoastEducation;

public abstract class Person
{
    public string FirstName {get; private set;}
    public string LastName {get; private set;}
    public string Phone {get; private set;}
    public string PersonalNumber {get; private set;}
    public string Adress {get; private set;}
    public string PostalCode {get; private set;}
    public string City {get; private set;}

    protected Person(string firstName, string lastName, string phone, string personalNumber, string adress, string postalCode, string city)
    {
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
        PersonalNumber = personalNumber;
        Adress = adress;
        PostalCode = postalCode;
        City = city;
    }

    public override string ToString()
    {
        return 
        $"För-Efternamn: {FirstName} {LastName} | " + 
        $"Telefon: {Phone} | " + 
        $"Personnummer: {PersonalNumber} | " +
        $"Adress: {Adress} | " +
        $"Postnummer: {PostalCode} | " +
        $"Stad: {City}";
    }
}
