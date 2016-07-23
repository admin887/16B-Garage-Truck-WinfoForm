using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;


namespace OpenGL
{
    class cOGL
    {
        Thread rotateThread;
        bool rotateFlag;
        Control p;
        int Width;
        int Height;
        uint m_uint_HWND = 0;
        uint m_uint_DC = 0;
        uint m_uint_RC = 0;
       public float angle = 0.0f;
        GLUquadric obj;
        public float TransparentA = 0.0f, TransparentB = 0.0f, TransparentC = -15.0f;

        public cOGL(Control pb)
        {
            p = pb;
            Width = p.Width;
            Height = p.Height;
            obj = GLU.gluNewQuadric();
            InitializeGL();
        }

        ~cOGL()
        {
            WGL.wglDeleteContext(m_uint_RC);
        }

        public uint HWND
        {
            get { return m_uint_HWND; }
        }



        public uint DC
        {
            get { return m_uint_DC; }
        }

        public uint RC
        {
            get { return m_uint_RC; }
        }

        public  void DrawAll(float backCabinLiftingAngle)
        {
            //axes
            //  GL.glBegin(GL.GL_LINES);
            //  //x  RED
            //  GL.glColor3f(1.0f, 0.0f, 0.0f);
            //  GL.glVertex3f(0.0f, 0.0f, 0.0f);
            //  GL.glVertex3f(3.0f, 0.0f, 0.0f);
            //  //////y  GREEN 
            //  GL.glColor3f(0.0f, 1.0f, 0.0f);
            //  GL.glVertex3f(0.0f, 0.0f, 0.0f);
            //  GL.glVertex3f(0.0f, 3.0f, 0.0f);
            //  //////z  BLUE
            //  GL.glColor3f(0.0f, 0.0f, 1.0f);
            //  GL.glVertex3f(0.0f, 0.0f, 0.0f);
            //  GL.glVertex3f(0.0f, 0.0f, 3.0f);
            //  GL.glEnd();

            //GL.glBegin(GL.GL_QUADS);

            //GL.glColor3f(255, 255, 255);
            //GL.glVertex2f(-1, -1);
            //GL.glVertex2f(1, -1);
            //GL.glVertex2f(1, 1);
            //GL.glVertex2f(-1, 1);
            //GL.glVertex2f(-1, -1);

            ////1 Gil

            float[] pos = new float[4];

            float[,] ground = new float[3, 3];


            //  MakeShadowMatrix(ground);


            CreateFrontCabin();
            CreateChassis();
            CreateBackWheels();
            CreateFrontWheels();
         
            CreateBackCabin(backCabinLiftingAngle);





            //GL.glFlush();


            // GL.glColor3f(1.0f, 0.0f, 0.0f);
            //
            // GL.glPushMatrix();
            // GL.glBegin(GL.GL_QUADS);
            // GL.glVertex3f(0.0f, 0.0f, 0.0f);
            // GL.glVertex3f(0.0f, 1.0f, 0.0f);
            // GL.glVertex3f(1.0f, 1.0f, 0.0f);
            // GL.glVertex3f(1.0f, 0.0f, 0.0f);
            // GL.glEnd();
            // GL.glPopMatrix();
            //
            // GL.glRotatef(90f, 0.0f, 1.0f, 0.0f);
            // GL.glColor3f(0.0f, 1.0f, 0.0f);
            // GL.glBegin(GL.GL_QUADS);
            // GL.glVertex3f(0.0f, 0.0f, 0.0f);
            // GL.glVertex3f(0.0f, 1.0f, 0.0f);
            // GL.glVertex3f(1.0f, 1.0f, 0.0f);
            // GL.glVertex3f(1.0f, 0.0f, 0.0f);
            // GL.glEnd();
            //
            //////2 Gil
            //
            //GL.glColor3f(0, 0, 1);
            //GL.glVertex3f(-1, 1, 1);
            //GL.glVertex3f(1, 1, 1);
            //GL.glVertex3f(1, -1, 1);
            //GL.glVertex3f(-1, -1, 1);
            //
            //////3 Gil
            //GL.glColor3f(1.0f, 0, 0);
            //GL.glVertex3f(-1, -1, 1);
            //GL.glVertex3f(-1, 1, 1);
            //GL.glVertex3f(-1, 1, -1);
            //GL.glVertex3f(-1, -1, -1);
            //
            //////4 Gil
            //GL.glColor3f(0.5f, 0, 0);
            //GL.glVertex3f(1, -1, 1);
            //GL.glVertex3f(1, 1, 1);
            //GL.glVertex3f(1, 1, -1);
            //GL.glVertex3f(1, -1, -1);
            //
            //////5 Gil
            //GL.glColor3f(0, 0.5f, 0);
            //GL.glVertex3f(-1, -1, 1);
            //GL.glVertex3f(1, -1, 1);
            //GL.glVertex3f(1, -1, -1);
            //GL.glVertex3f(-1, -1, -1);
            //
            //////6 Gil
            //GL.glColor3f(0, 0.5f, 0);
            //GL.glVertex3f(-1, 1, 1);
            //GL.glVertex3f(1, 1, 1);
            //GL.glVertex3f(1, 1, -1);
            //GL.glVertex3f(-1, 1, -1);
            //
            //
            //
            //
            //
            //
            ////roof 1
            //GL.glColor3f(0, 0.5f, 0.5f);
            //GL.glVertex3f(1, -1, 1); 
            //GL.glVertex3f(0, -2, 0);
            //GL.glVertex3f(1, -1, -1);
            //GL.glVertex3f(1, -1, 1);
            //
            ////roof 2
            //GL.glColor3f(0.5f, 0, 0.5f);
            //GL.glVertex3f(-1, -1, 1);
            //GL.glVertex3f(0, -2, 0);
            //GL.glVertex3f(-1, -1, -1);
            //GL.glVertex3f(-1, -1, 1);
            //
            ////roof 3
            //GL.glColor3f(0.5f, 0.5f, 0);
            //GL.glVertex3f(-1, -1, 1);
            //GL.glVertex3f(0, -2, 0);
            //GL.glVertex3f(1, -1, 1);
            //GL.glVertex3f(-1, -1, 1);
            //
            ////roof 4
            //GL.glColor3f(0.5f, 0.5f, 0.5f);
            //GL.glVertex3f(1, -1, -1);
            //GL.glVertex3f(0, -2, 0);
            //GL.glVertex3f(-1, -1, -1);
            //GL.glVertex3f(1, -1, -1);




            //GL.glEnd();



            //   GL.glBegin(GL.GL_QUADS);
            //
            //   GL.glTexCoord2f(0.5f, 0.5f);			// top right of texture
            //   GL.glVertex3f(-1.0f, 1.0f, -1.0f);		// top right of quad
            //   GL.glTexCoord2f(0.0f, 0.5f);			// top left of texture
            //   GL.glVertex3f(1.0f, 1.0f, -1.0f);		// top left of quad
            //   GL.glTexCoord2f(0.0f, 0.0f);			// bottom left of texture
            //   GL.glVertex3f(1.0f, -1.0f, -1.0f);	    // bottom left of quad
            //   GL.glTexCoord2f(0.5f, 0.0f);			// bottom right of texture
            //   GL.glVertex3f(-1.0f, -1.0f, -1.0f);		// bottom right of quad
            //
            //   GL.glTexCoord2f(0.5f, 1.0f);			
            //   GL.glVertex3f(1.0f, 1.0f, 1.0f);		
            //   GL.glTexCoord2f(0.0f, 1.0f);			
            //   GL.glVertex3f(-1.0f, 1.0f, 1.0f);      
            //   GL.glTexCoord2f(0.0f, 0.5f);			
            //   GL.glVertex3f(-1.0f, -1.0f, 1.0f);	   
            //   GL.glTexCoord2f(0.5f, 0.5f);			
            //   GL.glVertex3f(1.0f, -1.0f, 1.0f);      
            //
            //   GL.glTexCoord2f(1.0f, 0.5f);			
            //   GL.glVertex3f(-1.0f, 1.0f, 1.0f);
            //   GL.glTexCoord2f(0.5f, 0.5f);			
            //   GL.glVertex3f(-1.0f, 1.0f, -1.0f);
            //   GL.glTexCoord2f(0.5f, 0.0f);		
            //   GL.glVertex3f(-1.0f, -1.0f, -1.0f);
            //   GL.glTexCoord2f(1.0f, 0.0f);			
            //   GL.glVertex3f(-1.0f, -1.0f, 1.0f);
            //
            //   GL.glTexCoord2f(1.0f, 1.0f);
            //   GL.glVertex3f(1.0f, 1.0f, -1.0f);
            //   GL.glTexCoord2f(0.5f, 1.0f);
            //   GL.glVertex3f(1.0f, 1.0f, 1.0f);
            //   GL.glTexCoord2f(0.5f, 0.5f);
            //   GL.glVertex3f(1.0f, -1.0f, 1.0f);
            //   GL.glTexCoord2f(1.0f, 0.5f);
            //   GL.glVertex3f(1.0f, -1.0f, -1.0f);
            //
            //   GL.glEnd();
            //
            //   GL.glColor3f(0, 0.5f, 0.7f);
            //   GL.glRotatef(90.0f, -1.0f, 0.0f,0.0f);
            //   GLU.gluCylinder(obj, 0.1f, 0.1f, 2.0f, 32, 32);
            //
            //   GL.glFlush();
            //
            //  
            // 
            //   /*
            //   GL.glColor3f(0, 0, 1);
            //   GL.glVertex3f(-1, 1, 1);
            //   GL.glVertex3f(1, 1, 1);
            //   GL.glVertex3f(1, -1, 1);
            //   GL.glVertex3f(-1, -1, 1);
            //   */
            //   GL.glColor3f(1.0f, 1.0f, 1.0f);
            //   GL.glEnable(GL.GL_TEXTURE_2D);
            //   GL.glVertex3f(1.0f, -1.0f, 1.0f);	    // bottom left of quad
            //   GL.glTexCoord2f(1.0f,0.0f );			// bottom right of texture
            //   GL.glVertex3f(-1.0f, -1.0f, 1.0f);		// bottom right of quad
            //   GL.glEnd();
            // 
            //   /*
            //   GL.glColor3f(0, 0, 1);
            //   GL.glVertex3f(-1, 1, 1);
            //   GL.glVertex3f(1, 1, 1);
            //   GL.glVertex3f(1, -1, 1);
            //   GL.glVertex3f(-1, -1, 1);
            //   */
            //   GL.glColor3f(1.0f, 1.0f, 1.0f);
            //   GL.glEnable(GL.GL_TEXTURE_2D);
            //   GL.glTexCoord2f(1.0f,0.0f );			// bottom right of texture
            //   GL.glVertex3f(-1.0f, -1.0f, 1.0f);		// bottom right of quad
            //   GL.glEnd();
            // 
            //   /*
            //   GL.glColor3f(0, 0, 1);
            //   GL.glVertex3f(-1, 1, 1);
            //   GL.glVertex3f(1, 1, 1);
            //   GL.glVertex3f(1, -1, 1);
            //   GL.glVertex3f(-1, -1, 1);
            //   */
            //
            //
            //
            //   GL.glColor3f(1.0f, 1.0f, 1.0f);
            //   GL.glEnable(GL.GL_TEXTURE_2D);
        }
        public void Draw(float i_angle,float x, float y, float z,float backCabinLiftingAngle)
        {
            if (m_uint_DC == 0 || m_uint_RC == 0)
                return;

            GL.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            GL.glLoadIdentity();

            GL.glTranslatef(TransparentA, TransparentB, TransparentC);						// Translate 6 Units Into The Screen

            angle = i_angle;

            GL.glRotatef(angle, x, y, z);

            //Bitmap bitmap = new Bitmap("example.jpg");



            DrawAll(backCabinLiftingAngle);

            GL.glFlush();

            WGL.wglSwapBuffers(m_uint_DC);
        }




/*

        const int x = 0;
        const int y = 1;
        const int z = 2;

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

            dot = planeCoeff[0] * pos[0] +
                    planeCoeff[1] * pos[1] +
                    planeCoeff[2] * pos[2] +
                    planeCoeff[3];

            // Now do the projection
            // First column
            cubeXform[0] = dot - pos[0] * planeCoeff[0];
            cubeXform[4] = 0.0f - pos[0] * planeCoeff[1];
            cubeXform[8] = 0.0f - pos[0] * planeCoeff[2];
            cubeXform[12] = 0.0f - pos[0] * planeCoeff[3];

            // Second column
            cubeXform[1] = 0.0f - pos[1] * planeCoeff[0];
            cubeXform[5] = dot - pos[1] * planeCoeff[1];
            cubeXform[9] = 0.0f - pos[1] * planeCoeff[2];
            cubeXform[13] = 0.0f - pos[1] * planeCoeff[3];

            // Third Column
            cubeXform[2] = 0.0f - pos[2] * planeCoeff[0];
            cubeXform[6] = 0.0f - pos[2] * planeCoeff[1];
            cubeXform[10] = dot - pos[2] * planeCoeff[2];
            cubeXform[14] = 0.0f - pos[2] * planeCoeff[3];

            // Fourth Column
            cubeXform[3] = 0.0f - pos[3] * planeCoeff[0];
            cubeXform[7] = 0.0f - pos[3] * planeCoeff[1];
            cubeXform[11] = 0.0f - pos[3] * planeCoeff[2];
            cubeXform[15] = dot - pos[3] * planeCoeff[3];
        }
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
*/







