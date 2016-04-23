using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Obgates
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        RefreshLoop refreshLoop = new RefreshLoop(60, 20);
        EditorInterface editorInterface = new EditorInterface();

        private void Form1_Load(object sender, EventArgs e)
        {
            refreshLoop.RenderR += r_RenderR;
            refreshLoop.UpdateR += r_UpdateR;
            MouseWheel += Form1_MouseWheel;

            refreshLoop.Start();
        }

        int scroll = 0;

        void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            scroll += e.Delta / 120;
        }

        void r_UpdateR(object source, int fps, int ups)
        {
            if (this.InvokeRequired)
            {
                
            }
        }

        void r_RenderR(object source, int fps, int ups)
        {
            if (this.InvokeRequired)
            {
                // Render and display current component
                editorInterface.updateGraphics(scroll, MousePosition.X, 
                    MousePosition.Y, MouseButtons != 0, pictureBox1.Width,
                    pictureBox1.Height);
                scroll = 0;

                pictureBox1.Invalidate();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            refreshLoop.Exit();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            editorInterface.drawComponents(e.Graphics);
        }
    }
}
