using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            refreshLoop.Start();
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
                BackgroundImage = editorInterface.drawComponents(ClientSize);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            editorInterface.stepComponents();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            refreshLoop.Exit();
        }
    }
}
