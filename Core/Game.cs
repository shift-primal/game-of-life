public class Game
{
    private readonly Dimensions _gameDimensions;
    private readonly Dimensions _gridDimensions;

    private readonly Options _opts;

    private int _tickTimer = 0;
    private int _generationCount = 0;

    private readonly Screen _screen;
    private readonly Grid _grid;

    private bool _running = true;
    private bool _paused = false;

    private readonly Dictionary<ConsoleKey, Action> _keyActions;

    public Game()
    {
        _gameDimensions = new(Console.WindowWidth, Console.WindowHeight);
        _gridDimensions = new(_gameDimensions.Width, Convert.ToInt32(_gameDimensions.Height * 0.9));

        _opts = StartScreen.GetOptions();

        _screen = new(_gameDimensions, _gridDimensions);
        _grid = new(_gridDimensions);

        _keyActions = new()
        {
            { ConsoleKey.Escape, QuitGame },
            { ConsoleKey.Q, QuitGame },
            { ConsoleKey.Spacebar, TogglePausedGame },
            { ConsoleKey.P, TogglePausedGame },
            { ConsoleKey.Add, IncreaseSpeed },
            { ConsoleKey.UpArrow, IncreaseSpeed },
            { ConsoleKey.Subtract, DecreaseSpeed },
            { ConsoleKey.DownArrow, DecreaseSpeed },
            { ConsoleKey.RightArrow, TickIfPaused },
        };
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

    private void Tick()
    {
        _screen.Render(_grid);
        _grid.Tick();
        _generationCount++;
    }

    private void TickIfPaused()
    {
        if (_paused)
            Tick();
    }

    private void IncreaseSpeed()
    {
        var currSpeed = _opts.Speed;
        _opts.Speed = currSpeed.Next();
    }

    private void DecreaseSpeed()
    {
        var currSpeed = _opts.Speed;
        _opts.Speed = currSpeed.Prev();
    }

    private void MainLoop()
    {
        if (Console.KeyAvailable)
        {
            var key = Console.ReadKey(true);
            if (_keyActions.TryGetValue(key.Key, out var action))
                action();
        }

        if (!_paused && _tickTimer >= (int)_opts.Speed)
        {
            Tick();
            _tickTimer = 0;
        }

        Thread.Sleep(10);
        _tickTimer += 10;
    }

    public void Run()
    {
        _screen.Render(_grid);
        while (_running)
        {
            MainLoop();
        }
    }
}
