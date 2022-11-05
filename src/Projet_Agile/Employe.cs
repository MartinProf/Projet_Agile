using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Agile
{
    public class Employe : Person
    {
        public Employe(int noUser, string lastName, string firstName, string email, string password, string inscriptionDate)
        {

            try
            {
                this.lastName = lastName;
                this.firstName = firstName;
                this.email = email;
                this.password = password;
                this.inscriptionDate = inscriptionDate;
                if (noUser >= 1000)
                {
                    this.noUser = noUser;
                }
                else throw new Exception();
            }
            catch (Exception e)
            {
                Console.WriteLine("Le numéro entrée est non valide pour un Employé");
                this.noUser = -1;
            }
        }
        public int noUser
        {
            get; set;
        }
        public string lastName 
        { 
            get; set;
        }
        public string firstName 
        { 
            get; set;
        }
        public string email 
        { 
            get; set;
        }
        public string password 
        { 
            get; set;
        }
        public string inscriptionDate 
        { 
            get;
        }
    }
}
