public class Dentist : Person, ICook, IStudy
{
    public int QualificationLevel { get; private set; }
    public float Salary { get; private set; }

    public Dentist()
    {
        QualificationLevel = 0;
        Salary = 0;
    }

    public Dentist(string firstName, string lastName, bool isMale, int qualificationLevel, float salary) : base(firstName, lastName, isMale)
    {
        QualificationLevel = qualificationLevel;
        Salary = salary;
    }

    public void Cook()
    {
        Console.WriteLine("Cook steak");
    }

    public void Study()
    {
        QualificationLevel++;

        Salary += 1000 * QualificationLevel;
    }

    public override string ToString()
    {
        return base.ToString() + new String($"\nqualification level: {QualificationLevel}, \nsalary: {Salary}");
    }
}

