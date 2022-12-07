﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using Calendar = System.Globalization.Calendar;

namespace PunchClock
{

    public partial class Employee : System.Web.UI.Page
    {
        static int totalTimeWorkedJour1 = 0;
        static int totalTimeWorkedJour2 = 0;
        static int totalTimeWorkedJour3 = 0;
        static int totalTimeWorkedJour4 = 0;
        static int totalTimeWorkedJour5 = 0;
        static int totalTimeWorkedWeekend1 = 0;
        static int totalTimeWorkedWeekend2 = 0;
        static int totalWeekTimeWorked = totalTimeWorkedJour1 + totalTimeWorkedJour2 + totalTimeWorkedJour3 + totalTimeWorkedJour4 + totalTimeWorkedJour5 + totalTimeWorkedWeekend1 + totalTimeWorkedWeekend2;
        static int totalTimeHome = 0;
        static int totalTimeHomeA = 0;

        string resultProjet = "0";
        string resultMinutes = "0";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int yearNow = int.Parse(DateTime.Now.ToString("yyyy"));
                List<string> listWeek = numberOfWeekNumber(yearNow);
                totalTimeWorkedJour1 = 0;
                totalTimeWorkedJour2 = 0;
                totalTimeWorkedJour3 = 0;
                totalTimeWorkedJour4 = 0;
                totalTimeWorkedJour5 = 0;
                totalTimeWorkedWeekend1 = 0;
                totalTimeWorkedWeekend2 = 0;
                totalTimeHome = 0;
                totalTimeHomeA = 0;

                resultProjet = "0";
                resultMinutes = "0";

                txtEmpId.Text = "1";

                foreach (string number in listWeek)
                {
                    dropDownListWeek.Items.Add(number);
                }

