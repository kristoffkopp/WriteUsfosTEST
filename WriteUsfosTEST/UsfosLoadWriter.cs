using System.Collections.Generic;
using System.Linq;

namespace WriteUsfosTEST
{
    //Not using timeFuncNodeIDs.ToArray(), isMassList.ToArray() or eccList.ToArray()
    public class UsfosLoadWriter
    {
        public List<string> nodeLoadWriter(int[] nodeLoadIndexes, int[] nodelIDs, double[][] forceList, double[][] momentList, int[] loadGroup)
        {
            var stringList = new List<string>();
            var currentLoadGroupIDs = new List<int>();
            for (int k = 0; k < nodeLoadIndexes.Length; k++)
            {
                string line;
                if (!currentLoadGroupIDs.Contains(loadGroup[k]))
                    currentLoadGroupIDs.Add(loadGroup[k]);

                line = "NODELOAD " + (loadGroup[k] + 1) + "  " + (nodelIDs[k] + 1) + "    ";
                for (int i = 0; i < 3; i++)
                    line = line + ("    " + forceList[k][i]);

                if (!areAllElemetsZero(momentList[k]))
                {
                    line = line + "    ";
                    for (int j = 0; j < 3; j++)
                        line = line + ("    " + momentList[k][j]);
                }
                stringList.Add(line);
            }

            var scalingFactor = 1;
            foreach (int loadGr in currentLoadGroupIDs)
                stringList.Add("LOAD_COMB " + (loadGr + 1) + "     " + scalingFactor + " " + (loadGr + 1));
            //Uses loadGroup as ID for LOAD_COMB. ID and loadGroup should always be the same in Usfos

            return stringList;
        }
        public bool areAllElemetsZero(double[] array)
        {
            int totalZero = array.Count(x => x == 0);
            return (totalZero == array.Length) ? true : false;
        }
    }

}