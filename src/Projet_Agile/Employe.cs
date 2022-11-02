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
            this.noUser = noUser;
        }

        public int noUser
        {
            get; set;
        }
    }
}
