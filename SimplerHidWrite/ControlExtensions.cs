// Copyright (c) 2016-2017 Ilium VR, Inc.
// Licensed under the MIT License - https://raw.github.com/IliumVR/SimplerHidWrite/master/LICENSE

using System.Reflection;
using System.Windows.Forms;

namespace IliumVR.Tools.SimplerHidWrite
{
	public static class ControlExtensions
	{
		public static void MakeDoubleBuffered(this Control control, bool enable)
		{
			var doubleBufferPropertyInfo = control.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
			doubleBufferPropertyInfo.SetValue(control, enable, null);
		}
	}
}