        public void Draw()
        {
            Draw(angle + 3.0f, 0.0f, 2.0f, 0.0f,0.0f);

        }
       protected virtual void InitializeGL()
		{
			m_uint_HWND = (uint)p.Handle.ToInt32();
			m_uint_DC   = WGL.GetDC(m_uint_HWND);

            // Not doing the following WGL.wglSwapBuffers() on the DC will
            // result in a failure to subsequently create the RC.
            WGL.wglSwapBuffers(m_uint_DC);

            WGL.PIXELFORMATDESCRIPTOR pfd = new WGL.PIXELFORMATDESCRIPTOR();
            WGL.ZeroPixelDescriptor(ref pfd);
            pfd.nVersion = 1;
            pfd.dwFlags = (WGL.PFD_DRAW_TO_WINDOW | WGL.PFD_SUPPORT_OPENGL | WGL.PFD_DOUBLEBUFFER);
            pfd.iPixelType = (byte)(WGL.PFD_TYPE_RGBA);
            pfd.cColorBits = 32;
            pfd.cDepthBits = 32;
            pfd.iLayerType = (byte)(WGL.PFD_MAIN_PLANE);

            int pixelFormatIndex = 0;
            pixelFormatIndex = WGL.ChoosePixelFormat(m_uint_DC, ref pfd);
            if (pixelFormatIndex == 0)
            {
                MessageBox.Show("Unable to retrieve pixel format");
                return;
            }

            if (WGL.SetPixelFormat(m_uint_DC, pixelFormatIndex, ref pfd) == 0)
            {
                MessageBox.Show("Unable to set pixel format");
                return;
            }
            //Create rendering context
            m_uint_RC = WGL.wglCreateContext(m_uint_DC);
            if (m_uint_RC == 0)
            {
                MessageBox.Show("Unable to get rendering context");
                return;
            }
            if (WGL.wglMakeCurrent(m_uint_DC, m_uint_RC) == 0)
            {
                MessageBox.Show("Unable to make rendering context current");
                return;
            }


            initRenderingGL();
        }

