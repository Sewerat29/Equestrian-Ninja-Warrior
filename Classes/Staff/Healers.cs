

namespace ENW.Classes.Staff
{ //Incluir Aqui Polimorfismo/overload. Metodo "Heal" que faz coisas diferentes dependendo se é Vet ou Mechanic
    internal class Healers
    {
        string profession;
        int salary;

        public Healers(string profession, int salary)
        {
            this.profession = profession;
            this.salary = salary;
        }

        public void Heal()
        {


        }
    }
}
