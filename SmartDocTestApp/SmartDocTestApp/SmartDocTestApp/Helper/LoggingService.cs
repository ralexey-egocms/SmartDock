using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using Cirrious.CrossCore;

namespace SmartDocTestApp.Core.Services
{
	public static class LoggingService
	{
		public class TimeTrackingHandle : IDisposable
		{

			string _eventName = "";
			Dictionary<string, string> _parametrs = new Dictionary<string, string> ();

			#region Entities

			//IDisposable _insightsEntity;
			//IDisposable _flurryEntity;

			Stopwatch sw;

			#endregion

			public TimeTrackingHandle (string text, Dictionary<string, string> args = null)
			{
				_eventName = text;
				_parametrs = args;
				Start ();
			}

			void Start ()
			{
				#if DEBUG
				sw = new Stopwatch ();
				sw.Start ();
				#endif
			}

			void Stop ()
			{
				#if DEBUG
				sw.Stop ();
				Debug.WriteLine (String.Format ("[{0}] => Elapsed Time : {1} sec.", _eventName, sw.Elapsed.TotalSeconds.ToString ("F2")));
				sw = null;
				#endif
			}

			#region IDisposable implementation

			public void Dispose ()
			{
				Stop ();
				_parametrs = null;
				GC.Collect ();
			}

			#endregion
			
		}

		public enum Severity
		{
			Error,
			Warning,
			Critical
		}

		static IPlatformLoggingService _logging;

		public static bool Active{ get; private set; } = false;

		public static IPlatformLoggingService Logging {
			get { 
				return _logging ?? (_logging = Mvx.Resolve<IPlatformLoggingService> ()); 
			} 
		}

		public static void Start ()
		{
			if (Logging.Active) {
				Active = Logging.Init ();				
			}
		}

		public static void Stop ()
		{

		}
		//		if (Active) {
		//		if (Logging.DebugOutline) {
		//			#region Debug Output
		//
		//			#endregion
		//		}
		//		if (Logging.XamarinInsights) {
		//			#region Insights Output
		//
		//			#endregion
		//		}
		//		if (_appseeEnable) {
		//			#region AppSee Output
		//
		//			#endregion
		//		}
		//	}

		#region Report

		public static void Report (Exception ex)
		{
			Report (ex, Severity.Error);
		}

		public static void Report (Exception ex, Severity type)
		{
			Report (ex, new Dictionary<string, string> (), type);
		}

		public static void Report (Exception ex, Dictionary<string, string> args)
		{
			Report (ex, args, Severity.Error);
		}

		public static void Report (Exception ex, string key, string value, Severity type)
		{
			Report (ex, new Dictionary<string, string>{ [key ] =value }, type);
		}

		public static void Report (Exception ex, Dictionary<string, string> args, Severity type)
		{
			
			if (Active) {
				if (Logging.DebugOutline) {
					#region Debug Output
					string key = "";
					string value = "";
					if (args != null && args?.Keys.Count > 0) {
						key = args.Keys.First ();
						value = args [key];
					}
					Debug.WriteLine ($"[{type.ToString()}] {key}: {value};\n\rStackTrace:\n\r{ex?.ToString()}");
					#endregion
				}				
			}
		}

		#endregion

		#region Track

		public static void Track (string text)
		{
			Track (text, null);
		}

		public static void Track (string text, string key, string value)
		{
			Track (text, new Dictionary<string, string> { [key ] =value });
		}

		public static void Track (string text, Dictionary<string, string> args = null)
		{
			if (Active) {
				if (Logging.DebugOutline) {
					#region Debug Output
					Debug.WriteLine (text);
					#endregion
				}				
			}
		}

		public static void TrackConsolOnly (string text)
		{
			Debug.WriteLine (text);
		}

		#endregion

		#region TimeTracking

		public static TimeTrackingHandle TrackTime (string text)
		{
			return TrackTime (text, null);
		}

		public static TimeTrackingHandle TrackTime (string text, string key, string value)
		{
			return TrackTime (text, new Dictionary<string, string> { [key ] =value });
		}

		public static TimeTrackingHandle TrackTime (string text, Dictionary<string, string> args = null)
		{
			return new TimeTrackingHandle (text, args);
		}

		#endregion

		public static void Initialize ()
		{
			if (Active) {
				if (Logging.DebugOutline) {
					#region Debug Output
					Debug.WriteLine ("Init Logging");
					#endregion
				}				
			}



		}
	}
}

