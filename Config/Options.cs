using gameoflife.Core;

namespace gameoflife.Config
{
    public record Options
    {
        public Speed Speed { get; set; }
        public Dimensions Dimensions { get; set; }

        public Options(Speed speed, Dimensions dimensions)
        {
            Dimensions = dimensions;
            Speed = speed;
        }
    }
}
