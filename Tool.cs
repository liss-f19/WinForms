using Paint;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public abstract class Tool
{
    protected PictureBox pictureBox;
    protected DirectBitmap directBitmap;
    protected PictureBoxResizer pictureBoxResizer;

    public Tool(PictureBox pictureBox, DirectBitmap directBitmap, PictureBoxResizer pictureBoxResizer)
    {
        this.pictureBox = pictureBox;
        this.directBitmap = directBitmap;
        this.pictureBoxResizer = pictureBoxResizer;
    }

    public abstract void MouseDown(object sender, MouseEventArgs e);
    public abstract void MouseMove(object sender, MouseEventArgs e);
    public abstract void MouseUp(object sender, MouseEventArgs e);
}

public class PenTool : Tool
{
    private Point prevPoint = Point.Empty;
    private bool drawing = false;
    private Pen drawingPen;

    public PenTool(PictureBox pictureBox, DirectBitmap directBitmap, PictureBoxResizer picboxresizer, Color penColor) : base(pictureBox, directBitmap, picboxresizer)
    {
        this.drawingPen = new Pen(penColor, 1);
    }

    public override void MouseDown(object sender, MouseEventArgs e)
    {
        if (pictureBoxResizer.IsResizing)
            return;
        if (e.Button == MouseButtons.Left)
        {
            drawing = true;
            prevPoint = e.Location;
        }
    }

    public override void MouseMove(object sender, MouseEventArgs e)
    {
        if (pictureBoxResizer.IsResizing)
            return;
        if (drawing && e.Button == MouseButtons.Left)
        {
            directBitmap.DrawLineBresenham(prevPoint.X, prevPoint.Y, e.X, e.Y, drawingPen.Color);
            prevPoint = e.Location;
            pictureBox.Invalidate();
        }
    }

    public override void MouseUp(object sender, MouseEventArgs e)
    {
        if (pictureBoxResizer.IsResizing)
            return;

        if (drawing)
        {
            drawing = false;
        }
    }

    public void UpdatePenColor(Color newColor)
    {
        drawingPen.Color = newColor;
    }
}

public class SelectTool : Tool
{
    private Point selectionStart = Point.Empty;
    private Point selectionEnd = Point.Empty;
    private bool isSelecting = false;
    private ToolStripStatusLabel selectStatusbar;

    public SelectTool(PictureBox pictureBox, DirectBitmap directBitmap, PictureBoxResizer pr, ToolStripStatusLabel statusBar) : base(pictureBox, directBitmap, pr)
    {
        this.selectStatusbar = statusBar;
    }

    public override void MouseDown(object sender, MouseEventArgs e)
    {
        if (pictureBoxResizer.IsResizing)
            return;
        if (e.Button == MouseButtons.Left)
        {
            isSelecting = true;
            selectionStart = e.Location;
            selectionEnd = e.Location;
            UpdateSelectionStatus();
        }
    }

    public override void MouseMove(object sender, MouseEventArgs e)
    {
        if (pictureBoxResizer.IsResizing)
            return;
        if (isSelecting && e.Button == MouseButtons.Left)
        {
            selectionEnd = e.Location;
            UpdateSelectionStatus();
            pictureBox.Invalidate();
        }
    }

    public override void MouseUp(object sender, MouseEventArgs e)
    {
        if (pictureBoxResizer.IsResizing)
            return;
        if (isSelecting)
        {
            isSelecting = false;
            selectionEnd = e.Location;
            UpdateSelectionStatus();
            pictureBox.Invalidate();
        }
    }

    public void Paint(object sender, PaintEventArgs e)
    {
        Graphics graphics = e.Graphics;
        if (selectionStart != Point.Empty && selectionEnd != Point.Empty)
        {
            Pen dashedPen = new Pen(isSelecting ? Color.Black : Color.LightBlue, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash };
            Rectangle rect = GetRectangleFromPoints(selectionStart, selectionEnd);
            graphics.DrawRectangle(dashedPen, rect);
            dashedPen.Dispose();
        }
    }


    private void UpdateSelectionStatus()
    {
        if (selectionStart != Point.Empty && selectionEnd != Point.Empty)
        {
            Rectangle rect = GetRectangleFromPoints(selectionStart, selectionEnd);
           
            selectStatusbar.Text = $"S: ({rect.Left},{rect.Top}), " +
                                   $"E: ({rect.Right},{rect.Bottom}), " +
                                   $"Size: ({rect.Width},{rect.Height})";
        }
        else
        {
            selectStatusbar.Text = "S: (---,---), E: (---,---), Size: (---,---)";
        }
    }

    private Rectangle GetRectangleFromPoints(Point p1, Point p2)
    {
        int x = Math.Min(p1.X, p2.X);
        int y = Math.Min(p1.Y, p2.Y);
        int width = Math.Abs(p1.X - p2.X);
        int height = Math.Abs(p1.Y - p2.Y);
        return new Rectangle(x, y, width, height);
    }
}

public class LineTool : Tool
{
    private Point startPoint = Point.Empty;
    private Point endPoint = Point.Empty;
    private bool drawing = false;
    private Pen drawingPen;

    public LineTool(PictureBox pictureBox, DirectBitmap directBitmap, PictureBoxResizer pictureBoxResizer, Color penColor) : base(pictureBox, directBitmap, pictureBoxResizer)
    {
        this.drawingPen = new Pen(penColor, 1);
    }

    public override void MouseDown(object sender, MouseEventArgs e)
    {
        if (pictureBoxResizer.IsResizing)
            return;

        if (e.Button == MouseButtons.Left)
        {
            startPoint = e.Location;
            endPoint = startPoint; 
            drawing = true; 
            pictureBox.Invalidate();
        }
    }

    public override void MouseMove(object sender, MouseEventArgs e)
    {
        if (pictureBoxResizer.IsResizing || !drawing)
            return;

        if (e.Button == MouseButtons.Left)
        {
            endPoint = e.Location;
            pictureBox.Invalidate(); 
        }
    }

    public override void MouseUp(object sender, MouseEventArgs e)
    {
        if (pictureBoxResizer.IsResizing)
            return;

        if (drawing && e.Button == MouseButtons.Left)
        {
            endPoint = e.Location;
            directBitmap.DrawLineBresenham(startPoint.X, startPoint.Y, endPoint.X, endPoint.Y, drawingPen.Color);
            drawing = false; 
            pictureBox.Invalidate();
        }
    }

    public void Paint(object sender, PaintEventArgs e)
    {
        if (drawing)
        {
            e.Graphics.DrawLine(drawingPen, startPoint, endPoint);
        }
    }

    public void UpdatePenColor(Color newColor)
    {
        drawingPen.Color = newColor;
    }

}


