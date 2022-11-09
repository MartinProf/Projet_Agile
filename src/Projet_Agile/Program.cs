using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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


            Console.WriteLine("Veuillez entrer le no d'employé que vous voulez valider:");
            string empNumber = Console.ReadLine();

            validateTimeline validateTimeline = new validateTimeline();
            validateTimeline.validateTimesheet(empNumber, extensionFile);

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

            var date = DateTime.Parse("11-4-2022");

            //Classe ProjectTimeline
            /*
            Serializer(22, 34, 1, 1, date, DateTime.Now);
            Serializer(15, 34, 10, 2, date, DateTime.Now);
            Serializer(30, 34, 100, 3, date, DateTime.Now);
            Serializer(50, 35, 900, 4, date, DateTime.Now);
            Serializer(24, 35, 900, 1000, date, DateTime.Now);
            Serializer(10, 35, 900, 1001, date, DateTime.Now);
            Serializer(1, 35, 900, 1002, date, DateTime.Now);
            Serializer(2, 35, 900, 1003, date, DateTime.Now);
            Serializer(3, 35, 900, 1004, date, DateTime.Now);
            */

            Console.WriteLine(projectTimelinesList[projectTimelinesList.Count()-1]);

            Console.WriteLine("******************************************************************************\n");

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
                minute = minutesEcoule
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
    }
 }