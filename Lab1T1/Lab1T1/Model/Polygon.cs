using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Lab1T1.Model
{
    class Polygon
    {
        public DateTime thoiGianVe;
        List<Point> point = null;
        bool isDDK = false;
        private void DrawControlPoint(OpenGLControl glControl, Color? color = null)
        {
            var choose = color ?? Color.Red;
            var gl = glControl.OpenGL;
            gl.PointSize(3f);
            gl.Color(choose.R / 255.0, choose.G / 255.0, choose.B / 255.0);
            gl.Begin(OpenGL.GL_POINTS);
            point.ForEach(x => gl.Vertex(x.X, glControl.Height - x.Y));
            gl.End();
            gl.Flush();
        }
        public Polygon()
        {
            if (point == null)
            {
                point = new List<Point>();
            }
        }
        public void Add(Point a)
        {
            point.Add(a);
        }

        public void Draw(OpenGLControl glControl)
        {
            var gl = glControl.OpenGL;
            gl.Color(Color.Black.R / 255.0, Color.Black.G / 255.0, Color.Black.B / 255.0);
            gl.Begin(OpenGL.GL_LINE_LOOP);
            point.ForEach(x => gl.Vertex(x.X, glControl.Height - x.Y));
            gl.End();
            gl.Flush();
            if(isDDK == true)
            {
                DrawControlPoint(glControl);
            }
        }
    }
}
