namespace ENW.Classes.Horses
{
    public interface IGenericHorse
    {
        string Name { get; set; }
        string Color { get; set; }
        int Stamina { get; set; }
        int Strength { get; set; }
        int Speed { get; set; }
        int Dexterity { get; set; }
        int StreetCred { get; set; }
        int Strikes { get; set; }
        bool IsAlive { get; set; }
        int Money { get; set; }
        SingleHorseRace[] RaceLogs { get; set; }
    }
}