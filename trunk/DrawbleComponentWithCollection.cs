using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_Truck_WinfoForms
{
    public abstract class DrawbleComponentWithCollection : DrawbleComponent
    {
        public List<IDrawable> ObjectsToDraw { get; set; }

        public DrawbleComponentWithCollection()
        {
            ObjectsToDraw = new List<IDrawable>();
        }

        public override void DrawWithMatrixClosing()
        {
            foreach (IDrawable item in ObjectsToDraw)
            {
                item.DrawWithMatrixClosing();
            }
        }

        public override void Draw()
        {
            
        }
    }
}
