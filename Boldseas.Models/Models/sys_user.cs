using System;

namespace Boldseas.Models
{
	/// <summary>
	/// Sys user.
	/// </summary>
	public class Sys_User
	{
		public Sys_User ()
		{
		}

		/// <summary>
		/// Gets or sets the userid.
		/// </summary>
		/// <value>The user I.</value>
		public int UserID{ get; set; }

		/// <summary>
		/// Gets or sets the name_cn.
		/// </summary>
		/// <value>The name C.</value>
		public string Name_CN{ get; set; }

		/// <summary>
		/// Gets or sets the loginname.
		/// </summary>
		/// <value>The name of the login.</value>
		public string LoginName{ get; set; }

		/// <summary>
		/// Gets or sets the password.
		/// </summary>
		/// <value>The pass word.</value>
		public string PassWord{ get; set; }

		/// <summary>
		/// Gets or sets the user type ID.
		/// </summary>
		/// <value>The user type ID.</value>
		public int UserTypeID{ get; set; }

		/// <summary>
		/// Gets or sets the dealer ID.
		/// </summary>
		/// <value>The dealer I.</value>
		public int  DealerID{ get; set; }

		/// <summary>
		/// Gets or sets the name of the dealer.
		/// </summary>
		/// <value>The name of the dealer.</value>
		public string DealerName{ get; set; }

		/// <summary>
		/// Gets or sets the last login date.
		/// </summary>
		/// <value>The last login date.</value>
		public DateTime lastLoginDate{ get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this instance is valid.
		/// </summary>
		/// <value><c>true</c> if this instance is valid; otherwise, <c>false</c>.</value>
		public bool IsValid{ get; set; }
	}
}

