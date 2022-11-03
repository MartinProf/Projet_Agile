using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Projet_Agile
{
    class ProjectTimeline
    {
        public ProjectTimeline(int idTimeline, int idProject, int codeProject, int idUser, DateTime entry, DateTime output)
        {
            this.idTimeline = idTimeline;
            this.idProject = idProject;
            this.codeProject = codeProject;
            this.idUser = idUser;
            this.entry = entry;
            this.output = output;
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
        public void appendTimeline() 
        {
            string JString = JsonConvert.SerializeObject(this);
        }
    }
}