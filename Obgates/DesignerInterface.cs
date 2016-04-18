using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obgates
{
    class DesignerInterface
    {
        public Bitmap Frame(int width, int height)
        {
            Bitmap image = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(image);
            g.FillRectangle(Brushes.White, 0, 0, width, height);

            return image;
        }
    }
}
