using System;
using System.Collections.Generic;
using System.Text;

namespace MPEngine.Graphics
{
    public interface ITermWindow : IWindow
    {
        void SetBg(short bg, int x, int y);
        void SetFg(short fg, int x, int y);
        void SetCh(Int32 ch, int x, int y);

        short GetBg(int x, int y);
        short GetFg(int x, int y);
        Int32 GetCh(int x, int y);
    }
}
