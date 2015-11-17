using System;
using Newtonsoft.Json;

namespace SmartDocTestApp.Core
{
	public class LoginObject
	{
		public Guid UserId{ get; set; }

		public string Token{ get; set; }

		[JsonIgnore]
		public bool IsValid {
			get { 
				return Token != null && UserId != Guid.Empty;
			}
		}
	}
}

