using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGL;

namespace Garage_Truck_WinfoForms
{
    public class StreetLight : DrawbleComponent
    {
        public GLUquadric obj { get; set; }

        public float Red { get; set; }
        public float Green { get; set; }
        public float Blue { get; set; }
       

        public StreetLight()
        {
            obj = GLU.gluNewQuadric();
            Red = 0.5f;
            Green = 0.7f;
            Blue = 0.2f;
        }

        public override void Draw()
        {

            GL.glEnable(GL.GL_LIGHTING);
            GL.glEnable(GL.GL_LIGHT0);
            GL.glEnable(GL.GL_COLOR_MATERIAL);
            GL.glEnable(GL.GL_DEPTH_TEST);
            GL.glColorMaterial(GL.GL_FRONT_AND_BACK, GL.GL_AMBIENT_AND_DIFFUSE);

            GL.glColor3d(1, 1, 1);
            GL.glColor3d(0, 1, 1);
        //    GL.glBegin(GL.GL_SPHERE_MAP);
        //    
        //    GL.glRotatef(90f, -1.0f, 0.0f, 0.0f);
        //    GL.glTranslatef(4, 0, 0);
        //    GLU.gluCylinder(obj, 0.2f, 0.2f, 4f, 50, 50);
        //    GL.glEnd();
        //
        //    
        //    GL.glBegin(GL.GL_SPHERE_MAP);
            GL.glRotatef(-90f, 1, 0, 0);


            GL.glTranslatef(4, -0.1f, 1);
        //    GLU.gluCylinder(obj, 0.2f, 0.2f, 4f, 50, 50);
        //    GL.glEnd();


            GLUT.glutSolidCube(1);

            GL.glDisable(GL.GL_LIGHTING);

            GL.glDisable(GL.GL_TEXTURE_2D);
        }
    }
}
