using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGL;

namespace Garage_Truck_WinfoForms.Truck
{
    public class Truck : DrawbleComponent
    {

        public GLUquadric obj { get; set; }
        public Point3D Position { get; set; }
        public float backCabinLiftingAngle { get; set; }

        public float moveCar { get; set; }

        public bool ShadowDisplayed { get; set; }

        public float garbageDistance { get; set; }

        Garbage g = new Garbage();


        public Truck()
        {
            Position = new Point3D(0, 0, 0);
            obj = obj = GLU.gluNewQuadric();

      // FrontCabin fc = new FrontCabin();
      // ObjectsToDraw.Add(fc);
      //
      // Chassis c= new Chassis();
      // ObjectsToDraw.Add(c);
      //
      // BackWheels bw = new BackWheels();
      // ObjectsToDraw.Add(bw);
      //
      // FrontWheel fw = new FrontWheel();
      // ObjectsToDraw.Add(fw);
      //
      // BackCabin bc = new BackCabin();
      // ObjectsToDraw.Add(bc);

            ShadowDisplayed = true;

        }

        public override void DrawWithMatrixClosing()
        {


                  GL.glPushMatrix();
            //      //!!!!!!!!!!!!    		
            //      GL.glRotatef(90f, 1.0f, 0.0f, 0.0f);
            //
            //    //  GL.glColor3d(0.5, 0.5, 0.5);
            //   MakeShadowMatrix(ground);
            //   
            //
            //   GL.glMultMatrixf(cubeXform);
            //  
            DrawObjects(moveCar, backCabinLiftingAngle, ShadowDisplayed);
            //
            //        GL.glTranslatef(0, -1, 0);
            ////   GL.glTranslatef(0, 10, 0);
            //        GL.glEnable(GL.GL_TEXTURE_2D);
            //
            //        //!!!!!!!!!!!!!
            //        GL.glPopMatrix();
            //        //!!!!!!!!!!!!!

            //        DrawObjects(moveCar, backCabinLiftingAngle, !v_ShadowDisplayed);
              GL.glPopMatrix();
            //    
          

        }

