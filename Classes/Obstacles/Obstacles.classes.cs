
using Spectre.Console;
using System;

namespace ENW.Classes.Obstacles
{
    internal class Obstacles
    {
        private enum TypesOfObstacles
        {
            STAMINA,
            STRENGTH,
            SPEED,
            DEXTERITY
        }

        public void Generate()
        {
            Random rnd = new Random();
            int ObstacleNumber = rnd.Next(0, 3);
            TypesOfObstacles ObstacleType = (TypesOfObstacles)ObstacleNumber;

            switch (ObstacleType)
            {
                case TypesOfObstacles.STAMINA:
                    {
                        AnsiConsole.Markup("STAMINA\n");

                        break;
                    }
                case TypesOfObstacles.STRENGTH:
                    {
                        AnsiConsole.Markup("STRENGTH\n");

                        break;
                    }
                case TypesOfObstacles.SPEED:
                    {
                        AnsiConsole.Markup("SPEED\n");

                        break;
                    }
                case TypesOfObstacles.DEXTERITY:
                    {
                        AnsiConsole.Markup("DEXTERITY\n");

                        break;
                    }
                default:
                    AnsiConsole.Markup("LUL"); 
                    break;
            }
        }

    }
}
