using Spectre.Console;

using GameEngine;

namespace ENW
{
    internal class main
    {
        static void Main(string[] args)
        {
            AnsiConsole.Markup("Welcome to Equestrian Ninja Warrior\n");
            var GameRunner = new Runner(false);
            GameRunner.Run();

        }
    }
}
