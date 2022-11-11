using Newtonsoft.Json;
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
        internal static List<ProjectTimeline> projectTimelinesList = new List<ProjectTimeline>();
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

            validateTimeline validateTimeline = new validateTimeline();
            int empNumber;
            bool empExist = false;

            do
            {
                Console.WriteLine("Veuillez entrer le no d'employé que vous voulez valider:");

                string toPrint = "";

                foreach (var item in validateTimeline.listIdUser())
                {
                    toPrint += item + " ";
                }

                Console.WriteLine(toPrint);

                empNumber = int.Parse(Console.ReadLine());

                if (validateTimeline.empExist(empNumber))
                    empExist = true;
                else 
                    Console.WriteLine("\nLe numéro " + empNumber + " n'existe pas dans votre feuille de temps.\n");

            } while (!empExist);

            
            


            Console.WriteLine("******** TESTS UNITAIRES ********\n\n");

            Console.WriteLine("\n************************************* Classe Employe *****************************************\n");

            //Classe Employe
            var employe = new Employe(1000, "Forster", "James", "James@hotmail.com", "66666", "10 sept 2024");
            //Getters
            String msgEmploye1 = employe.noUser + " " + employe.lastName + " " + employe.firstName + " " + employe.email + " " + employe.password + " " + employe.inscriptionDate;
            Console.WriteLine("Getters Employe = " + msgEmploye1);
            //Setters
            string msgEmploye2 = (employe.noUser = 2) + " " + (employe.lastName = "Red") + " " + (employe.firstName = "Roseline") + " " + (employe.email = "Rosie@red.com") + " " + (employe.password = "34543");
            Console.WriteLine("Setters Employe = " + msgEmploye2);

            Console.WriteLine("\n************************************* Classe Administrator ***********************************\n");

            //Classe Administrator
            var administrator = new Administrator(1, "Woola", "Doodley", "Dood@hotmail.com", "78900", "12 juillet 2018");
            //Getters
            String msgAdmin1 = administrator.noUser + " " + administrator.lastName + " " + administrator.firstName + " " + administrator.email + " " + administrator.password + " " + administrator.inscriptionDate;
            Console.WriteLine("Getters Administrator = " + msgAdmin1);
            //Setters
            string msgAdmin2 = (administrator.noUser = 2) + " " + (administrator.lastName = "Blue") + " " + (administrator.firstName = "Bubble") + " " + (administrator.email = "Bubble@blue.com") + " " + (administrator.password = "32343");
            Console.WriteLine("Setters Administrator = " + msgAdmin2);
            //Create project
            Console.WriteLine("Create project method = " + administrator.createProject(12345, 54321));

            Console.WriteLine("\n************************************* Classe Project *****************************************\n");

            //Classe Project
            var project = new Project(1, 22);
            var projectTelework = new Project(2, 901);
            //Getters
            string msgProject1 = project.idProject + " " + project.codeProject;
            Console.WriteLine("Getters Project = " + msgProject1);
            //Télétrail?  (telework bool)
            Console.WriteLine("Is this telework? = " + project.telework + " codeProject = " + project.codeProject);
            Console.WriteLine("Is this telework? = " + projectTelework.telework + " codeProject = " + projectTelework.codeProject);

            Console.WriteLine("\n************************************* Classe ProjectTimeline *********************************\n");
            
            //Classe ProjectTimeline
            
            Console.WriteLine(projectTimelinesList[projectTimelinesList.Count() - 1]);

            Console.WriteLine("******************************************************************************\n");
            //GenerateSerializations(1000);

            Console.ReadKey();
        }
        
        public static void Serializer(int idTimeline, int idProject, int codeProject, int idUser, DateTime entry, DateTime output)
        {

            TimeSpan timeSpan = output.Subtract(entry);
            int minutesEcoule = (int)timeSpan.TotalMinutes;

            var projectTimeline = new ProjectTimeline
            {
                idTimeline = idTimeline,
                idProject = idProject,
                codeProject = codeProject,
                idUser = idUser,
                entry = entry,
                output = output,
                minute = minutesEcoule,
                weekNumber = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(entry, CalendarWeekRule.FirstDay, DayOfWeek.Monday)
        };

            projectTimelinesList.Add(projectTimeline);

            jsonTimelineString = JsonConvert.SerializeObject(projectTimelinesList);

            File.WriteAllText(extensionFile, jsonTimelineString);

        }

        public static void Deserializer(string timeSheet)
        {
            string content;

            using (StreamReader file = File.OpenText(timeSheet))
            {
                content = file.ReadToEnd();
                projectTimelinesList = JsonConvert.DeserializeObject<List<ProjectTimeline>>(content);
            }
        }

        internal static IEnumerable<ProjectTimeline> GetProjectTimelineList()
        {
            return projectTimelinesList;
        }

        /* GENERATEUR DE CARTE DE TEMPS
        private static void GenerateSerializations(int occurence)
        {
            for (int i = 1; i <= occurence; i++)
            {
                Random random = new Random();

                int idTimeline = i;
                int idProject = 35;
                int codeProject = random.Next(1, 2000);
                int idUser = random.Next(1, 2000);
                DateTime entry = DateTime.Now.AddDays(random.Next(0, 21));
                DateTime output = entry.AddHours(random.Next(1, 8));

                Serializer(idTimeline, idProject, codeProject, idUser, entry, output);
            }

        }*/
    }
}

