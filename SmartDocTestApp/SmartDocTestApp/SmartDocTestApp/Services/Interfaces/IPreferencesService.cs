using System;

namespace SmartDocTestApp.Core.Services.Interfaces
{
	public interface IPreferencesService
	{
		string Username{ get; set; }

		string Password{ get; set; }
	}
}

