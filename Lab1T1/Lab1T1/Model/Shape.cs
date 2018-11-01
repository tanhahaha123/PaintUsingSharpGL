using SharpGL;
using System;
using System.Drawing;

namespace Lab1T1.Model
{
    public class Shape
    {
        public DateTime timeCreate;
        public virtual void Draw(OpenGLControl glControl)
        {
            glControl.OpenGL.Color(0, 0, 0, 0);
            //Có thể sẽ đưa mã màu vào
            //Có thể sẽ đưa độ đậm nhạt vào
        }
    }

    public class Rectangel : Shape
    {
        public Point upLeft;
        public Point downRight;
        public Rectangel(Point upLeft, Point downRight)
        {
            this.upLeft = upLeft;
            this.downRight = downRight;
        }

        public override void Draw(OpenGLControl glControl)
        {
            timeCreate = DateTime.Now;
            var gl = glControl.OpenGL;
            gl.Begin(OpenGL.GL_LINE_LOOP);
            gl.Vertex(upLeft.X, glControl.Height - upLeft.Y);
            gl.Vertex(upLeft.X, glControl.Height - downRight.Y);
            gl.Vertex(downRight.X, glControl.Height - downRight.Y);
            gl.Vertex(downRight.X, glControl.Height - upLeft.Y);

        }
    }

    public class Line : Shape
    {
        public Point start;
        public Point end;

        public override void Draw(OpenGLControl glControl)
        {
            timeCreate = DateTime.Now;
            var gl = glControl.OpenGL;
            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(start.X, start.Y);
            gl.Vertex(end.X, end.Y);
        }
    }

    public class Eclipse : Shape
    {
        public Point upLeft;
        public Point downRight;
        public Point center;
        public double radiusX;
        public double radiusY;
        public Eclipse() { radiusX = -1; radiusY = -1; }
        public Eclipse(Point a, Point b)
        {
            upLeft = a;
            downRight = b;
            radiusX = -1;
            radiusY = -1;
        }

        public void FindRadius()
        {
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
            center.X = (upLeft.X + downRight.X) / 2;
            center.Y = (upLeft.Y + downRight.Y) / 2;
            center.Y = glControl.Height - center.Y;
            FindRadius();
            var gl = glControl.OpenGL;
            gl.Begin(OpenGL.GL_LINE_LOOP);
            for (int i = 0; i < 360; i++)
            {
                double rad = i * Math.PI / 180;
                gl.Vertex(center.X + radiusX * Math.Cos(rad), center.Y + radiusY * Math.Sin(rad));
            }
        }
    }

    public class Circle : Shape
    {
        public Point upLeft;
        public Point downRight;
        public Circle(Point a, Point b)
        {
            upLeft = a;
            downRight = b;
        }
        public override void Draw(OpenGLControl glControl)
        {
            var eclip = new Eclipse(upLeft, downRight);
            eclip.FindRadius();
            if (eclip.radiusX > eclip.radiusY)
            {
                eclip.radiusX = eclip.radiusY;
            }
            else
            {
                eclip.radiusY = eclip.radiusX;
            }

            eclip.Draw(glControl);
        }
    }
}
