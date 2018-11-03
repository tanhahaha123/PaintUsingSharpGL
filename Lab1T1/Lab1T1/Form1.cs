using Lab1T1.Model;
using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Lab1T1
{
    public partial class Form1 : Form
    {
        static Color userChoose = Color.Black;
        static float thickness = 1.0f;
        static Point start = new Point(-1000, -1000), end;
        static bool isDown = false;
        static Stack<Shape> listDraw = new Stack<Shape>();
        //chooseImg = 0 -> Line
        //          = 1 -> Circle
        //          = 2 -> Eclipse
        //          = 3 -> Recangle
        //          = 4 -> EquilateralTriangle
        //          = 5 -> Ngũ giác đều
        //          = 6 -> Lục giác đều
        static int chooseImg = -1;

        static Shape imgToDraw;

        public Form1()
        {
            listDraw.Clear();
            InitializeComponent();
        }


        private void openGLControl1_OpenGLInitialized(object sender, EventArgs e)
        {
            OpenGL gl = openGLControl.OpenGL;
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.ClearColor(255, 255, 255, 0);
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.LoadIdentity();
        }


        private void openGLControl1_Resized(object sender, EventArgs e)
        {
            OpenGL gl = openGLControl.OpenGL;
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.LoadIdentity();
            gl.Viewport(0, 0, openGLControl.Width, openGLControl.Height);
            gl.Ortho2D(0, openGLControl.Width, 0, openGLControl.Height);
        }


        private void openGLControl1_OpenGLDraw(object sender, SharpGL.RenderEventArgs args)
        {
            OpenGL gl = openGLControl.OpenGL;
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            //Bắt đầu vẽ
            //Lấy màu
            gl.Color(userChoose.R / 255.0, userChoose.G / 255.0, userChoose.B / 255.0, userChoose.A / 255.0);
            //Lấy độ đậm
            if (!float.TryParse(textBoxThickness.Text, out thickness))
            {
                thickness = 1.0f;
            }

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
                        break;
                    case 6:
                        break;
                    default:
                        imgToDraw = null;
                        break;
                }
            }

            while (listDraw.Count != 0)
            {
                var tmpCheck = listDraw.Pop();
                if (tmpCheck.upLeft.X != start.X || tmpCheck.upLeft.Y != start.Y)
                {
                    listDraw.Push(tmpCheck);
                    break;
                }
            }
            if (imgToDraw != null)
            {
                listDraw.Push(imgToDraw);
            }

            foreach (var x in listDraw)
            {
                x.Draw(openGLControl);
            }
            gl.Flush();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                userChoose = colorDialog1.Color;
            }
        }


        private void openGLControl_MouseUp(object sender, MouseEventArgs e)
        {
            isDown = false;
            end = e.Location;
        }

        private void Line_CheckedChanged(object sender, EventArgs e)
        {
            chooseImg = 0;
        }

        private void circle_CheckedChanged(object sender, EventArgs e)
        {
            chooseImg = 1;
        }

        private void eclipse_CheckedChanged(object sender, EventArgs e)
        {
            chooseImg = 2;
        }

        private void rectangle_CheckedChanged(object sender, EventArgs e)
        {
            chooseImg = 3;
        }

        private void equlateral_CheckedChanged(object sender, EventArgs e)
        {
            chooseImg = 4;
        }

        private void openGLControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDown == true)
            {
                end = e.Location;
            }
        }

        private void openGLControl_MouseDown(object sender, MouseEventArgs e)
        {
            start = e.Location;
            end = start;
            isDown = true;
        }
    }
}
