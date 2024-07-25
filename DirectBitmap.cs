using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
///https://stackoverflow.com/questions/24701703/c-sharp-faster-alternatives-to-setpixel-and-getpixel-for-bitmaps-for-windows-f/34801225#34801225
namespace Paint
{
    public class DirectBitmap : IDisposable
    {
        public Bitmap Bitmap { get; private set; }
        public Int32[] Bits { get; private set; }
        public bool Disposed { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }

        protected GCHandle BitsHandle { get; private set; }

        public DirectBitmap(int width, int height)
        {
            Width = width;
            Height = height;
            Bits = new Int32[width * height];
            BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
            Bitmap = new Bitmap(width, height, width * 4, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());
        }



        public void Resize(int newWidth, int newHeight)
        {
            
            Bitmap tempBitmap = new Bitmap(newWidth, newHeight, PixelFormat.Format32bppPArgb);
            try
            {
                using (Graphics g = Graphics.FromImage(tempBitmap))
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.DrawImage(Bitmap, new Rectangle(0, 0, newWidth, newHeight));
                }

                if (Bitmap != null)
                    Bitmap.Dispose();

                // Reallocate Bits if necessary
                if (newWidth * newHeight != Bits.Length)
                {
                    if (BitsHandle.IsAllocated)
                        BitsHandle.Free();
                    Bits = new int[newWidth * newHeight];
                    BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
                }

                Bitmap = tempBitmap;  
                Width = newWidth;
                Height = newHeight;
            }
            catch
            {
                tempBitmap.Dispose(); 
                throw; 
            }
        }

        public void SetPixel(int x, int y, Color colour)
        {
            if (x >= 0 && y >= 0 && x < Width && y < Height)
            {
                int index = x + (y * Width);
                int col = colour.ToArgb();

                Bits[index] = col;
            }
           
        }

        public Color GetPixel(int x, int y)
        {
            int index = x + (y * Width);
            int col = Bits[index];
            Color result = Color.FromArgb(col);

            return result;
        }

        public void Dispose()
        {
            if (Disposed) return;
            Disposed = true;
            if (Bitmap != null)
                Bitmap.Dispose();
            if (BitsHandle.IsAllocated)
                BitsHandle.Free();
        }

        // https://saturncloud.io/blog/bresenham-line-algorithm-a-powerful-tool-for-efficient-line-drawing/
  
        public void DrawLineBresenham(int x1, int y1, int x2, int y2, Color color)
        {
            bool slope = Math.Abs(y2 - y1) > Math.Abs(x2 - x1);

            if (slope)
            {
                int temp = x1;
                x1 = y1;
                y1 = temp;
                temp = x2;
                x2 = y2;
                y2 = temp;
            }

            if (x1 > x2)
            {
                int temp = x1;
                x1 = x2;
                x2 = temp;
                temp = y1;
                y1 = y2;
                y2 = temp;
            }

            int dx = Math.Abs(x2 - x1);
            int dy = Math.Abs(y2 - y1);
            int error = dx / 2;
            int y = y1;
            int ystep = y1 < y2 ? 1 : -1;

            for (int x = x1; x <= x2; x++)
            {
                if (slope)
                {
                    SetPixel(y, x, color);
                }
                else
                {
                    SetPixel(x, y, color);
                }
                error -= dy;
                if (error < 0)
                {
                    y += ystep;
                    error += dx;
                }
            }
        }
    }
}
