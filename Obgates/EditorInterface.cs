using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obgates
{
    class EditorInterface
    {
        Entity displayComponent = new Entity();

        public EditorInterface()
        {
            // Just debug stuff here
            displayComponent.subcomponents.Add(new NullGate());
            displayComponent.subcomponents.Add(new NullGate());
            displayComponent.subcomponents[1].y = -3;

            Wire w = new Wire();
            w.segments.Add(new Line(2, 1, 5, 1));
            displayComponent.wires.Add(w);
        }

        Vector2[] componentVertexBuffer;
        Vector2[] wireVertexBuffer;
        Vector2[] pinVertexBuffer;
        int[] VBOs = new int[3];

        public void drawComponents()
        {
            // Create buffer arrays
            componentVertexBuffer = new Vector2[displayComponent.componentPoints];
            wireVertexBuffer = new Vector2[displayComponent.wirePoints];
            pinVertexBuffer = new Vector2[displayComponent.pinPoints];

            // Draw components
            int pinCount = 0;
            for (int i = 0; i < displayComponent.subcomponents.Count(); i++)
            {
                // Component
                int x = displayComponent.subcomponents[i].x;
                int y = displayComponent.subcomponents[i].y;
                int w = displayComponent.subcomponents[i].width;
                int h = displayComponent.subcomponents[i].height;
                componentVertexBuffer[i * 4] = new Vector2(x + w, y);
                componentVertexBuffer[i * 4 + 1] = new Vector2(x + w, y + h);
                componentVertexBuffer[i * 4 + 3] = new Vector2(x, y);
                componentVertexBuffer[i * 4 + 2] = new Vector2(x, y + h);

                // Pins
                foreach (Pin pin in displayComponent.subcomponents[i].pins)
                {
                    int globalPinX = pin.x + displayComponent.subcomponents[i].x;
                    int globalPinY = pin.y + displayComponent.subcomponents[i].y;

                    const float PIN_SIZE = 0.1f;
                    pinVertexBuffer[pinCount] = new Vector2(globalPinX - PIN_SIZE, globalPinY + PIN_SIZE);
                    pinVertexBuffer[pinCount + 1] = new Vector2(globalPinX - PIN_SIZE, globalPinY - PIN_SIZE);
                    pinVertexBuffer[pinCount + 2] = new Vector2(globalPinX + PIN_SIZE, globalPinY - PIN_SIZE);
                    pinVertexBuffer[pinCount + 3] = new Vector2(globalPinX + PIN_SIZE, globalPinY + PIN_SIZE);
                    pinCount += 4;
                }
            }

            // Draw wires
            int wireCount = 0;
            foreach (Wire wire in displayComponent.wires)
            {
                // Draw each segment
                foreach (Line segment in wire.segments)
                {
                    wireVertexBuffer[wireCount] = new Vector2(segment.x1, segment.y1);
                    wireVertexBuffer[wireCount + 1] = new Vector2(segment.x2, segment.y2);
                    wireCount += 2;
                }
            }

            #region componentDrawing
            VBOs[0] = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, VBOs[0]);
            GL.BufferData<Vector2>(BufferTarget.ArrayBuffer,
                (IntPtr)(Vector2.SizeInBytes * componentVertexBuffer.Length),
                componentVertexBuffer, BufferUsageHint.StaticDraw);
            GL.EnableClientState(ArrayCap.VertexArray);
            GL.VertexPointer(2, VertexPointerType.Float, Vector2.SizeInBytes, 0);
            GL.DrawArrays(PrimitiveType.Quads, 0, componentVertexBuffer.Length);
            #endregion

            #region pinDrawing
            VBOs[1] = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, VBOs[1]);
            GL.BufferData<Vector2>(BufferTarget.ArrayBuffer,
                (IntPtr)(Vector2.SizeInBytes * pinVertexBuffer.Length),
                pinVertexBuffer, BufferUsageHint.StaticDraw);
            GL.EnableClientState(ArrayCap.VertexArray);
            GL.VertexPointer(2, VertexPointerType.Float,Vector2.SizeInBytes, 0);
            GL.DrawArrays(PrimitiveType.Quads, 0, pinVertexBuffer.Length);
            #endregion

            #region wireDrawing
            VBOs[2] = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, VBOs[2]);
            GL.BufferData<Vector2>(BufferTarget.ArrayBuffer,
                (IntPtr)(Vector2.SizeInBytes * wireVertexBuffer.Length),
                wireVertexBuffer, BufferUsageHint.StaticDraw);
            GL.EnableClientState(ArrayCap.VertexArray);
            GL.VertexPointer(2, VertexPointerType.Float, Vector2.SizeInBytes, 0);
            GL.DrawArrays(PrimitiveType.Lines, 0, wireVertexBuffer.Length);
            #endregion
        }

        public void stepComponents()
        {
            displayComponent.Step();
        }
    }
}
