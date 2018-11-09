using Lab1T1.Helper;
using SharpGL;
using System;
using System.Drawing;

namespace Lab1T1.Model
{
    public class Eclipse : Shape
    {
        public double radiusX;
        public double radiusY;
        public Eclipse(Point a, Point b, float thickness, Color userChoose)
        {
            thoiGianVe = DateTime.Now;
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
            gl.PushMatrix();
            Affine.Rotate(center, gocXoay, glControl.OpenGL);
            gl.Begin(OpenGL.GL_LINE_LOOP);
            for (double i = 0; i < 360; i += 0.1)
            {
                double rad = i * Math.PI / 180;
                gl.Vertex(center.X + radiusX * Math.Cos(rad), tmpCenterY + radiusY * Math.Sin(rad));
            }
            gl.End();
            if(veDdk == true)
            {
                DrawControlPoint(glControl);
            }
            gl.PopMatrix();
        }
    }

}
