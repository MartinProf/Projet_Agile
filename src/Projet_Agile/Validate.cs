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
    class Validate
    {

        string text1 = "";
        string text2 = "";
        string text3 = "";
        string text4 = "";
        string text5 = "";
        string text6 = "";
        string fileName = Program.extensionFile;
        string extension = Path.GetExtension(Program.extensionFile);

        public Validate() { }

        [JsonProperty("numero employe")]
        public int empNumber
        {
            get; set;
        }

        [JsonProperty("annee")]
        public int year
        {
            get; set;
        }

        [JsonProperty("numero semaine")]
        public int weekNumber
        {
            get; set;
        }

        public TimeSheet timeSt { get; set; }

        public override string ToString()
        {
            string returnString = $"numero employe : {empNumber}\n";
            returnString += $"annee : {year}\n";
            returnString += $"numero semaine : {weekNumber}\n";
            returnString += timeSt.ToString();
            return returnString;
        }

        public void createOrAddToResultJson(string fileName)
        {
            fileName = Program.extensionFile;
            extension = Path.GetExtension(fileName);
            string fileName2 = fileName.Substring(0, fileName.Length - extension.Length);
            fileName2 += "Result.json";
            Result result = new Result
            {
                NumEmploye = empNumber,
                Year = year,
                WeekNumber = weekNumber,

                ErrorCodes = new List<string>()
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


            File.WriteAllText(@fileName2, strResultJson);

        }

        public void readResultJson(string resultFile)
        {
            if (File.Exists(resultFile))
            {
                string jsonFile = File.ReadAllText(@resultFile);
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

                if (empNumber < 1000)
                {
                    foreach (List<WorkPeriod> jour in timeSt.oneWeek)
                    {
                        foreach (var item in jour)
                        {
                            if (item.codeProject <= 900)
                            {
                                minutes += item.minutes;
                            }
                        }
                    }

                    if (minutes < (36 * 60))
                    {
                        text1 = "L'administrateur : #" + empNumber + " n'a pas travaillé le minimum d'heures requises au bureau. Il en a travaillé " + minutes / 60 + " sur 36 minimum.";
                        createOrAddToResultJson(fileName);

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void validateProdEmp38Hours()
        {
            try
            {
                int minutes = 0;

                if (empNumber >= 1000 && empNumber < 2000)
                {
                    foreach (List<WorkPeriod> jour in timeSt.oneWeek)
                    {
                        foreach (var item in jour)
                        {
                            if (item.codeProject <= 900)
                            {
                                minutes += item.minutes;
                            }
                        }
                    }
                    if (minutes < (38 * 60))
                    {
                        text2 = "L'employé de production : #" + empNumber + " n'a pas travaillé le minimum d'heures requises au bureau. Il en a travaillé " + minutes / 60 + " sur 38 minimum.";
                        createOrAddToResultJson(fileName);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void validateExploitEmp38Hours()
        {
            try
            {
                int minutes = 0;

                if (empNumber >= 2000)
                {
                    foreach (List<WorkPeriod> jour in timeSt.oneWeek)
                    {
                        foreach (var item in jour)
                        {
                            minutes += item.minutes;
                        }
                    }
                    if (minutes < (38 * 60))
                    {
                        text2 = "L'employé d'exploitation : #" + empNumber + " n'a pas travaillé le minimum d'heures requises. Il en a travaillé " + minutes / 60 + " sur 38 minimum.";
                        createOrAddToResultJson(fileName);
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
                foreach (List<WorkPeriod> jour in timeSt.oneWeek)
                {
                    foreach (WorkPeriod workPeriod in jour)
                    {
                        if (workPeriod.codeProject <= 900)
                        {
                            minutesPerDay += workPeriod.minutes;
                        }
                    }
                    if (minutesPerDay < 360)
                    {
                        text3 += "Les employés de production et d'exploitation : #" + empNumber + " n'ont pas travaillé le minimum de temps requis (360 minutes) " + timeSt.DayName(jour) + "! temps travaillé ce jour-ci: " + minutesPerDay + " Minutes. ";
                        createOrAddToResultJson(fileName);
                    }
                }
            }
        }

        public void validateAdmin4HoursPerDay()
        {
            if (empNumber < 1000)
            {
                int minutesPerDay = 0;
                foreach (List<WorkPeriod> jour in timeSt.oneWeek)
                {
                    foreach (WorkPeriod workPeriod in jour)
                    {
                        if (workPeriod.codeProject <= 900)
                        {
                            minutesPerDay += workPeriod.minutes;
                        }
                    }
                    if (minutesPerDay < 240)
                    {
                        text4 += "Les employés de production et d'exploitation : #" + empNumber + " n'ont pas travaillé le minimum de temps requis (240 minutes) " + timeSt.DayName(jour) + "! temps travaillé ce jour-ci: " + minutesPerDay + " Minutes. ";
                        createOrAddToResultJson(fileName);
                    }
                }
            }
        }

        /*Cette fonction valide si l'employé a depassé les heures permises par semaine de travail au bureau (43h / 2580 minutes)*/
        public void validate43HoursMaxOffice()
        {
            int weeklytotal = 0;

            foreach (List<WorkPeriod> jour in timeSt.oneWeek)
            {
                foreach (WorkPeriod workPeriod in jour)
                {
                    if (workPeriod.codeProject <= 900) weeklytotal += workPeriod.minutes;
                }
            }
            if (weeklytotal > 2580)
            {
                text5 = "Les employés de production et d'exploitation ont depassé le temps de travail permis au bureau (43heures / 2580 minutes)!   temps travaillé ce jour-ci: " + weeklytotal + " Minutes.";
                createOrAddToResultJson(fileName);
            }
        }

        public void validateAdmin10HoursTeleWork()
        {
            try
            {
                int minutes = 0;

                if (empNumber < 1000)
                {
                    foreach (List<WorkPeriod> jour in timeSt.oneWeek)
                    {
                        foreach (var item in jour)
                        {
                            if (item.codeProject > 900)
                            {
                                minutes += item.minutes;
                            }
                        }
                    }
                    if (minutes > (10 * 60))
                    {
                        text6 = "L'administrateur : #" + empNumber + " a dépassé le nombre d'heures permises en télétravail. Il en a travaillé " + minutes / 60 + " sur une possibilité de 10 maximum.";
                        createOrAddToResultJson(fileName);
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
