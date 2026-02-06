public class UiView(
    int uiWidth,
    int uiHeight,
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

        string row = new(' ', uiWidth);

        for (int y = offsetY; y < offsetY + uiHeight; y++)
        {
            Console.SetCursorPosition(offsetX, y);
            Console.Write(row);
        }
    }
}
