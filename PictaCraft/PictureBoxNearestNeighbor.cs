using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PictaCraft
{
    /// <summary>
    /// A picture box that resizes images with the nearest neighbor algorithm.
    /// </summary>
    public class PictureBoxNearestNeighbor : PictureBox
    {
        /// <summary>
        /// Raises the Control.Paint event.
        /// </summary>
        /// <param name="e">The paint event arguments.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
            base.OnPaint(e);
        }
    }
}