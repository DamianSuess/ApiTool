/* Copyright Xeno Innovations, Inc. 2019
 * Date:    2019-7-22
 * Author:  Damian Suess
 * File:    MainForm.cs
 * Description:
 *  API Tool main window
 *
 * Goals/Resources:
 *  - Windows API Copy/Paste - aka pInvoke.net utility
 *  - Hot Key Hooks - https://www.codeproject.com/Articles/28064/Global-Mouse-and-Keyboard-Library
 *  - Capture Desktop - https://www.codeproject.com/Articles/12850/Capturing-the-Desktop-Screen-with-the-Mouse-Cursor
 *  - Monetize - https://www.codeproject.com/Articles/5162896/Bring-Food-to-the-Table
 *    - Support this app
 */

using System;
using System.Text;
using System.Timers;
using System.Windows.Forms;
using Xeno.ApiTool.Api;

namespace Xeno.ApiTool
{
  public partial class MainForm : Form
  {
    private static IntPtr _hWndLast;
    private IntPtr _hWndParent;
    private System.Timers.Timer _timer = new System.Timers.Timer();
    private int _x;
    private int _y;

    public MainForm()
    {
      InitializeComponent();

      _timer.Elapsed += new ElapsedEventHandler(OnMouseTimer);
      _timer.Interval = 500;
      _timer.Enabled = true;
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
    }

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
        }
      }
      else
      {
        label1.Text = "N/A";
        label2.Text = "N/A";
        label3.Text = "N/A";
        label4.Text = "N/A";
      }

      //User32.CURSORINFO ci = new User32.CURSORINFO();
      //if (User32.GetCursorInfo(out ci))
      //{
      //}
    }

    #region Helpers

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

    #endregion Helpers
  }
}
