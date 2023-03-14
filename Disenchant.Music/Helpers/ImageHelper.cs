using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
//using System.Windows.Media.Imaging;

namespace Disenchant.Music.Helpers
{
    public static class ImageHelper
    {
        /*
        public static Bitmap BitmapImage2Bitmap(BitmapImage bitmapImage)
        {
            // BitmapImage bitmapImage = new BitmapImage(new Uri("../Images/test.png", UriKind.Relative));
            byte[] coverBuffer = (byte[])(bitmapImage);
            new MemoryStream(bitmapImage);
            using (var stream = new MemoryStream(coverBuffer))
            {
                stream.Seek(0, SeekOrigin.Begin); var s2 = new MemoryStream(); stream.CopyTo(s2); s2.Position = 0;
                Cover.DecodePixelHeight = 100; Cover.DecodePixelWidth = 100;
                Cover.SetSource(s2.AsRandomAccessStream()); s2.Dispose();
            }
            using (MemoryStream outStream = new MemoryStream())
            {
                Bitmap.FromStream(outStream)
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapImage));
                enc.Save(outStream);
                System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(outStream);

                return new Bitmap(bitmap);
            }
        }
        //To convert the Bitmap back to a BitmapImage:

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);

        public static BitmapImage Bitmap2BitmapImage(Bitmap bitmap)
        {
            IntPtr hBitmap = bitmap.GetHbitmap();
            bitmap.pix
            BitmapImage retval;

            try
            {
                retval = (BitmapImage)Imaging.CreateBitmapSourceFromHBitmap(
                             hBitmap,
                             IntPtr.Zero,
                             Int32Rect.Empty,
                             BitmapSizeOptions.FromEmptyOptions());
            }
            finally
            {
                DeleteObject(hBitmap);
            }

            return retval;
        }
        */
    }
}
