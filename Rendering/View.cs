public class View
{
    public readonly int viewWidth;
    public readonly int viewHeight;

    private readonly GridView gridView;

    public View(int width, int height)
    {
        viewWidth = width;
        viewHeight = height;

        gridView = new(viewWidth, viewHeight, ConsoleColor.Black, ConsoleColor.White);
    }

    public void Render(Grid grid)
    {
        var cells = grid.GetCells();

        foreach (var c in cells)
        {
            if (c.IsAlive)
                gridView.DrawPixel(c.Position.X, c.Position.Y);
            else
                gridView.ClearPixel(c.Position.X, c.Position.Y);
        }
    }
}
