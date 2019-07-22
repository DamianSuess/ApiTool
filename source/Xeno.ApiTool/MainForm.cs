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
 *  - Support this app - https://www.codeproject.com/Articles/5162896/Bring-Food-to-the-Table
 *  - Windows hook - https://stackoverflow.com/questions/9665579/setting-up-hook-on-windows-messages
 */

using System;
using System.Windows.Forms;
using Xeno.ApiTool.Tools;

namespace Xeno.ApiTool
{
  public partial class MainForm : Form
  {
    private WindowInfo _wi = new WindowInfo();

    public MainForm()
    {
      InitializeComponent();

      _wi.Interval = 100;
      _wi.Tick += OnWindowInfoTick;
      _wi.Start();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
    }

    private void OnWindowInfoTick(WindowInfo info, WindowInfoEventsArgs e)
    {
      // Threaded Timer
      //label1.Invoke((MethodInvoker)(() => label1.Text = e.hWnd.ToString()));
      //label2.Invoke((MethodInvoker)(() => label2.Text = e.WindowText));
      //label3.Invoke((MethodInvoker)(() => label3.Text = e.WindowClassName));
      //label4.Invoke((MethodInvoker)(() => label4.Text = e.ParentText));
      //label5.Invoke((MethodInvoker)(() => label5.Text = e.ParentClassName));

      // WinForms timer
      lblCursorXY.Text = $"{e.CursorPosition.X}, {e.CursorPosition.Y}";

      lblWindowHwnd.Text = "0x" + e.hWnd.ToString("X2");
      lblWindowText.Text = e.WindowText;
      lblWindowClass.Text = e.WindowClassName;
      lblWindowParentText.Text = e.ParentText;
      lblWindowParentClass.Text = e.ParentClassName;
      lblWindowPath.Text = e.WindowPath;
    }
  }
}
