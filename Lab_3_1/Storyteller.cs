public class Storyteller : Person, ICook
{
    private enum StoryType { fantasy, drama, comedy, horror }
    private StoryType storyType;

    public void Cook()
    {
        Console.WriteLine("Cook veal");
    }

    public override string ToString()
    {
        return base.ToString() + new String($"\nstory type: {storyType.ToString()}");
    }
}

