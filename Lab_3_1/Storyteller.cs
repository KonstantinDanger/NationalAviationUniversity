public class Storyteller : Person, ICook, IStudy
{
    public string Vocabulary { get; private set; }

    public Storyteller() : base()
    {
        Vocabulary = default;
    }

    public Storyteller(string firstName, string lastName, bool isMale, string vocabulary) : base(firstName, lastName, isMale)
    {
        Vocabulary = vocabulary;
    }

    public void Cook()
    {
        Console.WriteLine("Cook veal");
    }

    public void Study()
    {
        string letters = "abcdefghijklmnopqrstuvwxyz";
        int count = new Random().Next(5, 15);
        string word = "";

        for (int i = 0; i < count; i++)
        {
            word += letters[new Random().Next(0, letters.Length-1)];
        }

        Vocabulary += $", {word}";
    }

    public override string ToString()
    {
        return base.ToString() + new String($"\nVocabulary: {Vocabulary}");
    }
}

