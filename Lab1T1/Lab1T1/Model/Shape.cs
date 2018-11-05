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

        public void DrawALineWithAngle(OpenGLControl glControl, int angle,Point goc, Point start, Point end)
        {
            var gl = glControl.OpenGL;
            gl.Translate(goc.X, glControl.Height - goc.Y, 0);
            gl.Rotate(angle, 0, 0, 1);
            gl.Translate(-goc.X, -(glControl.Height - goc.Y), 0);
            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(start.X, glControl.Height - start.Y);
            gl.Vertex(end.X, glControl.Height - end.Y);
            gl.End();
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

            radius = 100;
            x2 = 0;

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
            var upRight = new Point(downRight.X, upLeft.Y);
            base.Draw(glControl);
            var gl = glControl.OpenGL;
            gl.PushMatrix();
            DrawALineWithAngle(glControl, 0, upLeft, upLeft, upRight);
            if ((downRight.Y < upLeft.Y && downRight.X > upLeft.X)||(downRight.Y > upLeft.Y && downRight.X < upLeft.X))
            {
                DrawALineWithAngle(glControl, 60, upLeft, upLeft, upRight);
                DrawALineWithAngle(glControl, 60, upRight, upLeft, upRight);
            }
            else
            {
                DrawALineWithAngle(glControl, -60, upLeft, upLeft, upRight);
                DrawALineWithAngle(glControl, -60, upRight, upLeft, upRight);
            }
            gl.PopMatrix();
        }
    }

    public class EqualPentagon: Shape
    {
        public EqualPentagon(Point a, Point b, float thickness, Color color)
        {
            upLeft = a; downRight = b;
            this.thickness = thickness;
            userChoose = color;
        }

        public override void Draw(OpenGLControl glControl)
        {
            var upRight = new Point(downRight.X, upLeft.Y);
            base.Draw(glControl);
            var gl = glControl.OpenGL;
            gl.PushMatrix();
            DrawALineWithAngle(glControl, 0, upLeft, upLeft, upRight);
            if ((downRight.Y < upLeft.Y && downRight.X > upLeft.X) || (downRight.Y > upLeft.Y && downRight.X < upLeft.X))
            {
                DrawALineWithAngle(glControl, 108, upLeft, upLeft, upRight);
                DrawALineWithAngle(glControl, 108, upRight, upLeft, upRight);
                DrawALineWithAngle(glControl, 108, upLeft, upLeft, upRight);
                DrawALineWithAngle(glControl, 108, upRight, upLeft, upRight);
            }
            else
            {
                DrawALineWithAngle(glControl, -108, upLeft, upLeft, upRight);
                DrawALineWithAngle(glControl, -108, upRight, upLeft, upRight);
                DrawALineWithAngle(glControl, -108, upLeft, upLeft, upRight);
                DrawALineWithAngle(glControl, -108, upRight, upLeft, upRight);
            }
            gl.PopMatrix();
        }
    }

    public class EqualHexagon: Shape
    {
        public EqualHexagon(Point a, Point b, float thickness, Color color)
        {
            upLeft = a; downRight = b;
            this.thickness = thickness;
            userChoose = color;
        }

        public override void Draw(OpenGLControl glControl)
        {
            var upRight = new Point(downRight.X, upLeft.Y);
            base.Draw(glControl);
        }
    }
}
