public class StartScreen
{
    public bool Auto;
    public int Speed;

    public StartScreen()
    {
        Auto = QuestionAuto();

        if (Auto)
            Speed = QuestionSpeed();
    }

    private bool QuestionAuto()
    {
        Console.WriteLine("Do you want the game to run auto, or do you want to cycle manually?");
        Console.WriteLine("1: Auto");
        Console.WriteLine("2: Manually");

        var result = Console.ReadLine() switch
        {
            "1" => true,
            "2" => false,
            _ => true,
        };

        return result;
    }

    private int QuestionSpeed()
    {
        Console.WriteLine("What speed would you like the game to run at?");
        Console.WriteLine("1: Slow (1000ms)");
        Console.WriteLine("2: Medium (500ms)");
        Console.WriteLine("3: Fast (250ms");
        Console.WriteLine("4: Very Fast (100ms");
        Console.WriteLine("5: Super Fast (50ms)");

        var result = Console.ReadLine() switch
        {
            "1" => 1000,
            "2" => 500,
            "3" => 250,
            "4" => 100,
            "5" => 50,
            _ => 500,
        };

        return result;
    }
}
