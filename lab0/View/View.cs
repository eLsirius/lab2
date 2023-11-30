using System.Security.Cryptography.X509Certificates;

public class View
{
    public bool programmRunning;
    private readonly ICalendar calendarInterface = new Calendar();

    public void Greet()
    {
        Console.WriteLine("Usage:");
    }

    public void RepeatGreet()
    {
        Console.WriteLine("check to check if year is a leap one");
        Console.WriteLine("calc to calculate interval length");
        Console.WriteLine("day to get the name of day of the week");
        Console.WriteLine("quit to exit");
        WriteDashLine();

        string userInput = Console.ReadLine();
        ProcessInput(userInput);
    }
    public void WriteDashLine()
    {      
        Console.WriteLine("-------");
    }
    public void Start()
    {
        Greet();
        programmRunning = true;
        while (programmRunning)
            RepeatGreet();    
    }

    public void ProcessInput(string input)
    {
        var validInputs = new Dictionary<string, int>()
        {
            { "check", 0},
            { "calc", 1},
            { "day", 2},
            { "quit", 3},
        };
        if (!validInputs.ContainsKey(input))
        {
            WriteWrongInputMessage();
            return;
        }
        switch (validInputs[input])
        {
            case 0:
                CheckYearLeap();
                break;
            case 1:
                CalculateIntervalLength();
                break;
            case 2:
                GetNameOfDayOfTheWeek();
                break;
            case 3:
                Quit();
                break;
            default:   
                WriteNoInputMessage();
                break;     
        }
    }

    void WriteNoInputMessage()
    {
        Console.WriteLine("No input.");
    }

    void WriteWrongInputMessage()
    {
        Console.WriteLine("Wrong input.");
        WriteDashLine();
    }
    private bool CheckYearLeap()
    {
        Console.WriteLine("Input year: ");
        bool validInput = Int32.TryParse(Console.ReadLine(), out Int32 year);
        if (validInput && calendarInterface.LeapCheck(year))
        {
            Console.WriteLine("The year is leap!");
            WriteDashLine();
            return true;
        }
        Console.WriteLine("The year is not leap.");
        WriteDashLine();
        return false;
    }
    private int CalculateIntervalLength()
    {
        Console.WriteLine("Input first year: ");
        bool validInput1 = Int32.TryParse(Console.ReadLine(), out Int32 year1);
        Console.WriteLine("Input second year: ");
        bool validInput2 = Int32.TryParse(Console.ReadLine(), out Int32 year2);
        if (validInput1 && validInput2)
        {
            Console.WriteLine("The gap is: " + calendarInterface.GetYearIntervalLength(year1, year2) + " years");
            WriteDashLine();
            return calendarInterface.GetYearIntervalLength(year1, year2);
        }
        WriteWrongInputMessage();
        return 0;
    }

    private DayOfWeek GetNameOfDayOfTheWeek()
    {
        Console.WriteLine("Input year: ");
        bool validInput1 = Int32.TryParse(Console.ReadLine(), out Int32 year);
        Console.WriteLine("Input month: ");
        bool validInput2 = Int32.TryParse(Console.ReadLine(), out Int32 month);
        Console.WriteLine("Input day: ");
        bool validInput3 = Int32.TryParse(Console.ReadLine(), out Int32 day);
        if (!validInput1 || !validInput2 || !validInput3)
        {
            WriteWrongInputMessage();
            return 0;
        }
        WriteDashLine();
        Console.WriteLine("The day of the week is: " + calendarInterface.GetNameOfDayOfTheWeek(year, month, day) + ".");
        WriteDashLine();
        return calendarInterface.GetNameOfDayOfTheWeek(year, month, day);
    }

    private void Quit()
    {
        programmRunning = false;
    }
}