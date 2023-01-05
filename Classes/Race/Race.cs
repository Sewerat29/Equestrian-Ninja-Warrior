namespace ENW.Classes.Race
{
    internal class Race
    {
        private string horsesList;
        private string[] scoreBoard;
        private int numberOfTraps;

        public Race(string horsesList, int numberOfTraps)
        {
            this.horsesList = horsesList;
            this.numberOfTraps = numberOfTraps;
        }

        public void Start()
        {
            var obstacles = new Obstacles.Obstacles();

            for(int i = 0; i < numberOfTraps; i++)
            {
                obstacles.Generate();
            }
        }
    }
}
