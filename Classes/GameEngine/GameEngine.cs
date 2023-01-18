using ENW.Classes.Horses;
using ENW.Classes.Race;
using ENW.Classes.Staff;
using ENW.Classes.Stats;
using Spectre.Console;
using System.Text;



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
                string name = AnsiConsole.Ask<string>("What's your [#00d700]horse's[/] name?\n");
                string color = AnsiConsole.Prompt(new SelectionPrompt<string>()
                    .Title("What color is your [green]horse[/]?")
                    .PageSize(6)
                    .AddChoices(new[] { "[red]Red[/]", "[green]Green[/]", "[blue]Blue[/]", "[magenta]Magenta[/]", "[#ff5f00]Orange[/]", "[#ff5faf]Pink[/]" }));
                                        
                Console.Clear();

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

                var horse = new GenericHorse(name, color, streetCred, stamina, strength, speed, dexterity, 0, true, 0);

                IGenericHorse[] horseList = { horse };


                //Save(horseList);
                Console.Clear();
                Menu(horse);

                
            }
            //Listas e Cavalos Opositores
            void Race(IGenericHorse MyHorse)
            {
                var horse1 = new GenericHorse("[Red]Juca[/]", "Red", 10, 9, 14, 4, 18, 0, true, 0);
                var horse2 = new GenericHorse("[Blue]Martim[/]", "Blue", 18, 6, 14, 12, 10, 0, true, 0);
                var horse3 = new GenericHorse("[Green]Pimenta[/]", "Green", 15, 7, 7, 7, 15, 0, true, 0);
                var horse4 = new GenericHorse("[magenta]Juncal[/]", "Purple", 12, 18, 7, 7, 18, 0, true, 0);

                IGenericHorse[] horseList = { horse1, horse2, horse3, horse4, MyHorse};

                var race = new Race(horseList, 6);
                race.Start();
               // Console.Clear();
                Menu(MyHorse);
                
                
            }

            void Menu(IGenericHorse MyHorse)
            {
                string menuOptions = AnsiConsole.Prompt(new SelectionPrompt<string>()
                    .Title("Main Menu")
                    .PageSize(4)
                    .AddChoices(new[] { "[#afaf00]Race[/]", "[#afaf00]Shop[/]", "[#afaf00]Stats[/]", "[#afaf00]Exit[/]"  }));

                if (menuOptions == "[#afaf00]Race[/]")
                {
                    Race(MyHorse);
                }
                else if (menuOptions == "[#afaf00]Shop[/]")
                {
                    Console.Clear();
                    AnsiConsole.Markup("Welcome to the Shop! What can i get you?");

                }
                else if (menuOptions == "[#afaf00]Stats[/]")
                {
                   
                }
                else if (menuOptions == "[#afaf00]Exit[/]")
                {
                    Environment.Exit(1);
                }
               
            }

            return 0;
        }
       //Por alguma razão no meu pc não funciona a save function, mas funciona noutros. Pode ser um problema com permissões mas não tenho a certeza.

        public int Save(IGenericHorse[] data)
        {
            string dir = AppDomain.CurrentDomain.BaseDirectory;

            try
            {
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                string dirSave = dir + "/save";
                string fileName = dirSave + "/save.cvs";

                // Check if file already exists. If yes, delete it.     
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                // Create a new file     
                using (FileStream fs = File.Create(fileName))
                {
                    // Add collumns to file    
                    Byte[] title = new UTF8Encoding(true).GetBytes("Name, Color, Stamina, Strength, Speed, Dexterity, StreetCreed, Strikes, IsAlive\n");
                    fs.Write(title, 0, title.Length);

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
    }
}