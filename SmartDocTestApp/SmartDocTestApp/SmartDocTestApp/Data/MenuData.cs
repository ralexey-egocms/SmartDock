using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartDocTestApp.Core
{
	public class MenuData
	{
		public List<InstanseData> Instances { get; set; }
	}

	public class InstanseData
	{
		public int Id{ get; set; }

		public string Name{ get; set; }
	}
}

