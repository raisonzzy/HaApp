using System;
using Boldseas.Models;

namespace HAFIP
{
	public static class SystemObject
	{
		private static Sys_User _user;

		public static Sys_User User {
			get {
				return _user;
			}
			set {
				_user = value;
			}
		}
	}
}

