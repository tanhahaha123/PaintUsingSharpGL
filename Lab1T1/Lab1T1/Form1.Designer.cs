namespace Lab1T1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openGLControl = new SharpGL.OpenGLControl();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxThickness = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Line = new System.Windows.Forms.RadioButton();
            this.circle = new System.Windows.Forms.RadioButton();
            this.eclipse = new System.Windows.Forms.RadioButton();
            this.rectangle = new System.Windows.Forms.RadioButton();
            this.equalHexagon = new System.Windows.Forms.RadioButton();
            this.equalPetagon = new System.Windows.Forms.RadioButton();
            this.equilateralTriangle = new System.Windows.Forms.RadioButton();
            this.chonHinhBtn = new System.Windows.Forms.Button();
            this.modeTo3 = new System.Windows.Forms.Button();
            this.modeTo1 = new System.Windows.Forms.Button();
            this.timeTable = new System.Windows.Forms.TableLayoutPanel();
            this.abc = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).BeginInit();
            this.SuspendLayout();
            // 
            // openGLControl
            // 
            this.openGLControl.DrawFPS = false;
            this.openGLControl.Location = new System.Drawing.Point(12, 96);
            this.openGLControl.Name = "openGLControl";
            this.openGLControl.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLControl.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.openGLControl.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.openGLControl.Size = new System.Drawing.Size(689, 314);
            this.openGLControl.TabIndex = 0;
            this.openGLControl.OpenGLInitialized += new System.EventHandler(this.openGLControl1_OpenGLInitialized);
            this.openGLControl.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControl1_OpenGLDraw);
            this.openGLControl.Resized += new System.EventHandler(this.openGLControl1_Resized);
            this.openGLControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseDown);
            this.openGLControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseMove);
            this.openGLControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseUp);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(56, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 26);
            this.button1.TabIndex = 1;
            this.button1.Text = "Chọn màu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxThickness
            // 
            this.textBoxThickness.Location = new System.Drawing.Point(398, 61);
            this.textBoxThickness.Name = "textBoxThickness";
            this.textBoxThickness.Size = new System.Drawing.Size(110, 20);
            this.textBoxThickness.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(296, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nhập Font-size";
            // 
            // Line
            // 
            this.Line.AutoSize = true;
            this.Line.Location = new System.Drawing.Point(373, 12);
            this.Line.Name = "Line";
            this.Line.Size = new System.Drawing.Size(50, 18);
            this.Line.TabIndex = 4;
            this.Line.Text = "Line";
            this.Line.UseVisualStyleBackColor = true;
            this.Line.CheckedChanged += new System.EventHandler(this.Line_CheckedChanged);
            // 
            // circle
            // 
            this.circle.AutoSize = true;
            this.circle.Location = new System.Drawing.Point(373, 36);
            this.circle.Name = "circle";
            this.circle.Size = new System.Drawing.Size(59, 18);
            this.circle.TabIndex = 5;
            this.circle.Text = "Circle";
            this.circle.UseVisualStyleBackColor = true;
            this.circle.CheckedChanged += new System.EventHandler(this.circle_CheckedChanged);
            // 
            // eclipse
            // 
            this.eclipse.AutoSize = true;
            this.eclipse.Location = new System.Drawing.Point(442, 12);
            this.eclipse.Name = "eclipse";
            this.eclipse.Size = new System.Drawing.Size(66, 18);
            this.eclipse.TabIndex = 6;
            this.eclipse.Text = "Eclipse";
            this.eclipse.UseVisualStyleBackColor = true;
            this.eclipse.CheckedChanged += new System.EventHandler(this.eclipse_CheckedChanged);
            // 
            // rectangle
            // 
            this.rectangle.AutoSize = true;
            this.rectangle.Location = new System.Drawing.Point(442, 37);
            this.rectangle.Name = "rectangle";
            this.rectangle.Size = new System.Drawing.Size(83, 18);
            this.rectangle.TabIndex = 7;
            this.rectangle.Text = "Rectangle";
            this.rectangle.UseVisualStyleBackColor = true;
            this.rectangle.CheckedChanged += new System.EventHandler(this.rectangle_CheckedChanged);
            // 
            // equalHexagon
            // 
            this.equalHexagon.AutoSize = true;
            this.equalHexagon.Location = new System.Drawing.Point(531, 60);
            this.equalHexagon.Name = "equalHexagon";
            this.equalHexagon.Size = new System.Drawing.Size(140, 18);
            this.equalHexagon.TabIndex = 8;
            this.equalHexagon.Text = "Equilateral Hexagon";
            this.equalHexagon.UseVisualStyleBackColor = true;
            this.equalHexagon.CheckedChanged += new System.EventHandler(this.equalHexagon_CheckedChanged);
            // 
            // equalPetagon
            // 
            this.equalPetagon.AutoSize = true;
            this.equalPetagon.Location = new System.Drawing.Point(531, 36);
            this.equalPetagon.Name = "equalPetagon";
            this.equalPetagon.Size = new System.Drawing.Size(146, 18);
            this.equalPetagon.TabIndex = 9;
            this.equalPetagon.Text = "Equilateral Pentagon";
            this.equalPetagon.UseVisualStyleBackColor = true;
            this.equalPetagon.CheckedChanged += new System.EventHandler(this.equalPetagon_CheckedChanged);
            // 
            // equilateralTriangle
            // 
            this.equilateralTriangle.AutoSize = true;
            this.equilateralTriangle.Location = new System.Drawing.Point(531, 12);
            this.equilateralTriangle.Name = "equilateralTriangle";
            this.equilateralTriangle.Size = new System.Drawing.Size(137, 18);
            this.equilateralTriangle.TabIndex = 10;
            this.equilateralTriangle.Text = "Equilateral Triangle";
            this.equilateralTriangle.UseVisualStyleBackColor = true;
            this.equilateralTriangle.CheckedChanged += new System.EventHandler(this.equlateral_CheckedChanged);
            // 
            // chonHinhBtn
            // 
            this.chonHinhBtn.Location = new System.Drawing.Point(56, 56);
            this.chonHinhBtn.Name = "chonHinhBtn";
            this.chonHinhBtn.Size = new System.Drawing.Size(104, 25);
            this.chonHinhBtn.TabIndex = 11;
            this.chonHinhBtn.Text = "Chọn Hình";
            this.chonHinhBtn.UseVisualStyleBackColor = true;
            // 
            // modeTo3
            // 
            this.modeTo3.Location = new System.Drawing.Point(56, 31);
            this.modeTo3.Name = "modeTo3";
            this.modeTo3.Size = new System.Drawing.Size(104, 23);
            this.modeTo3.TabIndex = 12;
            this.modeTo3.Text = "DrawPoligon";
            this.modeTo3.UseVisualStyleBackColor = true;
            this.modeTo3.Click += new System.EventHandler(this.modeTo3_Click);
            // 
            // modeTo1
            // 
            this.modeTo1.Location = new System.Drawing.Point(198, 17);
            this.modeTo1.Name = "modeTo1";
            this.modeTo1.Size = new System.Drawing.Size(75, 23);
            this.modeTo1.TabIndex = 13;
            this.modeTo1.Text = "Vẽ Hình";
            this.modeTo1.UseVisualStyleBackColor = true;
            this.modeTo1.Click += new System.EventHandler(this.modeTo1_Click);
            // 
            // timeTable
            // 
            this.timeTable.AutoScroll = true;
            this.timeTable.ColumnCount = 2;
            this.timeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.5F));
            this.timeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.5F));
            this.timeTable.Location = new System.Drawing.Point(707, 96);
            this.timeTable.Name = "timeTable";
            this.timeTable.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.timeTable.RowCount = 2;
            this.timeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.timeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.timeTable.Size = new System.Drawing.Size(200, 314);
            this.timeTable.TabIndex = 14;
            // 
            // abc
            // 
            this.abc.AutoSize = true;
            this.abc.Location = new System.Drawing.Point(731, 79);
            this.abc.Name = "abc";
            this.abc.Size = new System.Drawing.Size(34, 14);
            this.abc.TabIndex = 0;
            this.abc.Text = "Hình";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(804, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Thời gian vẽ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.abc);
            this.Controls.Add(this.timeTable);
            this.Controls.Add(this.modeTo1);
            this.Controls.Add(this.modeTo3);
            this.Controls.Add(this.chonHinhBtn);
            this.Controls.Add(this.equilateralTriangle);
            this.Controls.Add(this.equalPetagon);
            this.Controls.Add(this.equalHexagon);
            this.Controls.Add(this.rectangle);
            this.Controls.Add(this.eclipse);
            this.Controls.Add(this.circle);
            this.Controls.Add(this.Line);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxThickness);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.openGLControl);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SharpGL.OpenGLControl openGLControl;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxThickness;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton Line;
        private System.Windows.Forms.RadioButton circle;
        private System.Windows.Forms.RadioButton eclipse;
        private System.Windows.Forms.RadioButton rectangle;
        private System.Windows.Forms.RadioButton equalHexagon;
        private System.Windows.Forms.RadioButton equalPetagon;
        private System.Windows.Forms.RadioButton equilateralTriangle;
        private System.Windows.Forms.Button chonHinhBtn;
        private System.Windows.Forms.Button modeTo3;
        private System.Windows.Forms.Button modeTo1;
        private System.Windows.Forms.TableLayoutPanel timeTable;
        private System.Windows.Forms.Label abc;
        private System.Windows.Forms.Label label2;
    }
}

