# Find the closest rectangle

The Rectangles Store

The requirements of this exercise are for you to implement a class that stores rectangles. A rectangle is defined by the following interface:
```
public interface IRectangle {
  int getLeft();
  int getTop();
  int getRight();
  int getBottom();
  Properties getProperties();
}
```
During its initialization process, your store will receive a rectangle that represents its bounds (e.g. the area in which other rectangles can appear), and a collection of rectangles. A visual representation of this can be seen at the right.

You are required to store these rectangles in an efficient manner (in terms of memory consumption), and to later return the topmost rectangle per specified x, y location (or null in case no rectangle exists in the specified location) in the most efficient way possible in terms of performance.

Note: *Assume that the solution should support a large number of rectangles, and that the bounding rectangle can be extremely large, so a solution containing a simple collection of rectangles isn't efficient enough performance-wise, and a solution containing a map of each point to its corresponding rectangle isn't efficient enough memory-wise.*

The interface that you should implement is defined as:
```
public interface IRectanglesStore {
  void initialize(IRectangle bounds, Collection<IRectangle> rectangles);
  IRectangle findRectangleAt(int x, int y);
}
```

the following snapshots meant to demonstrate the implementation rectangle storage it shows how the program returns the closest-rectangle using binary tree

![](./snap_1.png?raw=true)


![](./snap_2.png?raw=true)
