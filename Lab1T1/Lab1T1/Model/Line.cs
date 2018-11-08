using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1T1.Model
{
    public class Line : Shape
    {
        public Line(Point a, Point b, float thickness, Color userChoose)
        {
            upLeft = a;
            downRight = b;
            this.thickness = thickness;
            this.userChoose = userChoose;
        }

        public override void DrawControlPoint(OpenGLControl glControl, Color? color = null)
        {
            Color choose = color ?? Color.HotPink;
            var gl = glControl.OpenGL;
            gl.Color(choose.R / 255.0, choose.G / 255.0, choose.B / 255.0);
            gl.PointSize(5f);
            gl.Begin(OpenGL.GL_POINTS);
            gl.Vertex(upLeft.X, glControl.Height - upLeft.Y);
            gl.Vertex(downRight.X, glControl.Height - downRight.Y);
            gl.End();
            gl.Flush();
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
            if(veDdk == true)
            {
                DrawControlPoint(glControl);
            }
        }
    }

}
