/* Copyright Xeno Innovations, Inc. 2019
 * Date:    2019-7-22
 * Author:  Damian Suess
 * File:    Kernel32.cs
 * Description:
 *  Kernel32.dll
 */

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Xeno.ApiTool.Api
{
  public class Kernel32
  {
    [DllImport("kernel32.dll", SetLastError = true)]
    [PreserveSig]
    public static extern uint GetModuleFileName([In] IntPtr hModule, [Out] StringBuilder lpFilename, [In] [MarshalAs(UnmanagedType.U4)] int nSize);

    [DllImport("Kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern bool GetModuleHandleEx(UInt32 dwFlags, string lpModuleName, out IntPtr phModule);
  }
}
