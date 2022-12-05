using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Agile
{

    public static class Program
    {
        public static string jsonTimelineString;
        public static string extensionFile;
       
        internal static Validate validation = new Validate();
        static void Main(string[] args)
        {
            
            bool extConforme = false;

            do
            {
                Console.WriteLine("Veuillez entrer l'extension de fichier de votre feuille de temps: ");
                extensionFile = Console.ReadLine();
                try
                {
                    Deserializer(extensionFile);
                    extConforme = true;
                }
                catch (Exception)
                {

                    Console.WriteLine("La saisie de votre feuille de temps n'existe pas. Veuillez recommencer.\n\n");
                }

            } while (!extConforme);
            
            Console.WriteLine(GetTimesheetsList());
            
            validation.validateNormalEmp6HoursPerDay();

            validation.validateAdmin4HoursPerDay();

            validation.validate43HoursMaxOffice();

            validation.validateAdmin36Hours();

            validation.validateProdEmp38Hours();

            validation.validateExploitEmp38Hours();

            validation.validateAdmin10HoursTeleWork();

            Console.WriteLine("Veuillez entrer l'extension de fichier de votre feuille de temps ex: nomFichierResult.json: ");

            string resultFile = Console.ReadLine();

            if (resultFile != string.Empty)
            {
                validation.readResultJson(resultFile);
            }
            

            /*
            WorkPeriod workPeriod = new WorkPeriod(200,200);
            WorkPeriod workPeriod2 = new WorkPeriod(100,100);
            List<WorkPeriod> a = new List<WorkPeriod>();
            a.Add(workPeriod);
            a.Add(workPeriod2);

            TimeSheetGenerator timeSheetGenerator = new TimeSheetGenerator(200,2022,48,a,a,a,a,a,a,a);
            Generate("testDeJson",timeSheetGenerator);
            */

            Console.ReadKey();

        }
        
        
        
        internal static string GetTimesheetsList()
        {
            return validation.ToString();
        }
        public static void Deserializer(string timeSheet)
        {
            string content;

            using (StreamReader file = File.OpenText(timeSheet))
            {
                TimeSheet timeSt= new TimeSheet();
                content = file.ReadToEnd();
                JObject data = (JObject)JsonConvert.DeserializeObject(content);
                validation.empNumber = (int)data.Property("numero employe").Value;
                validation.year = (int)data.Property("annee").Value;
                validation.weekNumber = (int)data.Property("numero semaine").Value;

                List<WorkPeriod> workPeriods = new List<WorkPeriod>();
                int totalTimeWorkedJour1 = 0;
                int totalTimeWorkedJour2 = 0;
                int totalTimeWorkedJour3 = 0;
                int totalTimeWorkedJour4 = 0;
                int totalTimeWorkedJour5 = 0;
                int totalTimeWorkedWeekend1 = 0;
                int totalTimeWorkedWeekend2 = 0;

                foreach (var work in data.Property("jour1").Value)
                {
                    WorkPeriod tempWorkPeriod= new WorkPeriod();
                    if(totalTimeWorkedJour1 <= (24 * 60))
                    {
                        tempWorkPeriod.codeProject = (int)work["projet"];
                        tempWorkPeriod.minutes = (int)work["minutes"];
                        totalTimeWorkedJour1 += tempWorkPeriod.minutes;
                        if (totalTimeWorkedJour1 <= (24 * 60))
                        {
                            workPeriods.Add(tempWorkPeriod);
                        }
                        else
                        {
                            Console.WriteLine("dépassement");
                        }
                    }
                    else
                    {
                        Console.WriteLine("dépassement");
                    }

                }
                timeSt.oneWeek.Add(workPeriods);
               
                workPeriods = new List<WorkPeriod>();
                foreach (var work in data.Property("jour2").Value)
                {         
                    WorkPeriod tempWorkPeriod = new WorkPeriod();
                    tempWorkPeriod.codeProject = (int)work["projet"];
                    tempWorkPeriod.minutes = (int)work["minutes"];
                    workPeriods.Add(tempWorkPeriod);
                }
                timeSt.oneWeek.Add(workPeriods);
                
                workPeriods = new List<WorkPeriod>();
                foreach (var work in data.Property("jour3").Value)
                {
                    
                    WorkPeriod tempWorkPeriod = new WorkPeriod();
                    tempWorkPeriod.codeProject = (int)work["projet"];
                    tempWorkPeriod.minutes = (int)work["minutes"];
                    workPeriods.Add(tempWorkPeriod);
                }
                timeSt.oneWeek.Add(workPeriods);
               
                workPeriods = new List<WorkPeriod>();
                foreach (var work in data.Property("jour4").Value)
                {
                    
                    WorkPeriod tempWorkPeriod = new WorkPeriod();
                    tempWorkPeriod.codeProject = (int)work["projet"];
                    tempWorkPeriod.minutes = (int)work["minutes"];
                    workPeriods.Add(tempWorkPeriod);
                }
                timeSt.oneWeek.Add(workPeriods);
                
                workPeriods = new List<WorkPeriod>();
                foreach (var work in data.Property("jour5").Value)
                {
                    
                    WorkPeriod tempWorkPeriod = new WorkPeriod();
                    tempWorkPeriod.codeProject = (int)work["projet"];
                    tempWorkPeriod.minutes = (int)work["minutes"];
                    workPeriods.Add(tempWorkPeriod);
                }
                timeSt.oneWeek.Add(workPeriods);
                
                workPeriods = new List<WorkPeriod>();
                foreach (var work in data.Property("weekendl").Value)
                {
                    
                    WorkPeriod tempWorkPeriod = new WorkPeriod();
                    tempWorkPeriod.codeProject = (int)work["projet"];
                    tempWorkPeriod.minutes = (int)work["minutes"];
                    workPeriods.Add(tempWorkPeriod);
                }
                timeSt.oneWeek.Add(workPeriods);
                
                workPeriods = new List<WorkPeriod>();
                foreach (var work in data.Property("weekend2").Value)
                {
                    
                    WorkPeriod tempWorkPeriod = new WorkPeriod();
                    tempWorkPeriod.codeProject = (int)work["projet"];
                    tempWorkPeriod.minutes = (int)work["minutes"];
                    workPeriods.Add(tempWorkPeriod);
                }
                timeSt.oneWeek.Add(workPeriods);
                validation.timeSt = timeSt;
            }
        }
        public static void Generate(string fileName, TimeSheetGenerator b)
        {
            string extension = fileName + ".json";

            var jsonGenerator = JsonConvert.SerializeObject(b);

            File.WriteAllText(extension, jsonGenerator);

            Console.WriteLine(jsonGenerator);
        }

    }
}

