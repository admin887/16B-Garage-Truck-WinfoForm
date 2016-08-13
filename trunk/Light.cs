using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGL;

namespace Garage_Truck_WinfoForms
{
    
    class Light: DrawbleComponent
    {
        private float[,] m_ground = new float[3, 3];
        private float[] cubeXform = new float[16];

        private float[] m_pos = new float[4];
        private Point3D m_LightPos;
        public Point3D LightPos
        {
            get
            {
                return m_LightPos;
            }
            set
            {
                m_LightPos = value;
                m_pos = m_LightPos.ToArray();
            }
        }

        public Light()
        {
            LightPos = new Point3D();
            m_pos = new float[4];

        //   m_ground[0, 0] = 1;
        //   m_ground[0, 1] = 1;
        //   m_ground[0, 2] = -0.4f;       //Height
        //
        //   m_ground[1, 0] = 0;
        //   m_ground[1, 1] = 1;
        //   m_ground[1, 2] = -0.4f;
        //
        //   m_ground[2, 0] = 1;
        //   m_ground[2, 1] = 0;
        //   m_ground[2, 2] = -0.4f;

            m_ground[0, 0] = 1;
            m_ground[0, 1] = 1;
            m_ground[0, 2] = -0.5f;

            m_ground[1, 0] = 0;
            m_ground[1, 1] = 1;
            m_ground[1, 2] = -0.5f;

            m_ground[2, 0] = 1;
            m_ground[2, 1] = 0;
            m_ground[2, 2] = -0.5f;
        }

        public static int count=0;
        public override void Draw()
        {
           GL.glLightfv(GL.GL_LIGHT0, GL.GL_POSITION, m_pos);
           //GL.glDisable(GL.GL_LIGHTING);
    
           //GL.glDisable(GL.GL_LIGHTING);
           GL.glTranslatef(m_pos[0], m_pos[1], m_pos[2]);
           //Yellow Light source
    
           GL.glColor3d(255, 255, 255);
           GL.glColor3d(255, 255, 0);
           GLUT.glutSolidSphere(0.15, 8, 8);
           GL.glTranslatef(-m_pos[0], -m_pos[1], -m_pos[2]);

           GL.glEnable(GL.GL_LIGHTING);
           //projection line from source to plane
           GL.glBegin(GL.GL_LINES);
         //  GL.glColor3d(0.5, 0.5, 0);
           GL.glVertex3d(m_pos[0], m_pos[1], m_pos[2]);
           GL.glVertex3d(m_pos[0], m_ground[0, 1] - 1, m_pos[2]);
    
           GL.glEnd();
    
        }

        public void PaintShadowTo(IDrawable d)
        {
            GL.glEnable(GL.GL_LIGHTING);
            GL.glEnable(GL.GL_LIGHT0);
            GL.glEnable(GL.GL_COLOR_MATERIAL);
            GL.glEnable(GL.GL_DEPTH_TEST);
            GL.glColorMaterial(GL.GL_FRONT_AND_BACK, GL.GL_AMBIENT_AND_DIFFUSE);

           
          

            //main System draw
        
          //  GL.glTranslated(4, 0, -1);
           // GL.glRotated(180, 1, 0, 0);
            DrawObjects(false, 1);


            //end of regular show
            //!!!!!!!!!!!!!
            GL.glPopMatrix();
            //!!!!!!!!!!!!!

            //SHADING begin
            //we'll define cubeXform matrix in MakeShadowMatrix Sub
            // Disable lighting, we'll just draw the shadow
            //else instead of shadow we'll see stange projection of the same objects
            GL.glDisable(GL.GL_LIGHTING);

            // floor shadow
            //!!!!!!!!!!!!!
            GL.glPushMatrix();
            //!!!!!!!!!!!!    		
            MakeShadowMatrix(m_ground);
            GL.glMultMatrixf(cubeXform);

            DrawObjects(true, 1);
            //!!!!!!!!!!!!!
            GL.glPopMatrix();
            //!!!!!!!!!!!!!

            // wall shadow
            //!!!!!!!!!!!!!
            GL.glPushMatrix();
            //!!!!!!!!!!!!       
            // MakeShadowMatrix(wall);
            GL.glMultMatrixf(cubeXform);

            DrawObjects(true, 2);
            //!!!!!!!!!!!!!
            GL.glPopMatrix();
            //!!!!!!!!!!!!!



            GL.glDisable(GL.GL_LIGHTING);

            GL.glDisable(GL.GL_TEXTURE_2D);









  //
  //         GL.glEnable(GL.GL_LIGHTING);
  //
  //         GL.glPopMatrix();
  //
  //         GL.glDisable(GL.GL_LIGHTING);
  //
  //         GL.glPushMatrix();
  //
  //         MakeShadowMatrix(m_ground);
  //         GL.glMultMatrixf(cubeXform);
  //
  //         GL.glColor3d(0.5, 0.5, 0.5);
  //
  //
  //         d.Draw();
  //
  //     //GL.glMultMatrixf(cubeXform);
  //     //
  //     //
  //     //GL.glColor3d(0.8, 0.8, 0.8);
  //     //
  //     // d.DrawWithMatrixClosing();
  //     //
  //
  //          GL.glPopMatrix();
  //
  //
  //
  //
  //




          
        }
        void DrawObjects(bool isForShades, int c)
        {
            if (!isForShades)
                GL.glColor3d(0, 1, 1);
            else
                if (c == 1)
                    GL.glColor3d(0.5, 0.5, 0.5);
                //   GL.glColor3d(1, 1, 1);
                else
                    GL.glColor3d(0.8, 0.8, 0.8);

            //   GL.glRotated(90, 1, 0, 0);

            
            GLUT.glutSolidCube(1);

       //   GL.glTranslated(1, 2, 0.3);
       //   GL.glRotated(90, 1, 0, 0);
       //  if (!isForShades)
       //      GL.glColor3d(0, 1, 1);
       //  else
       //      if (c == 1)
       //          GL.glColor3d(0.5, 0.5, 0.5);
       //      else
       //          GL.glColor3d(0.8, 0.8, 0.8);
       //  GLUT.glutSolidTeapot(1);
       //  GL.glRotated(-90, 1, 0, 0);
       //  GL.glTranslated(-1, -2, -0.3);
        }

