using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF4FabulGauntlet.Inventory
{
	class EntityJSON
	{
		public int id { get; set; }
		public Layer[] layers { get; set; }
		public string name { get; set; }
		public int opacity { get; set; }
		public string type { get; set; }
		public bool visible { get; set; }
		public int x { get; set; }
		public int y { get; set; }
		public int width { get; set; }
		public int height { get; set; }

		public class Layer
		{
			public string draworder { get; set; }
			public int id { get; set; }
			public string name { get; set; }
			public Object[] objects { get; set; }
			public object opacity { get; set; }
			public string type { get; set; }
			public bool visible { get; set; }
			public int x { get; set; }
			public int y { get; set; }
		}

		public class Object
		{
			public int gid { get; set; }
			public int height { get; set; }
			public int id { get; set; }
			public string name { get; set; }
			public Property1[] properties { get; set; }
			public int rotation { get; set; }
			public string type { get; set; }
			public bool visible { get; set; }
			public int width { get; set; }
			public int x { get; set; }
			public int y { get; set; }
		}

		public class Property1
		{
			public string name { get; set; }
			public string type { get; set; }
			public object value { get; set; }
		}

	}
}
