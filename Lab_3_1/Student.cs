public class Student : Person, ICook, IStudy
{
    public DateTime BirthDate { get; private set; }
    public float AverageMark { get; private set; }
    public string StudentId { get; private set; }
    public int Course { get; private set; }
    public int IdentityCode { get; private set; }

    public Student() : base()
    {
        BirthDate = default;
        AverageMark = 0;
        StudentId = default;
        Course = 0;
    }

    public Student(string firstName, string lastName, bool isMale, DateTime birthDate, string studentId, int cource, int identityCode, int averageMark) : base(firstName, lastName, isMale) 
    {
        AverageMark = averageMark;
        BirthDate = birthDate;
        StudentId = studentId;
        Course = cource;
        IdentityCode = identityCode;
    }

    public void Cook()
    {
        Console.WriteLine("cook buckwheat");
    }
    
    public void Study()
    {
        if (Course >= 6)
            return;

        AverageMark += 5;

        if(AverageMark > 100)
        {
            Course++;
            AverageMark = 0;
        }
    }

    public bool IsExcellent() => AverageMark >= 90;

    public override string ToString()
    {
        return base.ToString() + new String($"\nstudent Id: {StudentId}, \nbirth date: {BirthDate}, \ncource: {Course}, \nidentity code: {IdentityCode}, \naverage mark: {AverageMark}");
    }

}

