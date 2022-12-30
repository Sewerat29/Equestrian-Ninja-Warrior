using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENW.Classes.Horses
{
    internal class GenericHorse
    {
        private string name;
        private string color;

        private int stamina;
        private int strength;
        private int speed;
        private int dexterity;
        private int streetCred;

        private int strikes = 0;
        private bool isAlive = true;

        public GenericHorse(string name, string color, int streetCred, int stamina, int strength, int speed, int dexterity)
        {
            this.name = name;
            this.color = color;
            this.streetCred = streetCred;
            this.stamina = stamina;
            this.strength = strength;
            this.speed = speed;
            this.dexterity = dexterity;
        }


    }
}
