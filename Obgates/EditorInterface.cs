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

        public EditorInterface()
        {
            displayComponent.subcomponents.Add(new NullGate());
        }

        public Bitmap drawComponents(Size frameSize)
        {
            // Get image and graphics
            Bitmap image = new Bitmap(frameSize.Width, frameSize.Height);
            Graphics g = Graphics.FromImage(image);

            // Fill background
            g.FillRectangle(Brushes.White, 0, 0, frameSize.Width, frameSize.Height);

            // Draw components
            foreach (Component subcomponent in displayComponent.subcomponents)
            {
                // Component
                g.DrawRectangle(Pens.Black, displayX * zoom, displayY * zoom,
                    subcomponent.width * zoom, subcomponent.height * zoom);
                // Pins
                foreach (Pin pin in subcomponent.pins)
                {
                    fillCircle(g, Brushes.Black, (displayX + pin.x) * zoom,
                        (displayY + pin.y) * zoom, 2);
                }
            }

            // Draw wires
            foreach (Wire wire in displayComponent.wires)
            {
                // Draw each segment
                foreach (Line segment in wire.segments)
                {
                    g.DrawLine(Pens.Black, segment.x1 + displayX, 
                        segment.y1 + displayY, segment.x2 + displayX, 
                        segment.y2 + displayY);
                }
            }

            // Return image
            return image;
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
