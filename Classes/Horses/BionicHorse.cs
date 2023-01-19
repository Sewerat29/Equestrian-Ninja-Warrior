using ENW.Classes.Horses;

namespace ENW.Classes.Horses
{
    //Inheritance . Purchasing Upgrades on the Shop will turn your GenericHorse into a BionicHorse
    internal class BionicHorse : GenericHorse
    {
        bool ironLungs = false;    //+2 stamina
        bool assBlaster3000 = false;   //+2 speed
        bool absoluteUnit = false; //+2 strength
        bool ultraInstinct = false;   //+2 dexterity
        bool totemOfUndying = false; //+1 strike

        public BionicHorse(string name, string color, int stamina, int strength, int speed, int dexterity, int strikes, int streetCred, bool isAlive, int money,bool isBionic, bool ironLungs, bool assBlaster3000, bool absoluteUnit, bool springLegs, bool totemOfUndying) : base(name, color, stamina, strength, speed, dexterity, strikes, streetCred, isAlive, isBionic)
        {
            this.ironLungs = ironLungs;
            this.assBlaster3000 = assBlaster3000; 
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
