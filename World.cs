using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_Truck_WinfoForms
{
    public class World : DrawbleComponentWithCollection
    {
        public World()
        {
            ObjectsToDraw = new List<IDrawable>();
            Road r = new Road();
            Grass g = new Grass();
            Garbage gar= new Garbage();
            Sky sky = new Sky();

            ObjectsToDraw.Add(sky);
             ObjectsToDraw.Add(g);
            ObjectsToDraw.Add(r);
            ObjectsToDraw.Add(gar);
        }
    }
}
