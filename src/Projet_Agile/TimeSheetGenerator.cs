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
        public TimeSheetGenerator()
        {
        }

        public TimeSheetGenerator(int empNumber, int year, int weekNumber, List<WorkPeriod> lundi,
            List<WorkPeriod> mardi, List<WorkPeriod> mercredi, List<WorkPeriod> jeudi,
            List<WorkPeriod> vendredi, List<WorkPeriod> samedi, List<WorkPeriod> dimanche)
        {
            this.numero_employe = empNumber;
            this.annee = year;
            this.numero_semaine = weekNumber;
            this.jour1 = lundi;
            this.jour2 = mardi;
            this.jour3 = mercredi;
            this.jour4 = jeudi;
            this.jour5 = vendredi;
            this.weekendl = samedi;
            this.weekend2 = dimanche;
        }


        [JsonProperty("numero_employe")]
        public int numero_employe { get; set; }

        [JsonProperty("annee")]
        public int annee { get; set; }

        [JsonProperty("numero_semaine")]
        public int numero_semaine { get; set; }

        [JsonProperty("jour1")]
        public List<WorkPeriod> jour1 { get; set; }

        [JsonProperty("jour2")]
        public List<WorkPeriod> jour2 { get; set; }

        [JsonProperty("jour3")]
        public List<WorkPeriod> jour3 { get; set; }

        [JsonProperty("jour4")]
        public List<WorkPeriod> jour4 { get; set; }

        [JsonProperty("jour5")]
        public List<WorkPeriod> jour5 { get; set; }

        [JsonProperty("weekendl")]
        public List<WorkPeriod> weekendl { get; set; }

        [JsonProperty("weekend2")]
        public List<WorkPeriod> weekend2 { get; set; }
    }
}