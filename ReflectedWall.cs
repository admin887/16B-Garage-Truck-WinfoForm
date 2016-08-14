using OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garage_Truck_WinfoForms.Truck;
using System.Windows.Forms;

namespace Garage_Truck_WinfoForms
{
    public class ReflectedWall : DrawbleComponent
    {
       

        public IDrawable CurrentObj { get; set; }

        double[] AccumulatedRotationsTraslations = new double[16];
        public ReflectedWall(IDrawable obj)
        {
            CurrentObj = obj;
        }
        public override void Draw()
        {
            double[] CurrentRotationTraslation = new double[16];

            GL.glGetDoublev(GL.GL_MODELVIEW_MATRIX, CurrentRotationTraslation);

          //  GL.glLoadMatrixd(AccumulatedRotationsTraslations); //Global Matrix


            GL.glEnable(GL.GL_BLEND);
                GL.glBlendFunc(GL.GL_SRC_ALPHA, GL.GL_ONE_MINUS_SRC_ALPHA);
            
            
                //only floor, draw only to STENCIL buffer
                GL.glEnable(GL.GL_STENCIL_TEST);
                GL.glStencilOp(GL.GL_REPLACE, GL.GL_REPLACE, GL.GL_REPLACE);
                GL.glStencilFunc(GL.GL_ALWAYS, 1, 0xFFFFFFFF); // draw floor always
                GL.glColorMask((byte)GL.GL_FALSE, (byte)GL.GL_FALSE, (byte)GL.GL_FALSE, (byte)GL.GL_FALSE);
                GL.glDisable(GL.GL_DEPTH_TEST);
            
                DrawFloor();
            
                // restore regular settings
                GL.glColorMask((byte)GL.GL_TRUE, (byte)GL.GL_TRUE, (byte)GL.GL_TRUE, (byte)GL.GL_TRUE);
                GL.glEnable(GL.GL_DEPTH_TEST);
            
                // reflection is drawn only where STENCIL buffer value equal to 1
                GL.glStencilFunc(GL.GL_EQUAL, 1, 0xFFFFFFFF);
                GL.glStencilOp(GL.GL_KEEP, GL.GL_KEEP, GL.GL_KEEP);
            
                GL.glEnable(GL.GL_STENCIL_TEST);
            
                // draw reflected scene
                GL.glPushMatrix();
                GL.glTranslated(0, 0, 2.5);
                    GL.glScalef(1, 1, -1); //swap on Z axis
                GL.glEnable(GL.GL_CULL_FACE);
                GL.glCullFace(GL.GL_BACK);
                            

                

                CurrentObj.DrawWithMatrixClosing();
                GL.glCullFace(GL.GL_FRONT);
                CurrentObj.DrawWithMatrixClosing();
                GL.glDisable(GL.GL_CULL_FACE);
                GL.glPopMatrix();
            
            
                // really draw floor 
                //( half-transparent ( see its color's alpha byte)))
                // in order to see reflected objects 
                GL.glDepthMask((byte)GL.GL_FALSE);
                DrawFloor();
                GL.glDepthMask((byte)GL.GL_TRUE);
                // Disable GL.GL_STENCIL_TEST to show All, else it will be cut on GL.GL_STENCIL
                GL.glDisable(GL.GL_STENCIL_TEST);
               // DrawFigures();
                //REFLECTION e    
            
                GL.glFlush();
            

        }

        private void DrawFloor()
        {
            GL.glEnable(GL.GL_LIGHTING);
            GL.glBegin(GL.GL_QUADS);
            //!!! for blended REFLECTION 
            GL.glColor4d(0, 0, 1, 0);
            GL.glVertex3d(-3, -3, 0);
            GL.glVertex3d(-3, 3, 0);
            GL.glVertex3d(3, 3, 0);
            GL.glVertex3d(3, -3, 0);
            GL.glEnd();
        }
    }
}
