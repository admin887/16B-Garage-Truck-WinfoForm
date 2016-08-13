using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGL;

namespace Garage_Truck_WinfoForms.Truck
{
    class Chassis : DrawbleComponent
    {
        public override void Draw()
        {
            GL.glPushMatrix();
            GL.glTranslatef(0.5f, -0.4f, 1.3f);
            GL.glBegin(GL.GL_POLYGON);
            GL.glColor3f(3.5f, 3.5f, 0);
            GL.glVertex3d(-0.5f, 0.5f, -0.5f);
            GL.glVertex3d(-0.5f, 0.5f, 0.5f);
            GL.glVertex3d(0.5f, 0.5f, 0.5f);
            GL.glVertex3d(0.5f, 0.5f, -0.5f);
            GL.glEnd();
            GL.glPopMatrix();
        }
    }
}
