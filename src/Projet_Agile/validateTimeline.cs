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

        public void validateAdmin36Hours(int empNumber)
        {
            try
            {
                for (int j = 0; j < projectTimelinesList.Count; j++)
                {
                    double weekWorkHours = 0;
                    int year = 0;
                    int weekNumber = 0;

                    if (empNumber == projectTimelinesList[j].idUser)
                    {
                        year = projectTimelinesList[j].entry.Year;
                        weekNumber = weeknumber(projectTimelinesList[j].entry);

                        DateTime monday = FirstDateOfWeek(year, weekNumber);
                        DateTime sunday = monday.AddDays(6);
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
                            Console.WriteLine("Semaine : " + weekNumber + "L'administrateur n'a pas travaillé le nombre d'heures minimum!");
                        }

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void validateUser38Hours(int empNumber)
        {
            try
            {
                for (int j = 0; j < projectTimelinesList.Count; j++)
                {
                    double weekWorkHours = 0;
                    int year = 0;
                    int weekNumber = 0;

                    if (empNumber == projectTimelinesList[j].idUser)
                    {
                        year = projectTimelinesList[j].entry.Year;
                        weekNumber = weeknumber(projectTimelinesList[j].entry);

                        DateTime monday = FirstDateOfWeek(year, weekNumber);
                        DateTime sunday = monday.AddDays(6);

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
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void validateUser43Hours(int empNumber)
        {
            try
            {
                for (int j = 0; j < projectTimelinesList.Count; j++)
                {
                    double weekWorkHours = 0;
                    int year = 0;
                    int weekNumber = 0;

                    if (empNumber == projectTimelinesList[j].idUser)
                    {
                        year = projectTimelinesList[j].entry.Year;
                        weekNumber = weeknumber(projectTimelinesList[j].entry);

                        DateTime monday = FirstDateOfWeek(year, weekNumber);
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
                                Console.WriteLine("Semaine : " + weekNumber + "L'employé a dépassé les heures de bureau permises!");
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

        //TODO
        private void validateAdmin4HoursPerDay(int empNumber) 
        {

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
        public void getUserInfo(int empNumber)
        {

            if (empNumber < 1000 && empNumber > 0)
            {
                validateAdmin36Hours(empNumber);
                validateUser43Hours(empNumber);
                validateAdminTelework10Hours(empNumber);
                validateAdmin4HoursPerDay(empNumber);
            }
            else if (empNumber >= 1000)
            {
                validateUser38Hours(empNumber);
                validateUser43Hours(empNumber);
                validateUser6HoursPerDay(empNumber);
            }
            else
            {
                Console.WriteLine("numero de user invalide");
            }
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

        //Fonction validateAdminTelework10Hours, valide si l'administrateur a travaillé moins de 10 heures de télétravail par semaine 
        public void validateAdminTelework10Hours(int empNumber)
        {
            int workFromHomeTime = 0;
            int year = 0;
            int weekNumber = 0;
            
            for (int i = 0; i < projectTimelinesList.Count; i++)
                {
                
                if (empNumber == projectTimelinesList[i].idUser)
                    {
                        year = projectTimelinesList[i].entry.Year;
                        weekNumber = weeknumber(projectTimelinesList[i].entry);

                        DateTime monday = FirstDateOfWeek(year, weekNumber);
                        DateTime sunday = monday.AddDays(6);

                        for (int j = 0; j < projectTimelinesList.Count; j++)
                            {
                                if (projectTimelinesList[j].entry >= monday && projectTimelinesList[j].output <= sunday)
                                {
                                    if (projectTimelinesList[j].codeProject == 900)
                                    {
                                        workFromHomeTime += projectTimelinesList[j].minute;
                                    }
                                }
                            }
                            if (workFromHomeTime > 600)
                            {
                                Console.WriteLine("L'administrateur a depassé les heures maximales permises de télétravail dans la semaine: " + weekNumber + "!" );
                            }
                        
                        
                    }
                }
            }


        //Fonction validateUser6HoursPerDay, valide si l'employé a travaillé moins de 6 heures par jour
        public void validateUser6HoursPerDay(int empNumber)
        {
           
            foreach (var item in projectTimelinesList)
            {
                if (item.idUser == empNumber)
                {
                    for (int i = 0; i < projectTimelinesList.Count; i++)
                    {
                        
                        if (item.minute < 360)
                            
                            Console.WriteLine("L'employé n'a pas travaillé un minimum de 6h les jours de semaine!");
                    }
                }
            }
        }

        public int[] listIdUser() 
        {
            int[] userList = new int[projectTimelinesList.Count()];

            for (int i = 0; i < projectTimelinesList.Count(); i++)
            {
                userList[i] = projectTimelinesList[i].idUser;
            }

            return userList.Distinct().ToArray();
        }
        
    }
}