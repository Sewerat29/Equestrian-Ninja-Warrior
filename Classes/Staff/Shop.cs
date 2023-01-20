using ENW.Classes.Horses;
using Spectre.Console;

namespace ENW.Classes.Staff
    
{
    internal class Shop
    {
        public void ShopMenu(IGenericHorse MyHorse)
        {
            string menuOptions = AnsiConsole.Prompt(new SelectionPrompt<string>() //Creates a Shop Menu
                .Title("Upgrades: [grey]$3000 each                                                                         Money: " + MyHorse.Money + "[/]")
                .PageSize(5)
                .AddChoices(new[] {
                    "[#afaf00]Iron Lungs®[/] [grey]+2 Stamina[/]",
                    "[#afaf00]AssBlaster3000®[/] [grey]+2 Speed[/]",
                    "[#afaf00]Absolute Unit®[/] [grey]+2 Strength[/]",
                    "[#afaf00]Ultra Instinct®[/] [grey]+2 Dexterity[/]"}));

            if (menuOptions == "[#afaf00]Iron Lungs®[/] [grey]+2 Stamina[/]") //Gives Upgrade to Horse, checks if the horse has Points and Money available before purchasing
            {
                if (MyHorse.Stamina >= 20) 
                {
                    AnsiConsole.Markup("[red]Stamina's already 20![/]\n");
                }
                else if (MyHorse.Money < 3000)
                {
                    AnsiConsole.Markup("[red]I'm not running a charity here! Come back when you have some money to spend![/]\n");
                }
                else if (MyHorse.Stamina == 19 && MyHorse.Money >= 3000)
                {
                    MyHorse.Stamina += 1;
                    MyHorse.Money -= 3000;
                    MyHorse.IsBionic = true;
                    AnsiConsole.Markup("[green]Always a pleasure doing business![/]\n");
                }
                else
                {
                    MyHorse.Stamina += 2;
                    MyHorse.Money -= 3000;
                    MyHorse.IsBionic = true;
                    AnsiConsole.Markup("[green]Always a pleasure doing business![/]\n");
                }
            }

            else if (menuOptions == "[#afaf00]AssBlaster3000®[/] [grey]+2 Speed[/]")
            {
                if (MyHorse.Speed >= 20)
                {
                    AnsiConsole.Markup("[red]Speed's already 20![/]\n");
                }
                else if (MyHorse.Money < 3000)
                {
                    AnsiConsole.Markup("[red]I'm not running a charity here! Come back when you have some money to spend![/]\n");
                }
                else if (MyHorse.Speed == 19 && MyHorse.Money >= 3000)
                {
                    MyHorse.Speed += 1;
                    MyHorse.Money -= 3000;
                    MyHorse.IsBionic = true;
                    AnsiConsole.Markup("[green]Always a pleasure doing business![/]\n");
                }
                else
                {
                    MyHorse.Speed += 2;
                    MyHorse.Money -= 3000;
                    MyHorse.IsBionic = true;
                    AnsiConsole.Markup("[green]Always a pleasure doing business![/]\n");
                }

            }
            else if (menuOptions == "[#afaf00]Absolute Unit®[/] [grey]+2 Strength[/]")
            {
                if (MyHorse.Strength >= 20)
                {
                    AnsiConsole.Markup("[red]Strength's already 20![/]\n");
                }
                else if (MyHorse.Money < 3000)
                {
                    AnsiConsole.Markup("[red]I'm not running a charity here! Come back when you have some money to spend![/]\n");
                }
                else if (MyHorse.Strength == 19 && MyHorse.Money >= 3000)
                {
                    MyHorse.Strength += 1;
                    MyHorse.Money -= 3000;
                    MyHorse.IsBionic = true;
                    AnsiConsole.Markup("[green]Always a pleasure doing business![/]\n");
                }
                else
                {
                    MyHorse.Strength += 2;
                    MyHorse.Money -= 3000;
                    MyHorse.IsBionic = true;
                    AnsiConsole.Markup("[green]Always a pleasure doing business![/]\n");
                }

            }
            else if (menuOptions == "[#afaf00]Ultra Instinct®[/] [grey]+2 Dexterity[/]")
            {
                if (MyHorse.Dexterity >= 20)
                {
                    AnsiConsole.Markup("[red]Dexterity's already 20![/]\n");
                }
                else if (MyHorse.Money < 3000)
                {
                    AnsiConsole.Markup("[red]I'm not running a charity here! Come back when you have some money to spend![/]\n");
                }
                else if (MyHorse.Dexterity == 19 && MyHorse.Money >= 3000)
                {
                    MyHorse.Dexterity += 1;
                    MyHorse.Money -= 3000;
                    MyHorse.IsBionic = true;
                    AnsiConsole.Markup("[green]Always a pleasure doing business![/]\n");
                }
                else
                {
                    MyHorse.Dexterity += 2;
                    MyHorse.Money -= 3000;
                    MyHorse.IsBionic = true;
                    AnsiConsole.Markup("[green]Always a pleasure doing business![/]\n");
                }

            }
        }
    }

}
