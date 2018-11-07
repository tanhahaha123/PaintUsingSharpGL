using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1T1.Model
{
    public class Rectangel : Shape
    {
        public Rectangel(Point upLeft, Point downRight, float thickness, Color userChoose)
        {
            this.upLeft = upLeft;
            this.downRight = downRight;
            this.thickness = thickness;
            this.userChoose = userChoose;
        }

        public override void Draw(OpenGLControl glControl)
        {
            base.Draw(glControl);
            timeCreate = DateTime.Now;
            var gl = glControl.OpenGL;
            gl.Begin(OpenGL.GL_LINE_LOOP);
            gl.Vertex(upLeft.X, glControl.Height - upLeft.Y);
            gl.Vertex(upLeft.X, glControl.Height - downRight.Y);
            gl.Vertex(downRight.X, glControl.Height - downRight.Y);
            gl.Vertex(downRight.X, glControl.Height - upLeft.Y);
            gl.End();
            if(veDdk == true)
            {
                DrawControlPoint(glControl);
            }
        }
    }

}
