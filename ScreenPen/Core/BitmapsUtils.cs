using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ScreenPen.Core
{
    public static class BitmapsUtils
    {
        public static Rectangle GetBitmapFullRectangle(Bitmap bitmap)
        {
            return new Rectangle(new Point(0, 0), bitmap.Size);
        }

        public static bool AreBitmapsEqual_Slow(Bitmap B1, Bitmap B2)
        {
            if (B1 == null || B2 == null || B1.Size != B2.Size || B1.PixelFormat != B2.PixelFormat)
                return false;


            BitmapData B1Data = B1.LockBits(GetBitmapFullRectangle(B1), ImageLockMode.ReadOnly, B1.PixelFormat);
            BitmapData B2Data = B2.LockBits(GetBitmapFullRectangle(B2), ImageLockMode.ReadOnly, B2.PixelFormat);

            try
            {
                for (int y = 0; y < B1Data.Height; y++)
                {
                    IntPtr ptrB1RowBeginning = IntPtr.Add(B1Data.Scan0, y * B1Data.Stride);
                    IntPtr ptrB2RowBeginning = IntPtr.Add(B2Data.Scan0, y * B2Data.Stride);

                    // assumming always 32bbpArgb we should make it dynamic in the future
                    for (int x = 0; x < B1Data.Width * 4; x++)
                    {
                        if (Marshal.ReadByte(ptrB1RowBeginning, x) != Marshal.ReadByte(ptrB2RowBeginning, x))
                            return false;
                    }
                }

                return true;
            }
            finally
            {
                B1.UnlockBits(B1Data);
                B2.UnlockBits(B2Data);
            }
        }

        public static Bitmap CopyBitmap(Bitmap BitmapToCopy)
        {
            Bitmap NewBitmap = new Bitmap(BitmapToCopy.Width, BitmapToCopy.Height, BitmapToCopy.PixelFormat);
            Graphics NewBitmapGraphics = Graphics.FromImage(NewBitmap);
            NewBitmapGraphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;

            NewBitmapGraphics.DrawImage(BitmapToCopy, new Point(0, 0));

            NewBitmapGraphics.Dispose();

            return NewBitmap;
        }

    }
}
