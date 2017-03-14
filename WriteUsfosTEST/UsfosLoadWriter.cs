using System.Collections.Generic;
using System.Linq;

namespace WriteUsfosTEST
{
	public class UsfosLoadWriter
	{
		public List<string> nodeLoadWriter (int[] nodeLoadIndexes, int[] nodelIDs, double[][] forceList, double[][] momentList, int[] loadGroup)
		{
			var stringList = new List<string>();
			if (loadGroup.Length < 1)
				return stringList;

			foreach (int index in nodeLoadIndexes)
			{
				string line;
				line = "NODELOAD " + loadGroup[0] + 1 + "  " + (nodelIDs[index] + 1) + "    ";
				for (int i = 0; i < 3; i++)
					line = line + ("    " + forceList[index][i]);

				if (!areAllElemetsZero(momentList[index]))
				{
					line = line + "    ";
					for (int j = 0; j < 3; j++)
						line = line + ("    " + momentList[index][j]);
				}
				stringList.Add(line);
			}
			double scalingFactor = 1.0000; int loadCombinationID = 1; // Needs further information on how to gather data from CfemWrapper
			stringList.Add( "LOAD_COMB " + loadCombinationID + "     " + scalingFactor + " " + loadGroup[0] + 1);
			return stringList;
		}
		public bool areAllElemetsZero(double[] array)
		{
			int totalZero = array.Count(x => x == 0);
			return (totalZero == array.Length) ? true : false;
		}
	}

}