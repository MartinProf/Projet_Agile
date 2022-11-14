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
            Console.WriteLine("******** TESTS UNITAIRES ********\n\n");

            Console.WriteLine("======== Validate Employe Normal 6 Hours at office per Day ========\n");
            
            validation.validateNormalEmp6HoursPerDay();

            Console.WriteLine("======== Validate Admin 4 Hours at office per Day ========\n");

            validation.validateAdmin4HoursPerDay();
                
            Console.WriteLine("\n======== Validate 43 Hours Max Per week ========\n");

            validation.validate43HoursMaxOffice();

            Console.WriteLine("\n======== Validate Admin 36 Hours Min Per week ========\n");

            validation.validateAdmin36Hours();

            Console.WriteLine("\n======== Validate Employe Normal 38 Hours Min Per week ========\n");

            validation.validateNormalEmp38Hours();

            Console.WriteLine("\n======== Validate Admin 10 Hours Max Telework Per Week ========\n");

            validation.validateAdmin10HoursTeleWork();
            string resultFile = Console.ReadLine();

            if (resultFile != string.Empty)
            {
                validation.readResultJson(resultFile);
            }

           

            Console.WriteLine("Veuillez entrer l'extension de fichier de votre feuille de temps: ");
            

            Console.ReadKey();

          
            
           
            
            Console.WriteLine("\n************************************* Classe ProjectTimeline *********************************\n");

            
            

            Console.WriteLine("******************************************************************************\n");


         
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
                List<WorkPeriod> workPeriods= new List<WorkPeriod>();
                content = file.ReadToEnd();
                JObject data = (JObject)JsonConvert.DeserializeObject(content);
                validation.empNumber = (int)data.Property("numero employe").Value;
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
                //timesheets = JsonConvert.DeserializeObject<Timesheet>(content);
            }
        }

        
    }
}

