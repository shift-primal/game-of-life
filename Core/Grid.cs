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
            bool shouldBeAlive = _r.Next(2) == 0;
            cells[x, y] = new Cell(x, y, shouldBeAlive);
        }
    }

    public Cell GetCell(int x, int y)
    {
        return cells[x, y];
    }

    public List<Cell> GetNeighbours(int x, int y)
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

    public List<Cell> GetAliveNeighbours(int x, int y)
    {
        List<Cell> aliveCells = [];

        var neighbours = GetNeighbours(x, y);

        foreach (var c in neighbours)
            if (c.IsAlive)
                aliveCells.Add(c);

        return aliveCells;
    }
}
