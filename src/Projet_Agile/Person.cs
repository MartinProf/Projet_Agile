using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Agile
{
    //Cette classe est la classe mère des classes "Administrator" et "Employee"
    public class Person
    {
        public Person(string lastName, string firstName, string email, string password)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.email = email;
            this.password = password;
            inscriptionDate = DateTime.Now.ToString();
        }

        public string lastName
        {
            get;
            set;
        }
        public string firstName
        {
            get;
            set;
        }
        public string email
        {
            get;
            set;
        }

        public string password

        {
            get;
            set;
        }
        public string inscriptionDate
        {
            get;
        }

       
    }
}
