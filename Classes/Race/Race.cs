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

            for(int i = 0; i < horsesList.Length; i++)
            {
                horsesList[i].RaceLogs.Add(new SingleHorseRace(0, 0, numberOfTraps));
            }

            for(int i = 0; i < numberOfTraps; i++)
            {
                var obstacleStruct = obstacles.Generate();

                for(int j = 0; horsesList.Length > j; j++)
                {
                    int RaceLogsLength = horsesList[j].RaceLogs.Count;

                    switch (obstacleStruct.Type)
                    {
                        
                        case "STAMINA":
                            {                                
                                if (horsesList[j].Stamina >= obstacleStruct.Difficulty)
                                {
                                    AnsiConsole.Markup($"{horsesList[j].Name} [green]really is unstoppable![/]\n");

                                    SingleHorseRace obstacleLog = horsesList[j].RaceLogs[RaceLogsLength - 1];
                                    obstacleLog.ObstaclesCheck[i] = "PASS";
                                    obstacleLog.Points += 1;
                                    horsesList[j].RaceLogs[RaceLogsLength - 1] = obstacleLog;

                                } else
                                {
                                    AnsiConsole.Markup($"{horsesList[j].Name} [red]has the lungs of a smoker![/] \n");

                                    SingleHorseRace obstacleLog = horsesList[j].RaceLogs[RaceLogsLength - 1];
                                    obstacleLog.ObstaclesCheck[i] = "STRIKE";
                                    horsesList[j].RaceLogs[RaceLogsLength - 1] = obstacleLog;
                                }

                                break;
                            }
                        case "STRENGTH":
                            {
                                if (horsesList[j].Strength >= obstacleStruct.Difficulty)
                                {
                                    AnsiConsole.Markup($"{horsesList[j].Name} [green]didn't even break a sweat![/] \n");

                                    SingleHorseRace obstacleLog = horsesList[j].RaceLogs[RaceLogsLength - 1];
                                    obstacleLog.ObstaclesCheck[i] = "PASS";
                                    obstacleLog.Points += 1;
                                    horsesList[j].RaceLogs[RaceLogsLength - 1] = obstacleLog;
                                }
                                else
                                {
                                    AnsiConsole.Markup($"{horsesList[j].Name} [red]really isn't the gym type[/] \n");

                                    SingleHorseRace obstacleLog = horsesList[j].RaceLogs[RaceLogsLength - 1];
                                    obstacleLog.ObstaclesCheck[i] = "STRIKE";
                                    horsesList[j].RaceLogs[RaceLogsLength - 1] = obstacleLog;
                                    horsesList[j].Strikes += 1; //eventos strikes
                                }
                                
                                break;

                            }
                        case "SPEED":
                            {
                                if (horsesList[j].Speed >= obstacleStruct.Difficulty)
                                {
                                    AnsiConsole.Markup($"{horsesList[j].Name}[green] managed to escape![/] \n");

                                    SingleHorseRace obstacleLog = horsesList[j].RaceLogs[RaceLogsLength - 1];
                                    obstacleLog.ObstaclesCheck[i] = "PASS";
                                    obstacleLog.Points += 1;
                                    horsesList[j].RaceLogs[RaceLogsLength - 1] = obstacleLog;

                                } else
                                {
                                    AnsiConsole.Markup($"{horsesList[j].Name} [red]is now fuel for the almighty Truck®![/] \n");

                                    SingleHorseRace obstacleLog = horsesList[j].RaceLogs[RaceLogsLength - 1];
                                    obstacleLog.ObstaclesCheck[i] = "STRIKE";
                                    horsesList[j].RaceLogs[RaceLogsLength - 1] = obstacleLog;
                                }
                                
                                break;
                            }
                        case "DEXTERITY":
                            {
                                if (horsesList[j].Dexterity >= obstacleStruct.Difficulty)
                                {
                                    AnsiConsole.Markup($"{horsesList[j].Name}[green]'s ninja skills are showing![/] \n");

                                    SingleHorseRace obstacleLog = horsesList[j].RaceLogs[RaceLogsLength - 1];
                                    obstacleLog.ObstaclesCheck[i] = "PASS";
                                    obstacleLog.Points += 1;
                                    horsesList[j].RaceLogs[RaceLogsLength - 1] = obstacleLog;

                                }
                                else
                                {
                                    AnsiConsole.Markup($"{horsesList[j].Name}[red]'s turned into horse steak![/] [#00ffd7]That you can delight yourself with by going to today's sponsor Cantina do Ipca®![/]\n");

                                    SingleHorseRace obstacleLog = horsesList[j].RaceLogs[RaceLogsLength - 1];
                                    obstacleLog.ObstaclesCheck[i] = "STRIKE";
                                    horsesList[j].RaceLogs[RaceLogsLength - 1] = obstacleLog;
                                }
                                                                
                                break;
                            }
                    }
                }

                horsesList = horsesList.OrderByDescending(ob => ob.RaceLogs[ob.RaceLogs.Count - 1].Points).ToArray();

                AnsiConsole.Markup("\n\n");
            }

            for (int i = 0; horsesList.Length > i; i++)
            {
                if(i == 0)
                {
                    SingleHorseRace leaderboardLog = horsesList[i].RaceLogs[horsesList[i].RaceLogs.Count - 1];
                    leaderboardLog.Place = 1;
                    horsesList[i].RaceLogs[horsesList[i].RaceLogs.Count - 1] = leaderboardLog;
                } 
                else
                {
                    SingleHorseRace previousLeaderboardLog = horsesList[i - 1].RaceLogs[horsesList[i - 1].RaceLogs.Count - 1];
                    SingleHorseRace leaderboardLog = horsesList[i].RaceLogs[horsesList[i].RaceLogs.Count - 1];

                    if(previousLeaderboardLog.Points == leaderboardLog.Points)
                    {
                        leaderboardLog.Place = previousLeaderboardLog.Place;
                        horsesList[i].RaceLogs[horsesList[i].RaceLogs.Count - 1] = leaderboardLog;
                    }
                    else
                    {
                        leaderboardLog.Place = previousLeaderboardLog.Place + 1;
                        horsesList[i].RaceLogs[horsesList[i].RaceLogs.Count - 1] = leaderboardLog;
                    }
                }
            }

            var table = new Table();
            
            table.AddColumn("Names");
            for(int i = 0; i < numberOfTraps; i++)
            {
                table.AddColumn($"Obstacles {i + 1}");
            }
            table.AddColumn("Total Points");
            table.AddColumn("Place");

            foreach (IGenericHorse horse in horsesList)
            {

                table.AddRow(
                    horse.Name,
                    horse.RaceLogs[horse.RaceLogs.Count - 1].ObstaclesCheck[0],
                    horse.RaceLogs[horse.RaceLogs.Count - 1].ObstaclesCheck[1],
                    horse.RaceLogs[horse.RaceLogs.Count - 1].ObstaclesCheck[2],
                    horse.RaceLogs[horse.RaceLogs.Count - 1].ObstaclesCheck[3],
                    horse.RaceLogs[horse.RaceLogs.Count - 1].ObstaclesCheck[4],
                    horse.RaceLogs[horse.RaceLogs.Count - 1].Points.ToString(),
                    horse.RaceLogs[horse.RaceLogs.Count - 1].Place.ToString()
                );
            }

            // Render the table to the console
            AnsiConsole.Write(table);
        }
        
    }
}
