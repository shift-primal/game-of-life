public class GridView(
    int gridWidth,
    int gridHeight,
    int offsetX,
    int offsetY,
    ConsoleColor pixelColor,
    ConsoleColor bgColor
)
{
    private const char pixel = '█';

    public void FillGrid(bool empty = false)
    {
        Console.ForegroundColor = pixelColor;
        Console.BackgroundColor = bgColor;

        char symbol = empty ? ' ' : pixel;
        string row = new(symbol, gridWidth);

        for (int y = offsetY; y < offsetY + gridHeight; y++)
        {
            Console.SetCursorPosition(offsetX, y);
            Console.Write(row);
        }
    }

    public void DrawPixel(int x, int y, ConsoleColor pixelColor = ConsoleColor.Black)
    {
        Console.ForegroundColor = pixelColor;
        Console.BackgroundColor = bgColor;

        Console.SetCursorPosition(x, y);
        Console.Write(pixel);

        Console.ResetColor();
    }

    public void ClearPixel(int x, int y)
    {
        Console.BackgroundColor = bgColor;

        Console.SetCursorPosition(x, y);
        Console.Write(" ");

        Console.ResetColor();
    }
}
