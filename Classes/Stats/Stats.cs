using ENW.Classes.Horses;
using Spectre.Console;

namespace ENW.Classes.Stats
{
    internal class Stats
    {
        public void StatsList(IGenericHorse MyHorse) //creates a bar chart that display the Stats
        {
            
            AnsiConsole.Write(new BarChart()
                .Width(50)
                .Label($"[red bold underline]{MyHorse.Name}'s Stats[/] \n")
                .CenterLabel()
                .AddItem("Dexterity", MyHorse.Dexterity, Color.Yellow)
                .AddItem("Strength", MyHorse.Strength, Color.Red)
                .AddItem("Speed", MyHorse.Speed, Color.Blue)
                .AddItem("Stamina", MyHorse.Stamina, Color.Green));
            AnsiConsole.Markup("\n");
            AnsiConsole.Write("Money: " + MyHorse.Money); //Shows the money 
            AnsiConsole.Markup("\n");
            AnsiConsole.Write("Bionic: " + MyHorse.IsBionic); //Shows if the horse is bionic
            AnsiConsole.Markup("\n\n");
        }
    }
}
