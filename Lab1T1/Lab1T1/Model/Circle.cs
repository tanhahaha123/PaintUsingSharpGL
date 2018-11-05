using SharpGL;
using System;
using System.Drawing;

namespace Lab1T1.Model
{
    public class Circle : Shape
    {
        public Point start, center;
        public long tmpX2, tmpY2;
        public double p;
        public int radius;

        private void PrepareData()
        {
            double tmpRadius = Math.Sqrt(Math.Pow(upLeft.X - center.X, 2) + Math.Pow(upLeft.Y - center.Y, 2));
            string tmpRStr = ((int)tmpRadius).ToString();
            radius = int.Parse(tmpRStr);
            start = new Point(0, radius);
            tmpX2 = 0;
            tmpY2 = 2 * start.Y;
            p = 5 / 4 - radius;
        }

        public Circle(Point a, Point b, float thickness, Color userChoose)
        {
            upLeft = a;
            downRight = b;
            if (a == b)
            {
                return;
            }

            this.thickness = thickness;
            this.userChoose = userChoose;
            int xCenter = (a.X + b.X);
            xCenter /= 2;
            int yCenter = (a.Y + b.Y);
            yCenter /= 2;

            center = new Point(xCenter, yCenter);
            PrepareData();
        }
        public override void Draw(OpenGLControl glControl)
        {
            //Prepare data
            long x2 = tmpX2;
            long y2 = tmpY2;
            p = 5 / 4 - radius;

            start = new Point(0, radius);

            base.Draw(glControl);
            int k = 0;
            var gl = glControl.OpenGL;
            gl.PointSize(thickness);
            gl.Begin(OpenGL.GL_POINTS);
            while (true)
            {
                if (start.X > start.Y)
                {
                    gl.End();
                    return;
                }
                //Vẽ điểm cũ,  và 7 điểm đối xứng của nó
                gl.Vertex(center.X - start.X, glControl.Height - (center.Y - start.Y));
                gl.Vertex(center.X + start.X, glControl.Height - (center.Y + start.Y));
                gl.Vertex(center.X - start.X, glControl.Height - (center.Y + start.Y));
                gl.Vertex(center.X + start.X, glControl.Height - (center.Y - start.Y));
                gl.Vertex(center.X + start.Y, glControl.Height - (center.Y + start.X));
                gl.Vertex(center.X - start.Y, glControl.Height - (center.Y + start.X));
                gl.Vertex(center.X + start.Y, glControl.Height - (center.Y - start.X));
                gl.Vertex(center.X - start.Y, glControl.Height - (center.Y - start.X));
                start.X++;
                x2 = x2 + 2;
                if (p < 0)
                {
                    p = p + x2 + 1;
                }
                else
                {
                    start.Y--;
                    y2 = y2 - 2;
                    p = p + x2 - y2 + 1;
                }
                k++;
            }
        }
    }
}
