using Lab1T1.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1T1.Helper
{
    public class ControlPoint
    {
        // minShape và minPolygon để tracking coi có shape nào hoặc polygon nào đang cho hiện điểm điều khiển và thao tác trên hình đó
        public static Shape minShape;
        public static Polygon minPolygon;

        public static void GetMin(List<Polygon> a, Stack<Shape> b, Point mouse)
        {
            minShape = null;
            minPolygon = null;
            b.ToList().ForEach(x => x.CountDistance(mouse));
            a.ForEach(x => x.CountDistance(mouse));
            if (b.Count != 0)
            {
                minShape = b.Peek();
            }
            if (a.Count != 0)
            {
                minPolygon = a[0];
            }
            //Tìm min distance của Polygon
            for (int i = 0; i < a.Count; i++)
            {
                a[i].isDDK = false;
                if (minPolygon.distance > a[i].distance)
                {
                    minPolygon = a[i];
                }
            }
            // Tìm min distance của Shape
            foreach (var k in b)
            {
                k.veDdk = false;
                if (minShape.distance > k.distance)
                {
                    minShape = k;
                }
            }
            if(minShape != null && minPolygon != null)
            {
                if(minShape.distance > minPolygon.distance)
                {
                    minShape = null;
                }
                else
                {
                    minPolygon = null;
                }
            }
        }

        public static void AllowToDraw(double epsilon)
        {
            if(minPolygon != null && minPolygon.distance < epsilon*epsilon)
            {
                minPolygon.isDDK = true;
            }
            else { minPolygon = null; }
            if(minShape != null && minShape.distance < epsilon * epsilon)
            {
                minShape.veDdk = true;
            }
            else { minShape = null; }
        }
    }
}
