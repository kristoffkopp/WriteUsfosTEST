using System.Collections.Generic;

namespace WriteUsfosTEST
{
	public class UsfosMaterialWriter
	{
		public List<string> materialWriter(List<UsfosMaterial> materials)
		{
			var stringList = new List<string>();
			foreach (UsfosMaterial material in materials)
			{
				string line;
				line = "MATERIAL " + material.Id + " Elastic"; // All materials sent from Focus Konstruksjon are Elastic
				line = line + ("    " + material.Emod + "    " + material.PoissNu + "    " + "0" + "    " + material.DensityRho);
				stringList.Add(line);
			}
			return stringList;
		}
	}
}