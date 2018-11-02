using SharpGL;
using System;
using System.Drawing;

namespace Lab1T1.Model
{
    public class Shape
    {
        public Point upLeft;
        public Point downRight;
        public DateTime timeCreate;
        public float thickness;
        public Color userChoose;
        public virtual void Draw(OpenGLControl glControl)
        {
            var gl = glControl.OpenGL;
            gl.Color(0, 0, 0, 0);
            gl.LineWidth(thickness);
            gl.Color(userChoose.R / 255.0, userChoose.G / 255.0, userChoose.B / 255.0);
        }
    }

    public class Rectangel : Shape
    {
        public Rectangel(Point upLeft, Point downRight, float thickness, Color userChoose)
        {
            this.upLeft = upLeft;
            this.downRight = downRight;
            this.thickness = thickness;
            this.userChoose = userChoose;
        }

        public override void Draw(OpenGLControl glControl)
        {
            base.Draw(glControl);
            timeCreate = DateTime.Now;
            var gl = glControl.OpenGL;
            gl.Begin(OpenGL.GL_LINE_LOOP);
            gl.Vertex(upLeft.X, glControl.Height - upLeft.Y);
            gl.Vertex(upLeft.X, glControl.Height - downRight.Y);
            gl.Vertex(downRight.X, glControl.Height - downRight.Y);
            gl.Vertex(downRight.X, glControl.Height - upLeft.Y);
            gl.End();
        }
    }

    public class Line : Shape
    {
        public Line(Point a, Point b, float thickness, Color userChoose)
        {
            upLeft = a;
            downRight = b;
            this.thickness = thickness;
            this.userChoose = userChoose;
        }
        public override void Draw(OpenGLControl glControl)
        {
            base.Draw(glControl);
            timeCreate = DateTime.Now;
            var gl = glControl.OpenGL;
            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(upLeft.X, glControl.Height - upLeft.Y);
            gl.Vertex(downRight.X, glControl.Height - downRight.Y);
            gl.End();
        }
    }

    public class Eclipse : Shape
    {
        public Point center;
        public double radiusX;
        public double radiusY;
        public Eclipse() { radiusX = -1; radiusY = -1; }
        public Eclipse(Point a, Point b, float thickness, Color userChoose)
        {
            upLeft = a;
            downRight = b;
            radiusX = -1;
            radiusY = -1;
            this.thickness = thickness;
            this.userChoose = userChoose;
        }

        public void FindRadius()
        {
            center.X = (upLeft.X + downRight.X) / 2;
            center.Y = (upLeft.Y + downRight.Y) / 2;
            if (radiusX == -1 || radiusY == -1)
            {
                var midX = new Point(upLeft.X, (upLeft.Y + downRight.Y) / 2);
                var midY = new Point((upLeft.X + downRight.X) / 2, downRight.Y);
                radiusX = Math.Pow(center.X - midX.X, 2) + Math.Pow(center.Y - midX.Y, 2);
                radiusX = Math.Sqrt(radiusX);
                radiusY = Math.Pow(center.X - midY.X, 2) + Math.Pow(center.Y - midY.Y, 2);
                radiusY = Math.Sqrt(radiusY);
            }
        }

        public override void Draw(OpenGLControl glControl)
        {
            base.Draw(glControl);
            FindRadius();
            var tmpCenterY = glControl.Height - center.Y;
            var gl = glControl.OpenGL;
            gl.Begin(OpenGL.GL_LINE_LOOP);
            for (double i = 0; i < 360; i += 0.1)
            {
                double rad = i * Math.PI / 180;
                gl.Vertex(center.X + radiusX * Math.Cos(rad), tmpCenterY + radiusY * Math.Sin(rad));
            }
            gl.End();
        }
    }

    public class Circle : Shape
    {
        private static Point start, center, tmp;
        private static long x2, y2;
        private static double p;
        private static int radius;

        public Circle(Point a, Point b, float thickness, Color userChoose)
        {
            upLeft = a;
            downRight = b;
            this.thickness = thickness;
            this.userChoose = userChoose;
            center = new Point((a.X + b.X) / 2, (a.Y + b.Y) / 2);
            double tmpRadius = Math.Sqrt(Math.Pow(a.X - center.X, 2) + Math.Pow(a.Y - center.Y, 2));
            string tmpRStr = ((int)tmpRadius).ToString();
            radius = int.Parse(tmpRStr);
            start = new Point(0, radius);
            x2 = 0; y2 = 2 * radius;
            p = 5 / 4 - double.Parse(tmpRStr.ToString());
        }
        public override void Draw(OpenGLControl glControl)
        {
            base.Draw(glControl);
            int k = 0;
            var gl = glControl.OpenGL;
            gl.PointSize(thickness);
            gl.Begin(OpenGL.GL_POINTS);
            while (true)
            {
                //Bug tại vì Sau khi chạy vòng lặp xong thì start.X >= start.Y rồi. Gán thì có cái hình vuông ở trong :O
                if (start.X >= start.Y)
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

    public class EquilateralTriangle : Shape
    {
        public EquilateralTriangle(Point a, Point b, float thickness, Color userChoose)
        {
            upLeft = a;
            downRight = b;
            this.thickness = thickness;
            this.userChoose = userChoose;
        }
        public override void Draw(OpenGLControl glControl)
        {
            base.Draw(glControl);
            var gl = glControl.OpenGL;

            gl.Begin(OpenGL.GL_LINE_LOOP);
            gl.Vertex(upLeft.X, glControl.Height - downRight.Y);
            gl.Vertex(downRight.X, glControl.Height - downRight.Y);
            double tmpUpleftY;
            var tmp1 = downRight.Y + Math.Abs(((downRight.X + upLeft.X) / 2 - upLeft.X) * Math.Sqrt(3));
            var tmp2 = downRight.Y - Math.Abs(((downRight.X + upLeft.X) / 2 - upLeft.X) * Math.Sqrt(3));
            if (Math.Abs(tmp1 - upLeft.Y) > Math.Abs(tmp2 - upLeft.Y))
            {
                tmpUpleftY = tmp2;
            }
            else
            {
                tmpUpleftY = tmp1;
            }
                
            gl.Vertex((downRight.X + upLeft.X) / 2, glControl.Height - tmpUpleftY);
            gl.End();
        }
    }
}
