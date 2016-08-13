using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_Truck_WinfoForms
{
    public class Point
    {
        public Point() { }

        public Point(float i_X, float i_Y)
        {
            X = i_X;
            Y = i_Y;
        }

        public float X { get; set; }
        public float Y { get; set; }
    }
}
