using System;
using System.Collections.Generic;
using System.Text;

namespace WolfEngine.GraphicsStuff
{
    interface IGraphicsComponent
    {
        void Render(IGraphicsObject obj);
    }
}
