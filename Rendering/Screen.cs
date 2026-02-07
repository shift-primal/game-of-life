using gameoflife.Core;

namespace gameoflife.Rendering
{
    public class Screen
    {
        private readonly Dimensions _screenDimensions;
        private readonly Dimensions _gridDimensions;
        private readonly Dimensions _uiDimensions;

        private readonly UiView _uiView;
        private readonly GridView _gridView;

        public Screen(Dimensions screenDimensions, Dimensions gridDimensions)
        {
            _screenDimensions = screenDimensions;

            _gridDimensions = gridDimensions;

            _uiDimensions = new(
                _screenDimensions.Width,
                _screenDimensions.Height - _gridDimensions.Height
            );

            _gridView = new(_gridDimensions, 0, 0, ConsoleColor.Black, ConsoleColor.White);

            _uiView = new(
                _uiDimensions,
                0,
                _gridDimensions.Height,
                ConsoleColor.Cyan,
                ConsoleColor.Black
            );

            Init();
        }

        private void Init()
        {
            Console.CursorVisible = false;
            Console.Clear();

            _uiView.Init();
        }

        public void RenderGrid(Grid grid)
        {
            var cells = grid.GetCells();

            foreach (var c in cells)
            {
                if (c.IsAlive)
                    _gridView.DrawPixel(c.Position.X, c.Position.Y);
                else
                    _gridView.ClearPixel(c.Position.X, c.Position.Y);
            }
        }

        public void RenderUi(UiStats stats)
        {
            _uiView.Update(stats);
        }
    }
}
