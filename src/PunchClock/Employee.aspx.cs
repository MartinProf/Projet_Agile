using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Calendar = System.Globalization.Calendar;

namespace PunchClock
{
    public partial class Employee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int yearNow = int.Parse(DateTime.Now.ToString("yyyy"));
            List<string> listWeek = numberOfWeekNumber(yearNow);
            
            foreach (string number in listWeek)
            {
                dropDownListWeek.Items.Add(number);
            }

            txtYear.Text = DateTime.Now.ToString("yyyy");

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

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void cbSickMonday_CheckedChanged(object sender, EventArgs e)
        {
                txtMinutesMonday.Text = "420";
                txtProjetMonday.Text = "999";
        }
        

        protected void btnAddMonday_Click(object sender, EventArgs e)
        {
            string resultProjet = "";
            string resultMinutes = "";

            string result = "";
            if (cbSickMonday.Checked)
            {
                txtMinutesMonday.Text = "420";
                txtProjetMonday.Text = "999";

                resultProjet = txtProjetMonday.Text;
                resultMinutes = txtMinutesMonday.Text;

                result = "Project Code: " + resultProjet + "<br/>" + "\nMinutes: " + resultMinutes;

                lblResultMonday.Text = result;

            }else
            {
                resultProjet = txtProjetMonday.Text;
                resultMinutes = txtMinutesMonday.Text;

                result = "Project Code: " + resultProjet+  "<br/>" + "\nMinutes: " + resultMinutes + "<br/><br/>";
                lblResultMonday.Text += result;
            }
            
        }

        protected void btnAddTuesday_Click(object sender, EventArgs e)
        {
            string resultProjet = "";
            string resultMinutes = "";

            string result = "";
            if (cbSickTuesday.Checked)
            {
                txtMinutesTuesday.Text = "420";
                txtProjetTuesday.Text = "999";

                resultProjet = txtProjetTuesday.Text;
                resultMinutes = txtMinutesTuesday.Text;

                result = "Project Code: " + resultProjet + "<br/>" + "\nMinutes: " + resultMinutes;

                lblResultTuesday.Text = result;

            }
            else
            {
                resultProjet = txtProjetTuesday.Text;
                resultMinutes = txtMinutesTuesday.Text;

                result = "Project Code: " + resultProjet + "<br/>" + "\nMinutes: " + resultMinutes + "<br/><br/>";
                lblResultTuesday.Text += result;
            }
        }

        protected void btnAddWednesday_Click(object sender, EventArgs e)
        {
            string resultProjet = "";
            string resultMinutes = "";

            string result = "";
            if (cbSickWednesday.Checked)
            {
                txtMinutesWednesday.Text = "420";
                txtProjetWednesday.Text = "999";

                resultProjet = txtProjetWednesday.Text;
                resultMinutes = txtMinutesWednesday.Text;

                result = "Project Code: " + resultProjet + "<br/>" + "\nMinutes: " + resultMinutes;

                lblResultWednesday.Text = result;

            }
            else
            {
                resultProjet = txtProjetWednesday.Text;
                resultMinutes = txtMinutesWednesday.Text;

                result = "Project Code: " + resultProjet + "<br/>" + "\nMinutes: " + resultMinutes + "<br/><br/>";
                lblResultWednesday.Text += result;
            }
        }

        protected void btnAddThursday_Click(object sender, EventArgs e)
        {
            string resultProjet = "";
            string resultMinutes = "";

            string result = "";
            if (cbSickThursday.Checked)
            {
                txtMinutesThursday.Text = "420";
                txtProjetThursday.Text = "999";

                resultProjet = txtProjetThursday.Text;
                resultMinutes = txtMinutesThursday.Text;

                result = "Project Code: " + resultProjet + "<br/>" + "\nMinutes: " + resultMinutes;

                lblResultThursday.Text = result;

            }
            else
            {
                resultProjet = txtProjetThursday.Text;
                resultMinutes = txtMinutesThursday.Text;

                result = "Project Code: " + resultProjet + "<br/>" + "\nMinutes: " + resultMinutes + "<br/><br/>";
                lblResultThursday.Text += result;
            }
        }

        protected void btnAddFriday_Click(object sender, EventArgs e)
        {
            string resultProjet = "";
            string resultMinutes = "";

            string result = "";
            if (cbSickFriday.Checked)
            {
                txtMinutesFriday.Text = "420";
                txtProjetFriday.Text = "999";

                resultProjet = txtProjetFriday.Text;
                resultMinutes = txtMinutesFriday.Text;

                result = "Project Code: " + resultProjet + "<br/>" + "\nMinutes: " + resultMinutes;

                lblResultFriday.Text = result;

            }
            else
            {
                resultProjet = txtProjetFriday.Text;
                resultMinutes = txtMinutesFriday.Text;

                result = "Project Code: " + resultProjet + "<br/>" + "\nMinutes: " + resultMinutes + "<br/><br/>";
                lblResultFriday.Text += result;
            }
        }

        protected void btnAddSaturday_Click(object sender, EventArgs e)
        {
            string resultProjet = "";
            string resultMinutes = "";

            string result = "";
            if (cbSickSaturday.Checked)
            {
                txtMinutesSaturday.Text = "420";
                txtProjetSaturday.Text = "999";

                resultProjet = txtProjetSaturday.Text;
                resultMinutes = txtMinutesSaturday.Text;

                result = "Project Code: " + resultProjet + "<br/>" + "\nMinutes: " + resultMinutes;

                lblResultSaturday.Text = result;

            }
            else
            {
                resultProjet = txtProjetSaturday.Text;
                resultMinutes = txtMinutesSaturday.Text;

                result = "Project Code: " + resultProjet + "<br/>" + "\nMinutes: " + resultMinutes + "<br/><br/>";
                lblResultSaturday.Text += result;
            }
        }

        protected void btnAddSunday_Click(object sender, EventArgs e)
        {
            string resultProjet = "";
            string resultMinutes = "";

            string result = "";
            if (cbSickSunday.Checked)
            {
                txtMinutesSunday.Text = "420";
                txtProjetSunday.Text = "999";

                resultProjet = txtProjetSunday.Text;
                resultMinutes = txtMinutesSunday.Text;

                result = "Project Code: " + resultProjet + "<br/>" + "\nMinutes: " + resultMinutes;

                lblResultSunday.Text = result;

            }
            else
            {
                resultProjet = txtProjetSunday.Text;
                resultMinutes = txtMinutesSunday.Text;

                result = "Project Code: " + resultProjet + "<br/>" + "\nMinutes: " + resultMinutes + "<br/><br/>";
                lblResultSunday.Text += result;
            }
        }

        private bool ItsHoliday(DateTime date) {
            string[] holidays = new string[12] { "01-01-2022", "15-04-2022", "23-05-2022", "24-06-2022", "01-07-2022", "01-08-2022", "05-09-2022", "30-09-2022", "10-10-2022", "11-11-2022", "25-12-2022", "26-12-2022" };
            string dateNewFormat = date.ToString("dd-mm-yyyy");

            foreach (string item in holidays)
            {
                if (dateNewFormat == item) return true;
            }

            return false;
        }

        public List<string> numberOfWeekNumber(int year) {
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
                result = i+1;
                week.Add(result.ToString());
            }

            return week;
        }

        public DateTime firstMondayOfWeek(int week, int year) {
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


    }
}