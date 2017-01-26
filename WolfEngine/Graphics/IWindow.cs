using System;
using System.Collections.Generic;
using System.Text;

namespace WolfEngine.Graphics
{
    interface IWindow
    {
        int Height { get; set; }
        int Width { get; set; }
        void Draw(int x, int y, ITexture texture);
    }
}
