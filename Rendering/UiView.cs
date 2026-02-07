using gameoflife.Core;

namespace gameoflife.Rendering
{
    public class UiView(
        Dimensions dimensions,
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

            string row = new(' ', dimensions.Width);

            for (int y = offsetY; y < offsetY + dimensions.Height; y++)
            {
                Console.SetCursorPosition(offsetX, y);
                Console.Write(row);
            }

            Console.ResetColor();
        }

        public void Update(UiStats stats)
        {
            Console.ForegroundColor = textColor;
            Console.BackgroundColor = bgColor;

            Console.SetCursorPosition(offsetX, offsetY + 1);

            Write($"Generation Count: {stats.GenerationCount}");
            Write($"Current Speed: {stats.Speed}");
            Write(stats.Paused ? "󰏤 PAUSED" : "󰐊 RUNNING");

            Console.ResetColor();
        }

        private static void Write(string msg)
        {
            Console.WriteLine(msg.PadLeft(msg.Length + 2));
        }
    }
}
