using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Agile
{
    public class Timesheet
    {
        public Timesheet() { }
        [JsonProperty("numero employe")]
        public int empNumber
        {
            get; set;
        }  
        public CarteDeTemps carteDeTemps { get; set; }
        public override string ToString()
        {
            string returnString = $"employe number : {empNumber}\n";
            returnString += carteDeTemps.ToString();
            return returnString;
        }


        public void validateAdmin36Hours()
        {
            try
            {
                int minutes = 0;

                if(empNumber < 1000)
                {
                    foreach (List<WorkPeriod> jour in carteDeTemps.oneWeek)
                    {
                        foreach (var item in jour)
                        {
                            if (item.codeProject <= 900)
                            {
                                minutes += item.minute;
                            }
                        }                       
                    }
                    if (minutes < (36 * 60))
                    {
                        Console.WriteLine("L'administrateur : #" + empNumber + " n'a pas travaillé le minimum d'heures requises au bureau. Il en a travaillé " + minutes / 60 + " sur 36 minimum.");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void validateNormalEmp38Hours()
        {
            try
            {
                int minutes = 0;

                if (empNumber >= 1000)
                {
                    foreach (List<WorkPeriod> jour in carteDeTemps.oneWeek)
                    {
                        foreach (var item in jour)
                        {
                            if (item.codeProject <= 900)
                            {
                                minutes += item.minute;
                            }
                        }                       
                    }
                    if (minutes < (38 * 60))
                    {
                        Console.WriteLine("L'employé normal : #" + empNumber + " n'a pas travaillé le minimum d'heures requises au bureau. Il en a travaillé " + minutes / 60 + " sur 38 minimum.");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*Cette fonction valide si l'employé regulier a fait ou non un minimum de 6 heures de travail par jour (Lundi - Vendredi)
        soit télétravail ou au bureau */
        public void validateNormalEmp6HoursPerDay()
        {   
            if (empNumber >= 1000)
            {
                int minutesPerDay = 0;
                foreach (List<WorkPeriod> jour in carteDeTemps.oneWeek)
                {                  
                    foreach (WorkPeriod workPeriod in jour)
                    {
                        if (workPeriod.codeProject <= 900)
                        {
                            minutesPerDay += workPeriod.minute;
                        }
                    }
                    if (minutesPerDay < 360)
                    {
                        Console.WriteLine("L'employé normal : #" + empNumber + " n'a pas travaillé le minimum de temps requis (360 minutes) " + carteDeTemps.DayName(jour) + "! temps travaillé ce jour-ci: " + minutesPerDay + " Minutes.");
                    }
                }              
            }           
        }

        public void validateAdmin4HoursPerDay()
        {
            if (empNumber < 1000)
            {
                int minutesPerDay = 0;
                foreach (List<WorkPeriod> jour in carteDeTemps.oneWeek)
                {                   
                    foreach (WorkPeriod workPeriod in jour)
                    {
                        if (workPeriod.codeProject <= 900)
                        {
                            minutesPerDay += workPeriod.minute;
                        }
                    }
                    if (minutesPerDay < 240)
                    {
                        Console.WriteLine("L'employé normal : #" + empNumber + " n'a pas travaillé le minimum de temps requis (240 minutes) " + carteDeTemps.DayName(jour) + "!  temps travaillé ce jour-ci: " + minutesPerDay + " Minutes.");
                    }
                }
            }
        }

        /*Cette fonction valide si l'employé a depassé les heures permises par semaine de travail au bureau (43h / 2580 minutes)*/
        public void validate43HoursMaxOffice()
        {
            int weeklytotal = 0;

            foreach (List<WorkPeriod> jour in carteDeTemps.oneWeek)
            {
                foreach (WorkPeriod workPeriod in jour)
                {
                    if (workPeriod.codeProject <= 900) weeklytotal += workPeriod.minute;
                }    
            }
            if (weeklytotal > 2580)
            {
                Console.WriteLine("L'employé a depassé le temps de travaul permis au bureau (43heures / 2580 minutes)!   temps travaillé cette semaine-ci: " + weeklytotal + " Minutes.");
            }
        }


        public void validateAdmin10HoursTeleWork()
        {
            try
            {
                int minutes = 0;

                if (empNumber < 1000)
                {
                    foreach (List<WorkPeriod> jour in carteDeTemps.oneWeek)
                    {
                        foreach (var item in jour)
                        {
                            if (item.codeProject > 900)
                            {
                                minutes += item.minute;
                            }
                        }
                    }
                    if (minutes > (10 * 60))
                    {
                        Console.WriteLine("L'administrateur : #" + empNumber + " a dépassé le nombre d'heures permises en télétravail. Il en a travaillé " + minutes / 60 + " sur une possibilité de 10 maximum.");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
