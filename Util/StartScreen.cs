public static class StartScreen
{
    public static Options GetOptions()
    {
        var speed = QuestionSpeed();

        return new(speed);
    }

    private static int QuestionSpeed()
    {
        Console.Clear();
        Console.WriteLine("What speed would you like the game to run at?");
        Console.WriteLine("1: Slow (1000ms)");
        Console.WriteLine("2: Medium (500ms)");
        Console.WriteLine("3: Fast (250ms");
        Console.WriteLine("4: Very Fast (100ms");
        Console.WriteLine("5: Super Fast (50ms)");
        Console.Write("Select one: ");

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
