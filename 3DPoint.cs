using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_Truck_WinfoForms
{
    public class Point3D: Point
    {
        public float Z { get; set; }

        public Point3D() { }

        public Point3D(float i_X, float i_Y, float i_Z)
            : base(i_X, i_Y)
        {
            Z = i_Z;
        }

        public float[] ToArray()
        {
            float[] returnArray = new float[4];

            returnArray[0] = X;
            returnArray[1] = Y;
            returnArray[2] = Z;
            returnArray[3] = 0;

            return returnArray;
        }
    }
}
