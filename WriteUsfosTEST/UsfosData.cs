using System.Collections.Generic;

namespace WriteUsfosTEST
{
	public class UsfosData
	{
		//Nodes
		public int[] NodeIndexes { get; set; }
		public double[][] NodeXYZ { get; set; }
		public int[][] BoundaryCode { get; set; }
		public double[][,] Trans { get; set; }
		//Material
		public int MaterialID { get; set; }
        public double materialEmod { get; set; }
        public double materialPoissNu { get; set; }
        public double MaterialDensityRho { get; set; }
        //Elements
        public int[] IndexBeam { get; set; }
		public int[] ElementType { get; set; }
		public int[] PropertyNumberBeam { get; set; }
		public int[] MaterialNumberBeam { get; set; }
		public int[,] NodeNumbersBeam { get; set; }
		//Crossection
		public int CrossSectionId { get; set; }
		public double AreaX { get; set; }
		public double Ix { get; set; }
		public double Iy { get; set; }
		public double Iz { get; set; }
		public double ShearAreaY { get; set; }
		public double ShearAreaZ { get; set; }
		//Loads
		public int[] LoadGroup { get; set; }
		public int[] NodeLoadIDs { get; set; }
		public int[] NodealIDs { get; set; }
		public double[][] ForceList { get; set; }
		public double[][] MomentList { get; set; }

	}
}