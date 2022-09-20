using System.Text.RegularExpressions;

public class FileHandler
{
    private string text;
    public string Text { get => text; }

    public void ReadFromFile(string path)
    {
        using (StreamReader reader = new StreamReader(path))
        {
            string txt = reader.ReadToEnd() + "\n";
            string pattern = @"[@;“”{}, ]+";
            txt = Regex.Replace(txt, pattern, String.Empty);
            text = txt;
        }
    }

    public void WriteToFile(string path, string data, bool append = false)
    {
        using (StreamWriter writer = new StreamWriter(path, append))
        {
            string txt = $"{text}\n{data}\n";
            writer.Write(txt);
        }
    }

    public void ClearBuffer()
    {
        text = default;
    }
}