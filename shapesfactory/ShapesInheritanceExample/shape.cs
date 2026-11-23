using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ShapesInheritanceExample
{
    /// <summary>
    /// Abstract Shape class. Provides a base implementation for geometric shapes, implementing the IShape interface. 
    /// It defines common properties such as color and position (x, y), and provides a default constructor and a 
    /// parameterized constructor for initializing these properties. The class also includes abstract methods for
    /// calculating area and perimeter, which must be implemented by derived classes. 
    /// Additionally, it provides a virtual method for drawing the shaope but it only outouts its name as a font, allowing 
    /// derived classes to override these methods as needed.
    /// </summary>
    abstract class Shape:IShape
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
       
        /// <summary>
        /// virtual method to draw the shape's name insode the shape.
        /// Should be overridden by child claasses, which can draw the shape and then call thi sto name it.
        /// </summary>
        /// <param name="g">graphics context to draw on</param>
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
        /// <summary>
        /// calculate the area of the shape.
        /// </summary>
        /// <returns>area</returns>
        public abstract double calcArea(); //any derrived class must implement this method

        /// <summary>
        /// calculate the preimeter of the shape
        /// </summary>
        /// <returns>perimeter</returns>
        public abstract double calcPerimeter(); //any derrived class must implement this method

        //set is declared as virtual so it can be overridden by a more specific child version
        //but is here so it can be called by that child version to do the generic stuff
        //note the use of the param keyword to provide a variable parameter list to cope with some shapes having more setup information than others
        
        /// <summary>
        /// virtual set the sets the properties stored in this class.
        /// Overriding method should set its properties and call this to set the base properties
        /// </summary>
        /// <param name="colour">colour of shape to be drawn</param>
        /// <param name="x">x poistion on drawing surface</param>
        /// <param name="y">y position on drawing surface</param>
        public  virtual void set(Color colour, int x, int y)
        {
            this.colour = colour;
            this.x = x;
            this.y =y;
        }

        /// <summary>
        /// Already declared as virtual in the base class Object.
        /// Outputs the Object's name without appended hierarchy.
        /// </summary>
        /// <returns></returns>
        public override string ToString() //get the standard object name and break hierarchy to get just the name
        {
            String text = base.ToString();
            String[] sut = text.Split('.');
            text = sut[sut.Length - 1];
            return text;
        }

    }
}


