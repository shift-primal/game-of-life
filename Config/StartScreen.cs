using gameoflife.Core;

namespace gameoflife.Config
{
    public static class StartScreen
    {
        public static Options GetOptions()
        {
            var speed = QuestionSpeed();
            var dimensions = new Dimensions(Console.WindowWidth, Console.WindowHeight);

            return new(speed, dimensions);
        }

        private static Speed QuestionSpeed()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("What speed would you like the game to run at?");
                Console.WriteLine("1: Slow (1000ms)");
                Console.WriteLine("2: Medium (500ms)");
                Console.WriteLine("3: Fast (250ms)");
                Console.WriteLine("4: Very Fast (100ms)");
                Console.WriteLine("5: Super Fast (50ms)");
                Console.WriteLine();
                Console.Write("Select one: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        return Speed.Slow;
                    case "2":
                        return Speed.Medium;
                    case "3":
                        return Speed.Fast;
                    case "4":
                        return Speed.VeryFast;
                    case "5":
                        return Speed.SuperFast;
                    default:
                        Console.WriteLine(
                            "Invalid input - Valid inputs are (1-5)\nPress any key to retry."
                        );
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
