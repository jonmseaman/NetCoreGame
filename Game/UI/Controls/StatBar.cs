using System;

namespace Game.UI.Controls
{
    public class StatBar : UiComponent
    {
        private int _statCurrent;
        private int _statMax;

        public StatBar(ConsoleColor bg)
        {
            BackgroundColor = bg;
        }

        public int StatCurrent
        {
            get { return _statCurrent; }
            set
            {
                if (value != _statCurrent)
                {
                    _statCurrent = value;
                    NeedsUpdate = true;
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
                    NeedsUpdate = true;
                }
            }
        }

        public ConsoleColor BackgroundColor { get; }

        public override void Update()
        {
            // Do nothing.
        }

        public override void Redraw()
        {
            var count = Width * StatCurrent / StatMax;
            Console.CursorLeft = Left;
            Console.CursorTop = Top;
            // Filled part.
            Console.BackgroundColor = BackgroundColor;
            for (var i = 0; i < count; i++)
                Console.Write(' ');
            // Empty part.
            Console.BackgroundColor = ConsoleColor.Black;
            for (var i = count; i < Width; i++)
                Console.Write(' ');
        }
    }
}