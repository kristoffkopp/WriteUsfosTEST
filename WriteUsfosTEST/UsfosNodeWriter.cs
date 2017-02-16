using System.Collections.Generic;
using System.Linq;

namespace WriteUsfosTEST
{
	public class UsfosNodeWriter
	{
		private List<string> transStringList;
		private int numberOfTrans = 0;

		public List<string> writeNodes(int[] nodeIdexes, double[][] nodeXYZ, int[][] bCode, double[][,] trans)
		{
			var stringList = new List<string>();
			transStringList = new List<string>();
			if (nodeIdexes.Length != trans.GetLength(0))
				return stringList;

			foreach(int index in nodeIdexes)
			{
				string line;
				line = ("NODE " + (index + 1) + "     ");
				line = line + (nodeXYZ[index][0].ToString() + "    ");
				line = line + (nodeXYZ[index][1].ToString() + "    ");
				line = line + (nodeXYZ[index][2].ToString());

				if(isTranslationIdentityMatrix(trans[index]) && areAllElemetsZero(bCode[index]))
				{
					stringList.Add(line);
					continue;
				}
				var boundaryCodeLine = "  " + bCode[index][0] + " " + bCode[index][1] + " " + bCode[index][2] + "   " + bCode[index][3] + " " + bCode[index][4] + " " + bCode[index][5];
				if (!isTranslationIdentityMatrix(trans[index]))
				{
					numberOfTrans++;
					line = line + boundaryCodeLine;
					line = line + ("    " + numberOfTrans);
					transStringList.Add(generateNodeTransString(numberOfTrans, trans[index]));
					stringList.Add(line);
					continue;
				}
				if(!areAllElemetsZero(bCode[index]))
				{
					line = line + boundaryCodeLine;
					stringList.Add(line);
				}
			}

			foreach(string line in transStringList)
			{
				stringList.Add(line);
			}

			return stringList;
		}

		public string generateNodeTransString(int numberOfNodeTrans, double[,] trans)
		{
			string line;
			line = ("NODETRANS " + (numberOfNodeTrans));
			for (int j = 0; j < 3; j++)
				line = line + ("   " + trans[j, 0] + " " + trans[j, 1] + " " + trans[j, 2]);

			return line;
		}

		public bool areAllElemetsZero (int[] array)
		{
			int totalZero = array.Count(x => x == 0);
			return (totalZero == array.Length) ? true : false;
		}

		public bool isTranslationIdentityMatrix (double[,] transMatrix)
		{
			//TODO: Use UMatrix3x3 reference in Focus Konstruksjon. First create identity matrix, then use compareMatrix
			//if (transMatrix.Length != 3)
			//	return false;

			//double[] transElementArray = new double[transMatrix.Length * transMatrix.Length];
			//for (int i = 0; i < transMatrix.Length; i++)
			//{
			//	for (int j = 0; j < transMatrix.Length; j++)
			//	{
			//		transElementArray[i + j] = transMatrix[i, j];
			//	}
			//}
			//UMatrix3x3 currentMatrix = new UMatrix3x3(transElementArray[0], transElementArray[1], transElementArray[2], transElementArray[3], transElementArray[4], transElementArray[5], transElementArray[6], transElementArray[7], transElementArray[8]);
			//identityMatrix = currentMatrix.CreateIdentityMatrix();
			//return (currentMatrix == identityMatrix) ? true : false;
			return (transMatrix[0,0] == 1) ? true: false;
		}

	}
}