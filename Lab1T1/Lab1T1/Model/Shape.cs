using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Lab1T1.Model
{
    public class Shape
    {
        public List<Point> listControlPoint = null;
        public Point upLeft;
        public Point downRight;
        public float thickness;
        public Color userChoose;
        public DateTime thoiGianVe;
        public bool veDdk = false;
        public double distance;
        public Point center;
        public int gocXoay = 0;

        public virtual void DrawControlPoint(OpenGLControl glControl, Color? color = null)
        {
            if (listControlPoint == null)
            {
                listControlPoint = new List<Point>();
            }
            else { listControlPoint.Clear(); }
            listControlPoint.Add(new Point(upLeft.X, upLeft.Y));
            listControlPoint.Add(new Point(downRight.X, downRight.Y));
            listControlPoint.Add(new Point(upLeft.X, downRight.Y));
            listControlPoint.Add(new Point(downRight.X, upLeft.Y));
            listControlPoint.Add(new Point(upLeft.X, (upLeft.Y + downRight.Y) / 2));
            listControlPoint.Add(new Point(downRight.X, (upLeft.Y + downRight.Y) / 2));
            listControlPoint.Add(new Point((upLeft.X + downRight.X) / 2, upLeft.Y));
            listControlPoint.Add(new Point((upLeft.X + downRight.X) / 2, downRight.Y));

            Color choose = color ?? Color.Red;
            var gl = glControl.OpenGL;
            gl.Color(choose.R / 255.0, choose.G / 255.0, choose.B / 255.0);
            gl.PointSize(5f);
            gl.Begin(OpenGL.GL_POINTS);
            listControlPoint.ForEach(x => gl.Vertex(x.X, glControl.Height - x.Y));
            gl.End();
            gl.Flush();
        }

        public void CountDistance(Point x)
        {
            Point center = new Point((upLeft.X + downRight.X) / 2, (upLeft.Y + downRight.Y) / 2);
            distance = Math.Pow(x.X - center.X, 2) + Math.Pow(x.Y - center.Y, 2);
        }
        public virtual void Draw(OpenGLControl glControl)
        {
            var gl = glControl.OpenGL;
            gl.Color(0, 0, 0, 0);
            gl.LineWidth(thickness);
            gl.Color(userChoose.R / 255.0, userChoose.G / 255.0, userChoose.B / 255.0);
        }

        public void DrawALineWithAngle(OpenGLControl glControl, int angle, Point goc, Point start, Point end)
        {
            var gl = glControl.OpenGL;
            gl.Translate(goc.X, glControl.Height - goc.Y, 0);
            gl.Rotate(angle, 0.0, 0.0, 1.0);
            gl.Translate(-goc.X, -(glControl.Height - goc.Y), 0);
            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(start.X, glControl.Height - start.Y);
            gl.Vertex(end.X, glControl.Height - end.Y);
            gl.End();
            gl.Flush();
        }

        public void DrawPointWithAngle(OpenGLControl glControl, int angle, Point goc, Point end)
        {
            var gl = glControl.OpenGL;
            gl.Translate(goc.X, glControl.Height - goc.Y, 0);
            gl.Rotate(angle, 0, 0, 1);
            gl.Translate(-goc.X, -(glControl.Height - goc.Y), 0);
            gl.Begin(OpenGL.GL_POINTS);
            gl.Vertex(end.X, glControl.Height - end.Y);
            gl.End();
        }
    }
}
