using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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

            if (ItsHoliday( firstMondayOfWeek(week, year))) 
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

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnAddMonday_Click(object sender, EventArgs e)
        {
            string resultProjet = "";
            string resultMinutes = "";

            string result = "";

            resultProjet = txtProjetMonday.Text;
            resultMinutes = txtMinutesMonday.Text;

            if (txtProjetMonday.BackColor != System.Drawing.Color.LightGray)
            {
                if (lblResultMonday.Text.Equals(""))
                {
                    result = "{project: " + resultProjet + ",<br/>" + "\nminutes: " + resultMinutes + "}<br/><br/>";
                    lblResultMonday.Text += result;
                }
                else
                {
                    result = ",{project: " + resultProjet + ",<br/>" + "\nminutes: " + resultMinutes + "}<br/><br/>";
                    lblResultMonday.Text += result;
                }

                if (cbSickMonday.Checked)
                {
                    btnAddMonday.Enabled = false;
                }
                if (resultProjet == "998")
                {
                    txtProjetMonday.BackColor = System.Drawing.Color.LightGray;
                    txtMinutesMonday.BackColor = System.Drawing.Color.LightGray;
                }
                txtProjetMonday.Text = "";
                txtMinutesMonday.Text = "";
            }
            else if (txtProjetMonday.BackColor == System.Drawing.Color.LightGray && int.Parse(resultProjet) >= 900)
            {
                if (lblResultMonday.Text.Equals(""))
                {
                    result = "{project: " + resultProjet + ",<br/>" + "\nminutes: " + resultMinutes + "}<br/><br/>";
                    lblResultMonday.Text += result;
                }
                else
                {
                    result = ",{project: " + resultProjet + ",<br/>" + "\nminutes: " + resultMinutes + "}<br/><br/>";
                    lblResultMonday.Text += result;
                }

                if (cbSickMonday.Checked)
                {
                    btnAddMonday.Enabled = false;
                }
                if (resultProjet == "998")
                {
                    txtProjetMonday.BackColor = System.Drawing.Color.LightGray;
                    txtMinutesMonday.BackColor = System.Drawing.Color.LightGray;
                }
                txtProjetMonday.Text = "";
                txtMinutesMonday.Text = "";
            }
            else
            {
                Response.Write("<script>alert('Seul le temps en télétravail est accepté pour cette journée');</script>");
            }
        }

        protected void btnAddTuesday_Click(object sender, EventArgs e)
        {
            string resultProjet = "";
            string resultMinutes = "";

            string result = "";

            resultProjet = txtProjetTuesday.Text;
            resultMinutes = txtMinutesTuesday.Text;

            if (txtProjetTuesday.BackColor != System.Drawing.Color.LightGray)
            {
                if (lblResultTuesday.Text.Equals(""))
                {
                    result = "{project: " + resultProjet + ",<br/>" + "\nminutes: " + resultMinutes + "}<br/><br/>";
                    lblResultTuesday.Text += result;
                }
                else
                {
                    result = ",{project: " + resultProjet + ",<br/>" + "\nminutes: " + resultMinutes + "}<br/><br/>";
                    lblResultTuesday.Text += result;
                }

                if (cbSickTuesday.Checked)
                {
                    btnAddTuesday.Enabled = false;
                }
                if (resultProjet == "998")
                {
                    txtProjetTuesday.BackColor = System.Drawing.Color.LightGray;
                    txtMinutesTuesday.BackColor = System.Drawing.Color.LightGray;
                }
                txtProjetTuesday.Text = "";
                txtMinutesTuesday.Text = "";
            }
            else if (txtProjetTuesday.BackColor == System.Drawing.Color.LightGray && int.Parse(resultProjet) >= 900)
            {
                if (lblResultTuesday.Text.Equals(""))
                {
                    result = "{project: " + resultProjet + ",<br/>" + "\nminutes: " + resultMinutes + "}<br/><br/>";
                    lblResultTuesday.Text += result;
                }
                else
                {
                    result = ",{project: " + resultProjet + ",<br/>" + "\nminutes: " + resultMinutes + "}<br/><br/>";
                    lblResultTuesday.Text += result;
                }

                if (cbSickTuesday.Checked)
                {
                    btnAddTuesday.Enabled = false;
                }
                if (resultProjet == "998")
                {
                    txtProjetTuesday.BackColor = System.Drawing.Color.LightGray;
                    txtMinutesTuesday.BackColor = System.Drawing.Color.LightGray;
                }
                txtProjetTuesday.Text = "";
                txtMinutesTuesday.Text = "";
            }
            else
            {
                Response.Write("<script>alert('Seul le temps en télétravail est accepté pour cette journée');</script>");
            }

        }

        protected void btnAddWednesday_Click(object sender, EventArgs e)
        {
            string resultProjet = "";
            string resultMinutes = "";

            string result = "";

            resultProjet = txtProjetWednesday.Text;
            resultMinutes = txtMinutesWednesday.Text;

            if (txtProjetWednesday.BackColor != System.Drawing.Color.LightGray)
            {
                if (lblResultWednesday.Text.Equals(""))
                {
                    result = "{project: " + resultProjet + ",<br/>" + "\nminutes: " + resultMinutes + "}<br/><br/>";
                    lblResultWednesday.Text += result;
                }
                else
                {
                    result = ",{project: " + resultProjet + ",<br/>" + "\nminutes: " + resultMinutes + "}<br/><br/>";
                    lblResultWednesday.Text += result;
                }

                if (cbSickWednesday.Checked)
                {
                    btnAddWednesday.Enabled = false;
                }
                if (resultProjet == "998")
                {
                    txtProjetWednesday.BackColor = System.Drawing.Color.LightGray;
                    txtMinutesWednesday.BackColor = System.Drawing.Color.LightGray;
                }

                txtProjetWednesday.Text = "";
                txtMinutesWednesday.Text = "";
            }
            else if (txtProjetWednesday.BackColor == System.Drawing.Color.LightGray && int.Parse(resultProjet) >= 900)
            {
                if (lblResultWednesday.Text.Equals(""))
                {
                    result = "{project: " + resultProjet + ",<br/>" + "\nminutes: " + resultMinutes + "}<br/><br/>";
                    lblResultWednesday.Text += result;
                }
                else
                {
                    result = ",{project: " + resultProjet + ",<br/>" + "\nminutes: " + resultMinutes + "}<br/><br/>";
                    lblResultWednesday.Text += result;
                }

                if (cbSickWednesday.Checked)
                {
                    btnAddWednesday.Enabled = false;
                }
                if (resultProjet == "998")
                {
                    txtProjetWednesday.BackColor = System.Drawing.Color.LightGray;
                    txtMinutesWednesday.BackColor = System.Drawing.Color.LightGray;
                }

                txtProjetWednesday.Text = "";
                txtMinutesWednesday.Text = "";
            }
            else
            {
                Response.Write("<script>alert('Seul le temps en télétravail est accepté pour cette journée');</script>");
            }
        }

        protected void btnAddThursday_Click(object sender, EventArgs e)
        {
            string resultProjet = "";
            string resultMinutes = "";

            string result = "";

            resultProjet = txtProjetThursday.Text;
            resultMinutes = txtMinutesThursday.Text;

            if (txtProjetThursday.BackColor != System.Drawing.Color.LightGray)
            {
                if (lblResultThursday.Text.Equals(""))
                {
                    result = "{project: " + resultProjet + ",<br/>" + "\nminutes: " + resultMinutes + "}<br/><br/>";
                    lblResultThursday.Text += result;
                }
                else
                {
                    result = ",{project: " + resultProjet + ",<br/>" + "\nminutes: " + resultMinutes + "}<br/><br/>";
                    lblResultThursday.Text += result;
                }

                if (cbSickThursday.Checked)
                {
                    btnAddThursday.Enabled = false;
                }
                if (resultProjet == "998")
                {
                    txtProjetThursday.BackColor = System.Drawing.Color.LightGray;
                    txtMinutesThursday.BackColor = System.Drawing.Color.LightGray;
                }

                txtProjetThursday.Text = "";
                txtMinutesThursday.Text = "";
            }
            else if (txtProjetThursday.BackColor == System.Drawing.Color.LightGray && int.Parse(resultProjet) >= 900)
            {
                if (lblResultThursday.Text.Equals(""))
                {
                    result = "{project: " + resultProjet + ",<br/>" + "\nminutes: " + resultMinutes + "}<br/><br/>";
                    lblResultThursday.Text += result;
                }
                else
                {
                    result = ",{project: " + resultProjet + ",<br/>" + "\nminutes: " + resultMinutes + "}<br/><br/>";
                    lblResultThursday.Text += result;
                }

                if (cbSickThursday.Checked)
                {
                    btnAddThursday.Enabled = false;
                }
                if (resultProjet == "998")
                {
                    txtProjetThursday.BackColor = System.Drawing.Color.LightGray;
                    txtMinutesThursday.BackColor = System.Drawing.Color.LightGray;
                }

                txtProjetThursday.Text = "";
                txtMinutesThursday.Text = "";
            }
            else
            {
                Response.Write("<script>alert('Seul le temps en télétravail est accepté pour cette journée');</script>");
            }
        }

        protected void btnAddFriday_Click(object sender, EventArgs e)
        {
            string resultProjet = "";
            string resultMinutes = "";

            string result = "";

            resultProjet = txtProjetFriday.Text;
            resultMinutes = txtMinutesFriday.Text;

            if (txtProjetFriday.BackColor != System.Drawing.Color.LightGray) 
            {
                if (lblResultFriday.Text.Equals(""))
                {
                    result = "{project: " + resultProjet + ",<br/>" + "\nminutes: " + resultMinutes + "}<br/><br/>";
                    lblResultFriday.Text += result;
                }
                else
                {
                    result = ",{project: " + resultProjet + ",<br/>" + "\nminutes: " + resultMinutes + "}<br/><br/>";
                    lblResultFriday.Text += result;
                }

                if (cbSickFriday.Checked)
                {
                    btnAddFriday.Enabled = false;
                }
                if (resultProjet == "998")
                {
                    txtProjetFriday.BackColor = System.Drawing.Color.LightGray;
                    txtMinutesFriday.BackColor = System.Drawing.Color.LightGray;
                }

                txtProjetFriday.Text = "";
                txtMinutesFriday.Text = "";

            }
            else if (txtProjetFriday.BackColor == System.Drawing.Color.LightGray && int.Parse(resultProjet) >= 900)
            {
                if (lblResultFriday.Text.Equals(""))
                {
                    result = "{project: " + resultProjet + ",<br/>" + "\nminutes: " + resultMinutes + "}<br/><br/>";
                    lblResultFriday.Text += result;
                }
                else
                {
                    result = ",{project: " + resultProjet + ",<br/>" + "\nminutes: " + resultMinutes + "}<br/><br/>";
                    lblResultFriday.Text += result;
                }

                if (cbSickFriday.Checked)
                {
                    btnAddFriday.Enabled = false;
                }
                if (resultProjet == "998")
                {
                    txtProjetFriday.BackColor = System.Drawing.Color.LightGray;
                    txtMinutesFriday.BackColor = System.Drawing.Color.LightGray;
                }

                txtProjetFriday.Text = "";
                txtMinutesFriday.Text = "";
            }
            else 
            {
                Response.Write("<script>alert('Seul le temps en télétravail est accepté pour cette journée');</script>");
            }

        }

        protected void btnAddSaturday_Click(object sender, EventArgs e)
        {
            string resultProjet = "";
            string resultMinutes = "";

            string result = "";

            resultProjet = txtProjetSaturday.Text;
            resultMinutes = txtMinutesSaturday.Text;

            if (int.Parse(resultProjet) == 998)
                Response.Write("<script>alert('Les fériés ne sont pas permis durant la fin de semaine');</script>");
            else
            {
                if (lblResultSaturday.Text.Equals(""))
                {
                    result = "{project: " + resultProjet + ",<br/>" + "\nminutes: " + resultMinutes + "}<br/><br/>";
                    lblResultSaturday.Text += result;
                }
                else
                {
                    result = ",{project: " + resultProjet + ",<br/>" + "\nminutes: " + resultMinutes + "}<br/><br/>";
                    lblResultSaturday.Text += result;
                }

                txtProjetSaturday.Text = "";
                txtMinutesSaturday.Text = "";
            }


            
        }

        protected void btnAddSunday_Click(object sender, EventArgs e)
        {
            string resultProjet = "";
            string resultMinutes = "";

            string result = "";

            resultProjet = txtProjetSunday.Text;
            resultMinutes = txtMinutesSunday.Text;

            if (int.Parse(resultProjet) == 998)
                Response.Write("<script>alert('Les fériés ne sont pas permis durant la fin de semaine');</script>");
            else
            {
                if (lblResultSunday.Text.Equals(""))
                {
                    result = "{project: " + resultProjet + ",<br/>" + "\nminutes: " + resultMinutes + "}<br/><br/>";
                    lblResultSunday.Text += result;
                }
                else 
                {
                    result = ",{project: " + resultProjet + ",<br/>" + "\nminutes: " + resultMinutes + "}<br/><br/>";
                    lblResultSunday.Text += result;
                }


                txtProjetSunday.Text = "";
                txtMinutesSunday.Text = "";
            }

        }

        private bool ItsHoliday(DateTime date) {
            string[] holidays = new string[12] { "01-01-2022", "15-04-2022", "23-05-2022", "24-06-2022", "01-07-2022", "01-08-2022", "05-09-2022", "30-09-2022", "10-10-2022", "11-11-2022", "25-12-2022", "26-12-2022" };
            string dateNewFormat = date.ToString("dd-MM-yyyy");

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

        protected void cbSickMonday_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSickMonday.Checked)
            {
                txtProjetMonday.Text = "999";
                txtMinutesMonday.Text = "420";
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
            }
            else {
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
                string id = txtEmpId.Text;
                string year = txtYear.Text;
                string weekNumber = dropDownListWeek.SelectedValue;
                jsonFile = stringJsonGenerator(id, year, weekNumber);
                jsonName = id + "-" + year + "-" + weekNumber + ".json";
                LabelTestJson.Text = jsonFile;
                
            }
            catch (Exception)
            {

                Response.Write("<script>alert('Un des champs est manquant!');</script>");

            }

            //File.WriteAllText(jsonName, jsonFile);

            //Projet_Agile.Program.Generate(jsonName, jsonFile);
        }

        private string stringJsonGenerator(string id, string year, string weekNumber)
        {
            string jsonFormat = "{";
            jsonFormat += "\"numero employe:\":" + id;
            jsonFormat += ",\n\"annee\":" + year;
            jsonFormat += ",\n\"numero semaine\":" + weekNumber;
            jsonFormat += ",\n\"jour1\":[" + lblResultMonday.Text + "],";
            jsonFormat += "\"jour2\":[" + lblResultTuesday.Text + "],";
            jsonFormat += "\"jour3\":[" + lblResultWednesday.Text + "],";
            jsonFormat += "\"jour4\":[" + lblResultThursday.Text + "],";
            jsonFormat += "\"jour5\":[" + lblResultFriday.Text + "],";
            jsonFormat += "\"weekendl\":[" + lblResultSaturday.Text + "],";
            jsonFormat += "\"weekend2\":[" + lblResultSunday.Text + "]}";

            return jsonFormat;
        }

        public static async Task jsonCreator(string jsonName, string jsonFile) 
        {
            //using Streamwriter file = new(jsonName, append: true);

            //await file.WriteAllTextAsync(jsonFile);
        }
    }
}
