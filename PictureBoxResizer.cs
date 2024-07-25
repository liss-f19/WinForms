using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Paint
{
    public class PictureBoxResizer
    {
        private PictureBox _pictureBox;
        private bool _isResizing, _isDragging = false;
        private Rectangle[] _resizeHandles = new Rectangle[3];
        private int _selectedHandle = -1; 
        private Point _lastMousePosition;
        private const int HandleSize = 8; 
        private Rectangle _tempRect = Rectangle.Empty;
        private Pen _dottedPen = new Pen(Color.Black) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dot };
        public event Action<int, int> Resized;

        private void ResizeImageToPictureBox()
        {
            Resized?.Invoke(_tempRect.Width, _tempRect.Height);
        }

        public PictureBoxResizer(PictureBox pictureBox)
        {
            _pictureBox = pictureBox;

            if (_pictureBox.Parent != null)
            {
                _pictureBox.Parent.Paint += ParentControl_Paint;
            }

            _pictureBox.Paint += PictureBox_Paint;
            _pictureBox.MouseDown += PictureBox_MouseDown;
            _pictureBox.MouseMove += PictureBox_MouseMove;
            _pictureBox.MouseUp += PictureBox_MouseUp;
  
            UpdateResizeHandles();
        }
        public bool IsResizing
        {
            get { return _isResizing; }
        }

        public bool IsDragging
        {
            get { return _isDragging; }
        }

        private void DrawResizeHandles(Graphics g)
        {
            foreach (var handle in _resizeHandles)
            {
                g.FillRectangle(Brushes.DarkBlue, handle); 
            }
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            Point mousePosition = e.Location;
            _tempRect = new Rectangle(_pictureBox.Left, _pictureBox.Top, _pictureBox.Width, _pictureBox.Height);

            for (int i = 0; i < _resizeHandles.Length; i++)
            {
                if (_resizeHandles[i].Contains(mousePosition))
                {
                   
                    _isResizing = true;
                    _isDragging = true;
                    _selectedHandle = i;
                    _lastMousePosition = mousePosition;
                    break;
                }
            }
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            UpdateCursor(e.Location);
            if (_isResizing && _selectedHandle != -1)
            {
                Point currentMousePos = e.Location;
                
                int dx = currentMousePos.X - _lastMousePosition.X;
                int dy = currentMousePos.Y - _lastMousePosition.Y;

                switch (_selectedHandle)
                {
                    case 0: 
                        _tempRect.Width += dx;
                        _tempRect.Height += dy;
                        break;
                    case 1: 
                        _tempRect.Height += dy;
                        break;
                    case 2: 
                        _tempRect.Width += dx;
                        break;
                }

                _lastMousePosition = currentMousePos; 
                _pictureBox.Parent.Invalidate();
                _pictureBox.Invalidate();
                UpdateCursor(e.Location);
            }
            
        }


        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (_isDragging || _isResizing)
            {
                if (_isResizing)
                {
                    ResizeImageToPictureBox();
                }

                ResetState();

                _pictureBox.Invalidate();
                _pictureBox.Parent.Invalidate();
            }
        }

        private void UpdateResizeHandles()
        {
            _resizeHandles[0] = new Rectangle(_pictureBox.Width - HandleSize, _pictureBox.Height - HandleSize, HandleSize, HandleSize); 
            _resizeHandles[1] = new Rectangle((_pictureBox.Width / 2) - (HandleSize / 2), _pictureBox.Height - HandleSize, HandleSize, HandleSize); 
            _resizeHandles[2] = new Rectangle(_pictureBox.Width - HandleSize, (_pictureBox.Height / 2) - (HandleSize / 2), HandleSize, HandleSize);
        }

        private void UpdateCursor(Point mouseLocation)
        {
            Cursor cur = Cursors.Default;
            for (int i = 0; i < _resizeHandles.Length; i++)
            {
                if (_resizeHandles[i].Contains(mouseLocation))
                {
                    switch (i)
                    {
                        case 0: 
                            cur = Cursors.SizeNWSE;
                            break;
                        case 1: 
                            cur = Cursors.SizeNS;
                            break;
                        case 2: 
                            cur = Cursors.SizeWE;
                            break;
                    }
                    break;
                }
            }
            _pictureBox.Cursor = cur;
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            DrawResizeHandles(e.Graphics);

            if (_isDragging && !_tempRect.IsEmpty)
            {
                    Rectangle drawRect = new Rectangle(0,0, _tempRect.Width, _tempRect.Height);
                    e.Graphics.DrawRectangle(_dottedPen, drawRect);
            }
        }

        private void ParentControl_Paint(object sender, PaintEventArgs e)
        {
            if (_isDragging && !_tempRect.IsEmpty)
            {
                Rectangle drawRect = new Rectangle(0, 0, _tempRect.Width, _tempRect.Height);
                e.Graphics.DrawRectangle(_dottedPen, drawRect);
            }
        }

        public void Detach()
        {
            _pictureBox.MouseMove -= PictureBox_MouseMove;
            _pictureBox.Paint -= PictureBox_Paint;
            _pictureBox.MouseDown -= PictureBox_MouseDown;
            _pictureBox.MouseUp -= PictureBox_MouseUp;
        }


        public void ResetState()
        {
            _tempRect = Rectangle.Empty;
            
            _isDragging = false;
            _isResizing = false;
            _selectedHandle = -1;
            UpdateResizeHandles();
            _pictureBox.Invalidate();
            if (_pictureBox.Parent != null)
            {
                _pictureBox.Parent.Invalidate();
            }
        }


    }
}
