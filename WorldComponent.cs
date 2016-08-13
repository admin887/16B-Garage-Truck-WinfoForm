using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_Truck_WinfoForms
{
    public abstract class WorldComponent: DrawbleComponent
    {
        protected float Width { get; set; }

        protected float Height { get; set; }

        protected float Length { get; set; }

        public Point3D StartPoition { get; set; }
    }
}
