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
}
