using System;
using System.Data;
using System.IO;
using Boldseas.Models;
using Boldseas.Common.SqliteHelper;

namespace Boldseas.Repositorys
{
	public class UserDal
	{
		#region 私有对象
		private string _dburl=Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.Resources), "haierapp.db3");
		#endregion

		#region 更新操作
		/// <summary>
		/// Inserts the user.
		/// </summary>
		/// <param name="user">User.</param>
		/// <param name="dburl">Dburl.</param>
		public int InsertUser(Sys_User user)
		{
			SqliteHelper.SqliteInit(_dburl);
			return SqliteHelper.ExecuteNonQuery ("delete from sys_user where UserID=@UserID;" +
										"insert into sys_user(UserID,Name_CN,LoginName,PassWord,UserTypeID,DealerID,DealerName,LastLoginDate,IsValid) " +
										"values(@UserID,@Name_CN,@LoginName,@PassWord,@UserTypeID,@DealerID,@DealerName,@LastLoginDate,@IsValid)",
										new object[] {
											user.UserID,
											user.UserID,
											user.Name_CN,
											user.LoginName,
											user.PassWord,
											user.UserTypeID,
											user.DealerID,
											string.IsNullOrEmpty(user.DealerName)?"":user.DealerName,
											DateTime.Today.ToString (),
											true
										});
		}
		/// <summary>
		/// Updates the user.
		/// </summary>
		/// <param name="user">User.</param>
		public int UpdateUser(Sys_User user)
		{
			SqliteHelper.SqliteInit (_dburl);
			return SqliteHelper.ExecuteNonQuery (
				"update sys_user " +
				"set Name_CN=@Name_CN," +
				"LoginName=@LoginName," +
				"PassWord=@PassWord," +
				"UserTypeID=@UserTypeID," +
				"DealerID=@DealerID," +
				"DealerName=@DealerName," +
				"LastLoginDate=@LastLoginDate," +
				"IsValid=@IsValid " +
				"where UserID=@UserID",
				new object[] {
					user.UserID,
					user.Name_CN,
					user.LoginName,
					user.PassWord,
					user.UserTypeID,
					user.DealerID,
					string.IsNullOrEmpty(user.DealerName)?"":user.DealerName,
					DateTime.Today.ToString (),
					user.IsValid
				});
		}

		public int Logout(int userID)
		{
			SqliteHelper.SqliteInit (_dburl);
			return SqliteHelper.ExecuteNonQuery (
				"update sys_user " +
				"set IsValid=@IsValid " +
				"where UserID=@UserID ",
				new object[] {
					false,
					userID
				});
		}
		#endregion

		#region 查询操作
		/// <summary>
		/// Gets the last login user.
		/// </summary>
		/// <returns>The last login user.</returns>
		public Sys_User GetLastLoginUser()
		{
			Sys_User user = null;
			SqliteHelper.SqliteInit (_dburl);
			DataSet ds = SqliteHelper.ExecuteDataSet ("select UserID,Name_CN,LoginName,PassWord,UserTypeID,DealerID,DealerName,LastLoginDate,IsValid from sys_user where IsValid=1 order by LastLoginDate desc", null);
			if (ds != null && ds.Tables.Count > 0) {
				foreach (DataRow dr in ds.Tables[0].Rows) {
					user = new Sys_User ();
					user.UserID = int.Parse(dr ["UserID"].ToString());
					user.Name_CN = dr ["Name_CN"].ToString();
					user.LoginName = dr ["LoginName"].ToString();
					user.PassWord = dr ["PassWord"].ToString();
					user.DealerID = int.Parse(dr ["DealerID"].ToString());
					user.DealerName = dr ["DealerName"].ToString();
					user.UserTypeID = int.Parse(dr ["UserTypeID"].ToString());
					user.lastLoginDate = DateTime.Parse(dr ["LastLoginDate"].ToString());
					break;
				}
			}
			return user;
		}
		#endregion
	}
}

