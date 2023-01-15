using ENW.Classes.Horses;
using Spectre.Console;

namespace ENW.Classes.Race
{
    internal class Race
    {
        private IGenericHorse[] horsesList;
        private IGenericHorse[]? scoreBoard;
        private int numberOfTraps;

        public Race(IGenericHorse[] horsesList, int numberOfTraps)
        {
            this.horsesList = horsesList;
            this.numberOfTraps = numberOfTraps;
        }

        public void Start()
        {
            var obstacles = new Obstacles.Obstacles();

            for(int i = 0; i < numberOfTraps; i++)
            {
                
                var obstacleStruct = obstacles.Generate();

                for(int j = 0; horsesList.Length > j; j++)
                {
                    if(i == 0)
                    {
                        
                    }

                    switch (obstacleStruct.Type)
                    {
                        
                        case "STAMINA":
                            {                                
                                if (horsesList[j].Stamina >= obstacleStruct.Difficulty)
                                {
                                    AnsiConsole.Markup($"{horsesList[j].Name} [green]really is unstoppable![/]\n");

                                } else
                                {
                                    AnsiConsole.Markup($"{horsesList[j].Name} [red]has the lungs of a smoker![/] \n");
                                }

                                break;
                            }
                        case "STRENGTH":
                            {
                                if (horsesList[j].Strength >= obstacleStruct.Difficulty)
                                {
                                    AnsiConsole.Markup($"{horsesList[j].Name} [green]didn't even break a sweat![/] \n");

                                }
                                else
                                {
                                    AnsiConsole.Markup($"{horsesList[j].Name} [red]really isn't the gym type[/] \n");
                                    horsesList[j].Strikes += 1; //eventos strikes
                                }
                                
                                break;

                            }
                        case "SPEED":
                            {
                                if (horsesList[j].Speed >= obstacleStruct.Difficulty)
                                {
                                    AnsiConsole.Markup($"{horsesList[j].Name}[green] managed to escape![/] \n");

                                } else
                                {
                                    AnsiConsole.Markup($"{horsesList[j].Name} [red]is now fuel for the almighty Truck®![/] \n");
                                }
                                
                                break;
                            }
                        case "DEXTERITY":
                            {
                                if (horsesList[j].Dexterity >= obstacleStruct.Difficulty)
                                {
                                    AnsiConsole.Markup($"{horsesList[j].Name}[green]'s ninja skills are showing![/] \n");

                                }
                                else
                                {
                                    AnsiConsole.Markup($"{horsesList[j].Name}[red]'s turned into horse steak![/] [#00ffd7]That you can delight yourself with by going to today's sponsor Cantina do Ipca®![/]\n");
                                }
                                                                
                                break;
                            }
                    }
                }
                AnsiConsole.Markup("\n\n");
            }
            var table = new Table();

            
            table.AddColumn("Names");
            for(int i = 0; i <= numberOfTraps; i++)
            {
                table.AddColumn($"Obstacles {i+1}");
            }
            table.AddColumn("Total");

            table.AddColumn("Place");

            // Add some rows
            table.AddRow("Baz", "[green]Qux[/]");
            table.AddRow(new Markup("[blue]Corgi[/]"), new Panel("Waldo"));

            // Render the table to the console
            AnsiConsole.Write(table);
        }
        
    }
}
