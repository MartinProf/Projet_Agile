using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Projet_Agile.Program;


namespace Projet_Agile
{
    class validateTimeline
    {
        List<ProjectTimeline> projectTimelinesList = (List<ProjectTimeline>)Program.GetProjectTimelineList();

        public validateTimeline()
        {
            
        }

        public void validateAdmin36Hours(int noUser, int year, int weekNumber)
        {
            double weekWorkHours = 0;
            DateTime monday = Program.FirstDateOfWeek(year, weekNumber);
            DateTime sunday = monday.AddDays(6);

            try
            {
                if (noUser < 1000)
                {
                    Console.WriteLine("Cet employé n'est pas un administrateur");
                }
                else
                {
                    for (int i = 0; i < projectTimelinesList.Count; i++)
                    {
                        if (projectTimelinesList[i].entry >= monday && projectTimelinesList[i].output <= sunday)
                        {
                            if (projectTimelinesList[i].codeProject <= 900)
                            {
                                double daylyWorkHours = projectTimelinesList[i].minute / 60;

                                weekWorkHours += Math.Round(daylyWorkHours);
                            }
                        }
                    }
                    if (weekWorkHours < 36)
                    {
                        Console.WriteLine("L'employé n'a pas travaillé le nombre d'heures minimum!");
                    }
                    else
                        Console.WriteLine(weekWorkHours);
                    //À enlever quand fonctionnel

                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void validateUser38Hours(int noUser, int year, int weekNumber)
        {
            double weekWorkHours = 0;
            DateTime monday = Program.FirstDateOfWeek(year, weekNumber);
            DateTime sunday = monday.AddDays(6);

            try
            {
                if (noUser >= 1000)
                {
                    Console.WriteLine("Cet employé n'est pas de type normal");
                }
                else
                {
                    for (int i = 0; i < projectTimelinesList.Count; i++)
                    {
                        if (projectTimelinesList[i].entry >= monday && projectTimelinesList[i].output <= sunday)
                        {
                            if (projectTimelinesList[i].codeProject >= 900)
                            {
                                double daylyWorkHours = projectTimelinesList[i].minute / 60;

                                weekWorkHours += Math.Round(daylyWorkHours);
                            }
                        }
                    }
                    if (weekWorkHours < 38)
                    {
                        Console.WriteLine("L'employé n'a pas travaillé le nombre d'heures minimum!");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void validateTimesheet(string empNumber, string extensionFile) 
        {
            
        }
    }
}
