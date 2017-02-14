using System.Collections.Generic;
using System.Linq;

namespace WriteUsfosTEST
{
	public class UsfosNodeWriter
	{
		public List<string> writeNodes(int[] nodeIdexes, double[][] nodeXYZ, int[][] bCode, double[][,] trans)
		{
			var stringList = new List<string>();
			if (nodeIdexes.Length != trans.GetLength(0))
				return stringList;

			foreach(int index in nodeIdexes)
			{
				string line;
				line = ("NODE " + (index + 1) + "     ");
				line = line + (nodeXYZ[index][0].ToString() + "    ");
				line = line + (nodeXYZ[index][1].ToString() + "    ");
				line = line + (nodeXYZ[index][2].ToString());

				line = line + ("  " + bCode[index][0] + " " + bCode[index][1] + " " + bCode[index][2] + "   " + bCode[index][3] + " " + bCode[index][4] + " " + bCode[index][5]);
				line = line + ("    " + (index + 1));
				stringList.Add(line);
			}

			for (int i = 0; i < trans.GetLength(0); i++)
			{
				string line;
				line = ("NODETRANS " + (i + 1));
				for (int j = 0; j < 3; j++)
					line = line + ("   " + trans[i][j, 0] + " " + trans[i][j, 1] + " " + trans[i][j, 2]);

				stringList.Add(line);
			}

			return stringList;
		}

		public bool areAllElemetsZero (int[] array)
		{
			int totalZero = array.Count(x => x == 0);
			return (totalZero == array.Length) ? true : false;
		}

	}
}