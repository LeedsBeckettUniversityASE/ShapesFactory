using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesInheritanceExample
{
    /// <summary>
    /// Rectangle class to draw a circle on a bitmap.
    /// </summary>
    class Rectangle :Shape
    {
        int width, height;
        public Rectangle():base()
        {
            width = 100;
            height = 100;
        }
        public Rectangle(Color colour, int x, int y, int width, int height) : base(colour, x, y)
        {

            this.width = width; //the only thingthat is different from shape
            this.height = height;
        }

        public void set(Color colour, int x, int y, int width, int height)
        {
            //note: This is not overridden, it is overloaded as it isn't the same method signature as in Shape
            base.set(colour,x,y);
            this.width = width;
            this.height =height;

        }

        public override void draw(Graphics g)
        {
            Pen p = new Pen(Color.Black,2);
            SolidBrush b = new SolidBrush(colour);
            g.FillRectangle(b, x, y, width, height);
            g.DrawRectangle(p, x, y, width, height);
            base.draw(g);
        }

        public override double calcArea()
        {
            return width * height;
        }

        public override double calcPerimeter()
        {
            return 2 * width + 2 * height;
        }

        public override string ToString() //all classes inherit from object and ToString() is abstract in object
        {
            String text = base.ToString() + "  " + this.width + " " + this.height;
            return text;
        }
    }
}
