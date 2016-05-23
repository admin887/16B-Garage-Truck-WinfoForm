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
        float angle = 0.0f;
GLUquadric obj;
        public float TransparentA=0.0f, TransparentB=0.0f, TransparentC=-15.0f;

        public cOGL(Control pb)
        {
            p=pb;
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
			get{ return m_uint_HWND; }
		}
		
      

        public uint DC
		{
			get{ return m_uint_DC;}
		}
		
        public uint RC
		{
			get{ return m_uint_RC; }
		}

        protected void DrawAll()
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



            CreateBackCabin();

            CreateFrontCabin();
            





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
        public void Draw()
        {
            if (m_uint_DC == 0 || m_uint_RC == 0)
                return;

            GL.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            GL.glLoadIdentity();

            GL.glTranslatef(TransparentA, TransparentB, TransparentC);						// Translate 6 Units Into The Screen
       
            angle += 3.0f;

            GL.glRotatef(angle, 0.0f, 2.0f, 0.0f);

            //Bitmap bitmap = new Bitmap("example.jpg");

        

            DrawAll();

            GL.glFlush();

            WGL.wglSwapBuffers(m_uint_DC);

        }
        public void rotate()
        {
            //Draw();
            Console.WriteLine("Hello World");
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
			pfd.nVersion        = 1; 
			pfd.dwFlags         = (WGL.PFD_DRAW_TO_WINDOW |  WGL.PFD_SUPPORT_OPENGL |  WGL.PFD_DOUBLEBUFFER); 
			pfd.iPixelType      = (byte)(WGL.PFD_TYPE_RGBA);
			pfd.cColorBits      = 32;
			pfd.cDepthBits      = 32;
			pfd.iLayerType      = (byte)(WGL.PFD_MAIN_PLANE);

			int pixelFormatIndex = 0;
			pixelFormatIndex = WGL.ChoosePixelFormat(m_uint_DC, ref pfd);
			if(pixelFormatIndex == 0)
			{
				MessageBox.Show("Unable to retrieve pixel format");
				return;
			}

			if(WGL.SetPixelFormat(m_uint_DC,pixelFormatIndex,ref pfd) == 0)
			{
				MessageBox.Show("Unable to set pixel format");
				return;
			}
			//Create rendering context
			m_uint_RC = WGL.wglCreateContext(m_uint_DC);
			if(m_uint_RC == 0)
			{
				MessageBox.Show("Unable to get rendering context");
				return;
			}
			if(WGL.wglMakeCurrent(m_uint_DC,m_uint_RC) == 0)
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
			if(m_uint_DC == 0 || m_uint_RC == 0)
				return;
			if(this.Width == 0 || this.Height == 0)
				return;
            GL.glEnable(GL.GL_DEPTH_TEST);
            GL.glDepthFunc(GL.GL_LEQUAL);

            GL.glViewport(-500, -400, 1920,1080);
           // GL.glViewport(50, 50, 200, 50);
            
            GL.glClearColor(0, 0.3f, 0, 0); 
			GL.glMatrixMode ( GL.GL_PROJECTION );
			GL.glLoadIdentity();
			GLU.gluPerspective( 50,((double)Width) / Height, 1.0,1000.0);
			GL.glMatrixMode ( GL.GL_MODELVIEW );
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




       public void CreateBackCabin()
        {
            //Side of the Truck!
         //   GL.glColor3f(1.0f, 0.0f, 0.0f);
           
            for (int i = 1; i < 3; i++)
            {
                InitTexture(i+".jpg");

                GL.glPushMatrix();
                GL.glBegin(GL.GL_QUADS);

                GL.glTexCoord2f(1,1);
                GL.glVertex3f(2.0f, 1.0f, 1.0f);

                GL.glTexCoord2f(1,0);
                GL.glVertex3f(2.0f, 0.0f, 1.0f);

                GL.glTexCoord2f(0,0);
                GL.glVertex3f(0.0f, 0.0f, 1.0f);

                GL.glTexCoord2f(0,1);
                GL.glVertex3f(0.0f, 1.0f, 1.0f);
                GL.glEnd();
                GL.glPopMatrix();


                GL.glTranslatef(0, 0, 1);
                GL.glRotatef(90f, 0.0f, 1.0f, 0.0f);
                GL.glTranslatef(0, 0, 2);
                GL.glRotatef(90f, 0.0f, 1.0f, 0.0f);
            }

            GL.glTranslatef(0, 0, 1);
            GL.glRotatef(90f, 0.0f, 1.0f, 0.0f);

            //Front and back

          //  GL.glColor3f(0.0f, 1.0f, 0.0f);
            for (int i = 0; i < 2; i++)
            {
                //  GL.glColor3f(i % 2, i % 2, i %2);
                InitTexture("back.jpg");

                GL.glPushMatrix();
                GL.glBegin(GL.GL_QUADS);

                GL.glTexCoord2f(0, 0);
                GL.glVertex3f(1.0f, 1.0f, 2.0f);

                GL.glTexCoord2f(0,1);
                GL.glVertex3f(1.0f, 0.0f, 2.0f);

                GL.glTexCoord2f(1,1);
                GL.glVertex3f(0.0f, 0.0f, 2.0f);

                GL.glTexCoord2f(1,0);
                GL.glVertex3f(0.0f, 1.0f, 2.0f);
                GL.glEnd();
                GL.glPopMatrix();


                GL.glTranslatef(0, 0, 2);
                GL.glRotatef(90f, 0.0f, 1.0f, 0.0f);
                GL.glTranslatef(0, 0, 1);
                GL.glRotatef(90f, 0.0f, 1.0f, 0.0f);
            }


        }

       public void CreateFrontCabinOld()
       {
           GL.glTranslatef(0, 0, 3f);
           GL.glRotatef(90f, 0.0f, 1.0f, 0.0f);

           GL.glColor3f(1.0f, 0.0f, 0.0f);
           for (int i = 0; i < 2; i++)
           {
               GL.glPushMatrix();
               GL.glBegin(GL.GL_QUADS);

               GL.glTexCoord2f(0.5f, 1.0f);
               GL.glVertex3f(0.7f, 1.0f, 1.0f);

               GL.glTexCoord2f(0.0f, 1.0f);
               GL.glVertex3f(0.7f, 0.0f, 1.0f);

               GL.glTexCoord2f(0.0f, 0.5f);
               GL.glVertex3f(0.0f, 0.0f, 1.0f);

               GL.glTexCoord2f(0.5f, 0.5f);
               GL.glVertex3f(0.0f, 1.0f, 1.0f);
               GL.glEnd();
               GL.glPopMatrix();


               GL.glTranslatef(0, 0, 1);
               GL.glRotatef(90f, 0.0f, 1.0f, 0.0f);
               GL.glTranslatef(0, 0, 0.7f);
               GL.glRotatef(90f, 0.0f, 1.0f, 0.0f);
           }

           GL.glTranslatef(0, 0, 1);
           GL.glRotatef(90f, 0.0f, 1.0f, 0.0f);

           //Front and back

           GL.glColor3f(0.0f, 1.0f, 0.0f);
           for (int i = 0; i < 2; i++)
           {
               //  GL.glColor3f(i % 2, i % 2, i %2);

               GL.glPushMatrix();
               GL.glBegin(GL.GL_QUADS);

               GL.glTexCoord2f(0.5f, 1.0f);
               GL.glVertex3f(1.0f, 1.0f, 0.7f);

               GL.glTexCoord2f(0.0f, 1.0f);
               GL.glVertex3f(1.0f, 0.0f, 0.7f);

               GL.glTexCoord2f(0.0f, 0.5f);
               GL.glVertex3f(0.0f, 0.0f, 0.7f);

               GL.glTexCoord2f(0.5f, 0.5f);
               GL.glVertex3f(0.0f, 1.0f, 0.7f);
               GL.glEnd();
               GL.glPopMatrix();


               GL.glTranslatef(0, 0, 0.7f);
               GL.glRotatef(90f, 0.0f, 1.0f, 0.0f);
               GL.glTranslatef(0, 0, 1);
               GL.glRotatef(90f, 0.0f, 1.0f, 0.0f);
           }

       }

       public void CreateFrontCabin()
       {
           GL.glTranslatef(0, 0, 2.6f);
           GL.glRotatef(90f, 0.0f, 1.0f, 0.0f);

       //    GL.glColor3f(1.0f, 0.0f, 0.0f);

           for (int i = 1; i < 3; i++)
           {
               InitTexture("side"+i+".jpg");

               GL.glPushMatrix();
               GL.glBegin(GL.GL_QUADS);

               GL.glTexCoord2f(1, 0);
               GL.glVertex3f(0.7f, 0.85f, 1.0f);

               GL.glTexCoord2f(1,1);
               GL.glVertex3f(0.7f, 0.0f, 1.0f);

               GL.glTexCoord2f(0,1);
               GL.glVertex3f(0.0f, 0.0f, 1.0f);

               GL.glTexCoord2f(0,0);
               GL.glVertex3f(0.0f, 0.85f, 1.0f);
               GL.glEnd();
               GL.glPopMatrix();


               GL.glTranslatef(0, 0, 1);
               GL.glRotatef(90f, 0.0f, 1.0f, 0.0f);
               GL.glTranslatef(0, 0, 0.7f);
               GL.glRotatef(90f, 0.0f, 1.0f, 0.0f);
           }

           GL.glTranslatef(0, 0, 1);
           GL.glRotatef(90f, 0.0f, 1.0f, 0.0f);

           //Front and back

        //   GL.glColor3f(0.0f, 1.0f, 0.0f);
           for (int i = 0; i < 2; i++)
           {
               //  GL.glColor3f(i % 2, i % 2, i %2);
               InitTexture("front.jpg");
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
}
