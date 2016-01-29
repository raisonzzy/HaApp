using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Collections.Generic;
using System.Drawing;

namespace HAFIP
{
	partial class DiyControllor : UIViewController
	{

		#region 控件定义

		UIButton HouseType_1_btn;
		UIButton HouseType_2_btn;
		UIButton HouseType_3_btn;
		UIButton HouseType_4_btn;
		UIButton HouseType_5_btn;
		UIButton HouseType_6_btn;
		UIButton HouseType_7_btn;
		UIButton HouseType_8_btn;
		UIButton HouseType_9_btn;
		UIButton HouseType_10_btn;
		UIButton HouseType_11_btn;

		List<UIButton> HoutypeBtns;


		#endregion

		public DiyControllor (IntPtr handle) : base (handle)
		{
		}

		public DiyControllor () : base ()
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			this.View.BackgroundColor = UIColor.FromRGB (230, 236, 245);

			HouseType_1_btn = new UIButton (new RectangleF (500, 55, 50, 50));
			HouseType_2_btn = new UIButton (new RectangleF (400, 115, 50, 50));
			HouseType_3_btn = new UIButton (new RectangleF (300, 175, 50, 50));
			HouseType_4_btn = new UIButton (new RectangleF (600, 115, 50, 50));
			HouseType_5_btn = new UIButton (new RectangleF (700, 175, 50, 50));
			HouseType_6_btn = new UIButton (new RectangleF (200, 235, 50, 50));
			HouseType_7_btn = new UIButton (new RectangleF (800, 295, 50, 50));
			HouseType_8_btn = new UIButton (new RectangleF (300, 355, 50, 50));
			HouseType_9_btn = new UIButton (new RectangleF (400, 415, 50, 50));
			HouseType_10_btn = new UIButton (new RectangleF (300, 355, 50, 50));
			HouseType_11_btn = new UIButton (new RectangleF (400, 415, 50, 50));

			HoutypeBtns = new List<UIButton> () {

				HouseType_1_btn,
				HouseType_2_btn,
				HouseType_3_btn,
				HouseType_4_btn,
				HouseType_5_btn,
				HouseType_6_btn,
				HouseType_7_btn,
				HouseType_8_btn,
				HouseType_9_btn,
				HouseType_10_btn,
				HouseType_11_btn 
			};



			for (int i = 0; i < HoutypeBtns.Count; i++) {
				HoutypeBtns [i].SetTitle ((i + 1).ToString (), UIControlState.Normal);
				HoutypeBtns [i].SetTitleColor (UIColor.Blue, UIControlState.Normal);
			}


			this.View.AddSubviews (HoutypeBtns.ToArray ());


		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}
