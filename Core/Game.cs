public class Game
{
    private readonly int _width;
    private readonly int _height;

    private readonly StartScreen _startScreen;

    private readonly View _view;
    private readonly Grid _grid;

    private readonly bool _auto;
    private readonly int _speed;

    public Game()
    {
        _width = Console.WindowWidth;
        _height = Console.WindowHeight;

        _startScreen = new();

        _auto = _startScreen.Auto;
        _speed = _startScreen.Speed;

        _view = new(_width, _height);
        _grid = new(_width, _height);
    }

    public void MainLoopManual()
    {
        bool running = true;
        _view.Render(_grid);

        while (running)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Spacebar || key.Key == ConsoleKey.RightArrow)
            {
                _grid.Tick();
                _view.Render(_grid);
            }
        }
    }

    public void MainLoopAuto()
    {
        bool running = true;
        _view.Render(_grid);

        while (running)
        {
            _grid.Tick();
            _view.Render(_grid);
            Thread.Sleep(_speed);
        }
    }

    public void Run()
    {
        if (_auto)
            MainLoopAuto();
        else
            MainLoopManual();
    }
}
