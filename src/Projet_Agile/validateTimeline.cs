using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            DateTime monday = FirstDateOfWeek(year, weekNumber);
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
                        weekNumber = weeknumber(projectTimelinesList[j].entry);

                        DateTime monday = FirstDateOfWeek(year, weekNumber);
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
                                    Console.WriteLine("Semaine : " + weekNumber + "L'employé n'a pas travaillé le nombre d'heures minimum!");
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

        private void validateAdmin4HoursPerDay(int empNumber) 
        {
            foreach (var item in projectTimelinesList)
            {
                if (item.idUser == empNumber && empNumber < 1000) 
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (item.minute < 240)
                            Console.WriteLine("L'administrateur n'a pas travaillé un minimum de 4h les jours de semaine!");
                    }
                }
            }
        }

        public void validateTimesheet(int empNumber, string extensionFile)
        {
            
            validateAdmin4HoursPerDay(empNumber);
        }

        public bool empExist(int empNumber) 
        {
            foreach (var item in projectTimelinesList)
            {
                if (item.idUser == empNumber)
                    return true;
            }

            return false;
        }

        private int weeknumber(DateTime dateTime) 
        {
            return CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(dateTime, CalendarWeekRule.FirstDay, DayOfWeek.Monday);

        }

        private DateTime FirstDateOfWeek(int year, int weekOfYear)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;

            DateTime firstThursday = jan1.AddDays(daysOffset);
            var cal = CultureInfo.CurrentCulture.Calendar;
            int firstWeek = cal.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            var weekNum = weekOfYear;
            if (firstWeek == 1)
            {
                weekNum -= 1;
            }

            var result = firstThursday.AddDays(weekNum * 7);

            return result.AddDays(-3);
        }

    }
}