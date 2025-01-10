using System.Diagnostics;

namespace AutoStartWin;

class Program
{
    public static readonly char[] options = { 'V'/*Valorant*/, 'L'/*League of Legends*/, 'F'/*Fortnite*/, 'Q'/*Quit*/, 'Y' /*Yes*/, 'N'/*No*/};
    static void Main(string[] args)
    {
        if (args.Contains("--boot"))
        {
            Discord();
            Input();
        }
        else
        {
            Input();
        }
    }

    public static void StartViaLNKfile(string filename)
    {
        string shortcutPath = ($@"{filename}");

        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = shortcutPath,
            UseShellExecute = true
        };

        try
        {
            Process.Start(startInfo);
        }
        catch (Exception ex)
        {
            Console.WriteLine("\r\nAn error occurred: " + ex.Message);
        }
    }

    public static void OpenURL(string[] url) 
    {
        for (int i = 0; i < url.Length; i++)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = url[i],
                UseShellExecute = true
            };
            
            Process.Start(startInfo);
        }
    }
    public static char ConvertToUppercase(char inputChar)
    {
        if (char.IsDigit(inputChar) || inputChar == 'E')
        {
            return 'E';
        }
        if (char.IsLower(inputChar))
        {
            inputChar = Convert.ToChar(Convert.ToByte(inputChar)-32);
        }
        if (options.Contains(inputChar))
        {
            return inputChar;
        }
        else 
        {
            return 'E';
        }
    }

    public static int Sec2Milisec(float sec)
    {
        float milisec = sec * 1000;
        return Convert.ToInt32(milisec);
    }
    static void Input()
    {
        Console.WriteLine(
            "Select one of the following options\n" +
            "-----------------------------------\n" +
            "[V] Valorant\n" +
            "[L] League of Legends\n" +
            "[F] Fortnite\n" +
            "[Q] Exit\n" +
            "-----------------------------------"
           );
        Console.Write("[V/L/F/Q]? ");
        char inputChar = Convert.ToChar(Console.ReadKey().KeyChar);
        Console.WriteLine("");
        char input = ConvertToUppercase(inputChar);
        switch (input)
        {
            case 'V':
                Valorant();
                break;
            case 'L':  
                LoL();
                break;
            case 'F':
                Fortnite();
                break;
            case 'Q':
                Quit();
                break;
            case 'E':
                Console.WriteLine("\nInvalid Option!\n");
                Input();
                break;
        }
    }

    static void Discord()
    {
        int SecLeft=16;
        for (int i = 0;i < 15 ; Thread.Sleep(Sec2Milisec(1)))
        {
            i++; SecLeft--;
            Console.Write($"\rDiscord will launch in {SecLeft} seconds");
            if (SecLeft == 1)
            {
                Console.WriteLine("\r\nLauching Discord");
                StartViaLNKfile(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Discord Inc\\Discord.lnk");
            }
        }
    } 

    static void Valorant()
    {
        int SecLeft=16;
        for (int i = 0;i < 15 ; Thread.Sleep(Sec2Milisec(1)))
        {
            i++; SecLeft--;
            Console.Write($"\rValorant Tracker will launch in {SecLeft} seconds");
            if (SecLeft == 1) 
            {
                Console.WriteLine("\r\nLauching Valorant Tracker");
                StartViaLNKfile(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Overwolf\\Valorant Tracker.lnk");

            }
        }
        SecLeft=31;
        for (int i = 0;i < 30 ; Thread.Sleep(Sec2Milisec(1)))
        {
            i++; SecLeft--;
            Console.Write($"\rValorant will launch in {SecLeft} seconds");
            if (SecLeft == 1) 
            {
                Console.WriteLine("\r\nLaunching Valorant");
                Console.WriteLine("good luck :)");
                StartViaLNKfile("C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs\\Riot Games\\VALORANT.lnk");
                Thread.Sleep(Sec2Milisec(45));
            
            }
        }
    }
    
    static void LoL ()
    {
        Console.WriteLine("\nLeague of Legends");
        Console.WriteLine("\r\nOpening champions build\n");
        string[] UrlsFromFile = StringArrayFromFile("urls.txt"); //file must be placed in C:/user/myname
        OpenURL(UrlsFromFile);
        int SecLeft=31;
        for (int i = 0;i < 30 ; Thread.Sleep(Sec2Milisec(1)))
        {
            i++; SecLeft--;
            Console.Write($"\rLeague of Legends will launch in {SecLeft} seconds");
            if (SecLeft == 1) 
            {
                Console.WriteLine("\r\nLaunching League of Legends");
                Console.WriteLine("good luck :)");
                StartViaLNKfile("C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs\\Riot Games\\League of Legends.lnk");
                Thread.Sleep(Sec2Milisec(45)); 
            }
        }
    }

    static void Fortnite()
    {
        int SecLeft=31;
        for (int i = 0;i < 30 ; Thread.Sleep(Sec2Milisec(1)))
        {
            i++; SecLeft--;
            Console.Write($"\rFortnite will launch in {SecLeft} seconds");
            if (SecLeft == 1) 
            {
                Console.Write("\rLaunching Fortnite");
                Console.WriteLine("good luck :)");
                StartViaLNKfile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +"\\Fortnite.url");
                Thread.Sleep(Sec2Milisec(45));
            
            }
        }
    }

    static void Quit()
    {
        Console.Write("Are you Sure? [Y/n] ");
        char inputChar = Convert.ToChar(Console.ReadKey().KeyChar);
        Console.WriteLine("");
        char input = ConvertToUppercase(inputChar);
        switch(input)
        {
            case 'Y':
                Console.WriteLine("Bye!");
                Environment.Exit(0);
                break;
            case 'N':
                Console.Write("\n");
                Input();
                break;
            default:
                Console.WriteLine("Bye!");
                Environment.Exit(0);
                break;
        }
    }

    static string[] StringArrayFromFile(string filename)
    {
        string FullFilename = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\" + filename;
        string[] urls = File.ReadLines(FullFilename).ToArray();
        return urls;
    }
}
