using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGL;

namespace Garage_Truck_WinfoForms.Truck
{
    public class BackWheels : DrawbleComponent
    {
           public GLUquadric obj { get; set; }

           public BackWheels()
           {
               obj = GLU.gluNewQuadric();
           }


        public override void Draw()
        {
            GL.glTranslatef(0, 0, 2f);
            GL.glRotatef(90f, 0.0f, 1.0f, 0.0f);

            // for (float i = 0; i < 2; i++)
            // {
            //     GL.glPushMatrix();
            //     GL.glTranslatef(-0.5f, -0.4f, -0.55f + i * 0.3f);
            //
            //     // InitTexture(Texture.Back.k_BackLeftWheel);
            //
            //     GL.glBindTexture(GL.GL_TEXTURE_2D, Textures[12]);
            //     GL.glEnable(GL.GL_TEXTURE_2D);
            //     GL.glEnable(GL.GL_BLEND);
            //     GL.glBlendFunc(GL.GL_SRC_ALPHA, GL.GL_ONE_MINUS_SRC_ALPHA);
            //     GL.glBegin(GL.GL_QUADS);
            //
            //     GL.glTexCoord2f(1, 1);
            //     GL.glVertex3f(1f, 0.65f, 0.5f);
            //
            //     GL.glTexCoord2f(1, 0);
            //     GL.glVertex3f(1f, 0.0f, 0.5f);
            //
            //     GL.glTexCoord2f(0, 0);
            //     GL.glVertex3f(0.0f, 0.0f, 0.5f);
            //
            //     GL.glTexCoord2f(0, 1);
            //     GL.glVertex3f(0.0f, 0.65f, 0.5f);
            //     GL.glEnd();
            //     GL.glPopMatrix();
            //}
            //for (float i = 0; i < 2; i++)
            //{
            //    //   InitTexture(Texture.Back.k_BackRightWheel);
            //    GL.glBindTexture(GL.GL_TEXTURE_2D, Textures[13]);
            //    GL.glPushMatrix();
            //    GL.glTranslatef(-0.5f, -0.4f, +0.3f + i * 0.3f);
            //    GL.glBegin(GL.GL_QUADS);
            //    GL.glTexCoord2f(1, 1);
            //    GL.glVertex3f(1f, 0.65f, 0.5f);
            //
            //    GL.glTexCoord2f(1, 0);
            //    GL.glVertex3f(1f, 0.0f, 0.5f);
            //
            //    GL.glTexCoord2f(0, 0);
            //    GL.glVertex3f(0.0f, 0.0f, 0.5f);
            //
            //    GL.glTexCoord2f(0, 1);
            //    GL.glVertex3f(0.0f, 0.65f, 0.5f);
            //    GL.glEnd();
            //    GL.glPopMatrix();
            //}
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
