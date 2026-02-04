public class View
{
    private readonly int viewWidth;
    private readonly int viewHeight;
    private readonly Grid grid;
    private readonly GridView gridView;

    public View()
    {
        viewWidth = Console.WindowWidth;
        viewHeight = Console.WindowHeight;

        grid = new(viewWidth, viewHeight);
        gridView = new(viewWidth, viewHeight, ConsoleColor.Black, ConsoleColor.White);
    }

    public void Render()
    {
        foreach (var c in grid.cells)
        {
            if (c.IsAlive)
                gridView.DrawPixel(c.Position.X, c.Position.Y);
            else
                gridView.ClearPixel(c.Position.X, c.Position.Y);
        }
    }
}
