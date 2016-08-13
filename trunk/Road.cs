using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGL;

namespace Garage_Truck_WinfoForms
{
    public class Road: DrawbleComponent
    {
        public override void Draw()
        {

            // InitTexture(Texture.Terrain.k_Asfalt);
            GL.glBindTexture(GL.GL_TEXTURE_2D, Textures[8]);
            GL.glEnable(GL.GL_TEXTURE_2D);
            // GL.glEnable(GL.GL_TEXTURE_2D);
            // GL.glBindTexture(GL.GL_TEXTURE_2D, texturaAsfalto);
            GL.glPushMatrix();
            GL.glTranslatef(-97, 0.5f, 4.5f);
            GL.glRotatef(90, 0, 1, 0);
            int count = 0;
            for (int y = 0; y < 20; y++)// this for loop draws the road
            {
                GL.glBegin(GL.GL_QUADS);
                GL.glTexCoord2f(0.0f, 0.0f); GL.glVertex3f(-0.8f, -0.1f, count);
                GL.glTexCoord2f(0.0f, 1.0f); GL.glVertex3f(-0.8f, -0.1f, count + 5);
                GL.glTexCoord2f(1.0f, 1.0f); GL.glVertex3f(3.8f, -0.1f, count + 5);
                GL.glTexCoord2f(1.0f, 0.0f); GL.glVertex3f(3.8f, -0.1f, count);
                GL.glEnd();
                count += 5;
            }
            GL.glPopMatrix();
            GL.glDisable(GL.GL_TEXTURE_2D);
        }
    }
}
