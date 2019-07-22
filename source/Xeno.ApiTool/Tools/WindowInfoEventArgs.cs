/* Copyright Xeno Innovations, Inc. 2019
 * Date:    2019-7-22
 * Author:  Damian Suess
 * File:    WindowInfoEventArgs.cs
 * Description:
 *  Event Arguments
 */

using System;
using Xeno.ApiTool.Api;

namespace Xeno.ApiTool.Tools
{
  public class WindowInfoEventsArgs : EventArgs
  {
    public WindowInfoEventsArgs()
    {
      Clear();
    }

    public User32.POINT CursorPosition { get; set; }

    public IntPtr hWnd { get; set; }

    public IntPtr hWndParent { get; set; }

    public string ParentClassName { get; set; }

    public string ParentText { get; set; }

    public string WindowClassName { get; set; }

    public string WindowPath { get; set; }

    public string WindowText { get; set; }

    public void Clear()
    {
      CursorPosition = new User32.POINT
      {
        X = 0,
        Y = 0
      };

      hWnd = (IntPtr)0;

      WindowText = string.Empty;
      WindowClassName = "N/A";
      WindowPath = "N/A";

      hWndParent = (IntPtr)0;
      ParentText = "N/A";
      ParentClassName = "N/A";
    }
  }
}
