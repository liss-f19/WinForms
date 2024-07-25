namespace Paint
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            fileMenuItem = new ToolStripMenuItem();
            newMenuItem = new ToolStripMenuItem();
            openMenuItem = new ToolStripMenuItem();
            saveMenuItem = new ToolStripMenuItem();
            saveAsMenuItem = new ToolStripMenuItem();
            printMenuItem = new ToolStripMenuItem();
            exitMenuItem = new ToolStripMenuItem();
            editMenuItem = new ToolStripMenuItem();
            cutMenuItem = new ToolStripMenuItem();
            copyMenuItem = new ToolStripMenuItem();
            pasteMenuItem = new ToolStripMenuItem();
            selectAllMenuItem = new ToolStripMenuItem();
            viewMenuItem = new ToolStripMenuItem();
            zoomToolStripMenuItem = new ToolStripMenuItem();
            zoomInToolStripMenuItem = new ToolStripMenuItem();
            zoomOutToolStripMenuItem = new ToolStripMenuItem();
            resetZoomToolStripMenuItem = new ToolStripMenuItem();
            imageMenuItem = new ToolStripMenuItem();
            colorsMenuItem = new ToolStripMenuItem();
            editColorsMenuItem = new ToolStripMenuItem();
            invertMenuItem = new ToolStripMenuItem();
            helpMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            positionStatusbar = new ToolStripStatusLabel();
            selectStatusbar = new ToolStripStatusLabel();
            sizeStatusbar = new ToolStripStatusLabel();
            zoomStatusbar = new ToolStripStatusLabel();
            pictureBox1 = new PictureBox();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            colorDialogMain = new ColorDialog();
            panel1 = new Panel();
            selectionStatusBar = new ToolStripStatusLabel();
            penButton = new Button();
            selectButton = new Button();
            lineButton = new Button();
            colorPanel = new TableLayoutPanel();
            pickedColorPictureBox = new PictureBox();
            pickedColorImageLeft = new PictureBox();
            pickedColorImageRight = new PictureBox();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pickedColorPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pickedColorImageLeft).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pickedColorImageRight).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileMenuItem, editMenuItem, viewMenuItem, imageMenuItem, colorsMenuItem, helpMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1182, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileMenuItem
            // 
            fileMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newMenuItem, openMenuItem, saveMenuItem, saveAsMenuItem, printMenuItem, exitMenuItem });
            fileMenuItem.Name = "fileMenuItem";
            fileMenuItem.Size = new Size(46, 24);
            fileMenuItem.Text = "File";
            // 
            // newMenuItem
            // 
            newMenuItem.Name = "newMenuItem";
            newMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            newMenuItem.Size = new Size(239, 26);
            newMenuItem.Text = "New...";
            newMenuItem.Click += newToolStripMenuItem_Click;
            // 
            // openMenuItem
            // 
            openMenuItem.Name = "openMenuItem";
            openMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            openMenuItem.Size = new Size(239, 26);
            openMenuItem.Text = "Open...";
            openMenuItem.Click += openMenuItem_Click;
            // 
            // saveMenuItem
            // 
            saveMenuItem.Name = "saveMenuItem";
            saveMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveMenuItem.Size = new Size(239, 26);
            saveMenuItem.Text = "Save";
            saveMenuItem.Click += saveMenuItem_Click;
            // 
            // saveAsMenuItem
            // 
            saveAsMenuItem.Name = "saveAsMenuItem";
            saveAsMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
            saveAsMenuItem.Size = new Size(239, 26);
            saveAsMenuItem.Text = "Save As..";
            saveAsMenuItem.Click += saveAsMenuItem_Click;
            // 
            // printMenuItem
            // 
            printMenuItem.Name = "printMenuItem";
            printMenuItem.ShortcutKeys = Keys.Control | Keys.P;
            printMenuItem.Size = new Size(239, 26);
            printMenuItem.Text = "Print...";
            // 
            // exitMenuItem
            // 
            exitMenuItem.Name = "exitMenuItem";
            exitMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            exitMenuItem.Size = new Size(239, 26);
            exitMenuItem.Text = "Exit";
            // 
            // editMenuItem
            // 
            editMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cutMenuItem, copyMenuItem, pasteMenuItem, selectAllMenuItem });
            editMenuItem.Name = "editMenuItem";
            editMenuItem.Size = new Size(49, 24);
            editMenuItem.Text = "Edit";
            // 
            // cutMenuItem
            // 
            cutMenuItem.Name = "cutMenuItem";
            cutMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            cutMenuItem.Size = new Size(206, 26);
            cutMenuItem.Text = "Cut";
            // 
            // copyMenuItem
            // 
            copyMenuItem.Name = "copyMenuItem";
            copyMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            copyMenuItem.Size = new Size(206, 26);
            copyMenuItem.Text = "Copy";
            // 
            // pasteMenuItem
            // 
            pasteMenuItem.Name = "pasteMenuItem";
            pasteMenuItem.ShortcutKeys = Keys.Control | Keys.V;
            pasteMenuItem.Size = new Size(206, 26);
            pasteMenuItem.Text = "Paste";
            // 
            // selectAllMenuItem
            // 
            selectAllMenuItem.Name = "selectAllMenuItem";
            selectAllMenuItem.ShortcutKeys = Keys.Control | Keys.A;
            selectAllMenuItem.Size = new Size(206, 26);
            selectAllMenuItem.Text = "Select All";
            selectAllMenuItem.Click += selectAllMenuItem_Click;
            // 
            // viewMenuItem
            // 
            viewMenuItem.DropDownItems.AddRange(new ToolStripItem[] { zoomToolStripMenuItem });
            viewMenuItem.Name = "viewMenuItem";
            viewMenuItem.Size = new Size(55, 24);
            viewMenuItem.Text = "View";
            // 
            // zoomToolStripMenuItem
            // 
            zoomToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { zoomInToolStripMenuItem, zoomOutToolStripMenuItem, resetZoomToolStripMenuItem });
            zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
            zoomToolStripMenuItem.Size = new Size(132, 26);
            zoomToolStripMenuItem.Text = "Zoom";
            // 
            // zoomInToolStripMenuItem
            // 
            zoomInToolStripMenuItem.Name = "zoomInToolStripMenuItem";
            zoomInToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Oemplus;
            zoomInToolStripMenuItem.Size = new Size(273, 26);
            zoomInToolStripMenuItem.Text = "Zoom In";
            zoomInToolStripMenuItem.Click += zoomInToolStripMenuItem_Click;
            // 
            // zoomOutToolStripMenuItem
            // 
            zoomOutToolStripMenuItem.Name = "zoomOutToolStripMenuItem";
            zoomOutToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.OemMinus;
            zoomOutToolStripMenuItem.Size = new Size(273, 26);
            zoomOutToolStripMenuItem.Text = "Zoom Out";
            zoomOutToolStripMenuItem.Click += zoomOutToolStripMenuItem_Click;
            // 
            // resetZoomToolStripMenuItem
            // 
            resetZoomToolStripMenuItem.Name = "resetZoomToolStripMenuItem";
            resetZoomToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D0;
            resetZoomToolStripMenuItem.Size = new Size(273, 26);
            resetZoomToolStripMenuItem.Text = "Reset Zoom";
            resetZoomToolStripMenuItem.Click += resetZoomToolStripMenuItem_Click;
            // 
            // imageMenuItem
            // 
            imageMenuItem.Name = "imageMenuItem";
            imageMenuItem.Size = new Size(65, 24);
            imageMenuItem.Text = "Image";
            // 
            // colorsMenuItem
            // 
            colorsMenuItem.DropDownItems.AddRange(new ToolStripItem[] { editColorsMenuItem, invertMenuItem });
            colorsMenuItem.Name = "colorsMenuItem";
            colorsMenuItem.Size = new Size(65, 24);
            colorsMenuItem.Text = "Colors";
            // 
            // editColorsMenuItem
            // 
            editColorsMenuItem.Name = "editColorsMenuItem";
            editColorsMenuItem.Size = new Size(221, 26);
            editColorsMenuItem.Text = "Edit Colors...";
            editColorsMenuItem.Click += editColorsMenuItem_Click;
            // 
            // invertMenuItem
            // 
            invertMenuItem.Name = "invertMenuItem";
            invertMenuItem.ShortcutKeys = Keys.Control | Keys.I;
            invertMenuItem.Size = new Size(221, 26);
            invertMenuItem.Text = "Invert Colors";
            invertMenuItem.Click += invertMenuItem_Click;
            // 
            // helpMenuItem
            // 
            helpMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            helpMenuItem.Name = "helpMenuItem";
            helpMenuItem.Size = new Size(55, 24);
            helpMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.ShortcutKeys = Keys.F12;
            aboutToolStripMenuItem.Size = new Size(177, 26);
            aboutToolStripMenuItem.Text = "About....";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { positionStatusbar, selectStatusbar, sizeStatusbar, zoomStatusbar });
            statusStrip1.Location = new Point(0, 787);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1182, 30);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // positionStatusbar
            // 
            positionStatusbar.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            positionStatusbar.ImageAlign = ContentAlignment.MiddleLeft;
            positionStatusbar.Name = "positionStatusbar";
            positionStatusbar.Size = new Size(514, 24);
            positionStatusbar.Spring = true;
            positionStatusbar.Text = "positionStatusbar";
            positionStatusbar.TextAlign = ContentAlignment.BottomLeft;
            // 
            // selectStatusbar
            // 
            selectStatusbar.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            selectStatusbar.Name = "selectStatusbar";
            selectStatusbar.Size = new Size(25, 24);
            selectStatusbar.Text = "--";
            // 
            // sizeStatusbar
            // 
            sizeStatusbar.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            sizeStatusbar.DisplayStyle = ToolStripItemDisplayStyle.Text;
            sizeStatusbar.ImageAlign = ContentAlignment.BottomLeft;
            sizeStatusbar.Name = "sizeStatusbar";
            sizeStatusbar.RightToLeft = RightToLeft.No;
            sizeStatusbar.Size = new Size(514, 24);
            sizeStatusbar.Spring = true;
            sizeStatusbar.Text = "sizeStatusbar";
            sizeStatusbar.TextAlign = ContentAlignment.BottomCenter;
            // 
            // zoomStatusbar
            // 
            zoomStatusbar.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            zoomStatusbar.Name = "zoomStatusbar";
            zoomStatusbar.Size = new Size(113, 24);
            zoomStatusbar.Text = "zoomStatusBar";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(5, 5);
            pictureBox1.Margin = new Padding(5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(800, 600);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseLeave += pictureBox1_MouseLeave;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            pictureBox1.MouseUp += pictureBox1_MouseUp;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.BackColor = SystemColors.ControlDark;
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(95, 109);
            panel1.Margin = new Padding(5);
            panel1.Name = "panel1";
            panel1.Size = new Size(1087, 677);
            panel1.TabIndex = 2;
            // 
            // selectionStatusBar
            // 
            selectionStatusBar.AutoSize = false;
            selectionStatusBar.Margin = new Padding(0, 3, 0, 2);
            selectionStatusBar.Name = "selectionStatusBar";
            selectionStatusBar.Size = new Size(100, 200);
            selectionStatusBar.Spring = true;
            // 
            // penButton
            // 
            penButton.Location = new Point(12, 55);
            penButton.Name = "penButton";
            penButton.Size = new Size(62, 31);
            penButton.TabIndex = 3;
            penButton.Text = "Pen";
            penButton.UseVisualStyleBackColor = true;
            penButton.Click += penButton_Click;
            // 
            // selectButton
            // 
            selectButton.Location = new Point(12, 92);
            selectButton.Name = "selectButton";
            selectButton.Size = new Size(62, 31);
            selectButton.TabIndex = 4;
            selectButton.Text = "Select";
            selectButton.UseVisualStyleBackColor = true;
            selectButton.Click += selectButton_Click;
            // 
            // lineButton
            // 
            lineButton.Location = new Point(12, 129);
            lineButton.Name = "lineButton";
            lineButton.Size = new Size(62, 31);
            lineButton.TabIndex = 5;
            lineButton.Text = "Line";
            lineButton.UseVisualStyleBackColor = true;
            lineButton.Click += lineButton_Click;
            // 
            // colorPanel
            // 
            colorPanel.ColumnCount = 15;
            colorPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
            colorPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
            colorPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
            colorPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
            colorPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
            colorPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
            colorPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
            colorPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
            colorPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
            colorPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
            colorPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
            colorPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
            colorPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
            colorPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
            colorPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
            colorPanel.Location = new Point(173, 40);
            colorPanel.Name = "colorPanel";
            colorPanel.RowCount = 2;
            colorPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            colorPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            colorPanel.Size = new Size(524, 61);
            colorPanel.TabIndex = 6;
            // 
            // pickedColorPictureBox
            // 
            pickedColorPictureBox.BackColor = SystemColors.ControlLightLight;
            pickedColorPictureBox.BorderStyle = BorderStyle.FixedSingle;
            pickedColorPictureBox.Location = new Point(95, 40);
            pickedColorPictureBox.Name = "pickedColorPictureBox";
            pickedColorPictureBox.Size = new Size(62, 61);
            pickedColorPictureBox.TabIndex = 7;
            pickedColorPictureBox.TabStop = false;
            // 
            // pickedColorImageLeft
            // 
            pickedColorImageLeft.BackColor = SystemColors.ControlLightLight;
            pickedColorImageLeft.BorderStyle = BorderStyle.FixedSingle;
            pickedColorImageLeft.Location = new Point(100, 45);
            pickedColorImageLeft.Name = "pickedColorImageLeft";
            pickedColorImageLeft.Size = new Size(33, 33);
            pickedColorImageLeft.TabIndex = 8;
            pickedColorImageLeft.TabStop = false;
            // 
            // pickedColorImageRight
            // 
            pickedColorImageRight.BackColor = SystemColors.ControlLightLight;
            pickedColorImageRight.BorderStyle = BorderStyle.FixedSingle;
            pickedColorImageRight.Location = new Point(118, 63);
            pickedColorImageRight.Name = "pickedColorImageRight";
            pickedColorImageRight.Size = new Size(33, 33);
            pickedColorImageRight.TabIndex = 9;
            pickedColorImageRight.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(1182, 817);
            Controls.Add(pickedColorImageRight);
            Controls.Add(pickedColorImageLeft);
            Controls.Add(pickedColorPictureBox);
            Controls.Add(colorPanel);
            Controls.Add(lineButton);
            Controls.Add(selectButton);
            Controls.Add(penButton);
            Controls.Add(panel1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MS Paint 2024";
       
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pickedColorPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)pickedColorImageLeft).EndInit();
            ((System.ComponentModel.ISupportInitialize)pickedColorImageRight).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileMenuItem;
        private ToolStripMenuItem newMenuItem;
        private ToolStripMenuItem openMenuItem;
        private ToolStripMenuItem saveMenuItem;
        private ToolStripMenuItem saveAsMenuItem;
        private ToolStripMenuItem printMenuItem;
        private ToolStripMenuItem exitMenuItem;
        private ToolStripMenuItem editMenuItem;
        private ToolStripMenuItem cutMenuItem;
        private ToolStripMenuItem copyMenuItem;
        private ToolStripMenuItem pasteMenuItem;
        private ToolStripMenuItem selectAllMenuItem;
        private ToolStripMenuItem viewMenuItem;
        private ToolStripMenuItem imageMenuItem;
        private ToolStripMenuItem colorsMenuItem;
        private ToolStripMenuItem editColorsMenuItem;
        private ToolStripMenuItem invertMenuItem;
        private ToolStripMenuItem helpMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel positionStatusbar;
        private ToolStripStatusLabel sizeStatusbar;
        private PictureBox pictureBox1;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private ColorDialog colorDialogMain;
        private Panel panel1;
        private ToolStripStatusLabel selectionStatusBar;
        private Button penButton;
        private Button selectButton;
        private Button lineButton;
        private ToolStripStatusLabel selectStatusbar;
        private ToolStripMenuItem zoomToolStripMenuItem;
        private ToolStripMenuItem zoomInToolStripMenuItem;
        private ToolStripMenuItem zoomOutToolStripMenuItem;
        private ToolStripMenuItem resetZoomToolStripMenuItem;
        private ToolStripStatusLabel zoomStatusbar;
        private TableLayoutPanel colorPanel;
        private PictureBox pickedColorPictureBox;
        private PictureBox pickedColorImageLeft;
        private PictureBox pickedColorImageRight;
    }
}
