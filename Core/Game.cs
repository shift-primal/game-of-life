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
        _running = false;
    }

    private void TogglePausedGame()
    {
        _paused = !_paused;
    }

    public void MainLoopManual()
    {
        while (_running)
        {
            var key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Spacebar || key.Key == ConsoleKey.RightArrow)
            {
                _grid.Tick();
                _view.Render(_grid);
            }
        }
    }

    public void MainLoopAuto()
    {
        while (_running)
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
                }

                if (!_paused)
                {
                    _grid.Tick();
                    _view.Render(_grid);
                }

                Thread.Sleep(_opts.Speed);
            }
        }
    }

    public void Run()
    {
        if (_opts.Auto)
            MainLoopAuto();
        else
            MainLoopManual();
    }
}
