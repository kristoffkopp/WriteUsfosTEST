using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WriteUsfosTEST;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace WriteUsfosTESTtest
{
	[TestClass]
	public class IntegrationTestsOfUsfosWriter
	{
		private List<string[]> lineElementList;
		[TestInitialize]
		public void init()
		{
			var filepath = @"C:\Users\Kristoffer\Documents\Visual Studio 2015\usfos_test_file_write_focus.usf";
			var dummyData = new GenerateDummyInputData();
			UsfosFileWriter fileWriter = new UsfosFileWriter(filepath, dummyData.UsfosDataSet);
			fileWriter.writeFile();

			var lines = File.ReadAllLines(filepath);
			lineElementList = new List<string[]>();
			foreach (string line in lines)
				if(!String.IsNullOrEmpty(line))
					lineElementList.Add(line.Split().Where(x => !string.IsNullOrEmpty(x)).ToArray());
		}

		[TestMethod]
		public void Canary()
		{
			Assert.IsTrue(true);
		}
		[TestMethod]
		public void readDummyUsfosDataShouldReturnNodeStringInFirstLineAtPositionOne()
		{
			Assert.AreEqual("NODE", lineElementList[0][0]);
		}
		[TestMethod]
		public void readDummyUsfosDataShouldHaveNodeTransReferanceInFirstLineAtPositionEleven()
		{
			Assert.AreEqual("1", lineElementList[0][11]);
		}
		[TestMethod]
		public void readDummyUsfosDataShouldHaveNode4WithBoundaryConditionsNotNodeTrans()
		{
			Assert.AreEqual(11, lineElementList[3].Length);
		}
		[TestMethod]
		public void readDummyUsfosDataShouldContainOnlyOneNodeTrans()
		{
			var numberOfNodeTrans = 0;
			foreach (string[] lineElement in lineElementList)
				if (lineElement[0] == "NODETRANS")
					numberOfNodeTrans++;

			Assert.AreEqual(1, numberOfNodeTrans);
		}
		[TestMethod]
		public void readDummyUsfosDataNodeLoad1ShouldNotHaveMomentForces()
		{
			Assert.AreEqual(6, lineElementList[12].Length);
		}
		[TestMethod]
		public void readDummyUsfosDataNodeLoad2ShouldHaveMomentForces()
		{
			Assert.AreEqual(9, lineElementList[13].Length);
		}
		[TestMethod]
		public void readDummyUsfosDataShouldHaveElaticMaterial()
		{
			foreach (string[] lineElement in lineElementList)
				if (lineElement[0] == "MATERIAL")
					Assert.AreEqual("Elastic", lineElement[2]);
		}
		[TestMethod]
		public void readDummyUsfosDataShouldCorssSectionGenBeamWithSpecificArea()
		{
			foreach (string[] lineElement in lineElementList)
				if (lineElement[0] == "GENBEAM")
					Assert.AreEqual("0.00781", lineElement[2]);
		}
		[TestMethod]
		public void readDummyUsfosDataSecondBeamElementShouldReferToFirstNodeThree()
		{
			Assert.AreEqual("3", lineElementList[9][2]);
		}
		[TestMethod]
		public void readDummyUsfosDataSecoundBeamElementShouldReferToFirstNodeFour()
		{
			Assert.AreEqual("4", lineElementList[9][3]);
		}
		[TestMethod]
		public void readDummyUsfosDataShouldContainOnlyOneLoadComb()
		{
			var numberOfLoadComb = 0;
			foreach (string[] lineElement in lineElementList)
				if (lineElement[0] == "LOAD_COMB")
					numberOfLoadComb++;

			Assert.AreEqual(1, numberOfLoadComb);
		}
	}
}