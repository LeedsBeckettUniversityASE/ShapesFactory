using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ShapesInheritanceExample
{
    /// <summary>
    /// Shapes Example using the Facory Design pattern to create the shapes.
    /// </summary>
    public partial class Form1 : Form 
    {
        List<Shape> shapes = new List<Shape>();
         
        public Form1()
        {
            InitializeComponent();

            ShapeFactory factory = new ShapeFactory();
            try
            {
                shapes.Add(factory.getShape("circle"));
                shapes.Add(factory.getShape("triangle"));
                shapes.Add(factory.getShape("rectangle"));
                
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Invalid shape: " + e);
                
            }

            //add some random shapes
            Random rand = new Random(77887);
            for (int i=0; i<150; i++)
            {
                int x = rand.Next(Size.Width);
                int y = rand.Next(Size.Height);
                int size = rand.Next(250);

                int red = rand.Next(255);
                int green = rand.Next(255);
                int blue = rand.Next(255);

                Color newColour = Color.FromArgb(128, red, green, blue); //128 is semi transparent

                int shape = rand.Next(4);
                Shape s;
                try
                {
                    Console.WriteLine("Creating shape type " + shape);
                    switch (shape)
                    {
                        case 0:
                            Circle c;
                            c = (Circle) factory.getShape("circle");
                            c.set(newColour, x, y, size);
                            shapes.Add(c);// new Circle(newColour, x, y, size));

                            break;
                        case 1:
                            Rectangle r;
                            r = (Rectangle) factory.getShape("rectangle");
                            r.set(newColour, x, y, size, size);
                            shapes.Add(r);
                            break;
                        case 2:
                            Square sq;
                            sq = (Square) factory.getShape("square");
                            sq.set(newColour, x, y, size, size);
                            shapes.Add(sq);
                            break;
                        case 3:
                           //there isn't a triangle
                            s = factory.getShape("tri");
                            s.set(newColour, x, y);
                            shapes.Add(s);
                            break;

                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("Invalid shape: " + e);

                }
            }
            
        }

        /// <summary>
        /// Handles the Paint event for the form, rendering all shapes in the collection to the screen.
        /// </summary>
        /// <remarks>This method iterates through a collection of shapes and calls their <c>draw</c>
        /// method to render them onto the form's graphics surface. If a null shape is encountered in the collection, a
        /// warning message is logged to the console.</remarks>
        /// <param name="sender">The source of the event, typically the form being painted.</param>
        /// <param name="e">A <see cref="PaintEventArgs"/> object that provides data for the Paint event, including the graphics surface
        /// to draw on.</param>
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Console.WriteLine("paint called");
            Graphics g = e.Graphics;
         

            for (int i = 0; i<shapes.Count; i++)
            {
                Shape s;
                s = (Shape) shapes[i];
                if (s != null)
                {
                    s.draw(g);
                    Console.WriteLine(s.ToString());
                }
                else
                    Console.WriteLine("invalid shape in array"); //shouldn't happen as factory does not produce rubbish

            }
        }
    }
}


