using Domain.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Intefaces
{
    public interface IRectangle
    {
        int getLeft();

        int getTop();

        int getRight();

        int getBottom();

        Properties getProperties();
    }
}
