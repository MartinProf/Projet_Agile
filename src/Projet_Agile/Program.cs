using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Agile
{
    class Program
    {
        static string jsonTimeline;
        static JsonSerializer serializer;
        static List<ProjectTimeline> projectTimelines;
        static void Main(string[] args)
        {
            serializer = new JsonSerializer();

            /********************** TESTS UNITAIRES **************************/

            //Classe Person
            var person = new Person("Walsh", "Bob", "Bobby@bobby.com", "12345");
            //Getters
            String msgPerson1 = person.lastName + " " + person.firstName + " " + person.email + " " + person.password + " " + person.inscriptionDate;
            Console.WriteLine("Getters Person = " + msgPerson1);
            //Setters
            string msgPerson2 = (person.lastName = "Forget") + " " + (person.firstName = "Martin") + " " + (person.email = "pasbobby@pasbobby.com") + " " + (person.password = "54321");
            Console.WriteLine("Setters Person = " + msgPerson2);

            Console.WriteLine("******************************************************************************");

            //Classe Employe
            var employe = new Employe(1, "Forster", "James", "James@hotmail.com", "66666", "10 sept 2024");
            //Getters
            String msgEmploye1 = employe.noUser + " " + employe.lastName + " " + employe.firstName + " " + employe.email + " " + employe.password + " " + employe.inscriptionDate;
            Console.WriteLine("Getters Employe = " + msgEmploye1);
            //Setters
            string msgEmploye2 = (employe.noUser = 2) + " " + (employe.lastName = "Red") + " " + (employe.firstName = "Roseline") + " " + (employe.email = "Rosie@red.com") + " " + (employe.password = "34543");
            Console.WriteLine("Setters Employe = " + msgEmploye2);

            Console.WriteLine("******************************************************************************");

            //Classe Administrator
            var administrator = new Administrator(1, "Woola", "Doodley", "Dood@hotmail.com", "78900", "12 juillet 2018");
            //Getters
            String msgAdmin1 = administrator.noUser + " " + administrator.lastName + " " + administrator.firstName + " " + administrator.email + " " + administrator.password + " " + administrator.inscriptionDate;
            Console.WriteLine("Getters Administrator = " + msgAdmin1);
            //Setters
            string msgAdmin2 = (administrator.noUser = 2) + " " + (administrator.lastName = "Blue") + " " + (administrator.firstName = "Bubble") + " " + (administrator.email = "Bubble@blue.com") + " " + (administrator.password = "32343");
            Console.WriteLine("Setters Administrator = " + msgAdmin2);

            Console.WriteLine("******************************************************************************");

            //Classe Project
            var project = new Project(1, 22);
            //Getters
            string msgProject1 = project.idProject + " " + project.codeProject;
            Console.WriteLine("Getters Project = " + msgProject1);
            //Setters
            string msgProject2 = (project.idProject = 666) + " " + (project.codeProject = 999);
            Console.WriteLine("Setters Project = " + msgProject2);

             Console.WriteLine("******************************************************************************");

            var date = DateTime.Parse("11-4-2022");
            //Classe ProjectTimeline
            //Serializer(1, 1, 1, 666, date, DateTime.Now);
            Deserializer(@"TimeSheet.json");
            //Export();
            //Import();
            //Test d'ajout au fichier TimeSheet.json
            //var projectTimeLine2 = new ProjectTimeline(2, project.idProject, project.codeProject, administrator.noUser, DateTime.Now, date);
            //var projectTimeLine3 = new ProjectTimeline(3, project.idProject, project.codeProject, employe.noUser, DateTime.Now, date);

            Console.WriteLine("******************************************************************************");



            Console.ReadKey();
        }

        static void Serializer(int idTimeline, int idProject, int codeProject, int idUser, DateTime entry, DateTime output)
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

            jsonTimeline = JsonConvert.SerializeObject(projectTimeline);

            string fileName = "TimeSheet.json";

            if (!File.Exists(fileName))
            {
                File.WriteAllText(fileName, jsonTimeline);
            }
            else
            {
                File.AppendAllText(fileName, jsonTimeline);
            }
        }

        static void Deserializer(string fileName) 
        {
            /*
            ProjectTimeline projectTimeline1 = JsonConvert.DeserializeObject<ProjectTimeline>(File.ReadAllText(fileName));

            using (StreamReader file = File.OpenText(fileName)) 
            {
                serializer = new JsonSerializer();
                ProjectTimeline projectTimeline2 = (ProjectTimeline)serializer.Deserialize(file, typeof(ProjectTimeline));
                Console.WriteLine(projectTimeline2.entry);
            }*/
            projectTimelines = JsonConvert.DeserializeObject<List<ProjectTimeline>>(File.OpenText(fileName).ReadToEnd());
        }
        /*
        static void Export() 
        {
            string fileName = "TimeSheet.json";
            using (var streamWriter = new StreamWriter(fileName)) 
            {
                using (var jsonWriter = new JsonTextWriter(streamWriter)) 
                {
                    jsonWriter.Formatting = Formatting.Indented;
                    serializer.Serialize(jsonWriter, JsonConvert.DeserializeObject(jsonTimeline));
                    Console.WriteLine(jsonWriter.ToString());
                }
            }
        }

        static void Import()
        {
            string fileName = "TimeSheet.json";

            using (var streamReader = new StreamReader(fileName))
            {
                using (var jsonReader = new JsonTextReader(streamReader))
                {
                    var projectTimeline = serializer.Deserialize<ProjectTimeline>(jsonReader);
                    Console.WriteLine(projectTimeline.ToString());
                }
            }
        }*/
    }
 }
