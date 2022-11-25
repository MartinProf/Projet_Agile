using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Agile
{
    public class TimeSheetGenerator
    {

        public TimeSheetGenerator(int empNumber, int year, int weekNumber, List<WorkPeriod> lundi,
            List<WorkPeriod> mardi, List<WorkPeriod> mercredi, List<WorkPeriod> jeudi,
            List<WorkPeriod> vendredi, List<WorkPeriod> samedi, List<WorkPeriod> dimanche)
        {
            this.EmpNumber = empNumber;
            this.Year = year;
            this.WeekNumber = weekNumber;
            this.Lundi = lundi;
            this.Mardi = mardi;
            this.Mercredi = mercredi;
            this.Jeudi = jeudi;
            this.Vendredi = vendredi;
            this.Samedi = samedi;
            this.Dimanche = dimanche;

        }


        [JsonProperty("numero employe")]
        public int EmpNumber { get; set; }

        [JsonProperty("annee")]
        public int Year { get; set; }

        [JsonProperty("numero semaine")]
        public int WeekNumber { get; set; }

        [JsonProperty("jour1")]
        public List<WorkPeriod> Lundi { get; set; }

        [JsonProperty("jour2")]
        public List<WorkPeriod> Mardi { get; set; }

        [JsonProperty("jour3")]
        public List<WorkPeriod> Mercredi { get; set; }

        [JsonProperty("jour4")]
        public List<WorkPeriod> Jeudi { get; set; }

        [JsonProperty("jour5")]
        public List<WorkPeriod> Vendredi { get; set; }

        [JsonProperty("weekendl")]
        public List<WorkPeriod> Samedi { get; set; }

        [JsonProperty("weekend2")]
        public List<WorkPeriod> Dimanche { get; set; }
    }
}