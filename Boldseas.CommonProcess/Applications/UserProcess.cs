using System;
using System.Data;
using Boldseas.Repositorys;
using Boldseas.Models;

namespace Boldseas.Process
{
	public class UserProcess
	{
		#region 私有对象
		private UserDal userDal=new UserDal ();
		#endregion

		public UserProcess ()
		{
			
		}
		#region 更新相关
		public int UserInsert(Sys_User user)
		{
			return userDal.InsertUser (user);
		}
		public int UpdateUser(Sys_User user)
		{
			return userDal.UpdateUser (user);
		}
		public int Logout(int userID)
		{
			return userDal.Logout (userID);
		}
		#endregion

		#region 查询操作
		/// <summary>
		/// Gets the last login user.
		/// </summary>
		/// <returns>The last login user.</returns>
		public Sys_User GetLastLoginUser()
		{
			return userDal.GetLastLoginUser ();
		}
		#endregion
	}
}

