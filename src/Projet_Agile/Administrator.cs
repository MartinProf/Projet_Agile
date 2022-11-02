using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Agile
{
    class Administrator : Person
    {
        public Administrator(int noUser, string lastName, string firstName, string email, string password, string inscriptionDate) : base(lastName, firstName, email, password)
        {
            if(noUser >= 1000)
            {
                this.noUser = int.Parse(null);
                this.lastName = null; 
                this.firstName = null;
                this.email = null;
                this.password = null;
                Console.WriteLine("Le numéro de user est invalide pour cette catégorie d'employé");
            }
            else
                this.noUser = noUser;
        }

        public int noUser
        {
            get; set;
        }

        public Project createProject(int id, int code)
        {           
            return new Project(id, code);
        }
    }
}
