using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.Collections.ObjectModel;

namespace SmartDocTestApp.Core
{
	public class MenuData
	{
		public ObservableCollection<InstanseData> Instances { get; set; }
	}

	public class InstanseData
	{
		public int Id { get; set; }

		public string Name { get; set; }
	}
}