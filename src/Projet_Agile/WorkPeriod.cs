﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Agile
{
    public class WorkPeriod
    {
        public WorkPeriod() { }

        public WorkPeriod(int codeProject, int minute)
        {
            this.codeProject = codeProject;
            this.minutes = minute;
        }

        [JsonProperty("projet")]
        public int codeProject
        {
            get; set;
        }
        [JsonProperty("minutes")]
        public int minutes
        {
            get; set;
        }

        public override string ToString()
        {
            return
                    $"codeProject : {codeProject}\n" +
                    $"minute : {minutes}\n";
        }
    }
}
