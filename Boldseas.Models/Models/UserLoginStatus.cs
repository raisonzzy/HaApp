using System;

namespace Boldseas.Models
{
	public class UserLoginStatus
	{



		public Sys_User LoginUser{ get; set; }

		public LoginStatus LoginStatus{ get; set; }
	}

	public class LoginStatus
	{
		public bool Status{ get; set; }

		public string ErrorMessage{ get; set; }
	}
}

