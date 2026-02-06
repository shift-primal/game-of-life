public class Screen
{
    private readonly int _screenWidth;
    private readonly int _screenHeight;

    public readonly int GridWidth;
    public readonly int GridHeight;

    public readonly int UiWidth;
    public readonly int UiHeight;

    private readonly UiView _uiView;
    private readonly GridView _gridView;

    public Screen(int screenWidth, int screenHeight)
    {
        _screenWidth = screenWidth;
        _screenHeight = screenHeight;

        GridWidth = _screenWidth;
        GridHeight = Convert.ToInt32(_screenHeight * 0.9);

        UiWidth = _screenWidth;
        UiHeight = _screenHeight - GridHeight;

        _uiView = new(UiWidth, UiHeight, 0, GridHeight, ConsoleColor.Cyan, ConsoleColor.DarkCyan);
        _gridView = new(GridWidth, GridHeight, 0, 0, ConsoleColor.Black, ConsoleColor.White);

        Init();
    }

    private void Init()
    {
        Console.CursorVisible = false;
        Console.Clear();

        _uiView.Init();
    }

    public void Render(Grid grid)
    {
        var cells = grid.GetCells();

        foreach (var c in cells)
        {
            if (c.IsAlive)
                _gridView.DrawPixel(c.Position.X, c.Position.Y);
            else
                _gridView.ClearPixel(c.Position.X, c.Position.Y);
        }
    }
}
