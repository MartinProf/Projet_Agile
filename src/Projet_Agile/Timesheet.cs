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
        [JsonProperty("jour1")]
        public  List<WorkPeriod> jour1 { get; set; }
        [JsonProperty("jour2")]
        public List<WorkPeriod> jour2 { get; set; }
        [JsonProperty("jour3")]
        public List<WorkPeriod> jour3 { get; set; }
        [JsonProperty("jour4")]
        public List<WorkPeriod> jour4 { get; set; }
        [JsonProperty("jour5")]
        public List<WorkPeriod> jour5 { get; set; }
        [JsonProperty("weekendl")]
        public List<WorkPeriod> weekend1 { get; set; }
        [JsonProperty("weekend2")]
        public List<WorkPeriod> weekend2 { get; set; }   
        public override string ToString()
        {
            string returnString = $"employe number : {empNumber}\n"+
               "Lundi:\n";

            foreach (WorkPeriod workPeriod in jour1 ?? new List<WorkPeriod>()) 
            {
                returnString += workPeriod.ToString();
                
            }
            returnString += $"Mardi:\n";
            foreach (WorkPeriod workPeriod in jour2 ?? new List<WorkPeriod>())
            {
                returnString += workPeriod.ToString();
            }
            returnString += $"Mercredi:\n";
            foreach (WorkPeriod workPeriod in jour3 ?? new List<WorkPeriod>())
            {
                returnString += workPeriod.ToString();
            }
            returnString += $"Jeudi:\n";
            foreach (WorkPeriod workPeriod in jour4 ?? new List<WorkPeriod>())
            {
                returnString += workPeriod.ToString();
            }
            returnString += $"Vendredi:\n";
            foreach (WorkPeriod workPeriod in jour5 ?? new List<WorkPeriod>())
            {
                returnString += workPeriod.ToString();
            }
            returnString += $"Samedi:\n";
            foreach (WorkPeriod workPeriod in weekend1 ?? new List<WorkPeriod>())
            {
                returnString += workPeriod.ToString();
            }
            returnString += $"Dimanche:\n";
            foreach (WorkPeriod workPeriod in weekend2 ?? new List<WorkPeriod>())
            {
                returnString += workPeriod.ToString();
            }
            return returnString;
        }


        public void validateAdmin36Hours()
        {
            try
            {
                int minutes = 0;

                if(empNumber < 1000)
                {
                    foreach (var item in jour1)
                    {
                        if (item.codeProject <= 900)
                        {
                            minutes += item.minute;
                        }
                    }
                    foreach (var item in jour2)
                    {
                        if (item.codeProject <= 900)
                        {
                            minutes += item.minute;
                        }
                    }
                    foreach (var item in jour3)
                    {
                        if (item.codeProject <= 900)
                        {
                            minutes += item.minute;
                        }
                    }
                    foreach (var item in jour4)
                    {
                        if (item.codeProject <= 900)
                        {
                            minutes += item.minute;
                        }
                    }
                    foreach (var item in jour5)
                    {
                        if (item.codeProject <= 900)
                        {
                            minutes += item.minute;
                        }
                    }
                    foreach (var item in weekend1)
                    {
                        if (item.codeProject <= 900)
                        {
                            minutes += item.minute;
                        }
                    }
                    foreach (var item in weekend2)
                    {
                        if (item.codeProject <= 900)
                        {
                            minutes += item.minute;
                        }
                    }

                    if(minutes < (36 * 60))
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
                    foreach (var item in jour1)
                    {
                        if (item.codeProject <= 900)
                        {
                            minutes += item.minute;
                        }
                    }
                    foreach (var item in jour2)
                    {
                        if (item.codeProject <= 900)
                        {
                            minutes += item.minute;
                        }
                    }
                    foreach (var item in jour3)
                    {
                        if (item.codeProject <= 900)
                        {
                            minutes += item.minute;
                        }
                    }
                    foreach (var item in jour4)
                    {
                        if (item.codeProject <= 900)
                        {
                            minutes += item.minute;
                        }
                    }
                    foreach (var item in jour5)
                    {
                        if (item.codeProject <= 900)
                        {
                            minutes += item.minute;
                        }
                    }
                    foreach (var item in weekend1)
                    {
                        if (item.codeProject <= 900)
                        {
                            minutes += item.minute;
                        }
                    }
                    foreach (var item in weekend2)
                    {
                        if (item.codeProject <= 900)
                        {
                            minutes += item.minute;
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

                    if(workPeriod.codeProject <= 900)
                    {
                        minutesPerDayMonday += workPeriod.minute;

                    }

                }
                if (minutesPerDayMonday < 360)
                {
                    Console.WriteLine("L'employé normal : #" + empNumber + " n'a pas travaillé le minimum de temps requis (360 minutes) lundi!   temps travaillé ce jour-ci: " + minutesPerDayMonday + " Minutes.");
                }

                int minutesPerDayTuesday = 0;
                foreach (WorkPeriod workPeriod in jour2)
                {

                    if (workPeriod.codeProject <= 900)
                    {
                        minutesPerDayTuesday += workPeriod.minute;

                    }
                }
                if (minutesPerDayTuesday < 360)
                {
                    Console.WriteLine("L'employé normal : #" + empNumber + " n'a pas travaillé le minimum de temps requis (360 minutes) le mardi!   temps travaillé ce jour-ci: " + minutesPerDayTuesday + " Minutes.");

                }

                int minutesPerDayWednesday = 0;
                foreach (WorkPeriod workPeriod in jour3)
                {


                    if (workPeriod.codeProject <= 900)
                    {
                        minutesPerDayWednesday += workPeriod.minute;

                    }
                }
                if (minutesPerDayWednesday < 360)
                {
                    Console.WriteLine("L'employé normal : #" + empNumber + " n'a pas travaillé le minimum de temps requis (360 minutes) le mercredi!   temps travaillé ce jour-ci: " + minutesPerDayWednesday + " Minutes.");

                }
                
                int minutesPerDayThursday = 0;
                foreach (WorkPeriod workPeriod in jour4)
                {


                    if (workPeriod.codeProject <= 900)
                    {
                        minutesPerDayThursday += workPeriod.minute;

                    }
                }
                if (minutesPerDayThursday < 360)
                {
                    Console.WriteLine("L'employé normal : #" + empNumber + " n'a pas travaillé le minimum de temps requis (360 minutes) le jeudi!   temps travaillé ce jour-ci: " + minutesPerDayThursday + " Minutes.");

                }

                int minutesPerDayFriday = 0;
                foreach (WorkPeriod workPeriod in jour5)
                {


                    if (workPeriod.codeProject <= 900)
                    {
                        minutesPerDayFriday += workPeriod.minute;

                    }
                }
                if (minutesPerDayFriday < 360)
                {
                    Console.WriteLine("L'employé normal : #" + empNumber + " n'a pas travaillé le minimum de temps requis (360 minutes) le Vendredi!   temps travaillé ce jour-ci: " + minutesPerDayFriday + " Minutes.");
                }
            }
            
        }

        public void validateAdmin4HoursPerDay()
        {
            if (empNumber < 1000)
            {
                int minutesPerDayMonday = 0;
                foreach (WorkPeriod workPeriod in jour1)
                {
                    if (workPeriod.codeProject <= 900)
                    {
                        minutesPerDayMonday += workPeriod.minute;

                    }

                }
                if (minutesPerDayMonday < 240)
                {
                    Console.WriteLine("L'employé normal : #" + empNumber + " n'a pas travaillé le minimum de temps requis (240 minutes) le lundi!   temps travaillé ce jour-ci: " + minutesPerDayMonday + " Minutes.");
                }

                int minutesPerDayTuesday = 0;
                foreach (WorkPeriod workPeriod in jour2)
                {

                    if (workPeriod.codeProject <= 900)
                    {
                        minutesPerDayTuesday += workPeriod.minute;

                    }
                }
                if (minutesPerDayTuesday < 240)
                {
                    Console.WriteLine("L'employé normal : #" + empNumber + " n'a pas travaillé le minimum de temps requis (240 minutes) le mardi!   temps travaillé ce jour-ci: " + minutesPerDayTuesday + " Minutes.");
                }

                int minutesPerDayWednesday = 0;
                foreach (WorkPeriod workPeriod in jour3)
                {

                    if (workPeriod.codeProject <= 900)
                    {
                        minutesPerDayWednesday += workPeriod.minute;

                    }
                }
                if (minutesPerDayWednesday < 240)
                {
                    Console.WriteLine("L'employé normal : #" + empNumber + " n'a pas travaillé le minimum de temps requis (240 minutes) le mercredi!   temps travaillé ce jour-ci: " + minutesPerDayWednesday + " Minutes.");
                }

                int minutesPerDayThursday = 0;
                foreach (WorkPeriod workPeriod in jour4)
                {

                    if (workPeriod.codeProject <= 900)
                    {
                        minutesPerDayThursday += workPeriod.minute;

                    }
                }
                if (minutesPerDayThursday < 240)
                {
                    Console.WriteLine("L'employé normal : #" + empNumber + " n'a pas travaillé le minimum de temps requis (240 minutes) le jeudi!   temps travaillé ce jour-ci: " + minutesPerDayThursday + " Minutes.");
                }

                int minutesPerDayFriday = 0;
                foreach (WorkPeriod workPeriod in jour5)
                {

                    if (workPeriod.codeProject <= 900)
                    {
                        minutesPerDayFriday += workPeriod.minute;

                    }
                }
                if (minutesPerDayFriday < 240)
                {
                    Console.WriteLine("L'administrateur : #" + empNumber + " n'a pas travaillé le minimum de temps requis (240 minutes) le Vendredi!   temps travaillé ce jour-ci: " + minutesPerDayFriday + " Minutes.");
                }
            }

        }

        /*Cette fonction valide si l'employé a depassé les heures permises par semaine de travail au bureau (43h / 2580 minutes)*/
        public void validate43HoursMaxOffice()
        {
            int weeklytotal = 0;

           
            foreach (WorkPeriod workPeriod in jour1)
            {
                if (workPeriod.codeProject <= 900) weeklytotal += workPeriod.minute;
            }
            foreach (WorkPeriod workPeriod in jour2)
            {
                if (workPeriod.codeProject <= 900) weeklytotal += workPeriod.minute;
            }
            foreach (WorkPeriod workPeriod in jour3)
            {
                if (workPeriod.codeProject <= 900) weeklytotal += workPeriod.minute;
            }
            foreach (WorkPeriod workPeriod in jour4)
            {
                if (workPeriod.codeProject <= 900) weeklytotal += workPeriod.minute;
            }
            foreach (WorkPeriod workPeriod in jour5)
            {
                if (workPeriod.codeProject <= 900) weeklytotal += workPeriod.minute;
            }
            foreach (WorkPeriod workPeriod in weekend1)
            {
                if (workPeriod.codeProject <= 900) weeklytotal += workPeriod.minute;
            }
            foreach (WorkPeriod workPeriod in weekend2)
            {
                if (workPeriod.codeProject <= 900) weeklytotal += workPeriod.minute;
            }

            
            if (weeklytotal > 2580)
            {
                Console.WriteLine("L'employé a depassé le temps de travaul permis au bureau (43heures / 2580 minutes)!   temps travaillé ce jour-ci: " + weeklytotal + " Minutes.");
            }
            
        }


        public void validateAdmin10HoursTeleWork()
        {
            try
            {
                int minutes = 0;

                if (empNumber < 1000)
                {
                    foreach (var item in jour1)
                    {
                        if (item.codeProject > 900)
                        {
                            minutes += item.minute;
                        }
                    }
                    foreach (var item in jour2)
                    {
                        if (item.codeProject > 900)
                        {
                            minutes += item.minute;
                        }
                    }
                    foreach (var item in jour3)
                    {
                        if (item.codeProject > 900)
                        {
                            minutes += item.minute;
                        }
                    }
                    foreach (var item in jour4)
                    {
                        if (item.codeProject > 900)
                        {
                            minutes += item.minute;
                        }
                    }
                    foreach (var item in jour5)
                    {
                        if (item.codeProject > 900)
                        {
                            minutes += item.minute;
                        }
                    }
                    foreach (var item in weekend1)
                    {
                        if (item.codeProject > 900)
                        {
                            minutes += item.minute;
                        }
                    }
                    foreach (var item in weekend2)
                    {
                        if (item.codeProject > 900)
                        {
                            minutes += item.minute;
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
