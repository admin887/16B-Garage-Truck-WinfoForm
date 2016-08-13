using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGL;

namespace Garage_Truck_WinfoForms.Truck
{
    public class BackCabin : DrawbleComponent
    {
        public float Angle { get; set; }

        public float GarbageDistance { get; set; }

        public BackCabin()
        {
            Angle = 0;
            GarbageDistance = -0.6f;
        }
        
        public override void Draw()
        {
            
            //-----------------------------------------------
            //Drawing The back Cabin

            //-----------------------------------------------
            GL.glTranslatef(-2, 0, -1.6f);
            GL.glRotatef(Angle / 3, 0.0f, 0.0f, 0.1f);
            GL.glTranslatef(Angle / 200, Angle / 1000, 0);
            GL.glEnable(GL.GL_TEXTURE_2D);
            GL.glPushMatrix();
            GL.glTranslatef(-0.275f, 0, 0);

            // InitTexture(Texture.Back.k_LeftSide);
            GL.glBindTexture(GL.GL_TEXTURE_2D, Textures[4]);

            GL.glPushMatrix();
            GL.glBegin(GL.GL_QUADS);

            GL.glTexCoord2f(1, 1);
            GL.glVertex3f(2.0f, 1.0f, 1.0f);

            GL.glTexCoord2f(1, 0);
            GL.glVertex3f(2.0f, 0.0f, 1.0f);

            GL.glTexCoord2f(0, 0);
            GL.glVertex3f(0.0f, 0.0f, 1.0f);

            GL.glTexCoord2f(0, 1);
            GL.glVertex3f(0.0f, 1.0f, 1.0f);
            GL.glEnd();
            GL.glPopMatrix();
            

            GL.glTranslatef(0, 0, 1);
            GL.glRotatef(90f, 0.0f, 1.0f, 0.0f);
            GL.glTranslatef(0, 0, 2);
            GL.glRotatef(90f, 0.0f, 1.0f, 0.0f);


            //    InitTexture(Texture.Back.k_RightSide);
            GL.glBindTexture(GL.GL_TEXTURE_2D, Textures[5]);

            GL.glPushMatrix();
            GL.glBegin(GL.GL_QUADS);

            GL.glTexCoord2f(1, 1);
            GL.glVertex3f(2.0f, 1.0f, 1.0f);

            GL.glTexCoord2f(1, 0);
            GL.glVertex3f(2.0f, 0.0f, 1.0f);

            GL.glTexCoord2f(0, 0);
            GL.glVertex3f(0.0f, 0.0f, 1.0f);

            GL.glTexCoord2f(0, 1);
            GL.glVertex3f(0.0f, 1.0f, 1.0f);
            GL.glEnd();
            GL.glPopMatrix();


            GL.glTranslatef(0, 0, 1);
            GL.glRotatef(90f, 0.0f, 1.0f, 0.0f);
            GL.glTranslatef(0, 0, 2);
            GL.glRotatef(90f, 0.0f, 1.0f, 0.0f);
            //Rotating for The 2 second sides

            GL.glTranslatef(0, 0, 1);
            GL.glRotatef(90, 0.0f, 1.0f, 0.0f);

            //Drawing The FrontSide  

            // InitTexture(Texture.Back.k_FrontSide);
            GL.glBindTexture(GL.GL_TEXTURE_2D, Textures[6]);

            GL.glPushMatrix();
            GL.glBegin(GL.GL_QUADS);

            GL.glTexCoord2f(0, 0);
            GL.glVertex3f(1.0f, 1.0f, 2.0f);

            GL.glTexCoord2f(0, 1);
            GL.glVertex3f(1.0f, 0.0f, 2.0f);

            GL.glTexCoord2f(1, 1);
            GL.glVertex3f(0.0f, 0.0f, 2.0f);

            GL.glTexCoord2f(1, 0);
            GL.glVertex3f(0.0f, 1.0f, 2.0f);
            GL.glEnd();
            GL.glPopMatrix();


            GL.glTranslatef(0, 0, 2);
            GL.glRotatef(90f, 0.0f, 1.0f, 0.0f);
            GL.glTranslatef(0, 0, 1);
            GL.glRotatef(90f, 0.0f, 1.0f, 0.0f);
            //Drawing The BackSide
            // InitTexture(Texture.Back.k_BackSide);
            GL.glBindTexture(GL.GL_TEXTURE_2D, Textures[7]);

            GL.glPushMatrix();
            GL.glBegin(GL.GL_QUADS);

            GL.glTexCoord2f(0, 0);
            GL.glVertex3f(1.0f, 1.0f, 2.0f);

            GL.glTexCoord2f(0, 1);
            GL.glVertex3f(1.0f, 0.0f, 2.0f);

            GL.glTexCoord2f(1, 1);
            GL.glVertex3f(0.0f, 0.0f, 2.0f);

            GL.glTexCoord2f(1, 0);
            GL.glVertex3f(0.0f, 1.0f, 2.0f);
            GL.glEnd();
            GL.glPopMatrix();


            GL.glTranslatef(0, 0, 2);
            GL.glRotatef(90f, 0.0f, 1.0f, 0.0f);

            GL.glTranslatef(0, 0, 1);
            GL.glRotatef(90f, 0.0f, 1.0f, 0.0f);
            GL.glPopMatrix();

           // float[] Zbuf = new float[1024 * 768];           // Need to be change to Width and height

            if (Angle >= 90)
            {
                GL.glPushMatrix();
                GL.glRotatef(-Angle / 60, 0, 0, 1f);
                if (GarbageDistance < 2f)
                {
                    GarbageDistance += 0.1f;
                }
                GL.glTranslatef(-GarbageDistance, 0.2f, 0.5f);
                //CreateGarbageCube();
                GL.glPopMatrix();
            }
            else
            {
                GarbageDistance = -0.6f;
            }
            GL.glDisable(GL.GL_TEXTURE_2D);
        }
    }
}
