using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGL;

namespace Garage_Truck_WinfoForms
{
    public class Sky: WorldComponent
    {
        public Sky()
        {
            Width = 240;
            Height = 200;
            Length = 240;

            StartPoition = new Point3D(10, -3, 7);

            StartPoition = new Point3D(StartPoition.X - Width / 2, StartPoition.Y - Height / 2, StartPoition.Z - Length / 2);

        }

        public override void Draw()
        {

         //  GL.glEnable(GL.GL_TEXTURE_2D);
           //  InitTexture(Texture.Terrain.k_Top);
         
         
           //start drawing quads
           GL.glPushMatrix();
           GL.glEnable(GL.GL_TEXTURE_2D);
           GL.glBindTexture(GL.GL_TEXTURE_2D, Textures[11]);
         GL.glBegin(GL.GL_QUADS);
         GL.glRotatef(90, 0, 1, 0);
         GL.glTexCoord2f(1.0f, 0.0f); GL.glVertex3d(StartPoition.X + Width, StartPoition.Y, StartPoition.Z);
         GL.glNormal3d(-1, 1, 1);
         GL.glNormal3d(-1, -1, 1);
         GL.glTexCoord2f(1.0f, 1.0f); GL.glVertex3d(StartPoition.X + Width, StartPoition.Y + Height, StartPoition.Z);
         GL.glNormal3d(1, -1, 1);
         GL.glTexCoord2f(0.0f, 1.0f); GL.glVertex3d(StartPoition.X, StartPoition.Y + Height, StartPoition.Z);
         GL.glNormal3d(1, 1, 1);
         GL.glTexCoord2f(0.0f, 0.0f); GL.glVertex3d(StartPoition.X, StartPoition.Y, StartPoition.Z);
       
         GL.glEnd();
         GL.glDisable(GL.GL_TEXTURE_2D);
       
         GL.glEnable(GL.GL_TEXTURE_2D);
       
            //1
          //InitTexture(Texture.Terrain.k_Top);
          GL.glBindTexture(GL.GL_TEXTURE_2D, Textures[11]);
          GL.glBegin(GL.GL_QUADS);
          GL.glNormal3d(1, 1, -1);
          GL.glTexCoord2f(1.0f, 0.0f); GL.glVertex3d(StartPoition.X, StartPoition.Y, StartPoition.Z + Length);
          GL.glNormal3d(1, -1, -1);
          GL.glTexCoord2f(1.0f, 1.0f); GL.glVertex3d(StartPoition.X, StartPoition.Y + Height, StartPoition.Z + Length);
          GL.glNormal3d(-1, -1, -1);
          GL.glTexCoord2f(0.0f, 1.0f); GL.glVertex3d(StartPoition.X + Width, StartPoition.Y + Height, StartPoition.Z + Length);
          GL.glNormal3d(-1, 1, -1);
          GL.glTexCoord2f(0.0f, 0.0f); GL.glVertex3d(StartPoition.X + Width, StartPoition.Y, StartPoition.Z + Length);
          GL.glEnd();
          GL.glDisable(GL.GL_TEXTURE_2D);

            //2
          GL.glEnable(GL.GL_TEXTURE_2D);
          // InitTexture(Texture.Terrain.k_Top);
          GL.glBindTexture(GL.GL_TEXTURE_2D, Textures[11]);
          GL.glBegin(GL.GL_QUADS);
          GL.glNormal3d(1, -1, 1);
          GL.glTexCoord2f(0.0f, 1.0f); GL.glVertex3d(StartPoition.X, StartPoition.Y + Height, StartPoition.Z);
          GL.glNormal3d(1, -1, -1);
          GL.glTexCoord2f(1.0f, 1.0f); GL.glVertex3d(StartPoition.X, StartPoition.Y + Height, StartPoition.Z + Length);
          GL.glNormal3d(1, 1, -1);
          GL.glTexCoord2f(1.0f, 0.0f); GL.glVertex3d(StartPoition.X, StartPoition.Y, StartPoition.Z + Length);
          GL.glNormal3d(1, 1, 1);
          GL.glTexCoord2f(0.0f, 0.0f); GL.glVertex3d(StartPoition.X, StartPoition.Y, StartPoition.Z);
          GL.glEnd();
          GL.glDisable(GL.GL_TEXTURE_2D);
        

            //3
          GL.glEnable(GL.GL_TEXTURE_2D);
          //  InitTexture(Texture.Terrain.k_Top);
          GL.glBindTexture(GL.GL_TEXTURE_2D, Textures[11]);
          GL.glBegin(GL.GL_QUADS);
          GL.glNormal3d(-1, 1, 1);
          GL.glTexCoord2f(0.0f, 0.0f); GL.glVertex3d(StartPoition.X + Width, StartPoition.Y, StartPoition.Z);
          GL.glNormal3d(-1, 1, -1);
          GL.glTexCoord2f(1.0f, 0.0f); GL.glVertex3d(StartPoition.X + Width, StartPoition.Y, StartPoition.Z + Length);
          GL.glNormal3d(-1, -1, -1);
          GL.glTexCoord2f(1.0f, 1.0f); GL.glVertex3d(StartPoition.X + Width, StartPoition.Y + Height, StartPoition.Z + Length);
          GL.glNormal3d(-1, -1, 1);
          GL.glTexCoord2f(0.0f, 1.0f); GL.glVertex3d(StartPoition.X + Width, StartPoition.Y + Height, StartPoition.Z);
          GL.glEnd();
          GL.glDisable(GL.GL_TEXTURE_2D);

   //     //4
   //
   //  GL.glEnable(GL.GL_TEXTURE_2D);
   //  //  InitTexture(Texture.Terrain.k_Top);
   //  GL.glBindTexture(GL.GL_TEXTURE_2D, Textures[11]);
   //  GL.glBegin(GL.GL_QUADS);
   //  GL.glNormal3d(-1, 1, 1);
   //  GL.glTexCoord2f(0.0f, 0.0f); GL.glVertex3d(StartPoition.X + Width, StartPoition.Y, StartPoition.Z);
   //  GL.glNormal3d(-1, -1, 1);
   //  GL.glTexCoord2f(1.0f, 0.0f); GL.glVertex3d(StartPoition.X + Width, StartPoition.Y, StartPoition.Z + Length);
   //  GL.glNormal3d(1, -1, 1);
   //  GL.glTexCoord2f(1.0f, 1.0f); GL.glVertex3d(StartPoition.X + Width, StartPoition.Y + Height, StartPoition.Z + Length);
   //  GL.glNormal3d(1, 1, 1);
   //  GL.glTexCoord2f(0.0f, 1.0f); GL.glVertex3d(StartPoition.X + Width, StartPoition.Y + Height, StartPoition.Z);
   //  GL.glEnd();
   //  GL.glDisable(GL.GL_TEXTURE_2D);
   //
//5//
   //  GL.glEnable(GL.GL_TEXTURE_2D);
   //  //  InitTexture(Texture.Terrain.k_Top);
   //  GL.glBindTexture(GL.GL_TEXTURE_2D, Textures[11]);
   //  GL.glBegin(GL.GL_QUADS);
   //  GL.glNormal3d(-1, 1, 1);
   //  GL.glTexCoord2f(0.0f, 0.0f); GL.glVertex3d(StartPoition.X + Width, StartPoition.Y, StartPoition.Z);
   //  GL.glNormal3d(1, 1, 1);
   //  GL.glTexCoord2f(1.0f, 0.0f); GL.glVertex3d(StartPoition.X + Width, StartPoition.Y, StartPoition.Z + Length);
   //  GL.glNormal3d(-1, 1, -1);
   //  GL.glTexCoord2f(1.0f, 1.0f); GL.glVertex3d(StartPoition.X + Width, StartPoition.Y + Height, StartPoition.Z + Length);
   //  GL.glNormal3d(1, 1, -1);
   //  GL.glTexCoord2f(0.0f, 1.0f); GL.glVertex3d(StartPoition.X + Width, StartPoition.Y + Height, StartPoition.Z);
   //  GL.glEnd();
   //  GL.glDisable(GL.GL_TEXTURE_2D);
   //
   //  //6
   //  GL.glEnable(GL.GL_TEXTURE_2D);
   //  //  InitTexture(Texture.Terrain.k_Top);
   //  GL.glBindTexture(GL.GL_TEXTURE_2D, Textures[11]);
   //  GL.glBegin(GL.GL_QUADS);
   //  GL.glNormal3d(-1, -1, 1);
   //  GL.glTexCoord2f(0.0f, 0.0f); GL.glVertex3d(StartPoition.X + Width, StartPoition.Y, StartPoition.Z);
   //  GL.glNormal3d(1, -1, 1);
   //  GL.glTexCoord2f(1.0f, 0.0f); GL.glVertex3d(StartPoition.X + Width, StartPoition.Y, StartPoition.Z + Length);
   //  GL.glNormal3d(1, -1, -1);
   //  GL.glTexCoord2f(1.0f, 1.0f); GL.glVertex3d(StartPoition.X + Width, StartPoition.Y + Height, StartPoition.Z + Length);
   //  GL.glNormal3d(-1, -1, -1);
   //  GL.glTexCoord2f(0.0f, 1.0f); GL.glVertex3d(StartPoition.X + Width, StartPoition.Y + Height, StartPoition.Z);
   //  GL.glEnd();
   //  GL.glDisable(GL.GL_TEXTURE_2D);
   // 
          GL.glPopMatrix();
        }
    }
}
