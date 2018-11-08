using Lab1T1.Helper;
using Lab1T1.Model;
using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Lab1T1
{
    public partial class Form1 : Form
    {
        static Color userChoose = Color.Black;
        static double epsilon = 100.123456789;
        static float thickness = 1.0f;
        static Point start = new Point(-1000, -1000), end;
        static List<Polygon> lPolygon = new List<Polygon>();
        static bool isDown = false, mouseLeft = false;
        //chooseImg = 0 -> Line
        //          = 1 -> Circle
        //          = 2 -> Eclipse
        //          = 3 -> Recangle
        //          = 4 -> EquilateralTriangle
        //          = 5 -> Ngũ giác đều
        //          = 6 -> Lục giác đều
        static int chooseImg = -1;
        //mode = 1 là trạng thái vẽ, mode = 2 là trạng thái tô màu.
        //mode = 3 là vẽ đa giác, mode = 4 là thao tác trên điểm điều khiển của hình
        static int mode = 1;
        static Polygon newPolygonItem;
        static Shape newShapeItem;
        static List<Label> name = new List<Label>();
        static List<Label> thoigian = new List<Label>();

        public Form1()
        {
            InitializeComponent();
            name.Add(hinhve0);
            name.Add(hinhve1);
            name.Add(hinhve2);
            name.Add(hinhve3);
            name.Add(hinhve4);
            name.Add(hinhve5);
            thoigian.Add(thoigianve0);
            thoigian.Add(thoigianve1);
            thoigian.Add(thoigianve2);
            thoigian.Add(thoigianve3);
            thoigian.Add(thoigianve4);
            thoigian.Add(thoigianve5);
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
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
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
            if (mode == 1)
            {
                //Lấy độ đậm
                if (!float.TryParse(textBoxThickness.Text, out thickness))
                {
                    thickness = 1.0f;
                }
                //Xem lựa chọn của user và chọn hinh vẽ và vẽ
                newShapeItem = Draw.TimHinhVe(openGLControl, chooseImg, start, end, userChoose, thickness);
            }
            else if (mode == 3)
            {
                if (mouseLeft == true)
                {
                    newPolygonItem.Draw(openGLControl);
                }
            }
            lPolygon.ForEach(x => x.Draw(openGLControl));
            Draw.ThucHienVe(openGLControl);
        }

        //Color dialog để chọn màu
        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                userChoose = colorDialog1.Color;
            }
        }

        private void openGLControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (mode == 1)
            {
                start = e.Location;
                end = start;
                isDown = true;
            }
        }

        private void openGLControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (mode == 1)
            {
                //Khi nhả chuột ở chế độ vẽ hình bình thường
                isDown = false;
                end = e.Location;
                if (newShapeItem != null)
                {
                    WriteLog.AddLog(new Log { name = newShapeItem.GetType().ToString().Split('.')[2], dayDraw = DateTime.Now });
                }
            }
            else if (mode == 3)
            {
                //Khi nhả chuột ở chế độ vẽ Polygon
                if (e.Button == MouseButtons.Left)
                {
                    newPolygonItem.Add(e.Location);
                    mouseLeft = true;
                }
                else
                {
                    lPolygon.Add(newPolygonItem);
                    WriteLog.AddLog(new Log { name = "Polygon", dayDraw = DateTime.Now });
                    newPolygonItem = new Polygon();
                    mouseLeft = false;
                }
            }
            else if (mode == 4)
            {
                //Khi nhả  chuột ở chế độ chọn hình
                //Tính khoảng cách tới tất cả các hình, tìm nhỏ nhất, so với epsilon, nếu nhỏ hơn thì hiện hình đó
                ControlPoint.GetMin(lPolygon, Draw.listDraw, e.Location);
                ControlPoint.AllowToDraw(100.123456789);
            }
            WriteLog.Render(name, thoigian);
        }

        private void openGLControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDown == true && mode == 1)
            {
                end = e.Location;
            }
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

        private void equalPetagon_CheckedChanged(object sender, EventArgs e)
        {
            chooseImg = 5;
        }

        private void modeTo1_Click(object sender, EventArgs e)
        {
            mode = 1;
        }

        private void chonHinhBtn_Click(object sender, EventArgs e)
        {
            mode = 4;
        }

        private void equalHexagon_CheckedChanged(object sender, EventArgs e)
        {
            chooseImg = 6;
        }

        private void modeTo3_Click(object sender, EventArgs e)
        {
            mode = 3;
            newPolygonItem = new Polygon();
        }
    }
}
