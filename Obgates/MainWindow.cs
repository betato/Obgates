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
        public MainWindow(int height, int width)
            : base(height, width)
        {
            
        }

        EditorInterface editorInterface = new EditorInterface();

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        } 

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            MouseState mouse = OpenTK.Input.Mouse.GetCursorState();
        }
    }
}
