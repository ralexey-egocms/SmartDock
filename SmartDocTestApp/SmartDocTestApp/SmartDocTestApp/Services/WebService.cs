using System;
using SmartDocTestApp.Core.Helpers;
using SmartDocTestApp.Core.Services;
using System.Collections.Generic;

namespace SmartDocTestApp.Core
{
	public class WebService: IWebService
	{
		#region IWebService implementation

		public LoginObject LogIn (string username, string password)
		{
			try {
				return AsyncHelper.RunSync<LoginObject> (() => {
					return RESTinwork.Instance.Get<LoginObject> (RequestMethod.Authenticate, new Dictionary<RequestParams, string> { {
							RequestParams.userName,
							username
						}, {
							RequestParams.password,
							password
						},
					}, RequestController.Login);
				});
			} catch (Exception ex) {
				LoggingService.Report (ex, LoggingService.Severity.Error);
				throw;
			}
		}


		public MenuData GetMenuData (LoginObject currentUser)
		{
			try {
				return AsyncHelper.RunSync<MenuData> (() => {
					return RESTinwork.Instance.Get<MenuData> (RequestMethod.ForUser, new Dictionary<RequestParams, string> { {
							RequestParams.userId,
							currentUser.UserId.ToString ()
						}, {
							RequestParams.token,
							currentUser.Token
						},
					}, RequestController.Menu);
				});
			} catch (Exception ex) {
				LoggingService.Report (ex, LoggingService.Severity.Error);
				throw;
			}
		}

		#endregion
		
	}
}

