using domain.classes;
using Domain.Classes;
using Domain.Intefaces;
using System.Collections.ObjectModel;

namespace Domain.Classes
{
    public class RectanglesStore : IRectanglesStore
    {
        BinaryTree binaryTree;
        public void initialize(IRectangle bounds, Collection<IRectangle> rectangles)
        {
            binaryTree = new BinaryTree(rectangles);
        }

        public IRectangle findRectangleAt(int x, int y)
        {
            Node node = binaryTree.Closest(y);

            return node.Tag ?? null;
        }
    }
}
