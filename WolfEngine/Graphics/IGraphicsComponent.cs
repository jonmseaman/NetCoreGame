using System;
using System.Collections.Generic;
using System.Text;

namespace WolfEngine.Graphics
{
    interface IGraphicsComponent
    {
        void Render(IGraphicsObject obj);
    }
}
