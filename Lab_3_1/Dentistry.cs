public class Dentistry
{
    private Dentist[] dentists;
    
    public int Length { get => dentists.Length; }

    public Dentistry()
    {
        dentists = new Dentist[0];
    }

    public Dentist this[int index]
    {
        get => dentists[index];

        set => dentists[index] = value;
    }

    public void Add(Dentist dentist)
    {
        Array.Resize(ref dentists, dentists.Length + 1);
        dentists[dentists.Length - 1] = dentist;
    }

    public void Remove(int index)
    {
        dentists[index] = null;
        Array.Resize(ref dentists, dentists.Length - 1);
    }

    public override string ToString()
    {
        return String.Format(String.Join("\n\n", dentists.Select(w => w.ToString())));
    }
}
