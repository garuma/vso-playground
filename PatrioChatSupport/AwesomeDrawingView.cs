
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace PatrioChatSupport
{
	public class AwesomeDrawingView : View
	{
		public AwesomeDrawingView (Context context) :
			base (context)
		{
			Initialize ();
		}

		public AwesomeDrawingView (Context context, IAttributeSet attrs) :
			base (context, attrs)
		{
			Initialize ();
		}

		public AwesomeDrawingView (Context context, IAttributeSet attrs, int defStyle) :
			base (context, attrs, defStyle)
		{
			Initialize ();
		}

		void Initialize ()
		{
		}

		protected override void OnDraw (Canvas canvas)
		{
			throw new Exception ("I'm too awesome to draw");
		}
	}
}
