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
        }

        double left = -10.0, right = 10.0, bottom = -10.0, top = 10.0;

        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            base.OnMouseWheel(e);
            
            float zoom = e.DeltaPrecise;

            double x = (double) e.X / (double) Width;
            double y = (double) e.Y / (double) Height;

            left += x * zoom;
            right -= (1 - x) * zoom;
            bottom += (1 - y) * zoom;
            top -= y * zoom;
        }

        protected override void OnMouseMove(MouseMoveEventArgs e)
        {
            base.OnMouseMove(e);

            if (e.Mouse.MiddleButton == ButtonState.Pressed)
            {
                double x = (double)e.XDelta / (double)Width;
                double y = (double)e.YDelta / (double)Height;

                double width = right - left;
                double height = top - bottom;

                left += -x * width;
                right += -x * width;
                bottom += y * height;
                top += y * height;
            }
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);

            double x = e.X;
            double y = e.Y;

            PointToScreen(ref x, ref y);
            Console.WriteLine(x + "," + y);
        }

        private void PointToScreen(ref double x, ref double y)
        {
            // Get absolute cursor position
            x = x / ((double)Width);
            y = 1 - (y / ((double)Height));

            // Get scaled cursor position
            x = (right - left) * x;
            y = (top - bottom) * y;

            // Get relative cursor position
            x = left + x;
            y = bottom + y;
        }
        
        private void DrawGrid()
        {
            // Init
            int step = 4;
            int bottomLineStart = round((int)bottom, step) - step;
            int leftLineStart = round((int)this.left, step) - step;
            int topLineStart = (int)(top + 1);
            int rightLineStart = (int)(right + 1);

            int horizontalLines = topLineStart - bottomLineStart;
            int verticalLines = rightLineStart - leftLineStart;
            int horizontalLinesX2 = horizontalLines * 2;
            int verticalLinesX2 = verticalLines * 2;

            Vector2[] gridVertexBuffer = new Vector2[horizontalLinesX2 + verticalLinesX2];
            int VBO = GL.GenBuffer();

            // Create grid
            for (int i = 0; i < horizontalLines; i += step)
            {
                gridVertexBuffer[i * 2] = new Vector2(leftLineStart, bottomLineStart + i);
                gridVertexBuffer[i * 2 + 1] = new Vector2(rightLineStart, bottomLineStart + i);
            }

            for (int i = 0; i < verticalLines; i += step)
            {
                gridVertexBuffer[(horizontalLinesX2) + i * 2] = new Vector2(leftLineStart + i, topLineStart);
                gridVertexBuffer[(horizontalLinesX2) + i * 2 + 1] = new Vector2(leftLineStart + i, bottomLineStart);
            }

            // Draw buffer
            GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
            GL.BufferData<Vector2>(BufferTarget.ArrayBuffer,
                (IntPtr)(Vector2.SizeInBytes * gridVertexBuffer.Length),
                gridVertexBuffer, BufferUsageHint.StaticDraw);
            GL.EnableClientState(ArrayCap.VertexArray);
            GL.VertexPointer(2, VertexPointerType.Float, Vector2.SizeInBytes, 0);
            GL.DrawArrays(PrimitiveType.Lines, 0, gridVertexBuffer.Length);
        }

        private int round(int value, int factor)
        {
            return (int)Math.Round((value / (double)factor), MidpointRounding.AwayFromZero) * factor;
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
            DrawGrid();

            SwapBuffers();
        }
    }
}
