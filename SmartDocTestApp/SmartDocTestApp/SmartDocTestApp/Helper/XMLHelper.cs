using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;
using SmartDocTestApp.Core.Services;

namespace SmartDocTestApp.Core
{
	public static class XMLHelper
	{
		public static T Deserialize<T> (string xmlString)
		{
			try {
				object result;
				XmlSerializer serializer = new XmlSerializer (typeof(T));
				using (TextReader reader = new System.IO.StringReader (xmlString)) {
					result = serializer.Deserialize (reader);
				}
				return (T)result;
			} catch (Exception ex) {
				LoggingService.Report (ex);
				return default(T);
			}
		}
	}
}

