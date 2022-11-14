using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Agile
{
    public class Timesheet
    {
        string text1 = "";
        string text2 = "";
        string text3 = "";
        string text4 = "";
        string text5 = "";
        string text6 = "";
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

        public void createOrAddToResultJson()
        {

            Result result = new Result
            {
                numEmploye = empNumber,
                errorCodes = new List<string>()
                {
                    text1,
                    text2,
                    text3,
                    text4,
                    text5,
                    text6
                }
            };
            string strResultJson = JsonConvert.SerializeObject(result);


            File.WriteAllText(@"Result.json", strResultJson);

        }

        public void readResultJson()
        {
            if (File.Exists("Result.json"))
            {
                string jsonFile = File.ReadAllText(@"Result.json");
                var dictionary = JsonConvert.DeserializeObject<IDictionary>(jsonFile);

                foreach (DictionaryEntry entry in dictionary)
                {
                    Console.WriteLine(entry.Key + ": " + entry.Value);
                }
            }
            else
            {
                Console.WriteLine("Test");
            }
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
                        //Console.WriteLine("L'administrateur : #" + empNumber + " n'a pas travaillé le minimum d'heures requises au bureau. Il en a travaillé " + minutes / 60 + " sur 36 minimum.");
                        text1 = "L'administrateur : #" + empNumber + " n'a pas travaillé le minimum d'heures requises au bureau. Il en a travaillé " + minutes / 60 + " sur 36 minimum.";
                        createOrAddToResultJson();

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
                        //Console.WriteLine("L'employé normal : #" + empNumber + " n'a pas travaillé le minimum d'heures requises au bureau. Il en a travaillé " + minutes / 60 + " sur 38 minimum.");
                        text2 = "L'employé normal : #" + empNumber + " n'a pas travaillé le minimum d'heures requises au bureau. Il en a travaillé " + minutes / 60 + " sur 38 minimum.";
                        createOrAddToResultJson();
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
                        //Console.WriteLine("L'employé normal : #" + empNumber + " n'a pas travaillé le minimum de temps requis (360 minutes) lundi!   temps travaillé ce jour-ci: " + minutesPerDayMonday + " Minutes.");
                        text3 += "L'employé normal : #" + empNumber + " n'a pas travaillé le minimum de temps requis (360 minutes) " + carteDeTemps.DayName(jour) + "! temps travaillé ce jour-ci: " + minutesPerDay + " Minutes. ";
                        createOrAddToResultJson();
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
                        // Console.WriteLine("L'employé normal : #" + empNumber + " n'a pas travaillé le minimum de temps requis (240 minutes) le lundi!   temps travaillé ce jour-ci: " + minutesPerDayMonday + " Minutes.");
                        text4 += "L'employé normal : #" + empNumber + " n'a pas travaillé le minimum de temps requis (360 minutes) " + carteDeTemps.DayName(jour) + "! temps travaillé ce jour-ci: " + minutesPerDay + " Minutes. ";
                        createOrAddToResultJson();
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
                //Console.WriteLine("L'employé a depassé le temps de travaul permis au bureau (43heures / 2580 minutes)!   temps travaillé ce jour-ci: " + weeklytotal + " Minutes.");
                text5 = "L'employé a depassé le temps de travail permis au bureau (43heures / 2580 minutes)!   temps travaillé ce jour-ci: " + weeklytotal + " Minutes.";
                createOrAddToResultJson();
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
                        //Console.WriteLine("L'administrateur : #" + empNumber + " a dépassé le nombre d'heures permises en télétravail. Il en a travaillé " + minutes / 60 + " sur une possibilité de 10 maximum.");
                        text6 = "L'administrateur : #" + empNumber + " a dépassé le nombre d'heures permises en télétravail. Il en a travaillé " + minutes / 60 + " sur une possibilité de 10 maximum.";
                        createOrAddToResultJson();
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
