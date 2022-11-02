using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Agile
{
    public class Employe : Person
    {
        public Employe(int noUser, string lastName, string firstName, string email, string password, string inscriptionDate) : base (lastName, firstName, email, password)
        {
            if(noUser < 1000)
            {
                Console.WriteLine("Le numéro de user est invalide pour cette catégorie d'employé");
            }
            else
                this.noUser = noUser;
        }

        public int noUser
        {
            get; set;
        }
    }
}
