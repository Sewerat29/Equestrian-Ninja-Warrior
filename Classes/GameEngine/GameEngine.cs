using Spectre.Console;

using ENW.Classes.Horses;
using ENW.Classes.Race;

namespace GameEngine
{
    public class Runner
    {
        bool saveExists = false;

        public Runner(bool saveExists)
        {
            this.saveExists = saveExists;
        }

        public int Run()
        {
            if (saveExists)
            {

            }
            else
            {
                AnsiConsole.Markup("Let's create your horse!\n");
                string name = AnsiConsole.Ask<string>("What's your [green]horse[/] name?\n");
                string color = AnsiConsole.Prompt(new SelectionPrompt<string>()
                    .Title("What color is your [green]horse[/]?")
                    .PageSize(6)
                    .AddChoices(new[] { "[red]Red[/]", "[green]Green[/]", "[blue]Blue[/]", "[magenta]Magenta[/]", "[#ff5f00]Orange[/]", "[#ff5faf]Pink[/]" }));

                AnsiConsole.Markup("You will have 50 points to distribute in 5 attributes to a max of 20 per attribute. Pick wisely!\n");
                int streetCred = AnsiConsole.Prompt(
                        new TextPrompt<int>("Street Cred: \n")
                            .ValidationErrorMessage("[red]That's not a valid number[/]" +
                            "")
                            .Validate(streetCred =>
                            {
                                return streetCred switch
                                {
                                    < 0 => ValidationResult.Error("[red]Minimum 0 points![/]"),
                                    > 20 => ValidationResult.Error("[red]Max 20 points![/]"),
                                    _ => ValidationResult.Success(),
                                };
                            }));
                int stamina = AnsiConsole.Prompt(
                        new TextPrompt<int>("Stamina: \n")
                            .ValidationErrorMessage("[red]That's not a valid number[/]")
                            .Validate(stamina =>
                            {
                                return stamina switch
                                {
                                    < 0 => ValidationResult.Error("[red]Minimum 0 points![/]"),
                                    > 20 => ValidationResult.Error("[red]Max 20 points![/]"),
                                    _ => ValidationResult.Success(),
                                };
                            }));
                int strength = AnsiConsole.Prompt(
                        new TextPrompt<int>("Strength: \n")
                            .ValidationErrorMessage("[red]That's not a valid number[/]")
                            .Validate(strength =>
                            {
                                return strength switch
                                {
                                    < 0 => ValidationResult.Error("[red]Minimum 0 points![/]"),
                                    > 20 => ValidationResult.Error("[red]Max 20 points![/]"),
                                    _ => ValidationResult.Success(),
                                };
                            }));
                int speed = AnsiConsole.Prompt(
                        new TextPrompt<int>("Speed: \n")
                            .ValidationErrorMessage("[red]That's not a valid number[/]")
                            .Validate(speed =>
                            {
                                return speed switch
                                {
                                    < 0 => ValidationResult.Error("[red]Minimum 0 points![/]"),
                                    > 20 => ValidationResult.Error("[red]Max 20 points![/]"),
                                    _ => ValidationResult.Success(),
                                };
                            }));
                int dexterity = AnsiConsole.Prompt(
                        new TextPrompt<int>("Dexterity: \n")
                            .ValidationErrorMessage("[red]That's not a valid number[/]")
                            .Validate(dexterity =>
                            {
                                return dexterity switch
                                {
                                    < 0 => ValidationResult.Error("[red]Minimum 0 points![/]"),
                                    > 20 => ValidationResult.Error("[red]Max 20 points![/]"),
                                    _ => ValidationResult.Success(),
                                };
                            }));

                var horse = new GenericHorse(name, color, streetCred, stamina, strength, speed, dexterity);

                Menu();
            }

            void Race()
            {
                var race = new Race("ah", 6);
                race.Start();
            }

            void Menu()
            {
                string menuOptions = AnsiConsole.Prompt(new SelectionPrompt<string>()
                    .Title("Main Menu")
                    .PageSize(3)
                    .AddChoices(new[] { "[#afaf00]Race[/]", "[#afaf00]Shop[/]", "[#afaf00]Exit[/]" }));

                if (menuOptions == "[#afaf00]Race[/]")
                {
                    Race();
                }
                else if (menuOptions == "[#afaf00]Shop[/]")
                {


                }
                else if (menuOptions == "[#afaf00]Exit[/]")
                {
                    System.Environment.Exit(1);

                }
            }

            return 0;
        }
    }
}
