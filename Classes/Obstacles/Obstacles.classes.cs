
using Spectre.Console;

namespace ENW.Classes.Obstacles
{
    internal class Obstacles
    {
        //Enums
        private enum TypesOfObstacles
        {
            STAMINA,
            STRENGTH,
            SPEED,
            DEXTERITY
        }

        public struct ObstaclesResponse
        {
            public string Type;
            public int Difficulty;
        }

        public ObstaclesResponse Generate()
        {
            Random rnd = new Random();
            int ObstacleNumber = rnd.Next(0, 4);
            TypesOfObstacles ObstacleType = (TypesOfObstacles)ObstacleNumber;
            ObstaclesResponse response;

            switch (ObstacleType)
            {
                case TypesOfObstacles.STAMINA:
                    {
                        response.Type = TypesOfObstacles.STAMINA.ToString(); //Override ToString
                        response.Difficulty = rnd.Next(0, 20);

                        AnsiConsole.Markup("The Eternal® treadmill is upon them! Can our contestants endure? \n");

                        return response;
                    }
                case TypesOfObstacles.STRENGTH:
                    {
                        response.Type = TypesOfObstacles.STRENGTH.ToString();
                        response.Difficulty = rnd.Next(0, 20);

                        AnsiConsole.Markup("It's really just a Really Big Boulder®! Brought to us by our lovely sponsor, [#00ffd7]Arasaka® Industries![/]\n");

                        return response;
                    }
                case TypesOfObstacles.SPEED:
                    {
                        response.Type = TypesOfObstacles.SPEED.ToString();
                        response.Difficulty = rnd.Next(0, 20);

                        AnsiConsole.Markup("The Giant Horse-Eating Truck® has just spawned on the track! Will our horses be able to outrun it??\n");

                        return response;
                    }
                case TypesOfObstacles.DEXTERITY:
                    {
                        response.Type = TypesOfObstacles.DEXTERITY.ToString();
                        response.Difficulty = rnd.Next(0, 20);

                        AnsiConsole.Markup("In come the Spinning Blades ready to chop these poor horses to shreds!\n");

                        return response;
                    }
                default:
                    {
                        response.Type = "NON VALID TYPE";
                        response.Difficulty = 0;

                        return response;
                    }
            }
        }
    }
}
