using System;
using System.IO;
using System.Net;
using System.Data;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Collections;
using System.Windows.Forms;
//using System.ComponentModel;
//using System.Collections.Generic;
//using System.Runtime.InteropServices;
using Comm;

namespace Comm
{
	public class Startup
	{
		public static void Main()
		{
			bool running = true;
			CommWin window = new CommWin();

			window.FormClosing += delegate { running = false; };
			
			while(running)
				Application.DoEvents();
		}
	}
}
