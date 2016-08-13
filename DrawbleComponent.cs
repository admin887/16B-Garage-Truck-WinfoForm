using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGL;

namespace Garage_Truck_WinfoForms
{
    public abstract class DrawbleComponent : IDrawable
    {
        public static uint[] Textures = new uint[17];

        public DrawbleComponent()
        {
            isVisible = true;
        }

        public abstract void Draw();

        public virtual void DrawWithMatrixClosing()
        {
            GL.glPushMatrix();

            Draw();

            GL.glPopMatrix();

            //returning to base Color
            GL.glColor3f(255, 255, 255);

            
        }

        public bool isVisible { get; set; }

       
    }
}
