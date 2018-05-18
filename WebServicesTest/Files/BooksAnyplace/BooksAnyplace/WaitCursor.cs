using System;
using System.Runtime.InteropServices;

namespace BooksAnyplace
{
	/// <summary>
	/// Show or remove wait cursor using COM interop.
	/// </summary>
	public class WaitCursor
	{
    [DllImport("coredll.dll")]
    private static extern int LoadCursor(int zeroValue, int cursorID);
    [DllImport("coredll.dll")]
    private static extern int SetCursor(int cursorHandle);
    
    public static void Show(bool ShowCursor)
    {
      int cursorHandle = 0;

      if (ShowCursor)
        cursorHandle = LoadCursor(0, 32514); // IDC_WAIT from WINUSER.H

      SetCursor(cursorHandle);
    }
  }
}
