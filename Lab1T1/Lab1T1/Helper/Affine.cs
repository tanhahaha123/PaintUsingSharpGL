using Lab1T1.Model;
using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1T1.Helper
{
    public class Affine
    {
        public static void TinhTien(Shape a, Point x)
        {
            a.upLeft.X += x.X;
            a.upLeft.Y += x.Y;
            a.downRight.X += x.X;
            a.downRight.Y += x.Y;
            a.center.X = a.upLeft.X + a.downRight.X;
            a.center.Y = a.upLeft.Y + a.downRight.Y;
            a.center.X /= 2;
            a.center.Y /= 2;
        }

        public static void TinhTien(Polygon a, Point x)
        {
            a.point = a.point.Select(k =>new Point(k.X + x.X, k.Y + x.Y)).ToList();
        }

        public static void Rotate(Point center, int angle, OpenGL gl)
        {
            gl.Translate(center.X, center.Y, 0);
            gl.Rotate(angle, 0, 0, 1);
            gl.Translate(-center.X, -center.Y, 0);
        }
    }
}
