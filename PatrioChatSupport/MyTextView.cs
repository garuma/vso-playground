
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
	public class MyTextView : TextView
	{
		public MyTextView (Context context) :
			base (context)
		{
			Initialize ();
		}

		public MyTextView (Context context, IAttributeSet attrs) :
			base (context, attrs)
		{
			Initialize ();
		}

		public MyTextView (Context context, IAttributeSet attrs, int defStyle) :
			base (context, attrs, defStyle)
		{
			Initialize ();
		}

		void Initialize ()
		{
			Text = "A TextView straight from Xamarin.Android: ";
		}
	}
}

