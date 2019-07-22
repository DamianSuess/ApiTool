/* Copyright Xeno Innovations, Inc. 2019
 * Date:    2019-7-22
 * Author:  Damian Suess
 * File:    WindowInfo.cs
 * Description:
 *  Mouse-over Window info
 */

using System;
using System.Text;
using System.Windows.Forms;
using Xeno.ApiTool.Api;

namespace Xeno.ApiTool.Tools
{
  public class WindowInfo
  {
    private IntPtr _hWndLast;
    private IntPtr _hWndParent;

    private User32.POINT _lastPoint = new User32.POINT();

    private WindowInfoEventsArgs _retArgs;

    // Threaded timer
    // private System.Timers.Timer _timer = new System.Timers.Timer();
    //
    // WinForms Timer
    private Timer _timer = new System.Windows.Forms.Timer();

    public WindowInfo()
    {
      // Threaded timer
      // _timer.Elapsed += new ElapsedEventHandler(OnMouseTimer);

      // WinForms timer
      _timer.Tick += OnMouseTimer;
      _timer.Interval = 100;
    }

    ~WindowInfo()
    {
      // _timer.Elapsed -= OnMouseTimer;
      _timer.Tick -= OnMouseTimer;
    }

    public delegate void TickHandler(WindowInfo info, WindowInfoEventsArgs e);

    public event TickHandler Tick;

    public int Interval
    {
      get => _timer.Interval;
      set => _timer.Interval = value;
    }

    public void Start()
    {
      _retArgs = new WindowInfoEventsArgs();
      _timer.Enabled = true;
    }

    public void Stop()
    {
      _timer.Enabled = false;
      _hWndLast = IntPtr.Zero;
    }

    private void OnMouseTimer(object sender, EventArgs e)
    {
      // System.Timers.Timer
      // private void OnMouseTimder(object sender, ElapsedEventArgs e)
      User32.POINT p = new User32.POINT();

      if (User32.GetCursorPos(out p))
      {
        StringBuilder sb = new StringBuilder(100);

        var hWnd = User32.WindowFromPoint(p);
        if (hWnd != _hWndLast)
        {
          _hWndLast = hWnd;
          _retArgs.hWnd = _hWndLast;

          var wtLen = User32.GetWindowText(hWnd, sb, sb.Capacity);
          _retArgs.WindowText = sb.ToString();
          Console.WriteLine($"Text: {sb}");
          // label3.Text = "Text: " + sb.ToString();

          var cnLen = User32.GetClassName(hWnd, sb, sb.Capacity);
          _retArgs.WindowClassName = sb.ToString();
          Console.WriteLine($"ClassName: {sb}");
          // label4.Text = "ClassName: " + sb.ToString();

          //var winStyle = GetWindowLong(hWndOver, GWL_STYLE);
          //Console.WriteLine($"WinStyle: {winStyle}");

          var hWndParent = User32.GetParent(hWnd);

          if (hWndParent != _hWndParent)
          {
            _hWndParent = hWndParent;
            _retArgs.hWndParent = hWndParent;
            Console.WriteLine($"Parent: {hWndParent}");

            //  GetWindowWord(hWnd, GWW_ID);  // GetWindowLong(..)

            User32.GetWindowText(hWndParent, sb, sb.Capacity);
            _retArgs.ParentText = sb.ToString();
            Console.WriteLine($"Parent Text: {sb}");

            var parentLen = User32.GetClassName(hWndParent, sb, sb.Capacity);
            _retArgs.ParentClassName = sb.ToString();
            Console.WriteLine($"Parent ClassName: {sb}");
          }

          var instance = User32.GetWindowLong(hWnd, User32.GWW_HINSTANCE);
          var fileLen = Kernel32.GetModuleFileName((IntPtr)instance, sb, sb.Capacity);
          _retArgs.WindowPath = sb.ToString();
          Console.WriteLine($"Path: {sb}");
        }

        if (_lastPoint.X != p.X || _lastPoint.Y != p.Y)
        {
          _lastPoint.X = p.X;
          _lastPoint.Y = p.Y;

          _retArgs.CursorPosition = _lastPoint;

          Console.WriteLine($"==================");
          Console.WriteLine($"X: {p.X}");
          Console.WriteLine($"Y: {p.Y}");

          Tick?.Invoke(this, _retArgs);
        }
      }
      else
      {
        _retArgs.Clear();
        Tick?.Invoke(this, _retArgs);
      }

      //User32.CURSORINFO ci = new User32.CURSORINFO();
      //if (User32.GetCursorInfo(out ci))
      //{
      //}
    }

    /*
      Process[] pc = Process.GetProcessesByName("Communicator");
      foreach (Process p in pc)
      {
        // Setting up the variable for the second argument for EnumProcessModules
        IntPtr[] hMods = new IntPtr[1024];

        GCHandle gch = GCHandle.Alloc(hMods, GCHandleType.Pinned); // Don't forget to free this later
        IntPtr pModules = gch.AddrOfPinnedObject();

        // Setting up the rest of the parameters for EnumProcessModules
        uint uiSize = (uint)(Marshal.SizeOf(typeof(IntPtr)) * (hMods.Length));
        uint cbNeeded = 0;

        if (EnumProcessModules(p.Handle, pModules, uiSize, out cbNeeded) == 1)
        {
          Int32 uiTotalNumberofModules = (Int32)(cbNeeded / (Marshal.SizeOf(typeof(IntPtr))));

          for (int i = 0; i < (int)uiTotalNumberofModules; i++)
          {
            StringBuilder strbld = new StringBuilder(1024);
            GetModuleFileNameEx(p.Handle, hMods[i], strbld, (uint)(strbld.Capacity));
            Console.WriteLine("File Path: " + strbld.ToString());
            Console.WriteLine();
          }
          Console.WriteLine("Number of Modules: " + uiTotalNumberofModules);
          Console.WriteLine();
        }

        // Must free the GCHandle object
        gch.Free();
      }
     */
  }

}
