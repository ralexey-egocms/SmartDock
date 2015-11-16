using Newtonsoft.Json;

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
	}
}

