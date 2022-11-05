using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Agile
{
    //Cette classe est la classe mère des classes "Administrator" et "Employee"
    public interface Person
    {
        string lastName
        {
            get;
            set;
        }
        string firstName
        {
            get;
            set;
        }
        string email
        {
            get;
            set;
        }

        string password

        {
            get;
            set;
        }
        string inscriptionDate
        {
            get;
        }
    }
}