        public void OnResize()
        {
            /*Width = p.Width;
            Height = p.Height;

            //!!!!!!!
            GL.glViewport(0, 0, Width, Height);
            //!!!!!!!
            
            initRenderingGL();
            Draw();*/
        }

        protected virtual void initRenderingGL()
        {
            if (m_uint_DC == 0 || m_uint_RC == 0)
                return;
            if (this.Width == 0 || this.Height == 0)
                return;
            GL.glEnable(GL.GL_DEPTH_TEST);
            GL.glDepthFunc(GL.GL_LEQUAL);

            GL.glViewport(-500, -400, 1920, 1080);
            // GL.glViewport(50, 50, 200, 50);

            GL.glClearColor(0, 0.3f, 0, 0);
            GL.glMatrixMode(GL.GL_PROJECTION);
            GL.glLoadIdentity();
            GLU.gluPerspective(50, ((double)Width) / Height, 1.0, 1000.0);
            GL.glMatrixMode(GL.GL_MODELVIEW);
            GL.glLoadIdentity();
            //  InitTexture("example.bmp");
            //   InitTexture("alon.bmp");
            //   InitTexture("truck.jpg");
            //      InitTexture("1.jpg");
        }
        public uint[] texture;		// texture

        void InitTexture(string imageBMPfile)
        {
            GL.glEnable(GL.GL_TEXTURE_2D);

            texture = new uint[1];		// storage for texture

            Bitmap image = new Bitmap(imageBMPfile);
            image.RotateFlip(RotateFlipType.RotateNoneFlipY); //Y axis in Windows is directed downwards, while in OpenGL-upwards
            System.Drawing.Imaging.BitmapData bitmapdata;
            Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);

