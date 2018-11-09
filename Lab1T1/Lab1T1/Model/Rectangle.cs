using Lab1T1.Helper;
using SharpGL;
using System;
using System.Drawing;

namespace Lab1T1.Model
{
    public class Rectangel : Shape
    {
        public Rectangel(Point upLeft, Point downRight, float thickness, Color userChoose)
        {
            thoiGianVe = DateTime.Now;
            this.upLeft = upLeft;
            this.downRight = downRight;
            this.thickness = thickness;
            this.userChoose = userChoose;
            center.X = upLeft.X + downRight.X;
            center.X /= 2;
            center.Y = upLeft.Y + downRight.Y;
            center.Y /= 2;
        }

        public override void Draw(OpenGLControl glControl)
        {
            base.Draw(glControl);
            var gl = glControl.OpenGL;
            gl.PushMatrix();
            gl.PushMatrix();
            Affine.Rotate(center, gocXoay, glControl.OpenGL);
            gl.Begin(OpenGL.GL_LINE_LOOP);
            gl.Vertex(upLeft.X, glControl.Height - upLeft.Y);
            gl.Vertex(upLeft.X, glControl.Height - downRight.Y);
            gl.Vertex(downRight.X, glControl.Height - downRight.Y);
            gl.Vertex(downRight.X, glControl.Height - upLeft.Y);
            gl.End();
            if (veDdk == true)
            {
                DrawControlPoint(glControl);
            }
            gl.PopMatrix();
        }
    }

}
