using System.Collections.Generic;

namespace WriteUsfosTEST
{
    enum elementDiscription
    {
        BEAM = 28,
        TRISHELL = 30
    }
    public class UsfosElementWriter
    {
        public List<string> writeElements(UsfosElement usfosElement)
        {
            var stringList = new List<string>();
            var xvecList = new List<double[]>();
            foreach (int index in usfosElement.IndexElement)
            {
                if (usfosElement.ElementType[index] == (int)elementDiscription.BEAM)
                {
                    string line;
                    line = elementDiscription.BEAM.ToString() + " " + (index + 1) + "  ";
                    line = line + ((usfosElement.NodeNumbersElements[index, 0] + 1) + " " + (usfosElement.NodeNumbersElements[index, 1] + 1)) + "   ";
                    line = line + ((usfosElement.MaterialNumberElement[index] + 1) + " " + (usfosElement.PropertyNumberElement[index] + 1));
                    stringList.Add(line);
                }

                if (usfosElement.ElementType[index] == (int)elementDiscription.TRISHELL)
                {
                    string line;
                    line = elementDiscription.TRISHELL.ToString() + " " + (index + 1) + "  ";
                    line = line + ((usfosElement.NodeNumbersElements[index, 0] + 1) + " " + (usfosElement.NodeNumbersElements[index, 1] + 1) + " " + (usfosElement.NodeNumbersElements[index, 2] + 1) + "   ");
                    line = line + ((usfosElement.MaterialNumberElement[index] + 1) + " " + (usfosElement.PropertyNumberElement[index] + 1));
                    line = line + "   " +(index + 1);
                    xvecList.Add(usfosElement.xVec[index]);
                    stringList.Add(line);
                }
            }
            for (int i = 0; i < xvecList.Count; i++)
                stringList.Add("UNITVEC " + (i + 1) + "    " + xvecList[i][0] + "   " + xvecList[i][1] + "   " + xvecList[i][2]);

            return stringList;
        }
    }
}