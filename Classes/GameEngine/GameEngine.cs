using ENW.Classes.Horses;
using ENW.Classes.Race;
using ENW.Classes.Staff;
using ENW.Classes.Stats;
using Spectre.Console;
using System.Text;

//This is the center of the action that makes the whole game run

namespace GameEngine
{
    public class Runner
    {
        bool saveExists;

        public Runner(bool saveExists)
        {
            string dir = AppDomain.CurrentDomain.BaseDirectory;


            if (File.Exists(dir + "save/save.cvs"))
            {
                this.saveExists = true;
            }
            else
            {
                this.saveExists = false;

            }
        }

        public int Run()
        {
            if (saveExists)
            {
                IGenericHorse myHorse = ReadSave();
                Menu(myHorse);
            }
            else
            {
                AnsiConsole.Markup("Let's create your horse!\n");
                string name = AnsiConsole.Ask<string>("What's your [#00d700]horse's[/] name?\n");
                string color = AnsiConsole.Prompt(new SelectionPrompt<string>()
                    .Title("What color is your [#00d700]horse[/]?")
                    .PageSize(6)
                    .AddChoices(new[]{ "[red]Red[/]", "[green]Green[/]", "[blue]Blue[/]", "[magenta]Magenta[/]", "[#ff5f00]Orange[/]", "[#ff5faf]Pink[/]" }));
                                        
                Console.Clear();
                
                //Stat Creator
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

                var horse = new GenericHorse(name, color, streetCred, stamina, strength, speed, dexterity, 0, true);

                IGenericHorse[] horseList = { horse };


                Save(horseList);
                Console.Clear();
                Menu(horse);
            }

            //Listas e Cavalos Opositores
            void Race(IGenericHorse MyHorse)
            {
                //List with the Npc Horses
                Console.Clear();
                var horse1 = new GenericHorse("[Red]Juca[/]", "Red", 10, 9, 14, 4, 18, 0, true);
                var horse2 = new GenericHorse("[Blue]Martim[/]", "Blue", 18, 16, 14, 12, 10, 0, true);
                var horse3 = new GenericHorse("[Green]Pimenta[/]", "Green", 8, 7, 7, 7, 15, 0, true);
                var horse4 = new GenericHorse("[magenta]Juncal[/]", "Magenta", 12, 18, 7, 7, 18, 0, true);

                IGenericHorse[] horseList = { horse1, horse2, horse3, horse4, MyHorse};

                var race = new Race(horseList, 8);
                race.Start();
                Menu(MyHorse);                
                
            }

            void Shop(IGenericHorse MyHorse)
            {
                Console.Clear();    
                var Shop = new Shop();
                Shop.ShopMenu(MyHorse);
                Menu(MyHorse);
            }

            void Stats(IGenericHorse MyHorse)
            {
                Console.Clear();
                var Stats = new Stats();
                Stats.StatsList(MyHorse);
                Menu(MyHorse);
            }

            //Main Menu
            void Menu(IGenericHorse MyHorse)
            {
                string menuOptions = AnsiConsole.Prompt(new SelectionPrompt<string>()
                    .Title("Main Menu")
                    .PageSize(5)
                    .AddChoices(new[] { "[#afaf00]Race[/]", "[#afaf00]Shop[/]", "[#afaf00]Stats[/]","[#afaf00]Save[/]", "[#afaf00]Exit[/]" }));

                if (menuOptions == "[#afaf00]Race[/]")
                {
                    Race(MyHorse);
                }
                else if (menuOptions == "[#afaf00]Shop[/]")
                {
                    Shop(MyHorse);
                    Menu(MyHorse);
                }
                else if (menuOptions == "[#afaf00]Stats[/]")
                {
                    Stats(MyHorse);
                }
                else if (menuOptions == "[#afaf00]Save[/]")
                {
                    IGenericHorse[] horseList = {  MyHorse };
                    Save(horseList);
                }
                else if (menuOptions == "[#afaf00]Exit[/]")
                {
                    Environment.Exit(1);
                }
            }

            return 0;
        }

        public int Save(IGenericHorse[] data)
        {
            string dir = AppDomain.CurrentDomain.BaseDirectory;

            try
            {
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                string dirSave = dir + "save";
                string fileName = dirSave + "/save.cvs";

                // Check if file already exists. If yes, delete it.     
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                // Create the directory save
                Directory.CreateDirectory(dirSave);

                // Create a new file     
                using (FileStream fs = File.Create(fileName))
                {
                    if (data.Length > 0)
                    {
                        for (int i = 0; i < data.Length; i++)
                        {
                            Byte[] horse = new UTF8Encoding().GetBytes($"{data[i].Name}, {data[i].Color}, {data[i].Stamina}, {data[i].Strength}, {data[i].Speed}, {data[i].Dexterity}, {data[i].StreetCred}, {data[i].Strikes}, {data[i].IsAlive}\n");
                            fs.Write(horse, 0, horse.Length);
                        }
                    }

                    fs.Close();
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }

            return 0;
        }

        IGenericHorse ReadSave()
        {
            string dir = AppDomain.CurrentDomain.BaseDirectory;
            IGenericHorse myHorse;


            using (var reader = new StreamReader(dir + "save/save.cvs"))
            {
                var line = reader.ReadLine();
                var values = line?.Split(',');

                myHorse = new GenericHorse(values[0], values[1], Int16.Parse(values[2]), Int16.Parse(values[3]), Int16.Parse(values[4]), Int16.Parse(values[5]), Int16.Parse(values[6]), Int16.Parse(values[7]), true);
            }

            return myHorse;
        }
    }
}