using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obgates
{
    class MainWindow : GameWindow
    {
        EditorInterface editorInterface = new EditorInterface();

        public MainWindow(int height, int width)
            : base(height, width)
        {
            this.VSync = VSyncMode.On;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            GL.Ortho(-5, 5, -5, 5, -1, 1);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.ClearColor(Color4.White);
            MouseState mouse = OpenTK.Input.Mouse.GetCursorState();
            editorInterface.drawComponents();

            SwapBuffers();
        }
    }
}