        private void DrawObjects(float carMove, float backCabinLiftingAngle, bool DisplayShadow)
        {

            if (DisplayShadow)
            {
                GL.glColor3d(0.5, 0.5, 0.5);
            }
            else
            {
                // createRoad();
                // createGrass();
                // createGarbage();
                // createTop();
             
                // DrawLight();
            }

            GL.glTranslatef(-carMove, 0, 0);
            GL.glEnable(GL.GL_LIGHTING);
            GL.glEnable(GL.GL_LIGHT0);
            GL.glEnable(GL.GL_COLOR_MATERIAL);
            GL.glEnable(GL.GL_DEPTH_TEST);
            GL.glColorMaterial(GL.GL_FRONT_AND_BACK, GL.GL_AMBIENT_AND_DIFFUSE);

            GL.glEnable(GL.GL_TEXTURE_2D);

            CreateFrontCabin();
            CreateChassis();
            CreateBackWheels();
            CreateFrontWheels();

            if (carMove == 0)
                CreateBackCabin(backCabinLiftingAngle);
            else
                CreateBackCabin(0);
            GL.glDisable(GL.GL_LIGHTING);

            GL.glDisable(GL.GL_TEXTURE_2D);
        }
        public void CreateFrontCabin()
        {
            GL.glTranslatef(0, 1, 2.6f);
            //GL.glRotatef(90f, 0.0f, 1.0f, 0.0f);

            //  InitTexture(Texture.Front.k_LeftSide);

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

        }
        public void CreateBackCabin(float backCabinLiftingAngle)
        {

            //-----------------------------------------------
            //Drawing The back Cabin

            //-----------------------------------------------
            GL.glTranslatef(-2, 0, -1.6f);
            GL.glRotatef(backCabinLiftingAngle / 3, 0.0f, 0.0f, 0.1f);
            GL.glTranslatef(backCabinLiftingAngle / 200, backCabinLiftingAngle / 1000, 0);
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

           // float[] Zbuf = new float[Width * Height];



            if (backCabinLiftingAngle >= 90)
            {
                GL.glPushMatrix();
                GL.glRotatef(-backCabinLiftingAngle / 60, 0, 0, 1f);
                if (garbageDistance < 2f)
                {
                    garbageDistance += 0.1f;
                }
                GL.glTranslatef(-garbageDistance, 0.2f, 0.5f);
                
                
                
                
                
                CreateGarbageCube();
                GL.glPopMatrix();

            }
            else
            {
                garbageDistance = -0.6f;
            }

            GL.glPopMatrix();
    
        }
        public void CreateBackWheels()
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
        public void CreateFrontWheels()
        {
            //GL.glTranslatef(0f, 0, 1f);
            GL.glRotatef(90f, 0.0f, 1.0f, 0.0f);
            GL.glTranslatef(1.6f, 0, 1.5f);
            GL.glRotatef(-90f, 0.0f, 1.0f, 0.0f);
            // for (float i = 0; i < 2; i++)
            // {
            //   //  InitTexture(Texture.Front.k_FrontLeftWheel);
            //     GL.glBindTexture(GL.GL_TEXTURE_2D, Textures[15]);
            //     GL.glPushMatrix();
            //     GL.glTranslatef(-0.5f, -0.4f, -0.55f + i * 1.1f);
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
            // }
            // for (float i = 0; i < 2; i++)
            // {
            //   //  InitTexture(Texture.Front.k_FrontLeftWheel);
            //     GL.glBindTexture(GL.GL_TEXTURE_2D, Textures[16]);
            //     GL.glPushMatrix();
            //     GL.glTranslatef(-0.5f, -0.4f, -0.55f + i * 0.3f);
            //     GL.glEnable(GL.GL_BLEND);
            //     GL.glBlendFunc(GL.GL_ONE, GL.GL_ONE_MINUS_SRC_ALPHA);
            //     GL.glBegin(GL.GL_POLYGON);
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
            // }
            // for (float i = 0; i < 2; i++)
            // {
            //     InitTexture(Texture.Front.k_FrontRightWheel);
            //     GL.glPushMatrix();
            //     GL.glTranslatef(-0.5f, -0.4f, +0.3f + i * 0.3f);
            //     GL.glBegin(GL.GL_QUADS);
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
            // }
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
        public void CreateGarbageCube()
        {

            //Face 1
            double x = 0.5f;
            float doubleX = (float)x;

            GL.glPushMatrix();

            GL.glTranslatef(0, 0, 0);


            //  InitTexture(Texture.Terrain.k_Garbage1);
            GL.glBindTexture(GL.GL_TEXTURE_2D, Textures[14]);

            GL.glBegin(GL.GL_QUADS);

            GL.glTexCoord2f(1, 1);
            GL.glVertex3f(-doubleX, doubleX, doubleX);

            GL.glTexCoord2f(1, 0);
            GL.glVertex3f(doubleX, doubleX, doubleX);

            GL.glTexCoord2f(0, 0);
            GL.glVertex3f(doubleX, -doubleX, doubleX);

            GL.glTexCoord2f(0, 1);
            GL.glVertex3f(-doubleX, -doubleX, doubleX);

            GL.glTexCoord2f(1, 1);
            GL.glVertex3f(-doubleX, doubleX, -doubleX);

            GL.glTexCoord2f(1, 0);
            GL.glVertex3f(doubleX, doubleX, -doubleX);

            GL.glTexCoord2f(0, 0);
            GL.glVertex3f(doubleX, -doubleX, -doubleX);

            GL.glTexCoord2f(0, 1);
            GL.glVertex3f(-doubleX, -doubleX, -doubleX);

            GL.glTexCoord2f(1, 1);
            GL.glVertex3f(-doubleX, doubleX, doubleX);

            GL.glTexCoord2f(1, 0);
            GL.glVertex3f(-doubleX, -doubleX, doubleX);

            GL.glTexCoord2f(0, 0);
            GL.glVertex3f(-doubleX, -doubleX, -doubleX);

            GL.glTexCoord2f(0, 1);
            GL.glVertex3f(-doubleX, doubleX, -doubleX);

            GL.glTexCoord2f(1, 1);
            GL.glVertex3f(doubleX, -doubleX, -doubleX);

            GL.glTexCoord2f(1, 0);
            GL.glVertex3f(doubleX, -doubleX, -doubleX);

            GL.glTexCoord2f(0, 0);
            GL.glVertex3f(doubleX, doubleX, -doubleX);

            GL.glTexCoord2f(0, 1);
            GL.glVertex3f(doubleX, doubleX, doubleX);

            GL.glTexCoord2f(1, 1);
            GL.glVertex3f(-doubleX, -doubleX, doubleX);

            GL.glTexCoord2f(1, 0);
            GL.glVertex3f(-doubleX, -doubleX, -doubleX);

            GL.glTexCoord2f(0, 0);
            GL.glVertex3f(doubleX, -doubleX, -doubleX);

            GL.glTexCoord2f(0, 1);
            GL.glVertex3f(-doubleX, -doubleX, doubleX);

            GL.glTexCoord2f(1, 1);
            GL.glVertex3f(-doubleX, doubleX, doubleX);

            GL.glTexCoord2f(1, 0);
            GL.glVertex3f(-doubleX, doubleX, -doubleX);

            GL.glTexCoord2f(0, 0);
            GL.glVertex3f(doubleX, doubleX, -doubleX);

            GL.glTexCoord2f(0, 1);
            GL.glVertex3f(doubleX, doubleX, doubleX);

            GL.glEnd();
            GL.glPopMatrix();

        }

        public void createGarbage()
        {
            int width = 10;
            int height = 10;
            int length = 10;

            //start in this coordinates
            int x = 10;
            int y = -3;
            int z = 7;

            //center the square
            x = x - width / 2;
            y = y - height / 2;
            z = z - length / 2;
            //  InitTexture(Texture.Terrain.k_Garbage);
            GL.glBindTexture(GL.GL_TEXTURE_2D, Textures[10]);
            GL.glEnable(GL.GL_TEXTURE_2D);
            GL.glPushMatrix();
            GL.glTranslatef(-1.9f, 0.55f, -4);
            GL.glBegin(GL.GL_QUADS);
            GL.glNormal3d(1, 1, 1);
            GL.glTexCoord2f(16.0f, 0.0f); GL.glVertex3d(x, -0.2f, z);
            GL.glNormal3d(1, 1, -1);
            GL.glTexCoord2f(16.0f, 16.0f); GL.glVertex3d(x, -0.2f, z + length);
            GL.glNormal3d(-1, 1, -1);
            GL.glTexCoord2f(0.0f, 16.0f); GL.glVertex3d(x + width, -0.2f, z + length);
            GL.glNormal3d(-1, 1, 1);
            GL.glTexCoord2f(0.0f, 0.0f); GL.glVertex3d(x + width, -0.2f, z);
            GL.glEnd();
            GL.glPopMatrix();
        }

        public void CreateChassis()
        {
            GL.glPushMatrix();
            GL.glTranslatef(0.5f, -0.4f, 1.3f);
            GL.glBegin(GL.GL_POLYGON);
            GL.glVertex3d(-0.5f, 0.5f, -0.5f);
            GL.glVertex3d(-0.5f, 0.5f, 0.5f);
            GL.glVertex3d(0.5f, 0.5f, 0.5f);
            GL.glVertex3d(0.5f, 0.5f, -0.5f);
            GL.glEnd();
            GL.glPopMatrix();

        }

     // public override void DrawWithMatrixClosing()
     // {
     //
     //  ///  GL.glPushMatrix();
     //  ///
     //  ///
     //  ///  foreach (IDrawable item in ObjectsToDraw)
     //  ///  {
     //  ///
     //  ///      item.Draw();
     //  ///  }
     //  ///
     //  ///  GL.glPopMatrix();
     //  ///  GL.glColor3f(255, 255, 255);
     //  ///  GL.glDisable(GL.GL_LIGHTING);
     // }


        public override void Draw()
        {
         
        }



    }
}
