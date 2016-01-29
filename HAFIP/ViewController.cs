//System
using System;
using System.IO;
using Foundation;
using UIKit;
using ObjCRuntime;

//Solution
using Boldseas.Process;
using Boldseas.Models;

//Components
using MBProgressHUD;

namespace HAFIP
{
	public partial class ViewController : UIViewController
	{
		#region 定义控件

		MainController main;
		private UIImageView imgView;
		private UIView loginView;
		private UILabel lblLogin;
		private UITextField txtLoginName;
		private UITextField txtPassword;
		private UIButton btnLogin;
		//加载对象
		private MTMBProgressHUD hud;

		#endregion

		#region 私有变量

		UserProcess userPro;
		private bool IskeyboardShow = false;

		#endregion

		#region Login初始化

		public ViewController (IntPtr handle) : base (handle)
		{
			
		}

		public ViewController () : base ()
		{

		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			//用户相关处理类
			userPro = new UserProcess ();
			//初始化加载控件
			hud = new MTMBProgressHUD (this.View) {
				LabelText = "Loading...",
				RemoveFromSuperViewOnHide = true,
				DimBackground = true
			};
			this.View.AddSubview (hud);
			hud.Show (true);
			//整体view背景色
			this.View.BackgroundColor = UIColor.Gray;
			// Perform any additional setup after loading the view, typically from a nib.
			imgView = new UIImageView (new CoreGraphics.CGRect (0, 0, this.View.Frame.Width, this.View.Frame.Height));
			imgView.Image = UIImage.FromFile ("Login/Login_background.jpg");
			//登录背景
			loginView = new UIView (new CoreGraphics.CGRect (550, 250, 350, 300));
			loginView.Alpha = (nfloat)0.45;
			loginView.BackgroundColor = UIColor.FromRGB ((nfloat)249, (nfloat)249, (nfloat)249);
			//登录标签
			lblLogin = new UILabel (new CoreGraphics.CGRect (550, 280, this.loginView.Frame.Width, 30));
			lblLogin.Text = "登录";
			lblLogin.TextAlignment = UITextAlignment.Center;
			//用户名
			txtLoginName = new UITextField (new CoreGraphics.CGRect (580, 330, this.loginView.Frame.Width - 60, 50));
			txtLoginName.BackgroundColor = UIColor.White;
			txtLoginName.TextColor = UIColor.Gray;
			txtLoginName.Placeholder = " 用户名";
			//密码
			txtPassword = new UITextField (new CoreGraphics.CGRect (580, 400, this.loginView.Frame.Width - 60, 50));
			txtPassword.BackgroundColor = UIColor.White;
			txtPassword.TextColor = UIColor.Gray;
			txtPassword.SecureTextEntry = true;
			txtPassword.Placeholder = " 密码";
			//登录按钮
			btnLogin = new UIButton (UIButtonType.System);
			btnLogin.Frame = new CoreGraphics.CGRect (580, 470, this.loginView.Frame.Width - 60, 50);
			btnLogin.SetTitle ("开始定制DIY", UIControlState.Normal);
			btnLogin.SetTitleColor (UIColor.FromRGB (186, 224, 249), UIControlState.Normal);
			btnLogin.BackgroundColor = UIColor.FromRGB (84, 138, 227);
			btnLogin.TouchUpInside += BtnLogin_TouchUpInside;
			//添加控件
			this.View.AddSubviews (imgView, loginView, lblLogin, txtLoginName, txtPassword, btnLogin);
			//键盘事件
			UIKeyboard.Notifications.ObserveWillShow ((s, e) => {
				if (!IskeyboardShow) {
					CoreGraphics.CGRect kbdFrame = e.FrameEnd;
					CoreGraphics.CGRect viewFrame = this.View.Frame;
					viewFrame.Y = viewFrame.Y - kbdFrame.Height + 180;
					this.View.Frame = viewFrame;
					IskeyboardShow = true;
				}
			});
			UIKeyboard.Notifications.ObserveWillHide ((s, e) => {
				CoreGraphics.CGRect kbdFrame = e.FrameEnd;
				CoreGraphics.CGRect viewFrame = this.View.Frame;
				viewFrame.Y = viewFrame.Y + kbdFrame.Height - 180;
				this.View.Frame = viewFrame;
				IskeyboardShow = false;
			});


		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		#endregion

		#region 登录按钮事件

		/// <summary>
		/// Buttons the login touch up inside.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private void BtnLogin_TouchUpInside (object sender, EventArgs e)
		{
			string username = this.txtLoginName.Text;
			string password = this.txtPassword.Text;

			if (CheckLogin (username, password)) {
				//loading
//				hud = new MTMBProgressHUD (this.View) {
//					LabelText = "Waiting...",
//					RemoveFromSuperViewOnHide = true,
//					DimBackground = true
//				};
//				this.View.AddSubview (hud);

				//hud.DidHide += HandleDidHide;
				hud.LabelText = "Waiting...";
				hud.Show (true);
				//用户登录
				AccountAPI accountClient = new AccountAPI ();

				UserLoginStatus res = accountClient.UserLogin (username, password);

				if (res.LoginStatus.Status) {
					this.View.EndEditing (true);
					//系统静态存储
					SystemObject.User = res.LoginUser;
					//添加到本地数据库
					res.LoginUser.PassWord = password;
					UserProcess userPro = new UserProcess ();
					userPro.UserInsert (res.LoginUser);

					//跳转到主页面
					main = new MainController ();

					this.NavigationController.PushViewController (main, true);

				} else {
					UIAlertView alert = new UIAlertView ();
					alert = new UIAlertView ();
					alert.Title = "登录提醒";
					alert.Message = "登录失败";
					alert.AddButton ("确定");
					alert.Show ();
				}
				hud.Hide (true);
			}

		}

		#endregion

		#region 登录验证

		/// <summary>
		/// Checks the login.
		/// </summary>
		/// <returns><c>true</c>, if login was checked, <c>false</c> otherwise.</returns>
		private bool CheckLogin (string username, string password)
		{
			bool res = true;
			UIAlertView alert;

			if (string.IsNullOrEmpty (username)) {
				res = false;
				alert = new UIAlertView ();
				alert.Title = "登录提醒";
				alert.Message = "请输入用户名";
				alert.AddButton ("确定");
				alert.Show ();
			} else if (string.IsNullOrEmpty (password)) {
				res = false;
				alert = new UIAlertView ();
				alert.Title = "登录提醒";
				alert.Message = "请输入密码";
				alert.AddButton ("确定");
				alert.Show ();
			} 
			return res;
		}

		#endregion

		#region 加载完成后触发

		void HandleDidHide (object sender, EventArgs e)
		{
			hud.RemoveFromSuperview ();
			hud = null;
		}

		#endregion
	}
}

