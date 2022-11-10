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
        public ProjectTimeline() { }

        public int idTimeline 
        { 
            get; set; 
        }
        public int idProject 
        { 
            get; set; 
        }
        public int codeProject 
        { 
            get; set;
        }
        public int idUser 
        { 
            get; set;
        }
        public DateTime entry 
        { 
            get; set;
        }
        public DateTime output 
        { 
            get; set;
        }
        public int minute 
        { 
            get; set; 
        }

        public int weekNumber
        {
            get; set;
        }

        public override string ToString()
        {
            return $"idTimeline : {idTimeline}\n" +
                    $"idProject : {idProject}\n" +
                    $"codeProject : {codeProject}\n" +
                    $"idUser : {idUser}\n" +
                    $"entry : {entry}\n" +
                    $"output : {output}\n" +
                    $"minute : {minute}\n" +
                    $"weekNumber : {weekNumber}\n\n";
        }

    }
}
