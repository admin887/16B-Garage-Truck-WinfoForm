using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGL;

namespace Garage_Truck_WinfoForms.Truck
{
    public class FrontCabin : DrawbleComponent
    {
        public override void Draw()
        {
            GL.glTranslatef(0, 1, 2.6f);
            //GL.glRotatef(90f, 0.0f, 1.0f, 0.0f);

            //  InitTexture(Texture.Front.k_LeftSide);
            GL.glEnable(GL.GL_TEXTURE_2D);

            GL.glBindTexture(GL.GL_TEXTURE_2D, Textures[0]);


            GL.glPushMatrix();
            GL.glBegin(GL.GL_QUADS);

            GL.glTexCoord2f(1, 0);
            GL.glVertex3f(0.7f, 0.85f, 1.0f);

            GL.glTexCoord2f(1, 1);
            GL.glVertex3f(0.7f, 0.0f, 1.0f);

            GL.glTexCoord2f(0, 1);
            GL.glVertex3f(0.0f, 0.0f, 1.0f);

            GL.glTexCoord2f(0, 0);
            GL.glVertex3f(0.0f, 0.85f, 1.0f);
            GL.glEnd();
            GL.glPopMatrix();


            GL.glTranslatef(0, 0, 1);
            GL.glRotatef(90f, 0.0f, 1.0f, 0.0f);
            GL.glTranslatef(0, 0, 0.7f);
            GL.glRotatef(90f, 0.0f, 1.0f, 0.0f);



            //  InitTexture(Texture.Front.k_RightSide);
            GL.glBindTexture(GL.GL_TEXTURE_2D, Textures[1]);

            GL.glPushMatrix();
            GL.glBegin(GL.GL_QUADS);

            GL.glTexCoord2f(1, 0);
            GL.glVertex3f(0.7f, 0.85f, 1.0f);

            GL.glTexCoord2f(1, 1);
            GL.glVertex3f(0.7f, 0.0f, 1.0f);

            GL.glTexCoord2f(0, 1);
            GL.glVertex3f(0.0f, 0.0f, 1.0f);

            GL.glTexCoord2f(0, 0);
            GL.glVertex3f(0.0f, 0.85f, 1.0f);
            GL.glEnd();
            GL.glPopMatrix();


            GL.glTranslatef(0, 0, 1);
            GL.glRotatef(90f, 0.0f, 1.0f, 0.0f);
            GL.glTranslatef(0, 0, 0.7f);
            GL.glRotatef(90f, 0.0f, 1.0f, 0.0f);






            GL.glTranslatef(0, 0, 1);
            GL.glRotatef(90f, 0.0f, 1.0f, 0.0f);

            //Front and back

            //   GL.glColor3f(0.0f, 1.0f, 0.0f);
            //   InitTexture(Texture.Front.k_BackSide);

            GL.glBindTexture(GL.GL_TEXTURE_2D, Textures[2]);
            GL.glPushMatrix();
            GL.glBegin(GL.GL_QUADS);

            GL.glTexCoord2f(1, 0);
            GL.glVertex3f(1.0f, 0.85f, 0.7f);

            GL.glTexCoord2f(1, 1);
            GL.glVertex3f(1.0f, 0.0f, 0.7f);

            GL.glTexCoord2f(0, 1);
            GL.glVertex3f(0.0f, 0.0f, 0.7f);

            GL.glTexCoord2f(0, 0);
            GL.glVertex3f(0.0f, 0.85f, 0.7f);
            GL.glEnd();
            GL.glPopMatrix();


            GL.glTranslatef(0, 0, 0.7f);
            GL.glRotatef(90f, 0.0f, 1.0f, 0.0f);
            GL.glTranslatef(0, 0, 1);
            GL.glRotatef(90f, 0.0f, 1.0f, 0.0f);





            //InitTexture(Texture.Front.k_FrontSide);
            GL.glBindTexture(GL.GL_TEXTURE_2D, Textures[3]);
            GL.glPushMatrix();
            GL.glBegin(GL.GL_QUADS);

            GL.glTexCoord2f(1, 0);
            GL.glVertex3f(1.0f, 0.85f, 0.7f);

            GL.glTexCoord2f(1, 1);
            GL.glVertex3f(1.0f, 0.0f, 0.7f);

            GL.glTexCoord2f(0, 1);
            GL.glVertex3f(0.0f, 0.0f, 0.7f);

            GL.glTexCoord2f(0, 0);
            GL.glVertex3f(0.0f, 0.85f, 0.7f);
            GL.glEnd();
            GL.glPopMatrix();


            GL.glTranslatef(0, 0, 0.7f);
            GL.glRotatef(90f, 0.0f, 1.0f, 0.0f);
            GL.glTranslatef(0, 0, 1);
            GL.glRotatef(90f, 0.0f, 1.0f, 0.0f);
            GL.glDisable(GL.GL_TEXTURE_2D);
        }
    }
}
