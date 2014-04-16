using System;
using System.Drawing;
using System.Windows.Forms;

namespace Shooting
{
    public class Shooter
    {
        public static Bitmap MakeScreenShot(Screen screen)
        {
            try
            {
                Bitmap bitmap = new Bitmap(screen.Bounds.Width, screen.Bounds.Height);

                using (Graphics gfx = Graphics.FromImage(bitmap))
                {
                    gfx.CopyFromScreen(0, 0, 0, 0, new Size(bitmap.Width, bitmap.Height));
                    gfx.Dispose();
                }
                return bitmap;
            }
            catch (Exception exc)
            {
                //using (Graphics gfx = Graphics.FromImage(bitmap))
                //{
                //    gfx.DrawString("Error:\r\n" + exc.ToString(), new Font("arial", 12), Brushes.Black, new PointF(0, 0));
                //}
            }
            return null;
        }
    }
}