                txtYear.Text = DateTime.Now.ToString("yyyy");
            }
        }

        protected void dropDownListWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            int year = int.Parse(txtYear.Text);
            int week = int.Parse(dropDownListWeek.SelectedValue);

            TBLundi.Text = firstMondayOfWeek(week, year).ToString("dd-MMMM-yyyy");
            TBMardi.Text = firstMondayOfWeek(week, year).AddDays(1).ToString("dd-MMMM-yyyy");
            TBMercredi.Text = firstMondayOfWeek(week, year).AddDays(2).ToString("dd-MMMM-yyyy");
            TBJeudi.Text = firstMondayOfWeek(week, year).AddDays(3).ToString("dd-MMMM-yyyy");
            TBVendredi.Text = firstMondayOfWeek(week, year).AddDays(4).ToString("dd-MMMM-yyyy");
            TBSamedi.Text = firstMondayOfWeek(week, year).AddDays(5).ToString("dd-MMMM-yyyy");
            TBDimanche.Text = firstMondayOfWeek(week, year).AddDays(6).ToString("dd-MMMM-yyyy");

            if (ItsHoliday(firstMondayOfWeek(week, year)))
            {
                txtProjetMonday.Text = "998";
                txtMinutesMonday.Text = "420";
            }
            if (ItsHoliday(firstMondayOfWeek(week, year).AddDays(1)))
            {
                txtProjetTuesday.Text = "998";
                txtMinutesTuesday.Text = "420";
            }
            if (ItsHoliday(firstMondayOfWeek(week, year).AddDays(2)))
            {
                txtProjetWednesday.Text = "998";
                txtMinutesWednesday.Text = "420";
            }
            if (ItsHoliday(firstMondayOfWeek(week, year).AddDays(3)))
            {
                txtProjetThursday.Text = "998";
                txtMinutesThursday.Text = "420";
            }
            if (ItsHoliday(firstMondayOfWeek(week, year).AddDays(4)))
            {
                txtProjetFriday.Text = "998";
                txtMinutesFriday.Text = "420";
            }

        }
        public bool validateTBweekContent()
        {
            if (
                !String.IsNullOrWhiteSpace(TBLundi.Text) &&
                !String.IsNullOrWhiteSpace(TBMardi.Text) &&
                !String.IsNullOrWhiteSpace(TBMercredi.Text) &&
                !String.IsNullOrWhiteSpace(TBJeudi.Text) &&
                !String.IsNullOrWhiteSpace(TBVendredi.Text) &&
                !String.IsNullOrWhiteSpace(TBSamedi.Text) &&
                !String.IsNullOrWhiteSpace(TBDimanche.Text)
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Welcome.aspx");
        }

        protected void addDayWeek(TextBox inputProjetDay, TextBox inputMinutesDay, Label resultDay, Label day, CheckBox sickDay, Button addDay)
        {
            resultProjet = "0";
            resultMinutes = "0";

            string result = "";
            string resultAffichage = "";

            resultProjet = inputProjetDay.Text;
            resultMinutes = inputMinutesDay.Text;

            if (!string.IsNullOrEmpty(txtEmpId.Text) && validateTBweekContent())
            {
                if (int.Parse(resultProjet) == 999 || int.Parse(resultProjet) < 900)
                {
                    resultAffichage = "Project Code: " + resultProjet + "<br/>" + "\nMinutes: " + resultMinutes + "<br/><br/>";
                    resultDay.Text += resultAffichage;

                    if (day.Text.Equals(""))
                    {
                        result = "{\"codeProject\":\"" + resultProjet + "\",\"minutes\":\"" + resultMinutes + "\"}";
                        day.Text += result;
                    }
                    else
                    {
                        result = ",{\"codeProject\":\"" + resultProjet + "\",\"minutes\":\"" + resultMinutes + "\"}";
                        day.Text += result;
                    }

                    if (sickDay.Checked)
                    {
                        addDay.Enabled = false;
                    }
                    if (resultProjet == "998")
                    {
                        inputProjetDay.BackColor = System.Drawing.Color.LightGray;
                        inputMinutesDay.BackColor = System.Drawing.Color.LightGray;
                    }


                    inputProjetDay.Text = "";
                    inputMinutesDay.Text = "";



                }
                else if (int.Parse(resultProjet) >= 900 && int.Parse(resultProjet) != 999)
                {
                    resultAffichage = "Project Code: " + resultProjet + "<br/>" + "\nMinutes: " + resultMinutes + "<br/><br/>";
                    resultDay.Text += resultAffichage;
                    totalTimeHome += int.Parse(resultMinutes);
                    totalTimeHomeA += int.Parse(resultMinutes);

                    if (day.Text.Equals(""))
                    {
                        result = "{\"codeProject\":\"" + resultProjet + "\",\"minutes\":\"" + resultMinutes + "\"}";
                        day.Text += result;
                    }
                    else
                    {
                        result = ",{\"codeProject\":\"" + resultProjet + "\",\"minutes\":\"" + resultMinutes + "\"}";
                        day.Text += result;
                    }

                    if (sickDay.Checked)
                    {
                        addDay.Enabled = false;
                    }
                    if (resultProjet == "998")
                    {
                        inputProjetDay.BackColor = System.Drawing.Color.LightGray;
                        inputMinutesDay.BackColor = System.Drawing.Color.LightGray;
                    }
                    inputProjetDay.Text = "";
                    inputMinutesDay.Text = "";
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "validateTelealert();", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "validateNumEmpAndTBDayalert();", true);
            }

        }
        protected void addWeekend(TextBox inputProjetDay, TextBox inputMinutesDay, Label resultDay, Label day)
        {
            resultProjet = "0";
            resultMinutes = "0";

            string result = "";
            string resultAffichage = "";

            resultProjet = inputProjetDay.Text;
            resultMinutes = inputMinutesDay.Text;

            try
            {
                if (!string.IsNullOrEmpty(txtEmpId.Text) && validateTBweekContent())
                {
                    if (int.Parse(resultProjet) >= 900 && int.Parse(resultProjet) != 999 && int.Parse(resultProjet) != 998)
                    {
                        totalTimeHome += int.Parse(resultMinutes);
                        totalTimeHomeA += int.Parse(resultMinutes);

                    }

                    if (int.Parse(resultProjet) == 998)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "validateFeriealert();", true);
                    }
                    else if (int.Parse(resultProjet) != 999)
                    {
                        resultAffichage = "Project Code: " + resultProjet + "<br/>" + "\nMinutes: " + resultMinutes + "<br/><br/>";
                        resultDay.Text += resultAffichage;

                        if (day.Text.Equals(""))
                        {
                            result = "{\"codeProject\":\"" + resultProjet + "\",\"minutes\":\"" + resultMinutes + "\"}";
                            day.Text += result;
                        }
                        else
                        {
                            result = ",{\"codeProject\":\"" + resultProjet + "\",\"minutes\":\"" + resultMinutes + "\"}";
                            day.Text += result;
                        }


                        inputProjetDay.Text = "";
                        inputMinutesDay.Text = "";
                    }


                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "validateNumEmpAndTBDayalert();", true);
                    }
                }


            }
            catch (Exception)
            {

                throw;
            }

        }


        protected void btnAddMonday_Click(object sender, EventArgs e)
        {
            try
            {
                resultMinutes = txtMinutesMonday.Text;
                totalTimeWorkedJour1 += int.Parse(resultMinutes);
                totalTimeHomeA += int.Parse(resultMinutes);
                DateTime mondayHollidays = DateTime.Parse(TBLundi.Text);

                if (ItsHoliday(mondayHollidays) && int.Parse(txtProjetMonday.Text) < 900 && int.Parse(txtProjetMonday.Text) != 998)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "validateFerieBureaualert();", true);
                }
                else
                {
                    if (totalTimeWorkedJour1 <= (24 * 60))
                    {
                        if (totalTimeHomeA <= (10 * 60) && int.Parse(txtEmpId.Text) <= 999 && int.Parse(txtProjetMonday.Text) >= 900)
                        {
                            addDayWeek(txtProjetMonday, txtMinutesMonday, lblResultMonday, LabelLundi, cbSickMonday, btnAddMonday);
                            totalTimeHomeA -= int.Parse(resultMinutes);
                        }
                        else if (int.Parse(txtEmpId.Text) >= 1000 || (int.Parse(txtEmpId.Text) <= 999 && int.Parse(txtProjetMonday.Text) < 900))
                        {
                            addDayWeek(txtProjetMonday, txtMinutesMonday, lblResultMonday, LabelLundi, cbSickMonday, btnAddMonday);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "validate10hAdminWalert();", true);
                            totalTimeHomeA -= int.Parse(resultMinutes);
                            totalTimeWorkedJour1 -= int.Parse(resultMinutes);
                        }
                    }
                    else
                    {
                        totalTimeWorkedJour1 -= int.Parse(resultMinutes);
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "validate24alert();", true);
                    }
                }

            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "validateChampsRequisalert();", true);
            }
        }

        protected void btnAddTuesday_Click(object sender, EventArgs e)
        {
            try
            {
                resultMinutes = txtMinutesTuesday.Text;
                totalTimeWorkedJour2 += int.Parse(resultMinutes);
                totalTimeHomeA += int.Parse(resultMinutes);
                DateTime tuesdayHollidays = DateTime.Parse(TBMardi.Text);

                if (ItsHoliday(tuesdayHollidays) && int.Parse(txtProjetTuesday.Text) < 900 && int.Parse(txtProjetTuesday.Text) != 998)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "validateFerieBureaualert();", true);
                }
                else
                {
                    if (totalTimeWorkedJour2 <= (24 * 60))
                    {
                        if (totalTimeHomeA <= (10 * 60) && int.Parse(txtEmpId.Text) <= 999 && int.Parse(txtProjetTuesday.Text) >= 900)
                        {
                            addDayWeek(txtProjetTuesday, txtMinutesTuesday, lblResultTuesday, LabelMardi, cbSickTuesday, btnAddTuesday);
                            totalTimeHomeA -= int.Parse(resultMinutes);
                        }
                        else if (int.Parse(txtEmpId.Text) >= 1000 || (int.Parse(txtEmpId.Text) <= 999 && int.Parse(txtProjetTuesday.Text) < 900))
                        {
                            addDayWeek(txtProjetTuesday, txtMinutesTuesday, lblResultTuesday, LabelMardi, cbSickTuesday, btnAddTuesday);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "validate10hAdminWalert();", true);
                            totalTimeHomeA -= int.Parse(resultMinutes);
                            totalTimeWorkedJour2 -= int.Parse(resultMinutes);
                        }
                    }
                    else
                    {
                        totalTimeWorkedJour2 -= int.Parse(resultMinutes);
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "validate24alert();", true);
                    }
                }

            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "validateChampsRequisalert();", true);
            }

        }

        protected void btnAddWednesday_Click(object sender, EventArgs e)
        {
            try
            {
                resultMinutes = txtMinutesWednesday.Text;
                totalTimeWorkedJour3 += int.Parse(resultMinutes);
                totalTimeHomeA += int.Parse(resultMinutes);
                DateTime wednesdayHollidays = DateTime.Parse(TBMercredi.Text);

                if (ItsHoliday(wednesdayHollidays) && int.Parse(txtProjetWednesday.Text) < 900 && int.Parse(txtProjetWednesday.Text) != 998)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "validateFerieBureaualert();", true);
                }
                else
                {
                    if (totalTimeWorkedJour3 <= (24 * 60))
                    {
                        if (totalTimeHomeA <= (10 * 60) && int.Parse(txtEmpId.Text) <= 999 && int.Parse(txtProjetWednesday.Text) >= 900)
                        {
                            addDayWeek(txtProjetWednesday, txtMinutesWednesday, lblResultWednesday, LabelMercredi, cbSickWednesday, btnAddWednesday);
                            totalTimeHomeA -= int.Parse(resultMinutes);
                        }
                        else if (int.Parse(txtEmpId.Text) >= 1000 || (int.Parse(txtEmpId.Text) <= 999 && int.Parse(txtProjetWednesday.Text) < 900))
                        {
                            addDayWeek(txtProjetWednesday, txtMinutesWednesday, lblResultWednesday, LabelMercredi, cbSickWednesday, btnAddWednesday);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "validate10hAdminWalert();", true);
                            totalTimeHomeA -= int.Parse(resultMinutes);
                            totalTimeWorkedJour3 -= int.Parse(resultMinutes);
                        }
                    }
                    else
                    {
                        totalTimeWorkedJour3 -= int.Parse(resultMinutes);
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "validate24alert();", true);
                    }
                }

            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "validateChampsRequisalert();", true);
            }
        }

        protected void btnAddThursday_Click(object sender, EventArgs e)
        {
            try
            {
                resultMinutes = txtMinutesThursday.Text;
                totalTimeWorkedJour4 += int.Parse(resultMinutes);
                totalTimeHomeA += int.Parse(resultMinutes);
                DateTime thursdayHollidays = DateTime.Parse(TBLundi.Text);

                if (ItsHoliday(thursdayHollidays) && int.Parse(txtProjetThursday.Text) < 900 && int.Parse(txtProjetThursday.Text) != 998)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "validateFerieBureaualert();", true);
                }
                else
                {
                    if (totalTimeWorkedJour4 <= (24 * 60))
                    {
                        if (totalTimeHomeA <= (10 * 60) && int.Parse(txtEmpId.Text) <= 999 && int.Parse(txtProjetThursday.Text) >= 900)
                        {
                            addDayWeek(txtProjetThursday, txtMinutesThursday, lblResultThursday, LabelJeudi, cbSickThursday, btnAddThursday);
                            totalTimeHomeA -= int.Parse(resultMinutes);
                        }
                        else if (int.Parse(txtEmpId.Text) >= 1000 || (int.Parse(txtEmpId.Text) <= 999 && int.Parse(txtProjetThursday.Text) < 900))
                        {
                            addDayWeek(txtProjetThursday, txtMinutesThursday, lblResultThursday, LabelMercredi, cbSickThursday, btnAddThursday);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "validate10hAdminWalert();", true);
                            totalTimeHomeA -= int.Parse(resultMinutes);
                            totalTimeWorkedJour4 -= int.Parse(resultMinutes);
                        }
                    }
                    else
                    {
                        totalTimeWorkedJour4 -= int.Parse(resultMinutes);
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "validate24alert();", true);
                    }
                }

            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "validateChampsRequisalert();", true);
            }
        }

        protected void btnAddFriday_Click(object sender, EventArgs e)
        {
            try
            {
                resultMinutes = txtMinutesFriday.Text;
                totalTimeWorkedJour5 += int.Parse(resultMinutes);
                totalTimeHomeA += int.Parse(resultMinutes);
                DateTime fridayHollidays = DateTime.Parse(TBVendredi.Text);

                if (ItsHoliday(fridayHollidays) && int.Parse(txtProjetFriday.Text) < 900 && int.Parse(txtProjetFriday.Text) != 998)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "validateFerieBureaualert();", true);
                }
                else
                {
                    if (totalTimeWorkedJour5 <= (24 * 60))
                    {
                        if (totalTimeHomeA <= (10 * 60) && int.Parse(txtEmpId.Text) <= 999 && int.Parse(txtProjetFriday.Text) >= 900)
                        {
                            addDayWeek(txtProjetFriday, txtMinutesFriday, lblResultFriday, LabelVendredi, cbSickFriday, btnAddFriday);
                            totalTimeHomeA -= int.Parse(resultMinutes);
                        }
                        else if (int.Parse(txtEmpId.Text) >= 1000 || (int.Parse(txtEmpId.Text) <= 999 && int.Parse(txtProjetFriday.Text) < 900))
                        {
                            addDayWeek(txtProjetFriday, txtMinutesFriday, lblResultFriday, LabelVendredi, cbSickFriday, btnAddFriday);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "validate10hAdminWalert();", true);
                            totalTimeHomeA -= int.Parse(resultMinutes);
                            totalTimeWorkedJour5 -= int.Parse(resultMinutes);
                        }
                    }
                    else
                    {
                        totalTimeWorkedJour5 -= int.Parse(resultMinutes);
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "validate24alert();", true);
                    }
                }

            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "validateChampsRequisalert();", true);
            }
        }

        protected void btnAddSaturday_Click(object sender, EventArgs e)
        {
            try
            {
                resultMinutes = txtMinutesSaturday.Text;
                totalTimeWorkedWeekend1 += int.Parse(resultMinutes);
                if (totalTimeWorkedWeekend1 <= (24 * 60))
                {
                    addWeekend(txtProjetSaturday, txtMinutesSaturday, lblResultSaturday, LabelSamedi);
                }
                else
                {
                    totalTimeWorkedWeekend1 -= int.Parse(resultMinutes);
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "validate24alert();", true);
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "validateChampsRequisalert();", true);
            }
        }

        protected void btnAddSunday_Click(object sender, EventArgs e)
        {
            try
            {
                resultMinutes = txtMinutesSunday.Text;
                totalTimeWorkedWeekend2 += int.Parse(resultMinutes);
                if (totalTimeWorkedWeekend2 <= (24 * 60))
                {
                    addWeekend(txtProjetSunday, txtMinutesSunday, lblResultSunday, LabelDimanche);
                }
                else
                {
                    totalTimeWorkedWeekend2 -= int.Parse(resultMinutes);
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "validate24alert();", true);
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "validateChampsRequisalert();", true);
            }
        }

        private bool ItsHoliday(DateTime date)
        {
            string[] holidays = new string[12] { "01-01-2022", "15-04-2022", "23-05-2022", "24-06-2022", "01-07-2022", "01-08-2022", "05-09-2022", "30-09-2022", "10-10-2022", "11-11-2022", "25-12-2022", "26-12-2022" };
            string dateNewFormat = date.ToString("dd-MM-yyyy");

            foreach (string item in holidays)
            {
                if (dateNewFormat == item) return true;
            }

            return false;
        }

        public List<string> numberOfWeekNumber(int year)
        {
            var currentCulture = CultureInfo.CurrentCulture;
            var weekNo = currentCulture.Calendar.GetWeekOfYear(
                new DateTime(year, 12, 31),
                currentCulture.DateTimeFormat.CalendarWeekRule,
                currentCulture.DateTimeFormat.FirstDayOfWeek
                );

            List<string> week = new List<string>();
            int result = 0;

            for (int i = 0; i < weekNo; i++)
            {
                result = i + 1;
                week.Add(result.ToString());
            }

            return week;
        }

        public DateTime firstMondayOfWeek(int week, int year)
        {
            var date = new DateTime(year, 01, 01);
            var firstDayOfYear = date.DayOfWeek;
            var result = date.AddDays(week * 7);

            if (firstDayOfYear == DayOfWeek.Monday)
                return result.Date;
            if (firstDayOfYear == DayOfWeek.Tuesday)
                return result.AddDays(-1).Date;
            if (firstDayOfYear == DayOfWeek.Wednesday)
                return result.AddDays(-2).Date;
            if (firstDayOfYear == DayOfWeek.Thursday)
                return result.AddDays(-3).Date;
            if (firstDayOfYear == DayOfWeek.Friday)
                return result.AddDays(-4).Date;
            if (firstDayOfYear == DayOfWeek.Saturday)
                return result.AddDays(-5).Date;
            return result.AddDays(-6).Date;

        }

        protected void cbSickMonday_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSickMonday.Checked)
            {
                txtProjetMonday.Text = "999";
                txtMinutesMonday.Text = "420";
                totalTimeHome -= totalTimeWorkedJour1;
                totalTimeHomeA -= totalTimeWorkedJour1;
                totalTimeWorkedJour1 = 0;
            }
            else
            {
                txtProjetMonday.Text = "";
                txtMinutesMonday.Text = "";
            }
        }
        protected void cbSickTuesday_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSickTuesday.Checked)
            {
                txtProjetTuesday.Text = "999";
                txtMinutesTuesday.Text = "420";
                totalTimeHome -= totalTimeWorkedJour2;
                totalTimeHomeA -= totalTimeWorkedJour2;
                totalTimeWorkedJour2 = 0;
            }
            else
            {
                txtProjetTuesday.Text = "";
                txtMinutesTuesday.Text = "";
            }
        }

        protected void cbSickWednesday_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSickWednesday.Checked)
            {
                txtProjetWednesday.Text = "999";
                txtMinutesWednesday.Text = "420";
                totalTimeHome -= totalTimeWorkedJour3;
                totalTimeHomeA -= totalTimeWorkedJour3;
                totalTimeWorkedJour3 = 0;
            }
            else
            {
                txtProjetWednesday.Text = "";
                txtMinutesWednesday.Text = "";
            }
        }

        protected void cbSickThursday_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSickThursday.Checked)
            {
                txtProjetThursday.Text = "999";
                txtMinutesThursday.Text = "420";
                totalTimeHome -= totalTimeWorkedJour4;
                totalTimeHomeA -= totalTimeWorkedJour4;
                totalTimeWorkedJour4 = 0;
            }
            else
            {
                txtProjetThursday.Text = "";
                txtMinutesThursday.Text = "";
            }
        }

        protected void cbSickFriday_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSickFriday.Checked)
            {
                txtProjetFriday.Text = "999";
                txtMinutesFriday.Text = "420";
                totalTimeHome -= totalTimeWorkedJour5;
                totalTimeHomeA -= totalTimeWorkedJour5;
                totalTimeWorkedJour5 = 0;
            }
            else
            {
                txtProjetFriday.Text = "";
                txtMinutesFriday.Text = "";
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string jsonFile = "";
            string jsonName = "";

            try
            {
                int empID = Int32.Parse(txtEmpId.Text);
                if (empID <= 999)
                {
                    int totalWeekTimeWorked = totalTimeWorkedJour1 + totalTimeWorkedJour2 + totalTimeWorkedJour3 + totalTimeWorkedJour4 + totalTimeWorkedJour5 + totalTimeWorkedWeekend1 + totalTimeWorkedWeekend2;

                    if ((totalTimeWorkedJour1 - totalTimeHome) >= 240 && (totalTimeWorkedJour2 - totalTimeHome) >= 240 && (totalTimeWorkedJour3 - totalTimeHome) >= 240 && (totalTimeWorkedJour4 - totalTimeHome) >= 240 && (totalTimeWorkedJour5 - totalTimeHome) >= 240)
                    {
                        if ((totalWeekTimeWorked - totalTimeHomeA) >= (36 * 60))
                        {

                            string idadmin = txtEmpId.Text;
                            string yearadmin = txtYear.Text;
                            string weekNumberadmin = dropDownListWeek.SelectedValue;
                            jsonFile = stringJsonGenerator(idadmin, yearadmin, weekNumberadmin);
                            jsonName = idadmin + "-" + yearadmin + "-" + weekNumberadmin;

                            totalTimeWorkedJour1 = 0;
                            totalTimeWorkedJour2 = 0;
                            totalTimeWorkedJour3 = 0;
                            totalTimeWorkedJour4 = 0;
                            totalTimeWorkedJour5 = 0;
                            totalTimeWorkedWeekend1 = 0;
                            totalTimeWorkedWeekend2 = 0;


                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "validate36hEmpWalert()", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "validate4AdminWalert()", true);
                    }
                }
                if (empID >= 1000)
                {
                    int totalWeekTimeWorked = totalTimeWorkedJour1 + totalTimeWorkedJour2 + totalTimeWorkedJour3 + totalTimeWorkedJour4 + totalTimeWorkedJour5 + totalTimeWorkedWeekend1 + totalTimeWorkedWeekend2;

                    if ((totalTimeWorkedJour1 - totalTimeHome) >= 360 && (totalTimeWorkedJour2 - totalTimeHome) >= 360 && (totalTimeWorkedJour3 - totalTimeHome) >= 360 && (totalTimeWorkedJour4 - totalTimeHome) >= 360 && (totalTimeWorkedJour5 - totalTimeHome) >= 360)
                    {


                        if ((totalWeekTimeWorked - totalTimeHome) > (43 * 60))
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "validate43WHalert()", true);
                        }
                        else
                        {
                            if ((totalWeekTimeWorked - totalTimeHome) >= (38 * 60) && empID < 2000)
                            {
                                string id = txtEmpId.Text;
                                string year = txtYear.Text;
                                string weekNumber = dropDownListWeek.SelectedValue;
                                jsonFile = stringJsonGenerator(id, year, weekNumber);
                                jsonName = id + "-" + year + "-" + weekNumber;

                                totalTimeWorkedJour1 = 0;
                                totalTimeWorkedJour2 = 0;
                                totalTimeWorkedJour3 = 0;
                                totalTimeWorkedJour4 = 0;
                                totalTimeWorkedJour5 = 0;
                                totalTimeWorkedWeekend1 = 0;
                                totalTimeWorkedWeekend2 = 0;
                            }

                            else if (totalWeekTimeWorked >= (38 * 60) && empID >= 2000)
                            {
                                string id = txtEmpId.Text;
                                string year = txtYear.Text;
                                string weekNumber = dropDownListWeek.SelectedValue;
                                jsonFile = stringJsonGenerator(id, year, weekNumber);
                                jsonName = id + "-" + year + "-" + weekNumber;

                                totalTimeWorkedJour1 = 0;
                                totalTimeWorkedJour2 = 0;
                                totalTimeWorkedJour3 = 0;
                                totalTimeWorkedJour4 = 0;
                                totalTimeWorkedJour5 = 0;
                                totalTimeWorkedWeekend1 = 0;
                                totalTimeWorkedWeekend2 = 0;
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "validate38hEmpWalert();", true);
                            }
                        }

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "validate6hEmpWalert();", true);
                    }


                }
                LabelTestJson.Text = stringJsonGenerator(txtEmpId.Text.ToString(), txtYear.Text.ToString(), dropDownListWeek.Text.ToString());

            }
            catch (Exception)
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "validateChampsRequisalert();", true);
            }


            try
            {
                if (String.IsNullOrWhiteSpace(jsonName) || String.IsNullOrWhiteSpace(jsonFile))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "validateJsonWalert();", true);
                }
                else
                    WriteToFile(jsonName, jsonFile);
            }
            catch (Exception ex)
            {
                LabelTestJson.Text = ex.Message.ToString();
            }
        }

        private string stringJsonGenerator(string id, string year, string weekNumber)
        {
            string jsonFormat = "{\"numero_employe\":\"" + id + "\",";
            jsonFormat += "\"annee\":\"" + year + "\",";
            jsonFormat += "\"numero_semaine\":\"" + weekNumber + "\",";
            jsonFormat += "\"jour1\":[" + LabelLundi.Text + "],";
            jsonFormat += "\"jour2\":[" + LabelMardi.Text + "],";
            jsonFormat += "\"jour3\":[" + LabelMercredi.Text + "],";
            jsonFormat += "\"jour4\":[" + LabelJeudi.Text + "],";
            jsonFormat += "\"jour5\":[" + LabelVendredi.Text + "],";
            jsonFormat += "\"weekendl\":[" + LabelSamedi.Text + "],";
            jsonFormat += "\"weekend2\":[" + LabelDimanche.Text + "]}";

            return jsonFormat;
        }

        public void WriteToFile(string fileName, string fileContent)
        {
            try
            {
                fileName += ".json";
                string FolderPath = @"C:\FeuillesTemps\";
                if (!Directory.Exists(FolderPath))
                    Directory.CreateDirectory(FolderPath);

                if (!File.Exists(FolderPath + fileName))
                    File.Create(FolderPath + fileName).Close();

                StreamWriter stream = new StreamWriter(FolderPath + fileName, true);
                stream.WriteLine(fileContent);
                stream.Close();

                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "validateJsonalert();", true);
            }
            catch (Exception ex)
            {
                LabelTestJson.Text = "Erreur survenue:" + ex.Message.ToString();
            }
        }


        protected void btnReset_Click(object sender, EventArgs e)
        {
            cbSickMonday.Checked = false;
            cbSickTuesday.Checked = false;
            cbSickWednesday.Checked = false;
            cbSickThursday.Checked = false;
            cbSickFriday.Checked = false;
            btnAddMonday.Enabled = true;
            btnAddTuesday.Enabled = true;
            btnAddWednesday.Enabled = true;
            btnAddThursday.Enabled = true;
            btnAddFriday.Enabled = true;
            btnAddSaturday.Enabled = true;
            btnAddSunday.Enabled = true;

            totalTimeWorkedJour1 = 0;
            totalTimeWorkedJour2 = 0;
            totalTimeWorkedJour3 = 0;
            totalTimeWorkedJour4 = 0;
            totalTimeWorkedJour5 = 0;
            totalTimeWorkedWeekend1 = 0;
            totalTimeWorkedWeekend2 = 0;
            totalWeekTimeWorked = totalTimeWorkedJour1 + totalTimeWorkedJour2 + totalTimeWorkedJour3 + totalTimeWorkedJour4 + totalTimeWorkedJour5 + totalTimeWorkedWeekend1 + totalTimeWorkedWeekend2;
            totalTimeHome = 0;
            totalTimeHomeA = 0;

            resultProjet = "0";
            resultMinutes = "0";
            txtProjetMonday.Text = "";
            txtProjetTuesday.Text = "";
            txtProjetTuesday.Text = "";
            txtProjetWednesday.Text = "";
            txtProjetThursday.Text = "";
            txtProjetFriday.Text = "";
            txtProjetSaturday.Text = "";
            txtProjetSunday.Text = "";
            txtMinutesMonday.Text = "";
            txtMinutesTuesday.Text = "";
            txtMinutesWednesday.Text = "";
            txtMinutesThursday.Text = "";
            txtMinutesFriday.Text = "";
            txtMinutesSaturday.Text = "";
            txtMinutesSunday.Text = "";
            txtEmpId.Text = "";
            lblResultMonday.Text = "";
            lblResultTuesday.Text = "";
            lblResultWednesday.Text = "";
            lblResultThursday.Text = "";
            lblResultFriday.Text = "";
            lblResultSaturday.Text = "";
            lblResultSunday.Text = "";
        }


    }
}
