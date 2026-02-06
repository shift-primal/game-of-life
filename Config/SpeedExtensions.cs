public static class SpeedExtensions
{
    private static readonly Speed[] _order =
    [
        Speed.Slow,
        Speed.Medium,
        Speed.Fast,
        Speed.VeryFast,
        Speed.SuperFast,
    ];

    public static Speed Next(this Speed speed)
    {
        var i = Array.IndexOf(_order, speed);

        if (i < _order.Length - 1)
            return _order[i + 1];

        return _order[i];
    }

    public static Speed Prev(this Speed speed)
    {
        var i = Array.IndexOf(_order, speed);

        if (i > 0)
            return _order[i - 1];

        return _order[i];
    }
}
