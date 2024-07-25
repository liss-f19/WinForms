namespace Paint
{
    partial class FormNewImage
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
            components = new System.ComponentModel.Container();
            numericUpDown1 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            chooseColorbutton = new Button();
            textBox1 = new TextBox();
            buttonNew = new Button();
            buttonCancel = new Button();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            colorDialog1 = new ColorDialog();
            imageList1 = new ImageList(components);
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(161, 30);
            numericUpDown1.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(150, 27);
            numericUpDown1.TabIndex = 0;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(161, 63);
            numericUpDown2.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDown2.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(150, 27);
            numericUpDown2.TabIndex = 1;
            numericUpDown2.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // chooseColorbutton
            // 
            chooseColorbutton.Location = new Point(161, 96);
            chooseColorbutton.Name = "chooseColorbutton";
            chooseColorbutton.Size = new Size(94, 29);
            chooseColorbutton.TabIndex = 2;
            chooseColorbutton.UseCompatibleTextRendering = true;
            chooseColorbutton.UseVisualStyleBackColor = true;
            chooseColorbutton.Click += chooseColorbutton_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(30, 96);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 3;
            textBox1.Text = "Background:";
            // 
            // buttonNew
            // 
            buttonNew.Location = new Point(30, 173);
            buttonNew.Name = "buttonNew";
            buttonNew.Size = new Size(94, 29);
            buttonNew.TabIndex = 4;
            buttonNew.Text = "New";
            buttonNew.UseVisualStyleBackColor = true;
            buttonNew.Click += buttonNew_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(146, 173);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(94, 29);
            buttonCancel.TabIndex = 5;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(30, 63);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 6;
            textBox2.Text = "Height:";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(30, 29);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 7;
            textBox3.Text = "Width:";
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // FormNewImage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(332, 318);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(buttonCancel);
            Controls.Add(buttonNew);
            Controls.Add(textBox1);
            Controls.Add(chooseColorbutton);
            Controls.Add(numericUpDown2);
            Controls.Add(numericUpDown1);
            Name = "FormNewImage";
            Text = "New Image";
            Load += FormNewImage_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private Button chooseColorbutton;
        private TextBox textBox1;
        private Button buttonNew;
        private Button buttonCancel;
        private TextBox textBox2;
        private TextBox textBox3;
        private ColorDialog colorDialog1;
        private ImageList imageList1;
    }
}