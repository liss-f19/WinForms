using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO.Enumeration;

namespace Paint
{
    public partial class Form1 : Form
    {
        private Tool currentTool;
        private string lastSavedFileName = string.Empty;
        private ImageFormat lastSavedFormat = ImageFormat.Png;
        private bool drawing = false;
        private Point prevPoint = Point.Empty;
        public Color PenColor { get; set; } = Color.Black;
        private Pen drawingPen = new Pen(Color.Black, 1);
        int width = 800;
        int height = 600;
        float zoomFactor = 1.0f;
        int originalwidthZoom;
        int originalheightZoom;
        public Color BackgroundColor { get; set; } = Color.White;
        private PictureBoxResizer _pictureBoxResizer;
        private DirectBitmap directBitmap;

        private bool isSelecting = false;
        private Point selectionStart = Point.Empty;
        private Point selectionEnd = Point.Empty;
        private Rectangle selectionRectangle = Rectangle.Empty;

        private INIFileStorage iniFileStorage = new INIFileStorage();
        private bool ignoreSingleClick = false;

        //ctor
        public Form1()
        {
            InitializeComponent();
            pictureBox1.BackColor = Color.White;
            panel1.AutoScroll = true;
            this.DoubleBuffered = true;

            PenColor = Properties.Settings.Default.LastPenColor;
            drawingPen = new Pen(PenColor, 1);
            openFileDialog1.Filter = "Image Files (*.bmp;*.jpg;*.jpeg;*.png)|*.bmp;*.jpg;*.jpeg;*.";
            saveFileDialog1.Filter = "Bitmap Image|*.bmp|JPEG Image|*.jpg|PNG Image|*.png";
            CreateDefaultImage();

            _pictureBoxResizer = new PictureBoxResizer(pictureBox1);
            _pictureBoxResizer.Resized += AdjustDirectBitmapSize;
            SetTool(new PenTool(pictureBox1, directBitmap, _pictureBoxResizer, PenColor));
            selectStatusbar.Text = "S: (---,---), E: (---,---), Size: (---,---)";
            UpdateRecentFilesMenu();
            UpdatePictureBoxImage();
            InitializeColorPalette();
        }

        //initial settings
        private void SetTool(Tool tool)
        {
            if (currentTool != null)
            {
                pictureBox1.MouseDown -= currentTool.MouseDown;
                pictureBox1.MouseMove -= currentTool.MouseMove;
                pictureBox1.MouseUp -= currentTool.MouseUp;
                if (currentTool is SelectTool)
                {
                    pictureBox1.Paint -= ((SelectTool)currentTool).Paint;

                }
                else if (currentTool is LineTool)
                {
                    pictureBox1.Paint -= ((LineTool)currentTool).Paint;
                }
                pictureBox1.Paint -= GeneralSelectionPaint;
            }

            currentTool = tool;

            pictureBox1.MouseDown += currentTool.MouseDown;
            pictureBox1.MouseMove += currentTool.MouseMove;
            pictureBox1.MouseUp += currentTool.MouseUp;

            if (currentTool is SelectTool)
            {
                pictureBox1.Paint += ((SelectTool)currentTool).Paint;
            }
            else if (currentTool is LineTool)
            {
                pictureBox1.Paint += ((LineTool)currentTool).Paint;
            }
        }

        private void CreateDefaultImage()
        {
            DisposeDirectBitmap();
            directBitmap = new DirectBitmap(800, 600);
            originalheightZoom = directBitmap.Height;
            originalwidthZoom = directBitmap.Width;
            using (Graphics g = Graphics.FromImage(directBitmap.Bitmap))
            {
                g.Clear(BackgroundColor);
            }
            UpdatePictureBoxImage();
            ResetSetupResizer();
        }

