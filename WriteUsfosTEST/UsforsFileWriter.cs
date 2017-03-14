using System.Collections.Generic;
using System.IO;

namespace WriteUsfosTEST
{
	public class UsfosFileWriter
	{
		private string m_FilePath;
		private UsfosData m_UsfosDataObject;
		private List<string> m_Lines;

		public UsfosFileWriter(string filePath, UsfosData usfosDataObject)
		{
			m_FilePath = filePath;
			m_UsfosDataObject = usfosDataObject;
			m_Lines = new List<string>();
			
		}

		public void writeFile()
		{
			UsfosNodeWriter usfosNodeWriter = new UsfosNodeWriter();
			var nodeStrings = usfosNodeWriter.writeNodes(m_UsfosDataObject.NodeIndexes, m_UsfosDataObject.NodeXYZ, m_UsfosDataObject.BoundaryCode, m_UsfosDataObject.Trans);
			m_Lines.AddRange(nodeStrings);

			UsfosMaterialWriter usfosMaterialWriter = new UsfosMaterialWriter();
			var materialStrings = usfosMaterialWriter.materialWriter(m_UsfosDataObject.MaterialID, m_UsfosDataObject.materialEmod, m_UsfosDataObject.materialPoissNu, m_UsfosDataObject.MaterialDensityRho);
			m_Lines.Add(materialStrings);

			UsfosElementWriter usfosElementWriter = new UsfosElementWriter();
			var elementStrings = usfosElementWriter.writeElements(m_UsfosDataObject.IndexBeam, m_UsfosDataObject.ElementType, m_UsfosDataObject.PropertyNumberBeam, m_UsfosDataObject.MaterialNumberBeam, m_UsfosDataObject.NodeNumbersBeam);
			m_Lines.AddRange(elementStrings);

			UsfosCrossSectionWriter usfosCossSecWriter = new UsfosCrossSectionWriter();
			var crossSectionString = usfosCossSecWriter.writeCrossSectionBeam(m_UsfosDataObject.CrossSectionId, m_UsfosDataObject.AreaX, m_UsfosDataObject.Ix, m_UsfosDataObject.Iy, m_UsfosDataObject.Iz, m_UsfosDataObject.ShearAreaY, m_UsfosDataObject.ShearAreaZ);
			m_Lines.AddRange(crossSectionString);

			UsfosLoadWriter usfosLoadWriter = new UsfosLoadWriter();
			var loadStrings = usfosLoadWriter.nodeLoadWriter(m_UsfosDataObject.NodeLoadIDs, m_UsfosDataObject.NodealIDs, m_UsfosDataObject.ForceList, m_UsfosDataObject.MomentList, m_UsfosDataObject.LoadGroup);
			m_Lines.AddRange(loadStrings);

			using (var writer = new StreamWriter(m_FilePath))
			{
				foreach(string line in m_Lines)
					writer.WriteLine(line);
				writer.WriteLineAsync();
			}
		}
	}
}
