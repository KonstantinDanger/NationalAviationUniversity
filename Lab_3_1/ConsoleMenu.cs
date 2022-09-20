using System.Text.RegularExpressions;
namespace FileManagement;

public class ConsoleMenu
{
    public static void StartMenu()
    {
        University university = new University();
        FileHandler fileHandler = new FileHandler();
        Dentistry dentistry = new Dentistry();
        Storyteller[] storytellers = new Storyteller[0]; 
        bool showSpecial = false;

        string[] dateTimeFormats = {"M/d/yyyy h:mm:ss tt", "M/d/yyyy h:mm tt",
                                           "MM/dd/yyyy hh:mm:ss", "M/d/yyyy h:mm:ss",
                                           "M/d/yyyy hh:mm tt", "M/d/yyyy hh tt",
                                           "M/d/yyyy h:mm", "M/d/yyyy h:mm",
                                           "MM/dd/yyyy hh:mm", "M/dd/yyyy hh:mm",
                                           "MM/d/yyyy HH:mm:ss.ffffff" };

        //add student Michael Burry true 12/12/2001 24Kf3sd 4 207743 84
        //add student Gregory Ramsey true 9/12/2000 24Kf3sd 5 78673 98
        //add student Anny May false 12/12/2000 DLB3gf#(%^@^#@($3454798 5 43523 92
        //add student Lilith May false 12/12/2000 DLB3gf 5 43523 56

        //add dentist Gregory Burry true 3 5000

        //add storyteller Mark Pattison true Word,AnotherWord,ThirdWord,SomeWord

        //@"C:\Users\SerGun\Desktop\ООП\Лаб№3.1\Lab_3_1\IOData\Data.txt"
        //@"C:\Users\SerGun\Desktop\ООП\Лаб№3.1\Lab_3_1\IOData\Output.txt"

        while (true)
        {
            #region commands
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("To add a student enter \"add student\" then enter: \"firstName\" \"lastName\" \"isMale\" \"birthDate\" \"studentID\" \"cource\" \"identity code\" \"average mark\"");
            Console.WriteLine("To add a dentist enter \"add dentist\" then enter: \"firstName\" \"lastName\" \"isMale\" \"qualification level\" \"salary\"");
            Console.WriteLine("To add a storyteller enter \"add storyteller\" then enter: \"firstName\" \"lastName\" \"isMale\" \"vocabulary \"word,word,word...\" \"");
            Console.WriteLine("*!File path shouldn't contain empty entries!*");
            Console.WriteLine("To read information from file enter \"read \"filePath\"\"");
            Console.WriteLine("To write information to file enter \"write \"filePath\"\"");
            Console.WriteLine("To show all excellent female students on 5th cource enter \"show \"excellent\"\"");
            Console.WriteLine("To make student study enter \"student\" \"student index\" \".study\"");
            Console.WriteLine("To make dentist study enter \"dentist\" \"dentist index\" \".study\"");
            Console.WriteLine("To make storyteller study enter \"storyteller\" \"storyteller index\" \".study\"");
            Console.WriteLine("To clear read text from the buffer enter \"clear buffer\"");
            Console.WriteLine("To end the program enter \"exit\"");
            Console.WriteLine("------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            #endregion

            #region output  

            if(university.Length != 0)
            {
                if (showSpecial)
                {
                    Console.WriteLine("\n------------------------------------------------------------------");
                    Console.WriteLine("Excellent female students on 5th course:\n");

                    for (int i = 0; i < university.Length; i++)
                    {
                        if (!university[i].IsMale && university[i].IsExcellent() && university[i].Course == 5)
                        {
                            Console.WriteLine($"{university[i]}\n");
                        }
                    }
                }

                Console.WriteLine("------------------------------------------------------------------");
                Console.WriteLine("Student list: ");
               
                for (int i = 0; i < university.Length; i++)
                {
                    Console.WriteLine($"\n{i + 1}) {university[i]}");
                }
            }

            showSpecial = false;

            if (dentistry.Length != 0)
            {
                Console.WriteLine("\n------------------------------------------------------------------");
                Console.WriteLine("Dentist list: ");

                for (int i = 0; i < dentistry.Length; i++)
                {
                    Console.WriteLine($"\n{i + 1}) {dentistry[i]}");
                }
            }

            if (storytellers.Length != 0)
            {
                Console.WriteLine("\n------------------------------------------------------------------");
                Console.WriteLine("Storytellers list: ");

                for (int i = 0; i < storytellers.Length; i++)
                {
                    Console.WriteLine($"\n{i + 1}) {storytellers[i]}");
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            #endregion

            Console.WriteLine("\n------------------------------------------------------------------");
            string input = Console.ReadLine();
            string[] str = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            #region input checks
            try
            {
                if (input.Contains("add"))
                {
                    if (input.Contains("student"))
                    {
                        if (str.Length != 10)
                        {
                            ErrorLog("Student array length error!");
                            continue;
                        }

                        AddStudent(str, university);
                    }
                    else if (input.Contains("dentist"))
                    {
                        if (str.Length != 7)
                        {
                            ErrorLog("Dentist array length error!");
                            continue;
                        }

                        AddDentist(str, dentistry);
                    }
                    else if (input.Contains("storyteller"))
                    {
                        if (str.Length != 6)
                        {
                            ErrorLog("Storyteller array length error!");
                            continue;
                        }

                        AddStoryteller(str, ref storytellers);
                    }
                }
                else if (input.Contains("list"))
                {
                    Console.WriteLine("Student list: ");
                    Console.WriteLine(university);
                }
                else if (input.Contains("read"))
                {
                    string path = str[1];

                    fileHandler.ReadFromFile(path);
                }
                else if (input.Contains("write"))
                {
                    string path = str[1];
                    fileHandler.WriteToFile(path, $"{university}\n\n{dentistry}", false);
                }
                else if (input.Contains("show"))
                {
                    if (university.Length == 0)
                    {
                        ErrorLog("There are no students yet!");
                        continue;
                    }

                    showSpecial = true;
                }
                else if (input.Contains("exit"))
                {
                    Environment.Exit(0);
                    break;
                }
                else if (input.Contains(".study"))
                {
                    int.TryParse(str[1], out int index);

                    if (input.Contains("student"))
                    {
                        if (index == 0)
                        {
                            ErrorLog("There are no students yet!");
                            continue;
                        }

                        if(university[index-1].Course >= 6)
                        {
                            ErrorLog("This student already have reached max course!");
                            continue;
                        }

                        university[index - 1].Study();
                    }
                    else if (input.Contains("dentist"))
                    {
                        if (index == 0)
                        {
                            ErrorLog("There are no students yet!");
                            continue;
                        }

                        dentistry[index - 1].Study();
                    }
                    else if (input.Contains("storyteller"))
                    {
                        if (index == 0)
                        {
                            ErrorLog("There are no storytellers yet!");
                            continue;
                        }

                        storytellers[index - 1].Study();
                    }

                }
                else if (input == "")
                {
                    Console.Clear();
                    continue;
                }
                else if(input.Contains("clear buffer"))
                {
                    fileHandler.ClearBuffer();
                }
                else
                {
                    ErrorLog();
                    continue;
                }
            }
            catch (IndexOutOfRangeException)
            {
                ErrorLog("Error!");
                continue;
            }
            #endregion

            Console.Clear();
        }
        Console.ReadLine();
    }

    private static void AddStudent(string[] str, University university)
    {
        string namePattern = @"[^a-zA-Z]+";
        string numberPattern = @"[^0-9]+";

        string firstName = Regex.Replace(str[2], namePattern, "");
        string lastName = Regex.Replace(str[3], namePattern, "");
        bool.TryParse(str[4], out bool isMale);
        DateTime.TryParse(Regex.Replace(str[5], @"[^0-9:/]+", ""), out DateTime birthDate);
        string studentID = Regex.Replace(str[6], @"[^a-zA-Z0-9]+", "");
        int.TryParse(Regex.Replace(str[7], numberPattern, ""), out int cource);
        int.TryParse(Regex.Replace(str[8], numberPattern, ""), out int identityCode);
        int.TryParse(Regex.Replace(str[9], numberPattern, ""), out int mark);

        university.Add(new(firstName, lastName, isMale, birthDate, studentID, cource, identityCode, mark));
    }

    private static void AddDentist(string[] str, Dentistry dentistry)
    {
        string namePattern = @"[^a-zA-Z]+";
        string numberPattern = @"[^0-9]+";

        string firstName = Regex.Replace(str[2], namePattern, "");
        string lastName = Regex.Replace(str[3], namePattern, "");
        bool.TryParse(str[4], out bool isMale);
        int.TryParse(Regex.Replace(str[5], numberPattern, ""), out int qualificationLevel);
        int.TryParse(Regex.Replace(str[6], numberPattern, ""), out int salary);

        dentistry.Add(new(firstName, lastName, isMale, qualificationLevel, salary));
    }

    private static void AddStoryteller(string[] str, ref Storyteller[] storytellers)
    {
        string namePattern = @"[^a-zA-Z]+";
        string numberPattern = @"[^0-9]+";

        string firstName = Regex.Replace(str[2], namePattern, "");
        string lastName = Regex.Replace(str[3], namePattern, "");
        bool.TryParse(str[4], out bool isMale);
        string vocabulary = Regex.Replace(String.Join(", ", str[5].Split(',', StringSplitOptions.None)), @"[^a-zA-Z', ]+", "");

        Array.Resize(ref storytellers, storytellers.Length + 1);
        storytellers[storytellers.Length - 1] = new (firstName, lastName, isMale, vocabulary);
    }

    private static void ErrorLog(string message = "There's no such command!")
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("------------------------------------------------------------------");
        Console.WriteLine(message);
        Console.WriteLine("------------------------------------------------------------------\n");
    }

    public static void SetConsoleSize(int width, int height)
    {
        Console.SetWindowSize(width, height);
    }
}