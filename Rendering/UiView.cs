public class UiView(
    Dimensions dimensions,
    int offsetX,
    int offsetY,
    ConsoleColor textColor,
    ConsoleColor bgColor
)
{
    public void Init()
    {
        ClearUi();
    }

    private void ClearUi()
    {
        Console.ForegroundColor = textColor;
        Console.BackgroundColor = bgColor;

        string row = new(' ', dimensions.Width);

        for (int y = offsetY; y < offsetY + dimensions.Height; y++)
        {
            Console.SetCursorPosition(offsetX, y);
            Console.Write(row);
        }

        Console.ResetColor();
    }

    public void Update()
    {
        Console.SetCursorPosition(offsetX, offsetY);
        Console.Write("hei");
    }
}
