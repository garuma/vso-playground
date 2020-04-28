
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
	public class MuButton : Button
	{
		static int foo = 1;

		public MuButton (Context context) :
			base (context)
		{
			Initialize ();
		}

		public MuButton (Context context, IAttributeSet attrs) :
			base (context, attrs)
		{
			Initialize ();
		}

		public MuButton (Context context, IAttributeSet attrs, int defStyle) :
			base (context, attrs, defStyle)
		{
			Initialize ();
		}

		void Initialize ()
		{
			throw new Exception ("This is a description test for a classic exception in a constructor");
		}
	}
}

