
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace PatrioChatSupport
{
	public class MyButton : Button
	{
		public MyButton (Context context) :
			base (context)
		{
			Initialize ();
		}

		public MyButton (Context context, IAttributeSet attrs) :
			base (context, attrs)
		{
			Initialize ();
		}

		public MyButton (Context context, IAttributeSet attrs, int defStyle) :
			base (context, attrs, defStyle)
		{
			Initialize ();
		}

		void Initialize ()
		{
			Text = "This is my custom button";
			var typeface = Android.Graphics.Typeface.CreateFromAsset (Context.Assets, "FontAwesome.otf");
			//if (typeface == null)
			//	throw new Exception ("No font found");
		}
	}
}

