using System.Collections.Generic;

namespace WriteUsfosTEST
{
	public class GenerateDummyInputData
	{
		public GenerateDummyInputData()
		{
			UsfosData usfosData = new UsfosData();
			usfosData.NodeIndexes = new int[] { 0, 1, 2, 3, 4, 5 };
			usfosData.NodeXYZ = new double[usfosData.NodeIndexes.Length][];
			usfosData.BoundaryCode = new int[usfosData.NodeIndexes.Length][];
			usfosData.Trans = new double[usfosData.NodeIndexes.Length][,];
			foreach (int index in usfosData.NodeIndexes)
			{
				usfosData.NodeXYZ[index] = new double[3] { 1.1233, 2.2342, 3.3452 };
				usfosData.BoundaryCode[index] = new int[6] { 0, 0, 0, 0, 0, 0 };
				usfosData.Trans[index] = new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };
			}
			usfosData.Trans[0][0, 0] = 0;
			usfosData.BoundaryCode[3] = new int[6] { 1, 1, 1, 1, 1, 1 };

			usfosData.Materials = new List<UsfosMaterial>();
			usfosData.Materials.Add(new UsfosMaterial());
			usfosData.Materials[0].Id = 1;
			usfosData.Materials[0].Emod = 210000000000;
			usfosData.Materials[0].DensityRho = 77000;
			usfosData.Materials[0].PoissNu = 0.3;

			usfosData.IndexBeam = new int[] { 0, 1, 2 };
			usfosData.ElementType = new int[] { 28, 28, 28 };
			usfosData.PropertyNumberBeam = new int[] { 1, 1, 1 }; //NB!TODO: find a way to link these to cross-sections
			usfosData.MaterialNumberBeam = new int[] { 1, 1, 1 }; //Check: since material is sent to cfem as Material++, is it 0 or 1 indexed?
			usfosData.NodeNumbersBeam = new int[usfosData.IndexBeam.Length][];
			usfosData.NodeNumbersBeam[0] = new int[] { 0, 1 };
			usfosData.NodeNumbersBeam[1] = new int[] { 2, 3 };
			usfosData.NodeNumbersBeam[2] = new int[] { 4, 5 };

			usfosData.CrossSectionId = 0;
			usfosData.AreaX = 0.00781;
			usfosData.Ix = 0.00002;
			usfosData.Iy = 0.000000595;
			usfosData.Iz = 0;
			usfosData.ShearAreaY = 0.006;
			usfosData.ShearAreaZ = 0.0002485;

			usfosData.LoadGroup = new int[] { 1 }; //NB! Do not have enough knowledge of how loadContainers and LoadGroups works. In usfos this is a LOAD_COMPination
			usfosData.NodeLoadIDs = new int[] { 0, 1, 2, 3 };
			usfosData.NodealIDs = new int[] { 4, 2, 0, 5 };
			usfosData.ForceList = new double[usfosData.NodeLoadIDs.Length][];
			usfosData.MomentList = new double[usfosData.NodeLoadIDs.Length][];
			foreach (int index in usfosData.NodeLoadIDs)
			{
				usfosData.ForceList[index] = new double[] { 5.543 + index, 5.543 + index, 5.543 + index };
				usfosData.MomentList[index] = new double[] { 2.543 * index, 2.543 * index, 2.543 * index };
			}
			UsfosDataSet = usfosData;
		}
		public UsfosData UsfosDataSet { get; set; }

	}
}
