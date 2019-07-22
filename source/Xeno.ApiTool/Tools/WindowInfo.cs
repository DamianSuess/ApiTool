/* Copyright Xeno Innovations, Inc. 2019
 * Date:    2019-7-22
 * Author:  Damian Suess
 * File:    WindowInfo.cs
 * Description:
 *
 */

using System;
using System.Text;
using System.Timers;
using Xeno.ApiTool.Api;

namespace Xeno.ApiTool.Tools
{
  public class WindowInfo
  {
    private EventArgs _eventArgs = null;
    private IntPtr _hWndLast;
    private IntPtr _hWndParent;
    private System.Timers.Timer _timer = new System.Timers.Timer();
    private int _x;
    private int _y;

    public WindowInfo()
    {
      _timer.Elapsed += new ElapsedEventHandler(OnMouseTimer);
      _timer.Interval = 500;
      _timer.Enabled = true;
    }

    ~WindowInfo()
    {
      _timer.Elapsed -= OnMouseTimer;
    }

    public delegate void TickHandler(WindowInfo info, EventArgs e);

    public event TickHandler Tick;

    private void OnMouseTimer(object sender, ElapsedEventArgs e)
    {
      User32.POINT p = new User32.POINT();

      if (User32.GetCursorPos(out p))
      {
        StringBuilder sb = new StringBuilder(100);

        if (_x != p.x || _y != p.y)
        {
          _x = p.x;
          _y = p.y;

          Console.WriteLine($"==================");
          Console.WriteLine($"X: {p.x}");
          Console.WriteLine($"Y: {p.y}");
        }

        //label1.Text = "X: " + Convert.ToString(p.x);
        //label2.Text = "Y: " + Convert.ToString(p.y);

        var hWnd = User32.WindowFromPoint(p);
        if (hWnd != _hWndLast)
        {
          _hWndLast = hWnd;
          var wtLen = User32.GetWindowText(hWnd, sb, sb.Capacity);
          Console.WriteLine($"Text: {sb}");
          // label3.Text = "Text: " + sb.ToString();

          var cnLen = User32.GetClassName(hWnd, sb, sb.Capacity);
          Console.WriteLine($"ClassName: {sb}");
          // label4.Text = "ClassName: " + sb.ToString();

          //var winStyle = GetWindowLong(hWndOver, GWL_STYLE);
          //Console.WriteLine($"WinStyle: {winStyle}");

          var hWndParent = User32.GetParent(hWnd);
          Console.WriteLine($"Parent: {hWndParent}");
          if (hWndParent != _hWndParent)
          {
            _hWndParent = hWndParent;
            //  GetWindowWord(hWnd, GWW_ID);

            User32.GetWindowText(hWndParent, sb, sb.Capacity);
            Console.WriteLine($"Parent Text: {sb}");

            var parentLen = User32.GetClassName(hWndParent, sb, sb.Capacity);
            Console.WriteLine($"Parent ClassName: {sb}");
          }

          var instance = User32.GetWindowLong(hWnd, User32.GWW_HINSTANCE);
          var fileLen = Kernel32.GetModuleFileName((IntPtr)instance, sb, sb.Capacity);
          Console.WriteLine($"Path: {sb}");

          Tick?.Invoke(this, _eventArgs);
        }
      }
      else
      {
        //label1.Text = "N/A";
        //label2.Text = "N/A";
        //label3.Text = "N/A";
        //label4.Text = "N/A";
      }

      //User32.CURSORINFO ci = new User32.CURSORINFO();
      //if (User32.GetCursorInfo(out ci))
      //{
      //}
    }
  }
}
