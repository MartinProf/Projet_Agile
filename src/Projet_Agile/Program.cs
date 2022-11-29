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

            validation.validateNormalEmp38Hours();

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
                foreach (var work in data.Property("jour1").Value)
                {
                    WorkPeriod tempWorkPeriod= new WorkPeriod();
                    tempWorkPeriod.codeProject = (int)work["projet"];
                    tempWorkPeriod.minute = (int)work["minutes"];
                    workPeriods.Add(tempWorkPeriod);                   
                }
                timeSt.oneWeek.Add(workPeriods);
               
                workPeriods = new List<WorkPeriod>();
                foreach (var work in data.Property("jour2").Value)
                {         
                    WorkPeriod tempWorkPeriod = new WorkPeriod();
                    tempWorkPeriod.codeProject = (int)work["projet"];
                    tempWorkPeriod.minute = (int)work["minutes"];
                    workPeriods.Add(tempWorkPeriod);
                }
                timeSt.oneWeek.Add(workPeriods);
                
                workPeriods = new List<WorkPeriod>();
                foreach (var work in data.Property("jour3").Value)
                {
                    
                    WorkPeriod tempWorkPeriod = new WorkPeriod();
                    tempWorkPeriod.codeProject = (int)work["projet"];
                    tempWorkPeriod.minute = (int)work["minutes"];
                    workPeriods.Add(tempWorkPeriod);
                }
                timeSt.oneWeek.Add(workPeriods);
               
                workPeriods = new List<WorkPeriod>();
                foreach (var work in data.Property("jour4").Value)
                {
                    
                    WorkPeriod tempWorkPeriod = new WorkPeriod();
                    tempWorkPeriod.codeProject = (int)work["projet"];
                    tempWorkPeriod.minute = (int)work["minutes"];
                    workPeriods.Add(tempWorkPeriod);
                }
                timeSt.oneWeek.Add(workPeriods);
                
                workPeriods = new List<WorkPeriod>();
                foreach (var work in data.Property("jour5").Value)
                {
                    
                    WorkPeriod tempWorkPeriod = new WorkPeriod();
                    tempWorkPeriod.codeProject = (int)work["projet"];
                    tempWorkPeriod.minute = (int)work["minutes"];
                    workPeriods.Add(tempWorkPeriod);
                }
                timeSt.oneWeek.Add(workPeriods);
                
                workPeriods = new List<WorkPeriod>();
                foreach (var work in data.Property("weekendl").Value)
                {
                    
                    WorkPeriod tempWorkPeriod = new WorkPeriod();
                    tempWorkPeriod.codeProject = (int)work["projet"];
                    tempWorkPeriod.minute = (int)work["minutes"];
                    workPeriods.Add(tempWorkPeriod);
                }
                timeSt.oneWeek.Add(workPeriods);
                
                workPeriods = new List<WorkPeriod>();
                foreach (var work in data.Property("weekend2").Value)
                {
                    
                    WorkPeriod tempWorkPeriod = new WorkPeriod();
                    tempWorkPeriod.codeProject = (int)work["projet"];
                    tempWorkPeriod.minute = (int)work["minutes"];
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

