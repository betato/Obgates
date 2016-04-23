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
        int zoom = 10;
        int displayX = 10;
        int displayY = 10;

        int frameWidth, frameHeight;

        int lastMouseX = 0;
        int lastMouseY = 0;

        public EditorInterface()
        {
            displayComponent.subcomponents.Add(new NullGate());
            Wire w = new Wire();
            w.segments.Add(new Line(2, 1, 5, 1));
            displayComponent.wires.Add(w);
        }

        public void updateGraphics(int deltaZoom, int mouseX, int mouseY, 
            bool mouseDown, int width, int height)
        {
            // Set frame size
            frameHeight = height;
            frameWidth = width;

            // Get change in mouse position if mouse down
            if (mouseDown)
            {
                displayX += mouseX - lastMouseX;
                displayY += mouseY - lastMouseY;
            }
            lastMouseY = mouseY;
            lastMouseX = mouseX;

            // Set zoom, do not lower past zero
            if (zoom + deltaZoom < 0)
            {
                deltaZoom = -zoom;
            }
            zoom += deltaZoom;
        }

        public void drawComponents(Graphics g)
        {
            // Fill background
            g.FillRectangle(Brushes.White, 0, 0, frameWidth, frameHeight);

            // Draw components
            foreach (Component subcomponent in displayComponent.subcomponents)
            {
                // Component
                g.DrawRectangle(Pens.Black, displayX, displayY,
                    subcomponent.width * zoom, subcomponent.height * zoom);
                // Pins
                foreach (Pin pin in subcomponent.pins)
                {
                    fillCircle(g, Brushes.Black, displayX + pin.x * zoom,
                        displayY + pin.y * zoom, (int)(0.2 * zoom));
                }
            }

            // Draw wires
            foreach (Wire wire in displayComponent.wires)
            {
                // Draw each segment
                foreach (Line segment in wire.segments)
                {
                    g.DrawLine(Pens.Black, segment.x1 * zoom + displayX,
                        segment.y1 * zoom + displayY, segment.x2 * zoom + displayX,
                        segment.y2 * zoom + displayY);
                }
            }
        }

        public void fillCircle(Graphics g, Brush b, int x, int y, int radius)
        {
            g.FillEllipse(b, x - radius, y - radius, radius * 2, radius * 2);
        }

        public void stepComponents()
        {

        }
    }
}
