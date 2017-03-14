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
        public List<string> writeElements(int[] indexElement, int[] elementType, int[] propertyNumberElement, int[] materialNumberElement, int[,] nodeNumbersElements)
        {
            var stringList = new List<string>();
            foreach (int index in indexElement)
            {
                if (elementType[index] == (int)elementDiscription.BEAM)
                {
                    string line;
                    line = elementDiscription.BEAM.ToString() + " " + (index + 1) + "  ";
                    line = line + ((nodeNumbersElements[index, 0] + 1) + " " + (nodeNumbersElements[index, 1] + 1)) + "   ";
                    line = line + ((materialNumberElement[index] + 1) + " " + (propertyNumberElement[index] + 1));
                    stringList.Add(line);
                }

                if (elementType[index] == (int)elementDiscription.TRISHELL)
                {
                    string line;
                    line = elementDiscription.TRISHELL.ToString() + " " + (index + 1) + "  ";
                    line = line + ((nodeNumbersElements[index, 0] + 1) + " " + (nodeNumbersElements[index, 1] + 1) + " " + (nodeNumbersElements[index, 2] + 1) + "   ");
                    line = line + ((materialNumberElement[index] + 1) + " " + (propertyNumberElement[index] + 1));
                    stringList.Add(line);
                }
            }
            return stringList;
        }
    }
}