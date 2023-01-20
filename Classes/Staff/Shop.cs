using ENW.Classes.Horses;
using Spectre.Console;

namespace ENW.Classes.Staff
    
{
    internal class Shop
    {
        public void ShopMenu(IGenericHorse MyHorse)
        {
            string menuOptions = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Upgrades: [grey]$3000 each                                                                         Money: " + MyHorse.Money + "[/]")
                .PageSize(5)
                .AddChoices(new[] {
                    "[#afaf00]Iron Lungs®[/] [grey]+2 Stamina[/]",
                    "[#afaf00]AssBlaster3000®[/] [grey]+2 Speed[/]",
                    "[#afaf00]Absolute Unit®[/] [grey]+2 Strength[/]",
                    "[#afaf00]Ultra Instinct®[/] [grey]+2 Dexterity[/]"}));

            if (menuOptions == "[#afaf00]Iron Lungs®[/] [grey]+2 Stamina[/]")
            {
                if (MyHorse.Money >= 3000 && MyHorse.Stamina < 20)
                {
                    MyHorse.Stamina += 2;
                    MyHorse.Money -= 3000;
                    MyHorse.IsBionic = true;
                }
            }
            else if (menuOptions == "[#afaf00]AssBlaster3000®[/] [grey]+2 Speed[/]")
            {
                if (MyHorse.Money >= 3000 && MyHorse.Speed < 20)
                {
                    MyHorse.Speed += 2;
                    MyHorse.Money -= 3000;
                    MyHorse.IsBionic = true;
                }
                else
                {
                    Console.WriteLine("Is this a joke??");
                }

            }
            else if (menuOptions == "[#afaf00]Absolute Unit®[/] [grey]+2 Strength[/]")
            {
                if (MyHorse.Money >= 3000 && MyHorse.Strength < 20)
                {
                    MyHorse.Strength += 2;
                    MyHorse.Money -= 3000;
                    MyHorse.IsBionic = true;
                }
                else
                {
                    Console.WriteLine("Is this a joke??");
                }

            }
            else if (menuOptions == "[#afaf00]Ultra Instinct®[/] [grey]+2 Dexterity[/]")
            {
                if (MyHorse.Money >= 3000 && MyHorse.Dexterity < 20)
                {
                    MyHorse.Dexterity += 2;
                    MyHorse.Money -= 3000;
                    MyHorse.IsBionic = true;
                }
                else
                {
                    Console.WriteLine("Is this a joke??");
                }

            }
        }
    }

}
