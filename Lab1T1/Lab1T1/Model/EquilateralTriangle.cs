using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1T1.Model
{

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
            if ((downRight.Y < upLeft.Y && downRight.X > upLeft.X) || (downRight.Y > upLeft.Y && downRight.X < upLeft.X))
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

}
