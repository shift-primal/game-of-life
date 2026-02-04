public class Game
{
    public void MainLoop()
    {
        bool running = true;

        while (running)
        {
            Console.ReadKey(true);
        }
    }

    public void Run()
    {
        Console.WriteLine("Game is starting...");
    }
}
