using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Lab1T1.Model
{
    public class Polygon
    {
        public DateTime thoiGianVe;
        public List<Point> point = null;
        public bool isDDK = false;
        public double distance;
        public Point center;

        private void DrawControlPoint(OpenGLControl glControl, Color? color = null)
        {
            var choose = color ?? Color.Red;
            var gl = glControl.OpenGL;
            gl.PointSize(5f);
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
            if(point.Count == 0)
            {
                thoiGianVe = DateTime.Now;
            }
            point.Add(a);
        }

        public void CountDistance(Point mouse)
        {
            //Thay vì loop trong này để ở ngoài được hông? Cải tiến?
            center = new Point(0, 0);
            point.ForEach(x => { center.X += x.X; center.Y += x.Y; });
            center.X /= point.Count;
            center.Y /= point.Count;

            distance = Math.Pow(mouse.X - center.X, 2) + Math.Pow(mouse.Y - center.Y, 2);
        }

        public void Draw(OpenGLControl glControl)
        {
            var gl = glControl.OpenGL;
            gl.Color(Color.Black.R / 255.0, Color.Black.G / 255.0, Color.Black.B / 255.0);
            gl.Begin(OpenGL.GL_LINE_LOOP);
            point.ForEach(x => gl.Vertex(x.X, glControl.Height - x.Y));
            gl.End();
            gl.Flush();
            if (isDDK == true)
            {
                DrawControlPoint(glControl);
            }
        }
    }
}
