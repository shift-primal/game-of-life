public record Options
{
    public Speed Speed { get; set; }

    public Options(Speed speed)
    {
        Speed = speed;
    }
}
