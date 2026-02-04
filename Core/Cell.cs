public class Cell(int x, int y, bool alive)
{
    public readonly Position Position = new(x, y);
    public bool IsAlive = alive;

    public void Kill()
    {
        IsAlive = false;
    }

    public void Revive()
    {
        IsAlive = true;
    }
}
