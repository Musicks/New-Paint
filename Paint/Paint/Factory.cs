using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    class Factory
    {
        public Shape getShape(String shapeType)
        {
            shapeType = shapeType.ToUpper().Trim(); //you could argue that you want a specific word string to create an object but I'm allowing any case combination


            if (shapeType.Equals("CIRCLE"))
            {
                return new circle();

            }
            else if (shapeType.Equals("RECTANGLE"))
            {
                return new rectangle();

            }
            else if (shapeType.Equals("SQUARE"))
            {
                return new square();
            }

            else if (shapeType.Equals("TRIANGLE"))
            {
                return new triangle();
            }

            else if (shapeType.Equals("TEXTURE"))
            {
                return new texture();
            }
            else
            {
                //if we get here then what has been passed in is unknown so throw an appropriate exception
                System.ArgumentException argEx = new System.ArgumentException("Factory error: " + shapeType + " does not exist");
                throw argEx;
            }


        }

    }
}
