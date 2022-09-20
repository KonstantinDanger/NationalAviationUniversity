namespace FileManagement;

public class ConsoleMenu
{
    public static void StartMenu()
    {
        University university = new University();
        FileHandler fileHandler = new FileHandler();
        Dentistry dentistry = new Dentistry();
        bool showSpecial = false;

        //add student Michael Burry true 12:12:2001:2001 24Kf3sd 4 207743 84
        //add student Gregory Ramsey true 9:12:2000:2000 24Kf3sd 5 78673 78
        //add student Anny May false 12:12:2000:2001 DLB3gf 5 43523 92

        //add dentist Gregory Burry true 3 5000

        //@"C:\Users\SerGun\Desktop\ООП\Лаб№3.1\Lab_3_1\IOData\Data.txt"
        //@"C:\Users\SerGun\Desktop\ООП\Лаб№3.1\Lab_3_1\IOData\Output.txt"

        while (true)
        {
            #region commands
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("To add a student enter \"add student\" then enter: \"firstName\" \"lastName\" \"isMale\" \"birthDate\" \"studentID\" \"cource\" \"identity code\" \"average mark\"");
            Console.WriteLine("To add a dentist enter \"add dentist\" then enter: \"firstName\" \"lastName\" \"isMale\" \"qualification level\" \"salary\"");
            Console.WriteLine("*!File path shouldn't contain empty entries!*");
            Console.WriteLine("To read information from file enter \"read \"filePath\"\"");
            Console.WriteLine("To write information to file enter \"write \"filePath\"\"");
            Console.WriteLine("To show all excellent female students on 5th cource enter \"show \"excellent\"\"");
            Console.WriteLine("To make student study enter \"student\" \"student index\" \".study\"");
            Console.WriteLine("To make dentist study enter \"dentist\" \"dentist index\" \".study\"");
            Console.WriteLine("To clear read text from the buffer enter \"clear buffer\"");
            Console.WriteLine("To end the program enter \"exit\"");
            Console.WriteLine("------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            #endregion

            #region output

            if(university.Length != 0)
            {
                Console.WriteLine("\n------------------------------------------------------------------");
                if (showSpecial)
                {
                    Console.WriteLine("Excellent female students on 5th course:\n");
                }
                else
                {
                    Console.WriteLine("Student list: ");
                }

                for (int i = 0; i < university.Length; i++)
                {
                    if (showSpecial)
                    {
                        if (!university[i].IsMale && university[i].IsExcellent() && university[i].Course == 5)
                            Console.WriteLine($"{university[i]}\n");
                    }
                    else
                    {
                        Console.WriteLine($"\n{i + 1}) {university[i]}");
                    }
                }
            }

            if(dentistry.Length != 0)
            {
                Console.WriteLine("\n------------------------------------------------------------------");
                Console.WriteLine("Dentist list: ");

                for (int i = 0; i < dentistry.Length; i++)
                {
                    Console.WriteLine($"\n{i + 1}) {dentistry[i]}");
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            showSpecial = false;
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
                            ErrorLog("Student array lenght error!");
                            continue;
                        }

                        string firstName = str[2];
                        string lastName = str[3];
                        bool.TryParse(str[4], out bool isMale);
                        DateTime.TryParse(str[5], out DateTime birthDate);
                        string studentID = str[6];
                        int.TryParse(str[7], out int cource);
                        int.TryParse(str[8], out int identityCode);
                        int.TryParse(str[9], out int mark);

                        university.Add(new(firstName, lastName, isMale, birthDate, studentID, cource, identityCode, mark));
                    }
                    else if (input.Contains("dentist"))
                    {
                        if (str.Length != 7)
                        {
                            ErrorLog("Dentist array lenght error!");
                            continue;
                        }

                        string firstName = str[2];
                        string lastName = str[3];
                        bool.TryParse(str[4], out bool isMale);
                        int.TryParse(str[5], out int qualificationLevel);
                        int.TryParse(str[6], out int salary);

                        dentistry.Add(new(firstName, lastName, isMale, qualificationLevel, salary));
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

