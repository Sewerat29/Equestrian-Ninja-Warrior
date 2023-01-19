using ENW.Classes.Horses;
using Spectre.Console;

namespace ENW.Classes.Staff
    
{
    internal class Shop
    {
        public void ShopMenu(IGenericHorse MyHorse)
        {
            string menuOptions = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Upgrades: [grey]$3000 each[/]") 
                .PageSize(5)
                .AddChoices(new[] {
                    "[#afaf00]Iron Lungs®[/] [grey]+2 Stamina[/]",
                    "[#afaf00]AssBlaster3000®[/] [grey]+2 Speed[/]",
                    "[#afaf00]Absolute Unit®[/] [grey]+2 Strength[/]",
                    "[#afaf00]Ultra Instinct®[/] [grey]+2 Dexterity[/]",
                    "[#afaf00]Totem of Undying®[/] [grey]+1 Strike[/]" }));

            if (menuOptions == "[#afaf00]Iron Lungs™[/]")
            {

            }
            else if (menuOptions == "[#afaf00]AssBlaster3000[/]")
            {
                

            }
            else if (menuOptions == "[#afaf00]Absolute Unit[/]")
            {

            }
            else if (menuOptions == "[#afaf00]Ultra Instinct[/]")
            {

            }
            else if (menuOptions == "[#afaf00]Totem of Undying[/]")
            {
                Environment.Exit(1);
            }
            
        }
    }

}
