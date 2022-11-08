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
    public partial class Form1 : Form 
    {
        ArrayList shapes = new ArrayList();
        
        




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
                    switch (shape)
                    {
                        case 0:
                            s = factory.getShape("circle");
                            s.set(newColour, x, y, size);
                            shapes.Add(s);// new Circle(newColour, x, y, size));

                            break;
                        case 1:
                            s = factory.getShape("rectangle");
                            s.set(newColour, x, y, size, size);
                            shapes.Add(s);
                            break;
                        case 2:
                            s = factory.getShape("square");
                            s.set(newColour, x, y, size, size);
                            shapes.Add(s);
                            break;
                        case 3:
                            s = factory.getShape("tritangle");
                            s.set(newColour, x, y, size, size);
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


