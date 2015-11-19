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

    public static class RESTinwork
    {
        const string urlTemplate = "https://www.smartdok.no/PublicAPI{0}/";

        public static string UrlTemplate
        {
            get
            {
                return urlTemplate + "{1}{2}";
            }
        }

        public static string CreateParametrsString(Dictionary<RequestParams, string> parametrs)
        {
            if (parametrs != null || parametrs.Count > 0)
            {
                string paramData = "?";
                foreach (var key in parametrs.Keys)
                {
                    paramData += WebUtility.UrlEncode(key.ToString()) + "=" + WebUtility.UrlEncode(parametrs[key]) + "&";
                }
                return paramData;
            }
            else
            {
                return "";
            }
        }
    }
}