        void MakeShadowMatrix(float[,] points)
        {
            float[] planeCoeff = new float[4];
            float dot;

            // Find the plane equation coefficients
            // Find the first three coefficients the same way we
            // find a normal.
            calcNormal(points, planeCoeff);

            // Find the last coefficient by back substitutions
            planeCoeff[3] = -(
                (planeCoeff[0] * points[2, 0]) + (planeCoeff[1] * points[2, 1]) +
                (planeCoeff[2] * points[2, 2]));


            // Dot product of plane and light position

            dot = planeCoeff[0] * m_pos[0] +
                    planeCoeff[1] * m_pos[1] +
                    planeCoeff[2] * m_pos[2] +
                    planeCoeff[3];

            // Now do the projection
            // First column
            cubeXform[0] = dot - m_pos[0] * planeCoeff[0];
            cubeXform[4] = 0.0f - m_pos[0] * planeCoeff[1];
            cubeXform[8] = 0.0f - m_pos[0] * planeCoeff[2];
            cubeXform[12] = 0.0f - m_pos[0] * planeCoeff[3];

            // Second column
            cubeXform[1] = 0.0f - m_pos[1] * planeCoeff[0];
            cubeXform[5] = dot - m_pos[1] * planeCoeff[1];
            cubeXform[9] = 0.0f - m_pos[1] * planeCoeff[2];
            cubeXform[13] = 0.0f - m_pos[1] * planeCoeff[3];

            // Third Column
            cubeXform[2] = 0.0f - m_pos[2] * planeCoeff[0];
            cubeXform[6] = 0.0f - m_pos[2] * planeCoeff[1];
            cubeXform[10] = dot - m_pos[2] * planeCoeff[2];
            cubeXform[14] = 0.0f - m_pos[2] * planeCoeff[3];

            // Fourth Column
            cubeXform[3] = 0.0f - m_pos[3] * planeCoeff[0];
            cubeXform[7] = 0.0f - m_pos[3] * planeCoeff[1];
            cubeXform[11] = 0.0f - m_pos[3] * planeCoeff[2];
            cubeXform[15] = dot - m_pos[3] * planeCoeff[3];
        }

        const int x = 0;
        const int y = 1;
        const int z = 2;

        void calcNormal(float[,] v, float[] outp)
        {
            float[] v1 = new float[3];
            float[] v2 = new float[3];

            // Calculate two vectors from the three points
            v1[x] = v[0, x] - v[1, x];
            v1[y] = v[0, y] - v[1, y];
            v1[z] = v[0, z] - v[1, z];

            v2[x] = v[1, x] - v[2, x];
            v2[y] = v[1, y] - v[2, y];
            v2[z] = v[1, z] - v[2, z];

            // Take the cross product of the two vectors to get
            // the normal vector which will be stored in out
            outp[x] = v1[y] * v2[z] - v1[z] * v2[y];
            outp[y] = v1[z] * v2[x] - v1[x] * v2[z];
            outp[z] = v1[x] * v2[y] - v1[y] * v2[x];

            // Normalize the vector (shorten length to one)
            ReduceToUnit(outp);
        }
        void ReduceToUnit(float[] vector)
        {
            float length;

            // Calculate the length of the vector		
            length = (float)Math.Sqrt((vector[0] * vector[0]) +
                                (vector[1] * vector[1]) +
                                (vector[2] * vector[2]));

            // Keep the program from blowing up by providing an exceptable
            // value for vectors that may calculated too close to zero.
            if (length == 0.0f)
                length = 1.0f;

            // Dividing each element by the length will result in a
            // unit normal vector.
            vector[0] /= length;
            vector[1] /= length;
            vector[2] /= length;
        }


       
    }
}
