using Foundation;
using UIKit;
using System;
using MBProgressHUD;
using Boldseas.Models;
using Boldseas.Process;

namespace HAFIP
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
	[Register ("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow _window;

		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
//			if (1 == 1) {
//				UIAlertView alert = new UIAlertView ();
//				alert.Title = "升级提醒";
//				alert.Message="发现有新版本可以更新，请尽快更新，否则影响正常使用";
//				alert.AddButton ("进行升级");
//				alert.AddButton ("取消");
//				alert.Dismissed += Alert_Dismissed;
//				alert.Show ();
//			}

			_window = new UIWindow (UIScreen.MainScreen.Bounds);
			UINavigationController _nva = new UINavigationController ();
			_nva.SetNavigationBarHidden (true, false);

			//自动登录
			Sys_User lastLoginUser = new UserProcess ().GetLastLoginUser ();
			if (lastLoginUser != null) {
				//系统静态存储
				SystemObject.User = lastLoginUser;
				//更新登录状态到数据库?

				//跳转到主页面

				_nva.PushViewController (new MainController (), true);
			} else {
				_nva.PushViewController (new ViewController (), true);
			}



			_window.RootViewController = _nva;
			_window.MakeKeyAndVisible ();
			return true;
		}

		private void Alert_Dismissed (object sender, UIButtonEventArgs e)
		{
			nint btnIndex = e.ButtonIndex;
			if (btnIndex == 0) {
				NSUrl url = new NSUrl ("https://www.baidu.com");
				if (UIApplication.SharedApplication.CanOpenUrl (url))
					UIApplication.SharedApplication.OpenUrl (url);
			}
		}

		public override void OnResignActivation (UIApplication application)
		{
			// Invoked when the application is about to move from active to inactive state.
			// This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
			// or when the user quits the application and it begins the transition to the background state.
			// Games should use this method to pause the game.
		}

		public override void DidEnterBackground (UIApplication application)
		{
			// Use this method to release shared resources, save user data, invalidate timers and store the application state.
			// If your application supports background exection this method is called instead of WillTerminate when the user quits.
		}

		public override void WillEnterForeground (UIApplication application)
		{
			// Called as part of the transiton from background to active state.
			// Here you can undo many of the changes made on entering the background.
		}

		public override void OnActivated (UIApplication application)
		{
			// Restart any tasks that were paused (or not yet started) while the application was inactive. 
			// If the application was previously in the background, optionally refresh the user interface.
		}

		public override void WillTerminate (UIApplication application)
		{
			// Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
		}
	}
}


