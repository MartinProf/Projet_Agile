using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Agile
{
    public class CarteDeTemps
    {
        public CarteDeTemps() 
        {
            oneWeek = new List<List<WorkPeriod>>(); 
        }
        public List<List<WorkPeriod>> oneWeek { get; set; }
        public string DayName(List<WorkPeriod> singleDay)
        {
            switch (oneWeek.IndexOf(singleDay))
            {
                case 0:
                    return "Lundi: \n";
                    
                case 1:
                    return "Mardi: \n";
                    
                case 2:
                    return"Mercredi: \n";
                    
                case 3:
                    return"Jeudi: \n";
                 
                case 4:
                    return"Vendredi: \n";
                   
                case 5:
                    return"Samedi: \n";
                  
                case 6:
                    return"Dimanche: \n";
                default:
                    return "???";

            }
        }
        public override string ToString()
        {
            string returnString = "La semaine:\n\n";
            
            foreach (List <WorkPeriod> jour in oneWeek ?? new List<List<WorkPeriod>>())
            {
                returnString += DayName(jour);
                foreach (WorkPeriod workPeriod in jour)
                {
                    returnString += workPeriod.ToString() + "\n";
                }
                

            }
            return returnString;
        }

    }
}
