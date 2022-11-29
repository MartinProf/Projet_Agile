using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Agile
{
    class TimeSheet
    {
        public TimeSheet()
        {
            oneWeek = new List<List<WorkPeriod>>();
        }

        public List<List<WorkPeriod>> oneWeek { get; set; }

        public string DayName(List<WorkPeriod> singleDay)
        {
            switch (oneWeek.IndexOf(singleDay))
            {
                case 0:
                    return "Lundi: ";

                case 1:
                    return "Mardi: ";

                case 2:
                    return "Mercredi: ";

                case 3:
                    return "Jeudi: ";

                case 4:
                    return "Vendredi: ";

                case 5:
                    return "Samedi: ";

                case 6:
                    return "Dimanche: ";
                default:
                    return "???";

            }
        }
        public override string ToString()
        {
            string returnString = "La semaine:\n\n";

            foreach (List<WorkPeriod> jour in oneWeek ?? new List<List<WorkPeriod>>())
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
