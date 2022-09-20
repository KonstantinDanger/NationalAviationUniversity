public class University
{
    private Student[] students;
    public int Length { get => students.Length; }

    public University()
    {
        students = new Student[0];
    }

    public Student this[int index]
    {
        get => students[index];

        set => students[index] = value;
    }

    public void Add(Student student)
    {
        Array.Resize(ref students, students.Length+1);
        students[students.Length-1] = student;
    }

    public void Remove(int index)
    {
        students[index] = null;
        Array.Resize(ref students, students.Length-1);
    }

    public override string ToString()
    {
        return String.Format(String.Join("\n\n", students.Select(w => w.ToString())));
    }
} 
