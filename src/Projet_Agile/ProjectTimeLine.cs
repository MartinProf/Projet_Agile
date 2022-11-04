using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Projet_Agile
{
    class ProjectTimeline
    {
        public int idTimeline { get; set; }
        public int idProject { get; set; }
        public int codeProject { get; set; }
        public int idUser { get; set; }
        public DateTime entry { get; set; }
        public DateTime output { get; set; }
        public int minute { get; set; }


        public ProjectTimeline() { }

        public override string ToString()
        {
            return $"idTimeline : {idTimeline}\n" +
                    $"idProject : {idTimeline}\n" +
                    $"codeProject : {idTimeline}\n" +
                    $"idUser : {idTimeline}\n" +
                    $"entry : {idTimeline}\n" +
                    $"output : {idTimeline}\n" +
                    $"minute : {minute}\n\n";
        }

        /*
        public ProjectTimeline(int idTimeline, int idProject, int codeProject, int idUser, DateTime entry, DateTime output )
        {
            var src = DateTime.Now;
            var hm = new DateTime(src.Year, src.Month, src.Day, src.Hour, src.Minute, 0);

            this.idTimeline = idTimeline;
            this.idProject = idProject;
            this.codeProject = codeProject;
            this.idUser = idUser;
            this.entry = hm;
            this.output = hm;
            appendTimeline(idTimeline,idProject,codeProject,idUser,entry,output);
        }

        public int idTimeline 
        { 
            get;
            set; 
        }
        public int idProject 
        { 
            get;
            set; 
        }
        public int codeProject 
        { 
            get;
            set; 
        }
        public int idUser 
        { 
            get;
            set; 
        }
        public DateTime entry 
        { 
            get; 
            set; 
        }
        public DateTime output 
        { 
            get;
            set; 
        }
        public void appendTimeline(int idTimeline, int idProject, int codeProject, int idUser, DateTime entry, DateTime output) 
        {
            string fileName = "TimeSheet.json";

            if (!File.Exists(fileName))
            {
                string jsonString = JsonConvert.SerializeObject(this);
                File.WriteAllText(fileName, jsonString);
            }
            else
            {
                string jsonStringExtra = JsonConvert.SerializeObject(this);
                File.AppendAllText(fileName, jsonStringExtra);
            }
        }
        
        ProjectTimeline[] projectTimeline;
        public void ReadTimeline()
        {
            string fileName = @"TimeSheet.json";
            if (File.Exists(fileName))
            {
                 projectTimeline = JsonConvert.DeserializeObject<ProjectTimeline>(File.ReadAllText(fileName));

            }
        }*/
    }
}
