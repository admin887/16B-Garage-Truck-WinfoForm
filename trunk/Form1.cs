﻿using System;
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
            c = new cOGL(panel1);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            c.Draw();
        }
    }
}
