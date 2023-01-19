using Spectre.Console;

using GameEngine;

namespace ENW
{
    internal class main
    {
        static void Main(string[] args)
        {
            AnsiConsole.Markup("Welcome to EQUESTRIAN NINJA WARRIOR®!! [#00d700]No Horses were harmed during the creation of this game![/]\n");
            var GameRunner = new Runner(false);
            GameRunner.Run();

        }
    }
}
