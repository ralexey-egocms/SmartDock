using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Newtonsoft.Json;
using System.Net;


using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net.Http;
using SmartDocTestApp.Core.Services;

namespace SmartDocTestApp.Core.Helpers
{
	public enum RequestParams
	{
		userName,
		password,
		userId,
		token
	}

	public enum RequestMethod
	{
		Authenticate,
		ForUser
	}

	public enum RequestController
	{
		Login,
		Menu,
		None
	}

	public class RESTinwork
	{
		static RESTinwork _instance = new RESTinwork ();

		public static RESTinwork Instance {
			get { return RESTinwork._instance; }
		}

		string urlTemplate = "https://www.smartdok.no/PublicAPI{0}/";

		public string UrlTemplate {
			get {
				return urlTemplate + "{1}{2}";
			}
		}

		static string CreateParametrsString (Dictionary<RequestParams, string> parametrs)
		{
			if (parametrs != null || parametrs.Count > 0) {
				string paramData = "?";
				foreach (var key in parametrs.Keys) {
					paramData += WebUtility.UrlEncode (key.ToString ()) + "=" + WebUtility.UrlEncode (parametrs [key]) + "&";
				}
				return paramData;
			} else {
				return "";
			}
		}

		public async Task<T> Get<T> (RequestMethod method, Dictionary<RequestParams, string> parametrs = null, RequestController controller = RequestController.None)
		{
			string content = "";
			try {
				string typename = typeof(T).Name;
				using (var client = new HttpClient ()) {
					client.BaseAddress = new Uri (urlTemplate);
					client.Timeout = new TimeSpan (0, 0, 30);
					var url = string.Format (UrlTemplate, controller != RequestController.None ? "/" + controller.ToString ().ToLower () : "", method.ToString ().ToLower (), CreateParametrsString (parametrs));
//					var raw = new FormUrlEncodedContent (parametrs.ToDictionary (a => a.Key.ToString (), b => b.Value));
					var response = await client.GetAsync (url);

					if (response.StatusCode != HttpStatusCode.OK) {
						Debug.WriteLine (String.Format ("Error fetching data. Server returned status code: {0}", response.StatusCode));
						LoggingService.Report (null, new Dictionary<string, string> { {
								"Error fetching data. Server returned status code",
								response.StatusCode.ToString ()
							}
						}, LoggingService.Severity.Error);
					}
					using (StreamReader reader = new StreamReader ((await response.Content.ReadAsStreamAsync ()), Encoding.GetEncoding ("windows-1252"))) {
						content = reader.ReadToEnd ();
						if (string.IsNullOrWhiteSpace (content) || !content.StartsWith ("{")) {
							bool resBool = false;
							if (bool.TryParse (content, out resBool)) {
								//var result = (TResponse)(object)Convert.ToBoolean (rawContent);

								Debug.WriteLine ("Method: {0} posted. Result: {1}", method.ToString (), resBool);
								return (T)(object)resBool;//(T)(bool.Parse (content));
							}
							int resInt = -100;
							if (int.TryParse (content, out resInt)) {
								Debug.WriteLine ("Method: {0} posted. Result: {1}", method.ToString (), resInt);
								return (T)(object)resInt;
							}
                            //Debug.WriteLine ($"[{typename}]Response contained empty body or incorrect... Body:[{content}]");
							LoggingService.Report (null, new Dictionary<string,string> {
								{ "request",typename },
								{ "content",content },
							});
							return default(T);//(T)Activator.CreateInstance (typeof(T));//default(T);
						} else {
							var json = content;
							var ass = JsonConvert.DeserializeObject<T> (json);
							if (ass != null)
								Debug.WriteLine (String.Format ("=>GETTED [{0}] table.", typename));
							else
								LoggingService.Report (null, new Dictionary<string,string> {
									{ "request",typename },
									{ "content",content },
								});
							return ass;
						}
//						return XMLHelper.Deserialize<T> (content);
					}
				}

			} catch (Exception ex) {
				Debug.WriteLine (String.Format ("GETTING ERROR {0}", ex.Message));
				LoggingService.Report (ex, new Dictionary<string,string> {
					{ "request",typeof(T).Name },
					{ "content",content },
				});
				return default(T);
			}
		}



		public async Task<TResponse> POST<TResponse> (RequestMethod method, Dictionary<string, string> parametrs = null)//data = null)
		{
			try {

				using (var client = new HttpClient ()) {
					client.BaseAddress = new Uri (urlTemplate);
					client.Timeout = new TimeSpan (0, 0, 30);
					var raw = parametrs;//JsonConvert.SerializeObject (data, new JsonSerializerSettings (){ NullValueHandling = NullValueHandling.Ignore });
					var response = await client.PostAsync (method.ToString ().ToLower () + ".asp", new FormUrlEncodedContent (raw));// new StringContent (raw, Encoding.UTF8, "application/json"));
					var rawContent = await response.Content.ReadAsStringAsync ();
					if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created) {
						bool resBool = false;
						if (bool.TryParse (rawContent, out resBool)) {
							//var result = (TResponse)(object)Convert.ToBoolean (rawContent);

							Debug.WriteLine ("Method: {0} posted. Result: {1}", method.ToString (), resBool);
							return (TResponse)(object)resBool;//(T)(bool.Parse (content));
						}
						int resInt = -100;
						if (int.TryParse (rawContent, out resInt)) {
							Debug.WriteLine ("Method: {0} posted. Result: {1}", method.ToString (), resInt);
							return (TResponse)(object)resInt;
						}
						Debug.WriteLine ("Method: {0} posted", method.ToString ());
						return default(TResponse);
					} else {
						Debug.WriteLine ("ERROR: {0}", rawContent);
//						result.Error = JsonConvert.DeserializeObject<ErrorWrapper> (rawContent).Error;
					}
				}

			} catch (Exception ex) {
				if (ex is WebException)
					Debug.WriteLine ("WebException: {1}", ex.ToString ());
				Debug.WriteLine ("ERROR: {1}", ex.ToString ());
				LoggingService.Report (ex);
			}
			return default(TResponse);
		}

	}

	public static class HttpWebRequestExtensions
	{
		public static Task<Stream> GetRequestStreamAsync (this HttpWebRequest request)
		{
			var tcs = new TaskCompletionSource<Stream> ();

			try {
				request.BeginGetRequestStream (iar => {
					try {
						var response = request.EndGetRequestStream (iar);
						tcs.SetResult (response);
					} catch (Exception exc) {
						tcs.SetException (exc);
					}
				}, null);
			} catch (Exception exc) {
				tcs.SetException (exc);
			}
			 
			return tcs.Task;
		}

		public static Task<HttpWebResponse> GetResponseAsync (this HttpWebRequest request)
		{
			var tcs = new TaskCompletionSource<HttpWebResponse> ();
			  
			try {
				request.BeginGetResponse (iar => {
					try {
						var response = (HttpWebResponse)request.EndGetResponse (iar);
						tcs.SetResult (response);
					} catch (Exception exc) {
						tcs.SetException (exc);
					}
				}, null);
			} catch (Exception exc) {
				tcs.SetException (exc);
			}
			  
			return tcs.Task;
		}
	}

}