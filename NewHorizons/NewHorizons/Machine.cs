namespace NewHorizons
{
    public class Machine
    {
        public string name;
        public float length;    //in feet
        public float width;     //in feet

        public Machine(string name, float length = 20, float width = 20)
        {
            this.name = name;
            this.length = length;
            this.width = width;
        } 
    }
}