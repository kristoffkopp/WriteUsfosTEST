using System;
using System.Collections.Generic;

namespace WriteUsfosTEST
{
	public class UsfosCrossSectionWriter
	{
		public List<string> writeCrossSectionBeam(int CrossSectionId, double AreaX, double Ix, double Iy, double Iz, double ShareAreaY, double ShareAreaZ)
		{
			var stringList = new List<string>();
			string line;
			line = "GENBEAM " + (CrossSectionId + 1) + "     " + AreaX + "    " + Ix + "    " + Iy + "    " + Iz + "    " + ShareAreaY + "    " + ShareAreaZ;
			stringList.Add(line);

			return stringList;
		}
	}
}
