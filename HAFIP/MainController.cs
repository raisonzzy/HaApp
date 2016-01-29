using System;
using System.CodeDom.Compiler;
using UIKit;
using Foundation;

using Boldseas.Process;
using Boldseas.Models;

//Components
using MBProgressHUD;

namespace HAFIP
{
	partial class MainController : UIViewController
	{
		#region 定义控件

		ViewController LoginView;
		private UIImageView imgView;
		private UIButton btnGoMain;
		private UIButton btnLogout;
		//加载对象
		private MTMBProgressHUD hud;

		#endregion

		#region 私有对象

		UserProcess userPro;

		#endregion

		#region 页面初始化

		public MainController (IntPtr handle) : base (handle)
		{
		}

		public MainController () : base ()
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			userPro = new UserProcess ();

			hud = new MTMBProgressHUD (this.View) {
				LabelText = "Waiting...",
				RemoveFromSuperViewOnHide = true,
				DimBackground = true
			};
			this.View.AddSubview (hud);

			this.NavigationController.NavigationBarHidden = true;
			this.View.BackgroundColor = UIColor.FromRGB (230, 236, 245);

			imgView = new UIImageView (new CoreGraphics.CGRect (0, 0, this.View.Frame.Width, this.View.Frame.Height));
			imgView.Image = UIImage.FromFile ("System/bg.png");

			btnGoMain = new UIButton (UIButtonType.System);
			btnGoMain.Frame = new CoreGraphics.CGRect (this.View.Frame.Width / 2 - 100, this.View.Frame.Height / 2 + 150, 200, 50);
			btnGoMain.SetTitle ("开启DIY定制", UIControlState.Normal);
			btnGoMain.SetTitleColor (UIColor.White, UIControlState.Normal);
			btnGoMain.Font = UIFont.FromName ("Helvetica-Bold", 30f);
			btnGoMain.TouchUpInside += btnGoMain_TouchUpInside;

			btnLogout = new UIButton (UIButtonType.System);
			btnLogout.SetImage (UIImage.FromFile ("System/椭圆 1.png"), UIControlState.Normal);
			btnLogout.Frame = new CoreGraphics.CGRect (980, 25, 30, 30);
			btnLogout.BackgroundColor = UIColor.White;
			btnLogout.TouchUpInside += BtnLogout_TouchUpInside;

			this.View.AddSubviews (imgView, btnGoMain, btnLogout);
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		#endregion

		#region 开启DIY定制

		/// <summary>
		/// Buttons the go main touch up inside.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private void btnGoMain_TouchUpInside (object sender, EventArgs e)
		{
			DiyControllor diy = new DiyControllor ();
			this.NavigationController.PushViewController (diy, true);
		}

		#endregion

		#region 退出登录

		private void BtnLogout_TouchUpInside (object sender, EventArgs e)
		{
			hud.Show (true);
			Sys_User user = SystemObject.User;
			userPro.Logout (user.UserID);
			SystemObject.User = null;
			LoginView = new ViewController ();
			this.NavigationController.PushViewController (LoginView, true);
		}

		#endregion
	}
}
