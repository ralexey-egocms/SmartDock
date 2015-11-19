using System;
using System.Threading.Tasks;

namespace SmartDocTestApp.Core
{
	public interface IWebService
	{
		//LoginObject LogIn(string username, string password);

		//MenuData GetMenuData(LoginObject currentUser);

		Task<LoginObject> LogInWP (string username, string password);

		Task<MenuData> GetMenuDataWP (LoginObject currentUser);
	}
}