using System;
using UIKit;

namespace HAFIP
{
	public class AlertTool
	{
		private UIAlertView _alert;

		public AlertTool (string Title,string Message,string CancelButtonTitle)
		{
			_alert = new UIAlertView (Title, Message, null, CancelButtonTitle, null);
		}
		public void Show()
		{
			_alert.Show ();
		}
	}
}

