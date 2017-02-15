using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WriteUsfosTEST;

namespace WriteUsfosTESTtest
{
	[TestClass]
	public class UsfosNodeWriterTest
	{
		private UsfosNodeWriter nodeWriter;

		[TestInitialize]
		public void init()
		{
			nodeWriter = new UsfosNodeWriter();
		}

		[TestMethod]
		public void Canary()
		{
			Assert.IsTrue(true);
		}

		[TestMethod]
		public void areAllElementsZeroshouldReturnTrueWhenListOfOnlyZero()
		{
			//Act & Assert together in one
			Assert.IsTrue(nodeWriter.areAllElemetsZero(new int[] {0,0,0,0,0,0}));
		}

		[TestMethod]
		public void areAllElementsZeroshouldReturnFalseWhenListOfZeroAndOnes()
		{
			//Act & Assert together in one
			Assert.IsFalse(nodeWriter.areAllElemetsZero(new int[] {0,0,0,1,0,0}));
		}
	}
}
