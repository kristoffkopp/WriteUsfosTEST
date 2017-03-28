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
				usfosData.NodeXYZ[index] = new double[3] { 1.1233+index, 2.2342+index, 3.3452+index };
				usfosData.BoundaryCode[index] = new int[6] { 0, 0, 0, 0, 0, 0 };
				usfosData.Trans[index] = new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };
			}
			usfosData.Trans[0][0, 0] = 0;
			usfosData.BoundaryCode[3] = new int[6] { 1, 1, 1, 1, 1, 1 };

            //Material
			usfosData.MaterialID = 0;
			usfosData.materialEmod = 210000000000;
			usfosData.MaterialDensityRho= 77000;
			usfosData.materialPoissNu = 0.3;

            //Beam Elements
			usfosData.usfosElement.IndexElement = new int[] { 0, 1, 2 };
			usfosData.usfosElement.ElementType = new int[] { 28, 28, 28 };
			usfosData.usfosElement.PropertyNumberElement= new int[] { 0, 0, 0 }; 
			usfosData.usfosElement.MaterialNumberElement = new int[] { 0, 0, 0 };
			usfosData.usfosElement.NodeNumbersElements = new int[usfosData.usfosElement.IndexElement.Length,2];
            usfosData.usfosElement.NodeNumbersElements[0, 0] = 0;
            usfosData.usfosElement.NodeNumbersElements[0, 1] = 1;
            usfosData.usfosElement.NodeNumbersElements[1, 0] = 2;
            usfosData.usfosElement.NodeNumbersElements[1, 1] = 3;
            usfosData.usfosElement.NodeNumbersElements[2, 0] = 4;
            usfosData.usfosElement.NodeNumbersElements[2, 1] = 5;

            //Shell Elements
            usfosData.usfosElementShell.IndexElement = new int[] { 0, 1 };
            usfosData.usfosElementShell.ElementType = new int[] { 30, 30 };
            usfosData.usfosElementShell.PropertyNumberElement = new int[] { 1, 1 };
            usfosData.usfosElementShell.MaterialNumberElement = new int[] { 0, 0 };
            usfosData.usfosElementShell.NodeNumbersElements = new int[usfosData.usfosElementShell.IndexElement.Length, 3];
            usfosData.usfosElementShell.NodeNumbersElements[0, 0] = 0;
            usfosData.usfosElementShell.NodeNumbersElements[0, 1] = 1;
            usfosData.usfosElementShell.NodeNumbersElements[0, 2] = 2;
            usfosData.usfosElementShell.NodeNumbersElements[1, 0] = 3;
            usfosData.usfosElementShell.NodeNumbersElements[1, 1] = 4;
            usfosData.usfosElementShell.NodeNumbersElements[1, 2] = 5;
            usfosData.usfosElementShell.xVec = new double[usfosData.usfosElementShell.IndexElement.Length][];
            usfosData.usfosElementShell.xVec[0] = new double[] { 1, 0, 0 };
            usfosData.usfosElementShell.xVec[1] = new double[] { 1, 0, 0 };

            //Beam - crossection
            usfosData.CrossSectionId = 0;
			usfosData.AreaX = 0.00781;
			usfosData.Ix = 0.00002;
			usfosData.Iy = 0.000000595;
			usfosData.Iz = 0;
			usfosData.ShearAreaY = 0.006;
			usfosData.ShearAreaZ = 0.0002485;

            //Shell - Crossection
            usfosData.CrossectionIDShell = 1;
            usfosData.thicknessShell = 0.03;

			usfosData.LoadGroup = new int[] { 0, 0, 0, 0 }; //NB! Do not have enough knowledge of how loadContainers and LoadGroups works. In usfos this is a LOAD_COMPination
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
