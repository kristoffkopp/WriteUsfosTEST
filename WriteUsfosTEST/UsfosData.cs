using System.Collections.Generic;

namespace WriteUsfosTEST
{
	public class UsfosData
	{
		public int[] NodeIndexes { get; set; }
		public double[][] NodeXYZ { get; set; }
		public int[][] BoundaryCode { get; set; }
		public double[][,] Trans { get; set; }
		public List<UsfosMaterial> Materials { get; set; }
		public int[] IndexBeam { get; set; }
		public int[] ElementType { get; set; }
		public int[] PropertyNumberBeam { get; set; }
		public int[] MaterialNumberBeam { get; set; }
		public int[][] NodeNumbersBeam { get; set; }
		public int[] LoadGroup { get; set; }
		public int[] NodeLoadIDs { get; set; }
		public int[] NodealIDs { get; set; }
		public double[][] ForceList { get; set; }
		public double[][] MomentList { get; set; }

	}
}