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
        static Polygon tmp;
        static int i = 1;

        public Form1()
        {
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
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.LoadIdentity();
            gl.Viewport(0, 0, openGLControl.Width, openGLControl.Height);
            gl.Ortho2D(0, openGLControl.Width, 0, openGLControl.Height);
        }


        private void openGLControl1_OpenGLDraw(object sender, SharpGL.RenderEventArgs args)
        {
            var oldCheck = Draw.listDraw.Count;
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
                var newItem = Draw.TimHinhVe(openGLControl, chooseImg, start, end, userChoose, thickness);
                if (oldCheck != Draw.listDraw.Count)
                {
                    oldCheck = Draw.listDraw.Count;
                    timeTable.RowCount = timeTable.RowCount + 1;
                    timeTable.RowStyles.Add(new RowStyle());
                    timeTable.Controls.Add(new Label() { Text = "Street" + i }, 0, timeTable.RowCount);
                    timeTable.Controls.Add(new Label() { Text = "888888" }, 1, timeTable.RowCount);
                    i++;
                }
            }
            else if(mode == 3)
            {
                if(mouseLeft == true)
                {
                    tmp.Draw(openGLControl);
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
                isDown = false;
                end = e.Location;
            }
            if(mode == 3)
            {
                if(e.Button == MouseButtons.Left)
                {
                    tmp.Add(e.Location);
                    mouseLeft = true;
                }
                else
                {
                    lPolygon.Add(tmp);
                    tmp = new Polygon();
                    mouseLeft = false;
                }
            }
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

        private void equalHexagon_CheckedChanged(object sender, EventArgs e)
        {
            chooseImg = 6;
        }

        private void modeTo3_Click(object sender, EventArgs e)
        {
            mode = 3;
            tmp = new Polygon();
        }
    }
}
