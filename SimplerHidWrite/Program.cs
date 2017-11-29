// Copyright (c) 2016-2017 Ilium VR, Inc.
// Licensed under the MIT License - https://raw.github.com/IliumVR/SimplerHidWrite/master/LICENSE

using System;
using System.Windows.Forms;

namespace IliumVR.Tools.SimplerHidWrite
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
	}
}
