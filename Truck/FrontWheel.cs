using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGL;

namespace Garage_Truck_WinfoForms.Truck
{
    public class FrontWheel : DrawbleComponent
    {
        public GLUquadric obj { get; set; }

        public FrontWheel()
        {
            obj = GLU.gluNewQuadric();
        }

        public override void Draw()
        {
            GL.glRotatef(90f, 0.0f, 1.0f, 0.0f);
            GL.glTranslatef(1.6f, 0, 1.5f);
            GL.glRotatef(-90f, 0.0f, 1.0f, 0.0f);
            
            for (int i = 1; i < 3; i++)
            {
                GL.glBegin(GL.GL_SPHERE_MAP);
                GLU.gluCylinder(obj, 0.3f, 0.3f, 0.2f, 25, 25);
                GL.glEnd();

                float x1, y1, z1, x2, y2, z2;
                double angle;
                double radius = 0.3f;

                x1 = 0f;
                y1 = 0f;
                z1 = 0.2f;


                GL.glBegin(GL.GL_TRIANGLE_FAN);

                GL.glVertex3f(x1, y1, z1);
                for (int j = 0; j < 2; j++)
                {
                    //GL.glRotatef(90, 1, 0, 0);
                    GL.glTranslatef(0, 0, -0.3f * j);
                    for (angle = 0.0f; angle < 2 * 3.14159 + 1; angle += 0.1f)
                    {
                        x2 = +(float)(System.Math.Sin(angle) * radius);
                        y2 = y1 + (float)(System.Math.Cos(angle) * radius);
                        z2 = z1;
                        GL.glVertex3f(x2, y2, z2);
                    }
                }

                GL.glEnd();
                GL.glTranslatef(0, 0, 0 + 0.8f);
            }
          
        }
    }
}
