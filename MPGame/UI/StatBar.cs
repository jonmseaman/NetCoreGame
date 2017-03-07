using System;

namespace MPGame.UI
{
    public class StatBar : IComponent
    {
        private bool _statChanged = true;
        private int _statCurrent;
        private int _statMax;

        public StatBar(ConsoleColor bg)
        {
            BackgroundColor = bg;
        }

        public int Top { get; set; }
        public int Left { get; set; }
        public int Width { get; set; }

        public int StatCurrent
        {
            get { return _statCurrent; }
            set
            {
                if (value != _statCurrent)
                {
                    _statCurrent = value;
                    _statChanged = true;
                }
            }
        }

        public int StatMax
        {
            get { return _statMax; }
            set
            {
                if (value != _statMax)
                {
                    _statMax = value;
                    _statChanged = true;
                }
            }
        }

        public ConsoleColor BackgroundColor { get; }

        public virtual void Render()
        {
            if (!_statChanged) return;

            var count = Width * StatCurrent / StatMax;
            Console.CursorLeft = Left;
            Console.CursorTop = Top;
            // Filled part.
            Console.BackgroundColor = BackgroundColor;
            for (var i = 0; i < count; i++)
                Console.Write(' ');
            // Empty part.
            Console.BackgroundColor = ConsoleColor.Black;
            for (var i = count + 1; i < Width; i++)
                Console.Write(' ');

            // Don't redraw if the stat hasn't been changed next time.
            _statChanged = false;
        }

        public virtual void Update()
        {
            // Do nothing.
        }
    }
}