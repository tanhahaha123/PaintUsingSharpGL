using SharpGL;
using System.Collections.Generic;
using System.Drawing;

namespace Lab1T1.Model
{
    class Polygon
    {
        List<Point> point = null;
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
        }
    }
}
