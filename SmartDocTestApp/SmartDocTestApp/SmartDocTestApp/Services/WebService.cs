using System;
using SmartDocTestApp.Core.Helpers;
using SmartDocTestApp.Core.Services;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SmartDocTestApp.Core
{
	public class WebService : IWebService
	{
		#region IWebService implementation

		public async Task<LoginObject> LogInWP (string username, string password)
		{
			try {
				HttpWebRequest request = HttpWebRequest.Create (
					                         String.Format ("https://www.smartdok.no/PublicAPI/login/authenticate?userName={0}&password={1}", username, password)) as HttpWebRequest;

				return await request.GetJsonAsync<LoginObject> () as LoginObject;
			} catch (Exception ex) {
				LoggingService.Report (ex, LoggingService.Severity.Error);
				throw;
			}
		}

		public async Task<MenuData> GetMenuDataWP (LoginObject currentUser)
		{
			try {
				var controller = RequestController.Menu;
				var method = RequestMethod.ForUser;
				var parametrs = new Dictionary<RequestParams, string> { {
						RequestParams.userId,
						currentUser.UserId.ToString ()
					}, {
						RequestParams.token,
						currentUser.Token
					}
				};

				var url = string.Format (
					          "https://www.smartdok.no/PublicAPI{0}/{1}{2}",
					          controller != RequestController.None ? "/" + controller.ToString ().ToLower () : "",
					          method.ToString ().ToLower (),
					          RESTinwork.CreateParametrsString (parametrs));

				HttpWebRequest request = HttpWebRequest.Create (url) as HttpWebRequest;

				return await request.GetJsonAsync<MenuData> () as MenuData;
			} catch (Exception ex) {
				LoggingService.Report (ex, LoggingService.Severity.Error);
				throw;
			}
		}

		#endregion
	}
}