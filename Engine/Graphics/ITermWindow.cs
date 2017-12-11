namespace Engine.Graphics
{
    public interface ITermWindow : IWindow
    {
        void SetBg(short bg, int x, int y);
        void SetFg(short fg, int x, int y);
        void SetCh(int ch, int x, int y);

        short GetBg(int x, int y);
        short GetFg(int x, int y);
        int GetCh(int x, int y);
    }
}