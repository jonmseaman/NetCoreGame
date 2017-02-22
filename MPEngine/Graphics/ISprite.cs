using System;
using System.Collections.Generic;
using System.Text;

namespace MPEngine.Graphics
{
    public interface ISprite
    {
        void Draw(IWindow win, int x, int y);
    }
}
