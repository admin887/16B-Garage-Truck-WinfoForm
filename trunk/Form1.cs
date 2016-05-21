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
    public partial class Form1 : Form
    {
        cOGL c;

        public Form1()
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
            //rotateFlag = false;
            timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            c.Draw();
        }

    }
}
