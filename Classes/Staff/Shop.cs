using ENW.Classes.Horses;
using Spectre.Console;

namespace ENW.Classes.Staff
    
{
    internal class Shop
    {
        public void ShopMenu(IGenericHorse MyHorse)
        {
            string menuOptions = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Upgrades:")
                .PageSize(5)
                .AddChoices(new[] {
                    "[#afaf00]Iron Lungs™[/]",
                    "[#afaf00]AssBlaster3000™[/]",
                    "[#afaf00]Absolute Unit™[/]",
                    "[#afaf00]Ultra Instinct™[/]",
                    "[#afaf00]Totem of Undying™[/]" }));

            if (menuOptions == "[#afaf00]Iron Lungs™[/]")
            {

            }
            else if (menuOptions == "[#afaf00]AssBlaster3000™[/]")
            {
                

            }
            else if (menuOptions == "[#afaf00]Absolute Unit™[/]")
            {

            }
            else if (menuOptions == "[#afaf00]Ultra Instinct™[/]")
            {

            }
            else if (menuOptions == "[#afaf00]Totem of Undying™[/]")
            {
                Environment.Exit(1);

            }
            
        }
    }

}
