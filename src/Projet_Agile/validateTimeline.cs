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

        public void validateUser38Hours(int noUser)
        {
            try
            {
                for (int j = 0; j < projectTimelinesList.Count; j++)
                {
                    double weekWorkHours = 0;
                    int year = 0;
                    int weekNumber = 0;

                    if (noUser == projectTimelinesList[j].idUser)
                    {
                        year = projectTimelinesList[j].entry.Year;
                        weekNumber = projectTimelinesList[j].week;

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
                                        if (projectTimelinesList[i].codeProject <= 900)
                                        {
                                            double daylyWorkHours = projectTimelinesList[i].minute / 60;

                                            weekWorkHours += Math.Round(daylyWorkHours);
                                        }
                                    }
                                }
                                if (weekWorkHours < 38)
                                {
                                    Console.WriteLine("Semaine : " + projectTimelinesList[j].week + "L'employé n'a pas travaillé le nombre d'heures minimum!");
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
            catch (Exception)
            {

                throw;
            }
        }

        public void validateUser43Hours(int noUser, int year, int weekNumber)
        {
            double weekWorkHours = 0;
            DateTime monday = Program.FirstDateOfWeek(year, weekNumber);
            DateTime sunday = monday.AddDays(6);

            try
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
                if (weekWorkHours > 43)
                {
                    Console.WriteLine("L'employé a dépassé le temps de travail permis au bureau");
                }               
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void getUserInfo(int noUser)
        {

            if (noUser < 1000 && noUser > 0)
            {
                validateAdmin36Hours(noUser);
                validateAdminTelework10Hours(noUser);
                validateAdmin4HoursPerDay(noUser);
            }
            else if (noUser >= 1000)
            {
                validateUser38Hours(noUser);
                validateUser43Hours(noUser);
                validateUser6HoursPerDay(noUser);
            }
            else
            {
                Console.WriteLine("numero de user invalide");
            }
        }
        public void validateTimesheet(string empNumber, string extensionFile)
        {

        }
    }
}