            bitmapdata = image.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            GL.glGenTextures(1, texture);
            GL.glBindTexture(GL.GL_TEXTURE_2D, texture[0]);
            //  VN-in order to use System.Drawing.Imaging.BitmapData Scan0 I've added overloaded version to
            //  OpenGL.cs
            //  [DllImport(GL_DLL, EntryPoint = "glTexImage2D")]
            //  public static extern void glTexImage2D(uint target, int level, int internalformat, int width, int height, int border, uint format, uint type, IntPtr pixels);
            GL.glTexImage2D(GL.GL_TEXTURE_2D, 0, (int)GL.GL_RGB8, image.Width, image.Height,
                0, GL.GL_BGR_EXT, GL.GL_UNSIGNED_byte, bitmapdata.Scan0);
            GL.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_LINEAR);		// Linear Filtering
            GL.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_LINEAR);		// Linear Filtering

            image.UnlockBits(bitmapdata);
            image.Dispose();
        }

        public void CreateBackWheels()
        {
            GL.glTranslatef(0, 0, 2f);
            GL.glRotatef(90f, 0.0f, 1.0f, 0.0f);
            
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
                    GL.glTranslatef(0,0,-0.3f*j);
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

       public void CreateGarbageCube()
        {

            //Face 1
            double x=0.2;
            GL.glBegin(GL.GL_QUADS);

            GL.glTranslatef(3f, 3f, 3f);
                //Face1
                GL.glVertex3d(-x, x, x); // vertex[0]
                GL.glVertex3d(x, x, x); // vertex[1]
                GL.glVertex3d(x, -x, x); // vertex[2]
                GL.glVertex3d(-x, -x, x); // vertex[3]
                //Face2
                GL.glVertex3d(-x, x, -x); // vertex[4]
                GL.glVertex3d(x, x, -x); // vertex[5]
                GL.glVertex3d(x, -x, -x); // vertex[6]
                GL.glVertex3d(-x, -x, -x); // vertex[7]
                //Face3
                GL.glVertex3d(-x, x, x);
                GL.glVertex3d(-x, -x, x);
                GL.glVertex3d(-x, -x, -x);
                GL.glVertex3d(-x, x, -x);
                //Face4
                GL.glVertex3d(x, -x, x);
                GL.glVertex3d(x, -x, -x);
                GL.glVertex3d(x, x, -x);
                GL.glVertex3d(x, x, x);
                //Face5
                GL.glVertex3d(-x, -x, x);
                GL.glVertex3d(-x, -x, -x);
                GL.glVertex3d(x, -x, -x);
                GL.glVertex3d(x, -x, x);
                //Face6
                GL.glVertex3d(-x, x, x);
                GL.glVertex3d(-x, x, -x);
                GL.glVertex3d(x, x, -x);
                GL.glVertex3d(x, x, x);
        
            //Face2
            /*GL.glBegin(GL.GL_POLYGON);
            GL.glVertex3d(-0.1f, 0.1f, -0.1f);
            GL.glVertex3d(-0.1f, 0.1f, 0.1f);
            GL.glVertex3d(0.1f, 0.1f, 0.1f);
            GL.glVertex3d(0.1f, 0.1f, -0.1f);*/
            GL.glEnd();
            GL.glPopMatrix();
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
            
            InitTexture(Texture.Back.k_LeftSide);
            
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
         

            InitTexture(Texture.Back.k_RightSide);

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

            InitTexture(Texture.Back.k_FrontSide);

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
            InitTexture(Texture.Back.k_BackSide);

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
            if(backCabinLiftingAngle>=90)
            {
                GL.glPushMatrix();
                for (int i = 0; i < 10; i++)
                {
                    GL.glRotatef(-backCabinLiftingAngle /70, 0, 0, 1f);
                    GL.glTranslatef(-0.6f, 0.2f, 0.1f);
                    CreateGarbageCube();
                }
                GL.glPopMatrix();
            }
        }

        public void CreateFrontCabin()
        {
            GL.glTranslatef(0, 1, 2.6f);
            //GL.glRotatef(90f, 0.0f, 1.0f, 0.0f);

            InitTexture(Texture.Front.k_LeftSide);

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



            InitTexture(Texture.Front.k_RightSide);

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
            InitTexture(Texture.Front.k_BackSide);
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





            InitTexture(Texture.Front.k_FrontSide);
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
    }
}
