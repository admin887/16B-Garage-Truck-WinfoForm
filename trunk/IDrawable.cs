using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_Truck_WinfoForms
{
    public interface IDrawable
    {
        void Draw();
        void DrawWithMatrixClosing();
        bool isVisible { get; set; }
    }
}
