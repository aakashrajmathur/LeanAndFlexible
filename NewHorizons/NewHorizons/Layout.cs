using System.Collections.Generic;

namespace NewHorizons
{
    public class Layout
    {
        Dictionary<Machine, position> machinePositions;
        public string name;

        public Layout(string name = "")
        {
            this.machinePositions = new Dictionary<Machine, position>();
        }
    }

    public class position
    {
        public float top;
        public float left;
    }

}
    //Every layout will consist of ALL machines, however the selection determines which Parts are included in analysis.