using Newtonsoft.Json;
using SmartDocTestApp.Core.Services;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace SmartDocTestApp.Core.Helpers
{
	public static class JSONhelper
	{
		public static string SerializeObject<T> (T obj)
		{
			return JsonConvert.SerializeObject (obj);
		}

		public static T DeserializeObject<T> (string json)
		{
			return JsonConvert.DeserializeObject<T> (json);
		}

		public static Task<T> GetJsonAsync<T> (this HttpWebRequest request)
		{
			var tcs = new TaskCompletionSource<T> ();

			try {
				request.BeginGetResponse (iar => {
					try {
						var response = (HttpWebResponse)request.EndGetResponse (iar);
						if (response.StatusCode != HttpStatusCode.OK)
							throw new Exception (String.Format ("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription));

						string str = String.Empty;
						using (Stream receiveStream = response.GetResponseStream ()) {
							using (StreamReader sr = new StreamReader (receiveStream)) {
								str = sr.ReadToEnd ();
							}
						}

						tcs.SetResult (JsonConvert.DeserializeObject<T> (str));
					} catch (Exception exc) {
						LoggingService.Report (exc, LoggingService.Severity.Error);
						tcs.SetResult (default(T));
					}
				}, null);
			} catch (Exception exc) {
				LoggingService.Report (exc, LoggingService.Severity.Error);
				return null;
			}

			return tcs.Task;
		}
	}
}