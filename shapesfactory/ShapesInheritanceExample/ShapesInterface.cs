using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesInheritanceExample
{
    /// <summary>
    /// Defines a contract for geometric shapes, providing methods to set properties, draw the shape,  and calculate its
    /// area and perimeter.
    /// </summary>
    /// <remarks>Implementations of this interface represent specific types of shapes (e.g., circles,
    /// rectangles)  and must provide concrete behavior for setting properties, rendering, and performing
    /// calculations.</remarks>
    interface Shapes
    {
        void set(Color c, int x, int y);
        void draw(Graphics g);
        double calcArea();
        double calcPerimeter();

    }
}
