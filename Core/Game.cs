public class Game
{
    private readonly int _width;
    private readonly int _height;

    private readonly Options _opts;

    private readonly View _view;
    private readonly Grid _grid;

    private bool _running = true;
    private bool _paused = false;

    public Game()
    {
        _width = Console.WindowWidth;
        _height = Console.WindowHeight;

        _opts = StartScreen.GetOptions();

        _view = new(_width, _height);
        _grid = new(_width, _height);
    }

    private void QuitGame()
    {
        Console.CursorVisible = true;
        Console.ResetColor();
        _running = false;
    }

    private void TogglePausedGame()
    {
        _paused = !_paused;
    }

    public void Tick()
    {
        _view.Render(_grid);
        _grid.Tick();
    }

    public void MainLoop()
    {
        if (Console.KeyAvailable)
        {
            var key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.Escape or ConsoleKey.Q:
                    QuitGame();
                    break;
                case ConsoleKey.Spacebar or ConsoleKey.P:
                    TogglePausedGame();
                    break;
                case ConsoleKey.RightArrow when _paused:
                    Tick();
                    break;
            }
        }

        if (!_paused)
        {
            Tick();
            Thread.Sleep(_opts.Speed);
        }
    }

    public void Run()
    {
        _view.Render(_grid);
        while (_running)
        {
            MainLoop();
        }
    }
}
