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

        public List<string> writeCrossSectionShellHomo(int CrossSectionId, double thickness)
        {
            var stringList = new List<string>();
            string line;
            line = "PLTHICK " + (CrossSectionId + 1) + "    " + thickness;
            stringList.Add(line);

            return stringList;
        }

        public List<string> writeCrossSectionShellComposit(int CompositSectionId, double z0, int[] materialIDs, double[] thicknessList, double[] thetalOrientationList)
        {
            var stringList = new List<string>();
            string line;
            line = "PLCOMP " + (CompositSectionId + 1) + "    " + z0;
            if(materialIDs.Length == thicknessList.Length && materialIDs.Length == thetalOrientationList.Length)
                for (int i = 0; i < materialIDs.Length; i++)
                    line = "   " + materialIDs[i] + "   " + thicknessList[i] + "   " + thetalOrientationList[i];

            stringList.Add(line);

            return stringList;
        }
    }
}