using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obgates
{
    class Line
    {
        public Line() { }

        public Line(int x1, int y1, int x2, int y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }

        public Line(Point p1, Point p2)
        {
            point1 = p1;
            point2 = p2;
        }

        int x1;
        int y1;

        int x2;
        int y2;

        public Point point1
        {
            get { return new Point(x1, y1); }
            set { x1 = point1.X; y1 = point1.Y; }
        }

        public Point point2
        {
            get { return new Point(x2, y2); }
            set { x2 = point2.X; y2 = point2.Y; }
        }
    }
}
