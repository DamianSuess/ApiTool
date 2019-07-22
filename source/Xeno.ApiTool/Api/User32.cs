/* Copyright Xeno Innovations, Inc. 2019
 * Date:    2019-7-22
 * Author:  Damian Suess
 * File:    User32.cs
 * Description:
 *  User32.dll
 */

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Xeno.ApiTool.Api
{
  public class User32
  {
    public const Int32 CURSOR_SHOWING = 0x00000001;

    public const int GWL_EXSTYLE = -20;
    public const int GWL_STYLE = -16;

    public const int GWW_HINSTANCE = -6;
    public const int GWW_ID = -12;

    public const int LWA_ALPHA = 2;

    public const int SM_CXSCREEN = 0;
    public const int SM_CYSCREEN = 1;

    public const int WS_EX_LAYERED = 0x80000;

    public static void ApplyMenuTransparency(IntPtr Handle, byte Transparency)
    {
      SetWindowLong(Handle, GWL_EXSTYLE, GetWindowLong(Handle, GWL_EXSTYLE) | WS_EX_LAYERED);
      SetLayeredWindowAttributes(Handle, 0, Transparency, LWA_ALPHA);
    }

    [DllImport("User32.dll")]
    public static extern IntPtr ChildWindowFromPoint(IntPtr hWndParent, POINT p);

    [DllImport("user32.dll", EntryPoint = "CopyIcon")]
    public static extern IntPtr CopyIcon(IntPtr hIcon);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

    [DllImport("user32.dll", EntryPoint = "GetCursorInfo")]
    public static extern bool GetCursorInfo(out CURSORINFO pci);

    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool GetCursorPos(out POINT lpPoint);

    [DllImport("user32.dll", EntryPoint = "GetDC")]
    public static extern IntPtr GetDC(IntPtr ptr);

    [DllImport("user32.dll", EntryPoint = "GetDesktopWindow")]
    public static extern IntPtr GetDesktopWindow();

    [DllImport("user32.dll", EntryPoint = "GetIconInfo")]
    public static extern bool GetIconInfo(IntPtr hIcon, out ICONINFO piconinfo);

    [DllImport("User32.dll")]
    public static extern IntPtr GetParent(IntPtr hWnd);

    [DllImport("user32.dll", EntryPoint = "GetSystemMetrics")]
    public static extern int GetSystemMetrics(int abc);

    public static string GetText(IntPtr hWnd)
    {
      // Allocate correct string length first
      var length = User32.GetWindowTextLength(hWnd);

      StringBuilder sb = new StringBuilder(length + 1);
      User32.GetWindowText(hWnd, sb, sb.Capacity);
      return sb.ToString();
    }


    //public static string GetWindowTextRaw(IntPtr hwnd)
    //{
    //  // Allocate correct string length first
    //  int length = (int)SendMessage(hwnd, WM_GETTEXTLENGTH, IntPtr.Zero, IntPtr.Zero);
    //  StringBuilder sb = new StringBuilder(length + 1);
    //
    //  SendMessage(hwnd, WM_GETTEXT, (IntPtr)sb.Capacity, sb);
    //  return sb.ToString();
    //}

    [DllImport("user32.dll", EntryPoint = "GetWindowDC")]
    public static extern IntPtr GetWindowDC(Int32 ptr);

    [DllImport("user32.dll", EntryPoint = "GetWindowLongA", SetLastError = true)]
    public static extern int GetWindowLong(IntPtr hwnd, int nIndex);

    [DllImport("user32.dll")]
    public static extern int GetWindowWord(IntPtr hwnd, int nIndex);

    [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    public static extern long GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    public static extern int GetWindowTextLength(IntPtr hWnd);

    [DllImport("user32.dll", EntryPoint = "ReleaseDC")]
    public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDc);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, [Out] StringBuilder lParam);

    [DllImport("user32.dll")]
    public static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);

    [DllImport("user32.dll", EntryPoint = "SetWindowLongA", SetLastError = true)]
    public static extern int SetWindowLong(IntPtr hwnd, int nIndex, int dwNewLong);

    [DllImport("User32.dll")]
    public static extern IntPtr WindowFromPoint(POINT p);

    [StructLayout(LayoutKind.Sequential)]
    public struct CURSORINFO
    {
      public Int32 cbSize;        // Specifies the size, in bytes, of the structure.
      public Int32 flags;         // Specifies the cursor state. This parameter can be one of the following values:
      public IntPtr hCursor;          // Handle to the cursor.
      public POINT ptScreenPos;       // A POINT structure that receives the screen coordinates of the cursor.
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ICONINFO
    {
      public bool fIcon;         // Specifies whether this structure defines an icon or a cursor. A value of TRUE specifies
      public Int32 xHotspot;     // Specifies the x-coordinate of a cursor's hot spot. If this structure defines an icon, the hot
      public Int32 yHotspot;     // Specifies the y-coordinate of the cursor's hot spot. If this structure defines an icon, the hot
      public IntPtr hbmMask;     // (HBITMAP) Specifies the icon bitmask bitmap. If this structure defines a black and white icon,
      public IntPtr hbmColor;    // (HBITMAP) Handle to the icon color bitmap. This member can be optional if this
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
      public Int32 X;
      public Int32 Y;

      public POINT(int x, int y)
      {
        this.X = x;
        this.Y = y;
      }

      public static implicit operator System.Drawing.Point(POINT p)
      {
        return new System.Drawing.Point(p.X, p.Y);
      }

      public static implicit operator POINT(System.Drawing.Point p)
      {
        return new POINT(p.X, p.Y);
      }
    }
  }
}
