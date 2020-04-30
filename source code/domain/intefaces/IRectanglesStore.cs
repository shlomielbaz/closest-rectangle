using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Domain.Intefaces
{
    public interface IRectanglesStore
    {
        void initialize(IRectangle bounds, Collection<IRectangle> rectangles);

        IRectangle findRectangleAt(int x, int y);
    }
}