        //menu items Clicks
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var newImgDialog = new FormNewImage())
            {
                if (newImgDialog.ShowDialog() == DialogResult.OK)
                {
                    DisposeDirectBitmap();

                    width = originalwidthZoom = newImgDialog.ImageWidth;
                    height = originalheightZoom = newImgDialog.ImageHeight;
                    Color bgColor = newImgDialog.BackgroundColor;
                    directBitmap = new DirectBitmap(width, height);

                    using (Graphics g = Graphics.FromImage(directBitmap.Bitmap))
                    {
                        g.Clear(bgColor);
                    }
                    UpdatePictureBoxImage();
                    ResetSetupResizer();
                }
            }
        }

        private void openMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var img = Image.FromFile(openFileDialog1.FileName))
                    {
                        CreateDirectBitmapFromImage(img);
                        originalheightZoom = img.Height;
                        originalwidthZoom = img.Width;
                        iniFileStorage.AddRecentFile(openFileDialog1.FileName);
                        UpdateRecentFilesMenu();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while attempting to load the file. The error is: " + ex.Message);
                }
            }
        }

        private void saveMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lastSavedFileName))
            {
                SaveImage(lastSavedFileName, lastSavedFormat);
            }
            else
            {
                saveAsMenuItem_Click(sender, e);
            }
        }

        private void saveAsMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog1.FileName;
                ImageFormat format = GetImageFormatFromFileName(fileName);
                SaveImage(fileName, format);
                lastSavedFileName = fileName;
                lastSavedFormat = format;
            }
        }

        private ImageFormat GetImageFormatFromFileName(string fileName)
        {
            switch (Path.GetExtension(fileName).ToLower())
            {
                case ".bmp":
                    return ImageFormat.Bmp;
                case ".jpg":
                case ".jpeg":
                    return ImageFormat.Jpeg;
                case ".png":
                    return ImageFormat.Png;
                default:
                    return ImageFormat.Png;
            }
        }

        private void SaveImage(string fileName, ImageFormat format)
        {
            try
            {
                pictureBox1.Image.Save(fileName, format);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save the image. Error: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editColorsMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialogMain.ShowDialog() == DialogResult.OK)
            {
                PenColor = colorDialogMain.Color;
                Properties.Settings.Default.LastPenColor = PenColor;
                Properties.Settings.Default.Save();

                if (currentTool is PenTool penTool)
                {
                    penTool.UpdatePenColor(PenColor);
                }
                else if (currentTool is LineTool lineTool)
                {
                    lineTool.UpdatePenColor(PenColor);
                }

                UpdatePictureBoxImage();
            }
        }

        private void selectAllMenuItem_Click(object sender, EventArgs e)
        {
            if (directBitmap != null)
            {
                selectionStart = new Point(0, 0);
                selectionEnd = new Point(directBitmap.Width, directBitmap.Height);
                selectionRectangle = GetRectangleFromPoints(selectionStart, selectionEnd);

                Rectangle rect = GetRectangleFromPoints(selectionStart, selectionEnd);
                selectStatusbar.Text = $"S: ({rect.Left},{rect.Top}), " +
                                       $"E: ({rect.Right},{rect.Bottom}), " +
                                       $"Size: ({rect.Width},{rect.Height})";
                pictureBox1.Paint += GeneralSelectionPaint;
                pictureBox1.Invalidate();
            }
        }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zoomFactor = 1.44f;

            int newWidth = (int)(directBitmap.Width * zoomFactor);
            int newHeight = (int)(directBitmap.Height * zoomFactor);

            DirectBitmap zoomedBitmap = new DirectBitmap(newWidth, newHeight);

            using (Graphics g = Graphics.FromImage(zoomedBitmap.Bitmap))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(directBitmap.Bitmap, new Rectangle(0, 0, newWidth, newHeight));
            }

            directBitmap.Dispose();

            directBitmap = zoomedBitmap;
            SetTool(new PenTool(pictureBox1, directBitmap, _pictureBoxResizer, PenColor));
            UpdatePictureBoxImage();
            _pictureBoxResizer.ResetState();
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zoomFactor = 0.35f;

            int newWidth = (int)(directBitmap.Width * zoomFactor);
            int newHeight = (int)(directBitmap.Height * zoomFactor);

            DirectBitmap zoomedBitmap = new DirectBitmap(newWidth, newHeight);

            using (Graphics g = Graphics.FromImage(zoomedBitmap.Bitmap))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(directBitmap.Bitmap, new Rectangle(0, 0, newWidth, newHeight));
            }

            directBitmap.Dispose();

            directBitmap = zoomedBitmap;
            SetTool(new PenTool(pictureBox1, directBitmap, _pictureBoxResizer, PenColor));
            UpdatePictureBoxImage();
            _pictureBoxResizer.ResetState();
        }

        private void resetZoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zoomFactor = 1.0f;
            if (originalwidthZoom == directBitmap.Width && originalheightZoom == directBitmap.Height)
            {
                return;
            }

            if (originalwidthZoom <= 0 || originalheightZoom <= 0)
            {
                throw new ArgumentException("Original dimensions must be greater than zero.");
            }

            directBitmap.Resize(originalwidthZoom, originalheightZoom);

            UpdatePictureBoxImage();
            _pictureBoxResizer.ResetState();
        }

        //https://www.homeandlearn.co.uk/extras/image/image-invert-colors.html
        private void invertMenuItem_Click(object sender, EventArgs e)
        {
            if (directBitmap != null)
            {
                int length = directBitmap.Bits.Length;
                for (int i = 0; i < length; i++)
                {
                    Color originalColor = Color.FromArgb(directBitmap.Bits[i]);
                    Color invertedColor = Color.FromArgb(originalColor.A, 255 - originalColor.R, 255 - originalColor.G, 255 - originalColor.B);
                    directBitmap.Bits[i] = invertedColor.ToArgb();
                }
                AdjustDirectBitmapSize(directBitmap.Width, directBitmap.Height);

            }
        }


        //general events for Form1
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            currentTool?.MouseMove(sender, e);
            positionStatusbar.Text = $"{e.X} x {e.Y} px.";
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (currentTool is SelectTool)
            {
                ((SelectTool)currentTool).Paint(sender, e);
            }
            else if (currentTool is LineTool)
            {
                ((LineTool)currentTool).Paint(sender, e);
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            currentTool?.MouseDown(sender, e);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            currentTool?.MouseUp(sender, e);

        }

        private void GeneralSelectionPaint(object sender, PaintEventArgs e)
        {
            if (!selectionRectangle.IsEmpty)
            {
                using (Pen selectPen = new Pen(Color.Green, 2) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash })
                {
                    e.Graphics.DrawRectangle(selectPen, selectionRectangle);
                }
            }
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            positionStatusbar.Text = $" ";
        }


        //buttons events
        private void penButton_Click(object sender, EventArgs e)
        {
            SetTool(new PenTool(pictureBox1, directBitmap, _pictureBoxResizer, PenColor));
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            SetTool(new SelectTool(pictureBox1, directBitmap, _pictureBoxResizer, selectStatusbar));
        }

        private void lineButton_Click(object sender, EventArgs e)
        {
            SetTool(new LineTool(pictureBox1, directBitmap, _pictureBoxResizer, PenColor));
        }

        //helpers & clean up 
        private void DisposeDirectBitmap()
        {
            if (directBitmap != null)
            {
                pictureBox1.Image = null;
                directBitmap.Dispose();
                directBitmap = null;
            }
        }

        private void UpdatePictureBoxImage()
        {
            pictureBox1.Image = directBitmap.Bitmap;
            pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
            pictureBox1.ClientSize = new Size(directBitmap.Width, directBitmap.Height);
            pictureBox1.Invalidate();
            sizeStatusbar.Text = $"{directBitmap.Width}, {directBitmap.Height} px.";
            UpdateZoomStatusLabel();
        }

        private void AdjustDirectBitmapSize(int newWidth, int newHeight)
        {
            if (directBitmap == null || (newWidth <= 0 || newHeight <= 0)) return;

            DirectBitmap newDirectBitmap = new DirectBitmap(newWidth, newHeight);

            using (Graphics g = Graphics.FromImage(newDirectBitmap.Bitmap))
            {
                g.Clear(BackgroundColor);
                int copyWidth = Math.Min(newWidth, directBitmap.Width);
                int copyHeight = Math.Min(newHeight, directBitmap.Height);

                g.DrawImage(directBitmap.Bitmap, new Rectangle(0, 0, copyWidth, copyHeight), new Rectangle(0, 0, copyWidth, copyHeight), GraphicsUnit.Pixel);
            }

            directBitmap.Dispose();
            directBitmap = newDirectBitmap;

            UpdatePictureBoxImage();
            SetTool(new PenTool(pictureBox1, directBitmap, _pictureBoxResizer, PenColor));
        }

        private void ResetSetupResizer()
        {
            if (_pictureBoxResizer != null)
            {
                _pictureBoxResizer.Detach();

            }
            _pictureBoxResizer = new PictureBoxResizer(pictureBox1);
            _pictureBoxResizer.Resized += AdjustDirectBitmapSize;
            _pictureBoxResizer.ResetState();
        }

        private Rectangle GetRectangleFromPoints(Point p1, Point p2)
        {
            int x = Math.Min(p1.X, p2.X);
            int y = Math.Min(p1.Y, p2.Y);
            int width = Math.Abs(p1.X - p2.X);
            int height = Math.Abs(p1.Y - p2.Y);
            return new Rectangle(x, y, width, height);
        }

        private void CreateDirectBitmapFromImage(Image img)
        {
            DisposeDirectBitmap();
            directBitmap = new DirectBitmap(img.Width, img.Height);
            using (Graphics g = Graphics.FromImage(directBitmap.Bitmap))
            {
                g.Clear(BackgroundColor);
                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));
            }
            UpdatePictureBoxImage();
            ResetSetupResizer();
        }

        private void UpdateZoomStatusLabel()
        {
            if (zoomFactor == 1.0f)
            {
                zoomStatusbar.Text = "100 %";
            }
            else
            {
                zoomStatusbar.Text = $"{(int)(zoomFactor * 100)} %";
            }
        }

        private void UpdateToolColor(Color color)
        {
            if (currentTool is PenTool penTool)
            {
                penTool.UpdatePenColor(color);
            }
            else if (currentTool is LineTool lineTool)
            {
                lineTool.UpdatePenColor(color);
            }
        }


        //Ini management
        private void UpdateRecentFilesMenu()
        {
            RemoveOldRecentFiles();

            var recentFiles = iniFileStorage.GetRecentFiles();
            int printMenuItemIndex = fileMenuItem.DropDownItems.IndexOf(printMenuItem);
            int exitMenuItemIndex = fileMenuItem.DropDownItems.IndexOf(exitMenuItem);
            ToolStripSeparator firstSeparator = new ToolStripSeparator();
            fileMenuItem.DropDownItems.Insert(printMenuItemIndex + 1, firstSeparator);

            int insertIndex = printMenuItemIndex + 1 + 1;  //"Print" --> "Separator" --> file
            int fileNumber = 1;
            foreach (var file in recentFiles)
            {
                string fileName = Path.GetFileName(file);
                string formattedName = $"{fileNumber}. {fileName}";
                ToolStripMenuItem item = new ToolStripMenuItem(formattedName);
                item.Click += (sender, args) => OpenRecentFile(file);
                fileMenuItem.DropDownItems.Insert(insertIndex++, item);
                fileNumber++;
            }

            ToolStripSeparator secondSeparator = new ToolStripSeparator();
            if (recentFiles.Any())
            {
                fileMenuItem.DropDownItems.Insert(insertIndex, secondSeparator);
            }
            else
            {
                fileMenuItem.DropDownItems.Insert(exitMenuItemIndex, secondSeparator);
            }

        }

        private void RemoveOldRecentFiles()
        {
            int printMenuItemIndex = fileMenuItem.DropDownItems.IndexOf(printMenuItem);
            int exitMenuItemIndex = fileMenuItem.DropDownItems.IndexOf(exitMenuItem);

            for (int i = exitMenuItemIndex - 1; i > printMenuItemIndex; i--)
            {
                fileMenuItem.DropDownItems.RemoveAt(i);
            }
        }

        private void OpenRecentFile(string filePath)
        {
            try
            {
                using (var img = Image.FromFile(filePath))
                {
                    CreateDirectBitmapFromImage(img);
                    originalheightZoom = img.Height;
                    originalwidthZoom = img.Width;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open recent file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //color palette
        public void InitializeColorPalette()
        {
            Color[] colors = 
                {
                Color.AliceBlue, Color.Azure, Color.MintCream, Color.FloralWhite, Color.Ivory,
                Color.Aqua, Color.LightSkyBlue, Color.MediumTurquoise, Color.Cyan, Color.Navy,
                Color.Crimson, Color.MediumVioletRed, Color.DarkSalmon, Color.Firebrick, Color.Red,
                Color.MediumSpringGreen, Color.PaleGreen, Color.LimeGreen, Color.ForestGreen, Color.Lime,
                Color.MediumPurple, Color.Purple, Color.DarkViolet, Color.Indigo, Color.BlueViolet,
                Color.Gray, Color.DimGray, Color.DarkGray, Color.DarkSlateGray, Color.Black
                 };

            int numColors = colors.Length;
            int columns = 15;
            int rows = 2;
            colorPanel.ColumnCount = columns;
            colorPanel.RowCount = rows;

            colorPanel.ColumnStyles.Clear();
            colorPanel.RowStyles.Clear();

            for (int c = 0; c < columns; c++)
            {
                colorPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / columns));
            }

            for (int r = 0; r < rows; r++)
            {
                colorPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / rows));
            }

            for (int i = 0; i < numColors; i++)
            {
                DoubleClickCustomButton colorButton = new DoubleClickCustomButton
                {
                    BackColor = colors[i],
                    Dock = DockStyle.Fill,
                    Margin = new Padding(1),
                };
                colorButton.Click += ColorButton_Click;
                colorButton.DoubleClick += ColorButton_DoubleClick;

                int row = i / columns;
                int column = i % columns;
                colorPanel.Controls.Add(colorButton, column, row);
            }
        }


        //single//double click events
        private void ColorButton_Click(object sender, EventArgs e)
        {
            if (ignoreSingleClick)
            {
                ignoreSingleClick = false;
                return;
            }
            DoubleClickCustomButton colorButton = sender as DoubleClickCustomButton;
            PenColor = colorButton.BackColor;
            UpdateToolColor(colorButton.BackColor);
            pickedColorImageLeft.BackColor = colorButton.BackColor; 
        }

        private void ColorButton_DoubleClick(object sender, EventArgs e)
        {
            ignoreSingleClick = true;

            DoubleClickCustomButton colorButton = sender as DoubleClickCustomButton;
            using (ColorDialog colorDialog = new ColorDialog())
            {
                colorDialog.Color = colorButton.BackColor; 

                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    colorButton.BackColor = colorDialog.Color; 
                    UpdateToolColor(colorDialog.Color); 
                }
            }
            UpdatePictureBoxImage();
        }

    

        
    }
}
