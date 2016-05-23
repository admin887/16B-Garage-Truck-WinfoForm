using System;
using System.Timers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenGL;

namespace Garage_Truck_WinfoForms
{
    public partial class Main : Form
    {
        cOGL c;

        int LastX=-1;
        int LastY=-1;


        public Main()
        {
            InitializeComponent();
            c = new cOGL(panel2);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            c.Draw();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
        private void buttonStop_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            c.Draw();
        }

        private void scroll9_Scroll(object sender, ScrollEventArgs e)
        {
            timer1.Interval = scroll9.Value;
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            LastX = e.X;
            LastY = e.Y;
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            LastX = -1;
            LastY = -1;
        }

        private void panel2_MouseHover(object sender, EventArgs e)
        {
        
        }

        private void panel2_Move(object sender, EventArgs e)
        {
         
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
         // if (LastX != -1 && LastY != -1)
         // {
         //
         //     if (LastX != e.X)
         //     {
         //      //   c.Draw(scroll1.Value, e.X, e.Y, 0);
         //
         //
         // }
         //
        }

        private void scroll1_ValueChanged(object sender, EventArgs e)
        {

            c.Draw(c.angle = scroll1.Value, scroll1.Value, scrool2.Value, 0);
        //    scrool2.Value = scroll1.Value;
            
        }

        private void scrool2_ValueChanged(object sender, EventArgs e)
        {
            c.Draw(c.angle = scrool2.Value, scroll1.Value, scrool2.Value, 0);

         //   scroll1.Value = scrool2.Value;
        }

        private void scroll1_Leave(object sender, EventArgs e)
        {
      

        }

        private void scrool2_Leave(object sender, EventArgs e)
        {
            scrool2.Maximum = scrool2.Value * 2;
        }

    }
}
