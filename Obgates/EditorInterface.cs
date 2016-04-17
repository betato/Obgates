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
        public Bitmap drawComponents(Size frameSize)
        {
            // Get image and graphics
            Bitmap image = new Bitmap(frameSize.Width, frameSize.Height);
            Graphics g = Graphics.FromImage(image);

            // Fill background
            g.FillRectangle(Brushes.White, 0, 0, frameSize.Width, frameSize.Height);

            // Return image
            return image;
        }

        public void stepComponents()
        {

        }
    }
}
