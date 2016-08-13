using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGL;

namespace Garage_Truck_WinfoForms
{
    public class Garbage: WorldComponent
    {
        public Garbage()
        {
            Width = 10;
            Height = 10;
            Length = 10;

            StartPoition = new Point3D(10, -3, 7);

            StartPoition = new Point3D(StartPoition.X - Width / 2, StartPoition.Y - Height / 2, StartPoition.Z - Length / 2);
        }
        public override void Draw()
        {
            //  InitTexture(Texture.Terrain.k_Garbage);
            GL.glBindTexture(GL.GL_TEXTURE_2D, Textures[10]);
            GL.glEnable(GL.GL_TEXTURE_2D);
            GL.glPushMatrix();
            GL.glTranslatef(-1.9f, 0.55f, -4);
            GL.glBegin(GL.GL_QUADS);
            GL.glNormal3d(1, 1, 1);
            GL.glTexCoord2f(16.0f, 0.0f); GL.glVertex3d(StartPoition.X, -0.2f, StartPoition.Z);
            GL.glNormal3d(1, 1, -1);
            GL.glTexCoord2f(16.0f, 16.0f); GL.glVertex3d(StartPoition.X, -0.2f, StartPoition.Z + Length);
            GL.glNormal3d(-1, 1, -1);
            GL.glTexCoord2f(0.0f, 16.0f); GL.glVertex3d(StartPoition.X + Width, -0.2f, StartPoition.Z + Length);
            GL.glNormal3d(-1, 1, 1);
            GL.glTexCoord2f(0.0f, 0.0f); GL.glVertex3d(StartPoition.X + Width, -0.2f, StartPoition.Z);
            GL.glEnd();
            GL.glPopMatrix();
            GL.glDisable(GL.GL_TEXTURE_2D);
        }
    }
}

