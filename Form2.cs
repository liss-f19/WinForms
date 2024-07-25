using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class FormNewImage : Form
    {
        public int ImageWidth => (int)numericUpDown1.Value;
        public int ImageHeight => (int)numericUpDown2.Value;
        public Color BackgroundColor { get; set; } = Color.White;

        public FormNewImage()
        {
            InitializeComponent();
        }

        private void FormNewImage_Load(object sender, EventArgs e)
        {

        }

        private void chooseColorbutton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                BackgroundColor = colorDialog1.Color;
                chooseColorbutton.BackColor = BackgroundColor;
            }
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();


        }
    }
}
