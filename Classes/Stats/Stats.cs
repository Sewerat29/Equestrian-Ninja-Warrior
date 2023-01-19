using ENW.Classes.Horses;
using Spectre.Console;

namespace ENW.Classes.Stats
{
    internal class Stats
    {
        public void StatsList(IGenericHorse MyHorse)
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
            AnsiConsole.Write("Money: " + MyHorse.Money);
            AnsiConsole.Markup("\n\n");
        }
    }
}
