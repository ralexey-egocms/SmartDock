using System;

namespace SmartDocTestApp.Core
{
	public interface IWebService
	{
		LoginObject LogIn (string username, string password);

		MenuData GetMenuData (LoginObject currentUser);
	}
}

