namespace ENW.Classes.Horses
{
    public struct SingleHorseRace
    {
        public List<string> ObstaclesCheck;
        public int Points;
        public int Place;

        public SingleHorseRace(int place, int points, int numberofTraps)
        {
            ObstaclesCheck = new List<string>( new string[numberofTraps] );
            Points = points;
            Place = place;
        }
    };

    internal class GenericHorse : IGenericHorse
    {
        public string Name { get; set; }
        public string Color { get; set; }

        public int Stamina { get; set; }
        public int Strength { get; set; }
        public int Speed { get; set; }
        public int Dexterity { get; set; }
        public int StreetCred { get; set; }

        public int Strikes { get; set; }
        public bool IsAlive { get; set; }

        public int Money { get; set; }

        public List<SingleHorseRace> RaceLogs {get; set;}

        public GenericHorse(string name, string color, int stamina, int strength, int speed, int dexterity, int strikes, int streetCred, bool isAlive, int money)
        {
            Name = name;
            Color = color;
           
            Stamina = stamina;
            Strength = strength;
            Speed = speed;
            
            Dexterity = dexterity;
            
            StreetCred = streetCred;
            
            Strikes = strikes;    //Eventos. Cavalo leva um strike se falhar num Obstáculo. 3 Strikes e isAlive=false
            IsAlive = isAlive;
            
            Money = money;

            RaceLogs = new List<SingleHorseRace>();
        }
    }
}
