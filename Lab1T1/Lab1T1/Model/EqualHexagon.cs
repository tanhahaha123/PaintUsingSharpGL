using SharpGL;
using System;
using System.Drawing;

namespace Lab1T1.Model
{


    public class EqualHexagon : Shape
    {
        public EqualHexagon(Point a, Point b, float thickness, Color color)
        {
            thoiGianVe = DateTime.Now;
            upLeft = a; downRight = b;
            this.thickness = thickness;
            userChoose = color;
        }

        public override void DrawControlPoint(OpenGLControl glControl, Color? color = null)
        {
            Color choose = color ?? Color.Red;
            var upRight = new Point(downRight.X, upLeft.Y);
            int angle;
            var gl = glControl.OpenGL;
            gl.Color(choose.R / 255.0, choose.G / 255.0, choose.B / 255.0);
            gl.PointSize(5f);
            gl.PushMatrix();
            DrawPointWithAngle(glControl, 0, upLeft, upRight);
            if ((downRight.Y < upLeft.Y && downRight.X > upLeft.X) || (downRight.Y > upLeft.Y && downRight.X < upLeft.X))
            {
                angle = 120;
            }
            else
            {
                angle = -120;
            }
            DrawPointWithAngle(glControl, angle, upLeft, upLeft);
            DrawPointWithAngle(glControl, angle, upRight, upRight);
            DrawPointWithAngle(glControl, angle, upLeft, upLeft);
            DrawPointWithAngle(glControl, angle, upRight, upRight);
            DrawPointWithAngle(glControl, angle, upLeft, upLeft);
            gl.PopMatrix();
        }

        public override void Draw(OpenGLControl glControl)
        {
            var upRight = new Point(downRight.X, upLeft.Y);
            base.Draw(glControl);
            int angle;
            var gl = glControl.OpenGL;
            gl.PushMatrix();
            DrawALineWithAngle(glControl, 0, upLeft, upLeft, upRight);
            if ((downRight.Y < upLeft.Y && downRight.X > upLeft.X) || (downRight.Y > upLeft.Y && downRight.X < upLeft.X))
            {
                angle = 120;
            }
            else
            {
                angle = -120;
            }
            DrawALineWithAngle(glControl, angle, upLeft, upLeft, upRight);
            DrawALineWithAngle(glControl, angle, upRight, upLeft, upRight);
            DrawALineWithAngle(glControl, angle, upLeft, upLeft, upRight);
            DrawALineWithAngle(glControl, angle, upRight, upLeft, upRight);
            DrawALineWithAngle(glControl, angle, upLeft, upLeft, upRight);
            gl.PopMatrix();
            if(veDdk == true)
            {
                DrawControlPoint(glControl);
            }
        }
    }
}
