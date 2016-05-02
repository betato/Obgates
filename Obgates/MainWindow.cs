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

        double left = -10.0, right = 10.0, bottom = -10.0, top = 10.0;

        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            base.OnMouseWheel(e);
            
            double zoom = e.DeltaPrecise;

            double x = (double) e.X / (double) Width;
            double y = (double) e.Y / (double) Height;

            left += x * zoom;
            right -= (1 - x) * zoom;
            bottom += (1 - y) * zoom;
            top -= y * zoom;
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.LoadIdentity();
            GL.Ortho(left, right, bottom, top, -1, 1);
            editorInterface.drawComponents();

            SwapBuffers();
        }
    }
}
