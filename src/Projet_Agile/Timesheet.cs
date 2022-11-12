using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Agile
{
    public class Timesheet
    {
        public Timesheet() { }
        [JsonProperty("numero employe")]
        public int empNumber
        {
            get; set;
        }
        [JsonProperty("jour1")]
        public  List<WorkPeriod> jour1 { get; set; }
        [JsonProperty("jour2")]
        public List<WorkPeriod> jour2 { get; set; }
        [JsonProperty("jour3")]
        public List<WorkPeriod> jour3 { get; set; }
        [JsonProperty("jour4")]
        public List<WorkPeriod> jour4 { get; set; }
        [JsonProperty("jour5")]
        public List<WorkPeriod> jour5 { get; set; }
        [JsonProperty("weekendl")]
        public List<WorkPeriod> weekend1 { get; set; }
        [JsonProperty("weekend2")]
        public List<WorkPeriod> weekend2 { get; set; }   
        public override string ToString()
        {
            string returnString = $"employe number : {empNumber}\n"+
               "Lundi:\n";

            foreach (WorkPeriod workPeriod in jour1 ?? new List<WorkPeriod>()) 
            {
                returnString += workPeriod.ToString();
                
            }
            returnString += $"Mardi:\n";
            foreach (WorkPeriod workPeriod in jour2 ?? new List<WorkPeriod>())
            {
                returnString += workPeriod.ToString();
            }
            returnString += $"Mercredi:\n";
            foreach (WorkPeriod workPeriod in jour3 ?? new List<WorkPeriod>())
            {
                returnString += workPeriod.ToString();
            }
            returnString += $"Jeudi:\n";
            foreach (WorkPeriod workPeriod in jour4 ?? new List<WorkPeriod>())
            {
                returnString += workPeriod.ToString();
            }
            returnString += $"Vendredi:\n";
            foreach (WorkPeriod workPeriod in jour5 ?? new List<WorkPeriod>())
            {
                returnString += workPeriod.ToString();
            }
            returnString += $"Samedi:\n";
            foreach (WorkPeriod workPeriod in weekend1 ?? new List<WorkPeriod>())
            {
                returnString += workPeriod.ToString();
            }
            returnString += $"Dimanche:\n";
            foreach (WorkPeriod workPeriod in weekend2 ?? new List<WorkPeriod>())
            {
                returnString += workPeriod.ToString();
            }
            return returnString;
        }

    }
}
