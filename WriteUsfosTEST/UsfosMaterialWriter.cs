using System.Collections.Generic;

namespace WriteUsfosTEST
{
	public class UsfosMaterialWriter
	{
		public string materialWriter(int materialId, double materialEmod, double materialPoissNu, double MaterialDensityRho)
		{
			string line;
			line = "MATERIAL " + (materialId + 1) + " Elastic"; // All materials sent from Focus Konstruksjon are Elastic
			line = line + ("    " + materialEmod + "    " + materialPoissNu + "    " + "0" + "    " + MaterialDensityRho);

            return line;
		}
	}
}