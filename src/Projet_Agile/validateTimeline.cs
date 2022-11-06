using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Projet_Agile
{
    class validateTimeline
    {
        List<ProjectTimeline> projectTimelinesList = (List<ProjectTimeline>)Program.GetProjectTimelineList();


        public void validateAdmin36Hours(Administrator administrator)
        {
            double weekWorkHours = 0;

            try
            {
                if (administrator.noUser >= 1000)
                {
                    Console.WriteLine("Cet employé n'est pas un Administrateur");
                }
                else
                {
                    for (int i = 0; i < projectTimelinesList.Count; i++)
                    {
                        if (projectTimelinesList[i].codeProject >= 900)
                        {
                            double daylyWorkHours = projectTimelinesList[i].minute / 60;

                            weekWorkHours += Math.Round(daylyWorkHours);
                        } 
                    }
                    if(weekWorkHours < 36)
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
    }
}
