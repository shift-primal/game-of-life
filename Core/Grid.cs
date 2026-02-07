public class Grid
{
    private readonly Random _r = new();
    private readonly Cell[,] _cells;

    private readonly Dimensions _dimensions;

    public Grid(Dimensions dimensions)
    {
        _dimensions = dimensions;

        _cells = new Cell[_dimensions.Width, _dimensions.Height];

        for (int x = 0; x < _dimensions.Width; x++)
        for (int y = 0; y < _dimensions.Height; y++)
        {
            bool shouldBeAlive = _r.Next(5) == 0;
            _cells[x, y] = new Cell(x, y, shouldBeAlive);
        }
    }

    public Cell[,] GetCells()
    {
        return _cells;
    }

    private List<Cell> GetNeighbours(int x, int y)
    {
        List<Cell> neighbours = [];

        for (int r = x - 1; r < x + 2; r++)
        {
            for (int c = y - 1; c < y + 2; c++)
            {
                if (
                    r < 0
                    || r >= _dimensions.Width
                    || c < 0
                    || c >= _dimensions.Height
                    || (r == x && c == y)
                )
                    continue;

                neighbours.Add(_cells[r, c]);
            }
        }

        return neighbours;
    }

    private int GetAliveNeighboursCount(int x, int y)
    {
        var neighbours = GetNeighbours(x, y);

        return neighbours.Count(c => c.IsAlive);
    }

    public void Tick()
    {
        List<Cell> toKill = [];
        List<Cell> toRevive = [];

        foreach (var c in _cells)
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
