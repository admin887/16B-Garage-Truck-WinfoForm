using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using Garage_Truck_WinfoForms;

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
        float m_speed;
        float m_travelDistance;
        float m_cameraMoving;
        float m_cameraRotate;
       public float angle = 0.0f;
        GLUquadric obj;
        public float TransparentA = 0.0f, TransparentB = 0.0f, TransparentC = -15.0f;

        public cOGL(Control pb)
        {
            p = pb;
            m_cameraMoving = 0;
            m_cameraMoving = 0;
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

        public  void DrawAll(int eCarMove,float backCabinLiftingAngle)
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
            GL.glTranslatef(0, -2, 0);
            createRoad();
            createGrass();
            createGarbage();
            createTop();
            if ((eCarMove==0 || Garage_Truck_WinfoForms.Main.moving==1) && m_travelDistance < 80)
            {
                if (m_travelDistance < 80)
                    m_travelDistance += m_speed;
                else
                    m_travelDistance = 80;
                GL.glTranslatef(-m_travelDistance, 0, 0);
                m_speed += 0.2f;
            }
            else if (( Garage_Truck_WinfoForms.Main.moving == -1) && m_travelDistance > 0)
            {
                if (m_travelDistance < 0)
                    m_travelDistance = 0;
                else
                    m_travelDistance -= m_speed;
                GL.glTranslatef(-m_travelDistance, 0, 0);
                m_speed += 0.2f;
            }
            else
            {
                if (m_travelDistance < 0)
                    m_travelDistance = 0;
                GL.glTranslatef(-m_travelDistance, 0, 0);
            }
                

            Console.WriteLine(m_travelDistance);

            if (eCarMove==1)
            {
                m_speed = 0;
                m_travelDistance = 0;
            }
            CreateFrontCabin();
            CreateChassis();
            CreateBackWheels();
            CreateFrontWheels();
            if(m_travelDistance==0)
                CreateBackCabin(backCabinLiftingAngle);
            else
                CreateBackCabin(0);






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
        public void MoveTheTruck()
        { 
}
        public void Draw(float i_angle1,float i_angle2,float i_angle3,float x, float y,float backCabinLiftingAngle,int eMoveTruck)
        {
            if (m_uint_DC == 0 || m_uint_RC == 0)
                return;

            GL.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            GL.glLoadIdentity();

            GL.glTranslatef(TransparentA, TransparentB, TransparentC);						// Translate 6 Units Into The Screen
            if (Main.cam == Main.eCameraMovig.Forward)
            {
                m_cameraMoving += 0.35f;
            }
            else if (Main.cam == Main.eCameraMovig.Backward)
            {
                m_cameraMoving -= 0.35f;
            }
            else if(Main.cam == Main.eCameraMovig.Right)
            {
                m_cameraRotate += 3f;
            }
            else if (Main.cam == Main.eCameraMovig.Left)
            {
                m_cameraRotate -= 3f;
            }
            else if (Main.cam == Main.eCameraMovig.Reset)
            {
                m_cameraMoving = 0;
                m_cameraRotate = 0;
            }
            GL.glTranslatef(0, 0, m_cameraMoving);
            GL.glRotatef(m_cameraRotate, 0, 1, 0);
            GL.glRotatef(i_angle1, x, y, 1);
            GL.glRotatef(i_angle2, 1, y, x);
            GL.glRotatef(i_angle3, x, 1, y);
            //Bitmap bitmap = new Bitmap("example.jpg");



            DrawAll(eMoveTruck, backCabinLiftingAngle);

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
            //Draw(angle + 3.0f, 2.0f,0, 2.0f, 0.0f,0.0f,2);

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
            InitTexture(Texture.Terrain.k_Garbage);
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
        public void createGrass()
        {
            int width = 240;
            int height = 200;
            int length = 240;

            //start in this coordinates
            int x = 10;
            int y = -3;
            int z = 7;

            //center the square
            x = x - width / 2;
            y = y - height / 2;
            z = z - length / 2;
            InitTexture(Texture.Terrain.k_Grass);
            GL.glEnable(GL.GL_TEXTURE_2D);
            GL.glPushMatrix();
            GL.glTranslatef(0, 0.5f, 0);
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
        public void createTop()
        {
            int width = 240;
            int height = 200;
            int length = 240;

            //start in this coordinates
            int x = 10;
            int y = -3;
            int z = 7;

            //center the square
            x = x - width / 2;
            y = y - height / 2;
            z = z - length / 2;
            GL.glEnable(GL.GL_TEXTURE_2D);
            InitTexture(Texture.Terrain.k_Top);

            //start drawing quads
            GL.glPushMatrix();
            GL.glBegin(GL.GL_QUADS);
            GL.glRotatef(90, 0, 1, 0);
            GL.glTexCoord2f(1.0f, 0.0f); GL.glVertex3d(x + width, y, z);
            GL.glNormal3d(-1, 1, 1);
            GL.glNormal3d(-1, -1, 1);
            GL.glTexCoord2f(1.0f, 1.0f); GL.glVertex3d(x + width, y + height, z);
            GL.glNormal3d(1, -1, 1);
            GL.glTexCoord2f(0.0f, 1.0f); GL.glVertex3d(x, y + height, z);
            GL.glNormal3d(1, 1, 1);
            GL.glTexCoord2f(0.0f, 0.0f); GL.glVertex3d(x, y, z);
      
            GL.glEnd();
            GL.glPopMatrix();

            GL.glEnable(GL.GL_TEXTURE_2D);
            InitTexture(Texture.Terrain.k_Top);
            GL.glBegin(GL.GL_QUADS);
            GL.glNormal3d(1, 1, -1);
            GL.glTexCoord2f(1.0f, 0.0f); GL.glVertex3d(x, y, z + length);
            GL.glNormal3d(1, -1, -1);
            GL.glTexCoord2f(1.0f, 1.0f); GL.glVertex3d(x, y + height, z + length);
            GL.glNormal3d(-1, -1, -1);
            GL.glTexCoord2f(0.0f, 1.0f); GL.glVertex3d(x + width, y + height, z + length);
            GL.glNormal3d(-1, 1, -1);
            GL.glTexCoord2f(0.0f, 0.0f); GL.glVertex3d(x + width, y, z + length);
            GL.glEnd();

            GL.glEnable(GL.GL_TEXTURE_2D);
            InitTexture(Texture.Terrain.k_Top);
            GL.glBegin(GL.GL_QUADS);
            GL.glNormal3d(1, -1, 1);
            GL.glTexCoord2f(0.0f, 1.0f); GL.glVertex3d(x, y + height, z);
            GL.glNormal3d(1, -1, -1);
            GL.glTexCoord2f(1.0f, 1.0f); GL.glVertex3d(x, y + height, z + length);
            GL.glNormal3d(1, 1, -1);
            GL.glTexCoord2f(1.0f, 0.0f); GL.glVertex3d(x, y, z + length);
            GL.glNormal3d(1, 1, 1);
            GL.glTexCoord2f(0.0f, 0.0f); GL.glVertex3d(x, y, z);
            GL.glEnd();

            GL.glEnable(GL.GL_TEXTURE_2D);
            InitTexture(Texture.Terrain.k_Top);
            GL.glBegin(GL.GL_QUADS);
            GL.glNormal3d(-1, 1, 1);
            GL.glTexCoord2f(0.0f, 0.0f); GL.glVertex3d(x + width, y, z);
            GL.glNormal3d(-1, 1, -1);
            GL.glTexCoord2f(1.0f, 0.0f); GL.glVertex3d(x + width, y, z + length);
            GL.glNormal3d(-1, -1, -1);
            GL.glTexCoord2f(1.0f, 1.0f); GL.glVertex3d(x + width, y + height, z + length);
            GL.glNormal3d(-1, -1, 1);
            GL.glTexCoord2f(0.0f, 1.0f); GL.glVertex3d(x + width, y + height, z);
            GL.glEnd();
        }
        public void createRoad()
        {
            InitTexture(Texture.Terrain.k_Asfalt);
            GL.glEnable(GL.GL_TEXTURE_2D);
           // GL.glBindTexture(GL.GL_TEXTURE_2D, texturaAsfalto);
            GL.glPushMatrix();
            GL.glTranslatef(-97, 0.5f, 4.5f);
            GL.glRotatef(90, 0, 1, 0);
            int count = 0;
            for (int y = 0; y < 20; y++)// this for loop draws the road
            {
                GL.glBegin(GL.GL_QUADS);
                GL.glTexCoord2f(0.0f, 0.0f); GL.glVertex3f(-0.8f, 0, count);
                GL.glTexCoord2f(0.0f, 1.0f); GL.glVertex3f(-0.8f, 0, count + 5);
                GL.glTexCoord2f(1.0f, 1.0f); GL.glVertex3f(3.8f, 0, count + 5);
                GL.glTexCoord2f(1.0f, 0.0f); GL.glVertex3f(3.8f, 0, count);
                GL.glEnd();
                count +=  5;
            }

            GL.glPopMatrix();
        }
        public void CreateBackWheels()
        {
            GL.glTranslatef(0, 0, 2f);
            GL.glRotatef(90f, 0.0f, 1.0f, 0.0f);

            for (float i = 0; i < 2; i++)
            {
                GL.glPushMatrix();
                GL.glTranslatef(-0.5f, -0.4f, -0.55f+i*0.3f);

                InitTexture(Texture.Back.k_BackLeftWheel);
                GL.glEnable(GL.GL_TEXTURE_2D);
                GL.glEnable(GL.GL_BLEND);
                GL.glBlendFunc(GL.GL_SRC_ALPHA, GL.GL_ONE_MINUS_SRC_ALPHA);
                GL.glBegin(GL.GL_QUADS);

                GL.glTexCoord2f(1, 1);
                GL.glVertex3f(1f, 0.65f, 0.5f);

                GL.glTexCoord2f(1, 0);
                GL.glVertex3f(1f, 0.0f, 0.5f);

                GL.glTexCoord2f(0, 0);
                GL.glVertex3f(0.0f, 0.0f, 0.5f);

                GL.glTexCoord2f(0, 1);
                GL.glVertex3f(0.0f, 0.65f, 0.5f);
                GL.glEnd();
                GL.glPopMatrix();
            }
            for (float i = 0; i < 2; i++)
            {
                InitTexture(Texture.Back.k_BackRightWheel);
                GL.glPushMatrix();
                GL.glTranslatef(-0.5f, -0.4f, +0.3f + i * 0.3f);
                GL.glBegin(GL.GL_QUADS);
                GL.glTexCoord2f(1, 1);
                GL.glVertex3f(1f, 0.65f, 0.5f);

                GL.glTexCoord2f(1, 0);
                GL.glVertex3f(1f, 0.0f, 0.5f);

                GL.glTexCoord2f(0, 0);
                GL.glVertex3f(0.0f, 0.0f, 0.5f);

                GL.glTexCoord2f(0, 1);
                GL.glVertex3f(0.0f, 0.65f, 0.5f);
                GL.glEnd();
                GL.glPopMatrix();
            }
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
            for (float i = 0; i < 2; i++)
            {
                InitTexture(Texture.Front.k_FrontLeftWheel);
                GL.glPushMatrix();
                GL.glTranslatef(-0.5f, -0.4f, -0.55f + i * 1.1f);
                GL.glEnable(GL.GL_BLEND);
                GL.glBlendFunc(GL.GL_SRC_ALPHA, GL.GL_ONE_MINUS_SRC_ALPHA);
                GL.glBegin(GL.GL_QUADS);

                GL.glTexCoord2f(1, 1);
                GL.glVertex3f(1f, 0.65f, 0.5f);

                GL.glTexCoord2f(1, 0);
                GL.glVertex3f(1f, 0.0f, 0.5f);

                GL.glTexCoord2f(0, 0);
                GL.glVertex3f(0.0f, 0.0f, 0.5f);

                GL.glTexCoord2f(0, 1);
                GL.glVertex3f(0.0f, 0.65f, 0.5f);
                GL.glEnd();
                GL.glPopMatrix();
            }
            for (float i = 0; i < 2; i++)
            {
                InitTexture(Texture.Front.k_FrontLeftWheel);
                GL.glPushMatrix();
                GL.glTranslatef(-0.5f, -0.4f, -0.55f + i * 0.3f);
                GL.glEnable(GL.GL_BLEND);
                GL.glBlendFunc(GL.GL_ONE, GL.GL_ONE_MINUS_SRC_ALPHA);
                GL.glBegin(GL.GL_POLYGON);

                GL.glTexCoord2f(1, 1);
                GL.glVertex3f(1f, 0.65f, 0.5f);

                GL.glTexCoord2f(1, 0);
                GL.glVertex3f(1f, 0.0f, 0.5f);

                GL.glTexCoord2f(0, 0);
                GL.glVertex3f(0.0f, 0.0f, 0.5f);

                GL.glTexCoord2f(0, 1);
                GL.glVertex3f(0.0f, 0.65f, 0.5f);
                GL.glEnd();
                GL.glPopMatrix();
            }
            for (float i = 0; i < 2; i++)
            {
                InitTexture(Texture.Front.k_FrontRightWheel);
                GL.glPushMatrix();
                GL.glTranslatef(-0.5f, -0.4f, +0.3f + i * 0.3f);
                GL.glBegin(GL.GL_QUADS);
                GL.glTexCoord2f(1, 1);
                GL.glVertex3f(1f, 0.65f, 0.5f);

                GL.glTexCoord2f(1, 0);
                GL.glVertex3f(1f, 0.0f, 0.5f);

                GL.glTexCoord2f(0, 0);
                GL.glVertex3f(0.0f, 0.0f, 0.5f);

                GL.glTexCoord2f(0, 1);
                GL.glVertex3f(0.0f, 0.65f, 0.5f);
                GL.glEnd();
                GL.glPopMatrix();
            }
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
            float doubleX = (float)x;

            GL.glPushMatrix();

            GL.glTranslatef(0, 0, 0);


            InitTexture(Texture.Terrain.k_Garbage1);

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
                    GL.glRotatef(-backCabinLiftingAngle /60, 0, 0, 1f);
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
