﻿using ENW.Classes.Horses;

namespace ENW.Classes.Horses
{
    //Herança
    internal class BionicHorse : GenericHorse
    {
        bool ironLungs = false;    //+2 stamina
        bool assBlaster = false;   //+2 speed
        bool absoluteUnit = false; //+2 strength
        bool ultraInstinct = false;   //+2 dexterity
        bool totemOfUndying = false; //+1 strike

        public BionicHorse(string name, string color, int stamina, int strength, int speed, int dexterity, int strikes, int streetCred, bool isAlive, int money, bool ironLungs, bool assBlaster, bool absoluteUnit, bool springLegs, bool totemOfUndying) : base(name, color, stamina, strength, speed, dexterity, strikes, streetCred, isAlive, money)
        {
            this.ironLungs = ironLungs;
            this.assBlaster = assBlaster; 
            this.absoluteUnit = absoluteUnit;
            this.ultraInstinct = springLegs;
            this.totemOfUndying = totemOfUndying;
        }

        public void IronLungs()
        {
            if (ironLungs == true)
            {


            }
        }
    }
}