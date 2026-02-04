public class GridView
{
    private readonly int _gridWidth;
    private readonly int _gridHeight;
    private readonly ConsoleColor _pixelColor;
    private readonly ConsoleColor _bgColor;
    private const char _pixel = '█';

    public GridView(int gridWidth, int gridHeight, ConsoleColor pixelColor, ConsoleColor bgColor)
    {
        _gridWidth = gridWidth;
        _gridHeight = gridHeight;
        _pixelColor = pixelColor;
        _bgColor = bgColor;

        Init();
    }

    public void Init()
    {
        Console.CursorVisible = false;

        ClearScreen();
    }

    public void ClearScreen()
    {
        Console.ForegroundColor = _pixelColor;
        Console.BackgroundColor = _bgColor;
        Console.Clear();
        FillScreen(true);
    }

    public void FillScreen(bool empty = false)
    {
        char symbol = empty ? ' ' : _pixel;
        string row = new(symbol, _gridWidth);

        for (int y = 0; y < _gridHeight; y++)
        {
            Console.SetCursorPosition(0, y);
            Console.Write(row);
        }
    }

    public void DrawPixel(int x, int y, ConsoleColor pixelColor = ConsoleColor.Black)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = pixelColor;
        Console.Write(_pixel);

        Console.ResetColor();
    }

    public void ClearPixel(int x, int y)
    {
        Console.SetCursorPosition(x, y);
        Console.BackgroundColor = _bgColor;
        Console.Write(" ");

        Console.ResetColor();
    }
}
