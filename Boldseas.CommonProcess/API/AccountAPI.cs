using System;
using Boldseas.Common.HttpHelper;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Boldseas.Models;



namespace Boldseas.Process
{
	public class AccountAPI
	{
		static readonly  string domin = "http://112.124.18.248:9009/api";
		static readonly  HttpHelper _httpHelper = new HttpHelper ();

		public AccountAPI ()
		{
		}


		/// <summary>
		/// Users login.
		/// </summary>
		/// <returns>The login.</returns>
		/// <param name="userName">User name.</param>
		/// <param name="PassWord">Pass word.</param>
		public  UserLoginStatus UserLogin (string userName, string PassWord)
		{
			var url = domin + "/appuserlogin/LoginName={0}/PassWord={1}";
			url = string.Format (url, userName, PassWord);
			HttpResult result = _httpHelper.GetHtml (new HttpItem () {
				URL = url,
				ResultType = ResultType.Byte
			});
			string sss = result.Html;
			using (MemoryStream ms = new MemoryStream (result.ResultByte)) {
				DataContractJsonSerializer serializer = new DataContractJsonSerializer (typeof(UserLoginStatus));
				ms.Position = 0;
				UserLoginStatus loginUser = (UserLoginStatus)serializer.ReadObject (ms);
				return loginUser;
			}
		}

	}
}

