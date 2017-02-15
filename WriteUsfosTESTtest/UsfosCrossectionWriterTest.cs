using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using WriteUsfosTEST;

namespace WriteUsfosTESTtest
{
	[TestClass]
	public class UsfosCrossectionWriterTest
	{
		private List<string> stringList;
		private string[] elementArray;
		[TestInitialize]
		public void init()
		{
			UsfosCrossSectionWriter usfosCossSecWriter = new UsfosCrossSectionWriter();
			stringList = usfosCossSecWriter.writeCrossSectionBeam(0, 0.00781, 0.00002, 0.000000595, 0, 0.006, 0.0002485);
			elementArray = stringList[0].Split().Where(x => !string.IsNullOrEmpty(x)).ToArray();
		}
		[TestMethod]
		public void Canary()
		{
			Assert.IsTrue(true);
		}
		[TestMethod]
		public void writeCrossSectionBeamShouldReturnOneStringWhenCrossSextionIDIsOne()
		{
			Assert.AreEqual(1, stringList.Count);
		}

		[TestMethod]
		public void writeCrossSectionBeamFirstStringShouldBeginWithGENBEAM1WhenCrossSextionIDIsOne()
		{
			var line = elementArray[0] + " " + elementArray[1];
			Assert.AreEqual("GENBEAM 1", line);
		}
		[TestMethod]
		public void writeCrossSectionBeamStringShouldHaveAreaOfSteelAtPositonThree()
		{
			var line = elementArray[2];
			Assert.AreEqual("0.00781", line);
		}
		[TestMethod]
		public void writeCrossSectionBeamStringShouldHaveIxOfProfileAtPositonFour()
		{
			var line = elementArray[3];
			Assert.AreEqual("2E-05", line);
		}
		[TestMethod]
		public void writeCrossSectionBeamStringShouldHaveIxOfProfileAtPositonFive()
		{
			var line = elementArray[4];
			Assert.AreEqual("5.95E-07", line);
		}
		[TestMethod]
		public void writeCrossSectionBeamStringShouldHaveIxOfProfileAtPositonSix()
		{
			var line = elementArray[5];
			Assert.AreEqual("0", line);
		}
		[TestMethod]
		public void writeCrossSectionBeamStringShouldHaveShareAreaYOfProfileAtPositonSEven()
		{
			var line = elementArray[6];
			Assert.AreEqual("0.006", line);
		}
		[TestMethod]
		public void writeCrossSectionBeamStringShouldHaveShareAreaZOfProfileAtPositonEight()
		{
			var line = elementArray[7];
			Assert.AreEqual("0.0002485", line);
		}
	}
}
