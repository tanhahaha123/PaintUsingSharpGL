using Lab1T1.Model;
using SharpGL;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Lab1T1.Helper
{
    public class Draw
    {
        public static Stack<Shape> listDraw = new Stack<Shape>();
        public static Shape TimHinhVe(OpenGLControl openGLControl, int chooseImg, Point start, Point end, Color userChoose, float thickness)
        {
            Shape imgToDraw = null;
            //Xem lựa chọn của user và chọn hinh vẽ
            if (start.X != -1000)
            {
                switch (chooseImg)
                {
                    case 0:
                        imgToDraw = new Line(start, end, thickness, userChoose);
                        break;
                    case 1:
                        imgToDraw = new Circle(start, end, thickness, userChoose);
                        break;
                    case 2:
                        imgToDraw = new Eclipse(start, end, thickness, userChoose);
                        break;
                    case 3:
                        imgToDraw = new Rectangel(start, end, thickness, userChoose);
                        break;
                    case 4:
                        imgToDraw = new EquilateralTriangle(start, end, thickness, userChoose);
                        break;
                    case 5:
                        imgToDraw = new EqualPentagon(start, end, thickness, userChoose);
                        break;
                    case 6:
                        imgToDraw = new EqualHexagon(start, end, thickness, userChoose);
                        break;
                    default:
                        imgToDraw = null;
                        break;
                }
            }
            if (imgToDraw != null)
            {
                if (listDraw.Count > 0)
                {
                    var tmpPop = listDraw.Pop();
                    if (tmpPop.upLeft != imgToDraw.upLeft)
                    {
                        listDraw.Push(tmpPop);
                    }
                }
                listDraw.Push(imgToDraw);
            }
            return imgToDraw;
        }

        public static void ThucHienVe(OpenGLControl openGLControl)
        {
            var gl = openGLControl.OpenGL;
            listDraw.ToList().ForEach(x => x.Draw(openGLControl));
            gl.Flush();
        }
    }
}
