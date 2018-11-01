using Lab1T1.Model;
using SharpGL;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab1T1
{
    public partial class Form1 : Form
    {
        static Color userChoose = Color.Black;
        static float thickness = 1.0f;
        static Point start = new Point(-1, -1), end, tmpStart = start;
        static bool isDown = false;
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Hàm khởi tạo của OpenGL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openGLControl1_OpenGLInitialized(object sender, EventArgs e)
        {
            OpenGL gl = openGLControl.OpenGL;
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.ClearColor(255, 255, 255, 0);
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.LoadIdentity();
        }

        /// <summary>
        /// Hàm xử lý khi resize vùng vẽ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openGLControl1_Resized(object sender, EventArgs e)
        {
            OpenGL gl = openGLControl.OpenGL;
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.LoadIdentity();
            gl.Viewport(0, 0, openGLControl.Width, openGLControl.Height);
            gl.Ortho2D(0, openGLControl.Width, 0, openGLControl.Height);
        }

        /// <summary>
        /// Hàm vẽ trên OpenGL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void openGLControl1_OpenGLDraw(object sender, SharpGL.RenderEventArgs args)
        {
            OpenGL gl = openGLControl.OpenGL;
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            //Bắt đầu vẽ
            //Lấy màu
            gl.Color(userChoose.R / 255.0, userChoose.G / 255.0, userChoose.B / 255.0, userChoose.A / 255.0);
            //Lấy độ đậm
            if (float.TryParse(textBoxThickness.Text, out thickness))
            {
                gl.LineWidth(thickness);
            }
            else gl.LineWidth(1.0f);

            Circle a = new Circle(start, end);
            a.Draw(openGLControl);

            gl.End();
            gl.Flush();
        }

        /// <summary>
        /// Click vào button chọn màu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                userChoose = colorDialog1.Color;
            }
        }

        /// <summary>
        /// Xử lý khi thả chuột ra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openGLControl_MouseUp(object sender, MouseEventArgs e)
        {
            isDown = false;
            end = e.Location;
            tmpStart = start;
        }

        /// <summary>
        /// Xử lý khi vừa nhấn chuột vừa di chuyển chuột
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openGLControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDown == true)
            {
                end = e.Location;
            }
        }

        /// <summary>
        /// Hàm xử lý khi click chuột
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openGLControl_MouseDown(object sender, MouseEventArgs e)
        {
            start = e.Location;
            end = start;
            isDown = true;
        }
    }
}
