public class Grid
{
    private readonly Random _r = new();
    public Cell[,] cells;

    private readonly int _width;
    private readonly int _height;

    public Grid(int w, int h)
    {
        _width = w;
        _height = h;

        cells = new Cell[_width, _height];

        for (int x = 0; x < w; x++)
        for (int y = 0; y < h; y++)
        {
            bool shouldBeAlive = _r.Next(5) == 0;
            cells[x, y] = new Cell(x, y, shouldBeAlive);
        }
    }

    private List<Cell> GetNeighbours(int x, int y)
    {
        List<Cell> neighbours = [];

        for (int r = x - 1; r < x + 2; r++)
        {
            for (int c = y - 1; c < y + 2; c++)
            {
                if (r < 0 || r >= _width || c < 0 || c >= _height || (r == x && c == y))
                    continue;

                neighbours.Add(cells[r, c]);
            }
        }

        return neighbours;
    }

    private int GetAliveNeighboursCount(int x, int y)
    {
        var neighbours = GetNeighbours(x, y);

        return neighbours.Cast<Cell>().Count(c => c.IsAlive);
    }

    public void Tick()
    {
        List<Cell> toKill = [];
        List<Cell> toRevive = [];

        foreach (var c in cells)
        {
            int nc = GetAliveNeighboursCount(c.Position.X, c.Position.Y);

            if (c.IsAlive && (nc < 2 || nc > 3))
                toKill.Add(c);
            else if (!c.IsAlive && nc == 3)
                toRevive.Add(c);
        }

        foreach (var c in toKill)
            c.Kill();

        foreach (var c in toRevive)
            c.Revive();
    }
}
