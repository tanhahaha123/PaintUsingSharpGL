using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1T1.Model
{

    public class EqualTriangle : Shape
    {
        public EqualTriangle(Point a, Point b, float thickness, Color userChoose)
        {
            upLeft = a;
            downRight = b;
            this.thickness = thickness;
            this.userChoose = userChoose;
        }

        public override void DrawControlPoint(OpenGLControl glControl, Color? color = null)
        {
            var upRight = new Point(downRight.X, upLeft.Y);
            Color choose = color ?? Color.HotPink;
            var gl = glControl.OpenGL;
            gl.Color(choose.R / 255.0, choose.G / 255.0, choose.B / 255.0);
            gl.PointSize(5f);
            gl.PushMatrix();
            DrawPointWithAngle(glControl, 0, upLeft, upRight);
            if ((downRight.Y < upLeft.Y && downRight.X > upLeft.X) || (downRight.Y > upLeft.Y && downRight.X < upLeft.X))
            {
                DrawPointWithAngle(glControl, 60, upLeft, upLeft);
                DrawPointWithAngle(glControl, 60, upRight, upRight);
            }
            else
            {
                DrawPointWithAngle(glControl, -60, upLeft, upLeft);
                DrawPointWithAngle(glControl, -60, upRight, upRight);
            }
            gl.PopMatrix();
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
            if(veDdk == true)
            {
                DrawControlPoint(glControl);
            }
        }
    }

}
