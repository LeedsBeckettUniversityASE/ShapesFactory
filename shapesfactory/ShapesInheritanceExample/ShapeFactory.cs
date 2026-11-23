using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesInheritanceExample
{
    /// <summary>
    /// Shape factory creates Shape objects, use
    /// </summary>
    class ShapeFactory
    {
        /// <summary>
        /// Creates an object of passed in shape
        /// </summary>
        /// <param name="shapeType"></param>
        /// <returns>Shape reference or throws exception if shape unknown.</returns>
        public Shape getShape(String shapeType)
        {
            shapeType = shapeType.ToUpper().Trim(); //you could argue that you want a specific word string to create an object but I'm allowing any case combination
            
           
            if (shapeType.Equals("CIRCLE"))
            {
                return new Circle();

            }
            else if (shapeType.Equals("RECTANGLE"))
            {
                return new Rectangle();

            }
            else if (shapeType.Equals("SQUARE"))
            {
                return new Square();
            }
            else
            {
                //if we get here then what has been passed in is unkown so throw an appropriate exception
                //in reality you would probably want to create your own exception class for this but for this example I'm just using the built in ArgumentException
                System.ArgumentException argEx = new System.ArgumentException("Factory error: "+shapeType+" does not exist");
                throw argEx;
            }

           
        }
    }
}
