using System;
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
        string resultMinutes = "0";


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

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void addDayWeek(TextBox inputProjetDay, TextBox inputMinutesDay,Label resultDay, Label day, CheckBox sickDay, Button addDay)
        {
            string  resultProjet = "";
            resultMinutes = "0";

            string result = "";
            string resultAffichage = "";

            resultProjet = inputProjetDay.Text;
            resultMinutes = inputMinutesDay.Text;

            if (inputProjetDay.BackColor != System.Drawing.Color.LightGray)
            {
                resultAffichage = "Project Code: " + resultProjet + "<br/>" + "\nMinutes: " + resultMinutes + "<br/><br/>";
                resultDay.Text += resultAffichage;

                if (day.Text.Equals(""))
                {
                    result = "{\"project:\" " + resultProjet + "," + "\n\"minutes:\" " + resultMinutes + "}";
                    day.Text += result;
                }
                else
                {
                    result = "\n,{\"project:\" " + resultProjet + "," + "\n\"minutes:\" " + resultMinutes + "}";
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
            else if (inputProjetDay.BackColor == System.Drawing.Color.LightGray && int.Parse(resultProjet) >= 900)
            {
                resultAffichage = "Project Code: " + resultProjet + "<br/>" + "\nMinutes: " + resultMinutes + "<br/><br/>";
                resultDay.Text += resultAffichage;

                if (day.Text.Equals(""))
                {
                    result = "{\"project:\" " + resultProjet + "," + "\n\"minutes:\" " + resultMinutes + "}";
                    day.Text += result;
                }
                else
                {
                    result = "\n,{\"project:\" " + resultProjet + "," + "\n\"minutes:\" " + resultMinutes + "}";
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
        protected void addWeekend(TextBox inputProjetDay, TextBox inputMinutesDay, Label resultDay, Label day)
        {
            string resultProjet = "";
            resultMinutes = "0";

            string result = "";
            string resultAffichage = "";

            resultProjet = inputProjetDay.Text;
            resultMinutes = inputMinutesDay.Text;

            try
            {
                if (int.Parse(resultProjet) == 998)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup","validateFeriealert();", true);
                }
                else
                {
                    resultAffichage = "Project Code: " + resultProjet + "<br/>" + "\nMinutes: " + resultMinutes + "<br/><br/>";
                    resultDay.Text += resultAffichage;

                    if (day.Text.Equals(""))
                    {
                        result = "{\"project:\" " + resultProjet + "," + "\n\"minutes:\" " + resultMinutes + "}";
                        day.Text += result;
                    }
                    else
                    {
                        result = "\n,{\"project:\" " + resultProjet + "," + "\n\"minutes:\" " + resultMinutes + "}";
                        day.Text += result;
                    }

                    inputProjetDay.Text = "";
                    inputMinutesDay.Text = "";
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
                if (totalTimeWorkedJour1 <= (24 * 60))
                {
                    addDayWeek(txtProjetMonday, txtMinutesMonday, lblResultMonday, LabelLundi, cbSickMonday, btnAddMonday);

                }
                else
                {
                    totalTimeWorkedJour1 = 0;
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "validate24alert();", true);
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
                if (totalTimeWorkedJour2 <= (24 * 60))
                {
                    addDayWeek(txtProjetTuesday, txtMinutesTuesday, lblResultTuesday, LabelMardi, cbSickTuesday, btnAddTuesday);
                }
                else
                {
                    totalTimeWorkedJour2 = 0;
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "validate24alert();", true);
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
                if (totalTimeWorkedJour3 <= (24 * 60))
                {
                    addDayWeek(txtProjetWednesday, txtMinutesWednesday, lblResultWednesday, LabelMercredi, cbSickWednesday, btnAddWednesday);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "validate24alert();", true);
                }
            }
            catch (Exception)
            {
                totalTimeWorkedJour3 = 0;
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "validateChampsRequisalert();", true);
            }
        }

        protected void btnAddThursday_Click(object sender, EventArgs e)
        {
            try
            {
                resultMinutes = txtMinutesThursday.Text;
                totalTimeWorkedJour4 += int.Parse(resultMinutes);
                if (totalTimeWorkedJour4 <= (24 * 60))
                {
                    addDayWeek(txtProjetThursday, txtMinutesThursday, lblResultThursday, LabelJeudi, cbSickThursday, btnAddThursday);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "validate24alert();", true);
                }
            }
            catch (Exception)
            {
                totalTimeWorkedJour4 = 0;
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "validateChampsRequisalert();", true);
            }
        }

        protected void btnAddFriday_Click(object sender, EventArgs e)
        {
            try
            {
                resultMinutes = txtMinutesFriday.Text;
                totalTimeWorkedJour5 += int.Parse(resultMinutes);
                if (totalTimeWorkedJour5 <= (24 * 60))
                {
                    addDayWeek(txtProjetFriday, txtMinutesFriday, lblResultFriday, LabelVendredi, cbSickFriday, btnAddFriday);
                }
                else
                {
                    totalTimeWorkedJour5 = 0;
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "validate24alert();", true);
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
                    totalTimeWorkedWeekend1 = 0;
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
                    totalTimeWorkedWeekend2 = 0;
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "validate24alert();", true);
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "validateChampsRequisalert();", true);
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
                int empID =Int32.Parse(txtEmpId.Text);
                if (empID <= 999)
                {
                    if (totalTimeWorkedJour1 >= 240 && totalTimeWorkedJour2 >= 240 && totalTimeWorkedJour3 >= 240 && totalTimeWorkedJour4 >= 240 && totalTimeWorkedJour5 >= 240)
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
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "validate4halert();", true);
                    }
                }
                if (empID >= 1000 && empID <= 1999)
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
                    
                }
                if (empID >= 2000)
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

                }

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
            string jsonFormat = "{";
            jsonFormat += "\"numero employe:\":" + id;
            jsonFormat += ",\n\"annee\":" + year;
            jsonFormat += ",\n\"numero semaine\":" + weekNumber;
            jsonFormat += ",\n\"jour1\":\n[\n" + LabelLundi.Text + "\n]\n,\n";
            jsonFormat += "\"jour2\":\n[\n" + LabelMardi.Text + "\n]\n,\n";
            jsonFormat += "\"jour3\":\n[\n" + LabelMercredi.Text + "\n]\n,\n";
            jsonFormat += "\"jour4\":\n[\n" + LabelJeudi.Text + "\n]\n,\n";
            jsonFormat += "\"jour5\":\n[\n" + LabelVendredi.Text + "\n]\n,\n";
            jsonFormat += "\"weekendl\":\n[\n" + LabelSamedi.Text + "\n]\n,\n";
            jsonFormat += "\"weekend2\":\n[\n" + LabelDimanche.Text + "\n]\n}";

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

        protected void btnRestartMonday_Click(object sender, EventArgs e)
        {

        }
    }
}
