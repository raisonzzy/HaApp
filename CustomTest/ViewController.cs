using System;
using System.IO;
using UIKit;
using Boldseas.Common;


namespace CustomTest
{
	public partial class ViewController : UIViewController
	{
		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			//SqliteHelper.SqliteInit (Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.Personal), "AppData.db3"));
//
//			int	status = Convert.ToInt32 (SqliteHelper.ExecuteScalar ("select ID from Cus where ID=10", null));
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

