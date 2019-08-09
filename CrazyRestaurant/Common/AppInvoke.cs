using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace CrazyRestaurant.Common
{
    public class AppInvoke
    {
        //user32
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpWindowClass, string lpWindowName);
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, string windowTitle);
        [DllImport("user32.dll")]
        private static extern int GetWindowRect(IntPtr hwnd, out Rect lpRect);
        [DllImport("User32.dll")]
        private extern static IntPtr GetDC(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);
        [DllImport("user32.dll")]
        public static extern int MoveWindow(IntPtr hWnd, int x, int y, int nWidth, int nHeight, bool BRePaint);

        //gdi32
        private const int SRCCOPY = 0x00CC0020;
        [DllImport("gdi32.dll")]
        private static extern bool BitBlt(IntPtr hObject, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hObjectSource, int nXSrc, int nYSrc, int dwRop);
        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth, int nHeight);
        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateCompatibleDC(IntPtr hDC);
        [DllImport("gdi32.dll")]
        private static extern bool DeleteDC(IntPtr hDC);
        [DllImport("gdi32.dll")]
        private static extern bool DeleteObject(IntPtr hObject);
        [DllImport("gdi32.dll")]
        private static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

        static IntPtr hWnd = IntPtr.Zero;
        static Rect rect = new Rect();

        public static Rectangle Rectangle { get; private set; }

        private struct Rect
        {
            internal int Left;
            internal int Top;
            internal int Right;
            internal int Bottom;
        }

        public static IntPtr Init()
        {
            hWnd = FindWindow(null, "夜神模拟器");
            var rectForm = new Rect();
            GetWindowRect(hWnd, out rectForm);
            MoveWindow(hWnd, rectForm.Left, rectForm.Top, 400, 738, true);
            hWnd = FindWindowEx(hWnd, IntPtr.Zero, null, "ScreenBoardClassWindow");
            GetWindowRect(hWnd, out rect);
            Rectangle = new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
            return hWnd;
        }

        public static Image GetImage()
        {
            IntPtr hdcSrc = GetDC(hWnd);
            IntPtr hdcDest = CreateCompatibleDC(hdcSrc);
            IntPtr hBitmap = CreateCompatibleBitmap(hdcSrc, Rectangle.Width, Rectangle.Height);
            IntPtr hOld = SelectObject(hdcDest, hBitmap);
            BitBlt(hdcDest, 0, 0, Rectangle.Width, Rectangle.Height, hdcSrc, 0, 0, SRCCOPY);
            SelectObject(hdcDest, hOld);
            DeleteDC(hdcDest);
            ReleaseDC(hWnd, hdcSrc);
            Image img = Image.FromHbitmap(hBitmap);
            DeleteObject(hBitmap);
            return img;
        }
    }
}
