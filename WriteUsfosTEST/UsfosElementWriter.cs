using System.Collections.Generic;

namespace WriteUsfosTEST
{
	enum elementDiscription
	{
		BEAM = 28
	}
	public class UsfosElementWriter
	{
		public List<string> writeElements(int[] indexBeam, int[] elementType, int[] propertyNumberBeam, int[] materialNumberBeam, int[,] nodeNumbersBeam)
		{
			var stringList = new List<string>();
			foreach(int index in indexBeam)
			{
				if (elementType[index] == (int)elementDiscription.BEAM)
				{
					string line;
					line = elementDiscription.BEAM.ToString() + " " + (index + 1) + "  ";
					line = line + ((nodeNumbersBeam[index,0] + 1) + " " + (nodeNumbersBeam[index,1] + 1)) + "   ";
					line = line + (materialNumberBeam[index] + " " + propertyNumberBeam[index]);
					stringList.Add(line);
				}
			}
			return stringList;
		}
	}
}