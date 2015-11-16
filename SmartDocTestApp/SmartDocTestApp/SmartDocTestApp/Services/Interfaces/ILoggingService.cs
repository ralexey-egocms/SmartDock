using System;
using System.Collections.Generic;

namespace SmartDocTestApp.Core.Services
{
	public interface ILoggingService
	{
		
	}

	public interface IPlatformLoggingService
	{
		bool Init ();

		bool Active{ get; set; }

		bool DebugOutline{ get; set; }

		void TrackNative (string text, Dictionary<string, string> args);

		void ReportNative (Exception ex, Dictionary<string, string> args, LoggingService.Severity type);
	}
}

