public class Person
{
    public string FirstName { get; protected set; }
    public string LastName { get; protected set; }
    public bool IsMale { get; protected set; }

    public Person()
    {
        FirstName = "null";
        LastName = "null";
        IsMale = default;
    }

    public Person(string firstName, string lastName, bool isMale)
    {
        FirstName = firstName;
        LastName = lastName;
        IsMale = isMale;
    }

    public override string ToString()
    {
        return String.Format($"{this.GetType().Name} {FirstName + LastName} \nfirst name: {FirstName}, \nlast name: {LastName}, \nis_male: {IsMale},");
    }
}

