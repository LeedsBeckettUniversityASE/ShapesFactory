using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ShapesInheritanceExample
{
    /// <summary>
    /// Abstract Shape class.
    /// </summary>
    abstract class Shape:Shapes
    {
        protected Color colour; //shape's colour
        protected int x, y; //not I could use c# properties for this
        public Shape()
        {
            colour = Color.Red;
            x = y = 100;
        }

      
        public Shape(Color colour, int x, int y)
        {

            this.colour = colour; //shape's colour
            this.x = x; //its x pos
            this.y = y; //its y pos
            //can't provide anything else as "shape" is too general
        }

        //the three methods below are from the Shapes interface
        //here we are passing on the obligation to implement them to the derived classes by declaring them as abstract
        public virtual void draw(Graphics g)
        {
            Font drawFont = new Font("Arial", 12);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            // Set format of string.
            StringFormat drawFormat = new StringFormat();
            drawFormat.FormatFlags = StringFormatFlags.NoClip;
            String text = this.ToString();
            g.DrawString(text, drawFont, drawBrush,this.x, this.y, drawFormat);
        }
        public abstract double calcArea(); //any derrived class must implement this method
        public abstract double calcPerimeter(); //any derrived class must implement this method

        //set is declared as virtual so it can be overridden by a more specific child version
        //but is here so it can be called by that child version to do the generic stuff
        //note the use of the param keyword to provide a variable parameter list to cope with some shapes having more setup information than others
        public  virtual void set(Color colour, int x, int y)
        {
            this.colour = colour;
            this.x = x;
            this.y =y;
        }


        public override string ToString() //get the standard object name and break hierarchy to get just the name
        {
            String text = base.ToString();
            String[] sut = text.Split('.');
            text = sut[sut.Length - 1];
            return text;
        }

    }
}


