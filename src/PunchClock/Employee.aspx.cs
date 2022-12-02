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
            string resultAffichage = "";

            resultProjet = txtProjetMonday.Text;
            resultMinutes = txtMinutesMonday.Text;

            if (txtProjetMonday.BackColor != System.Drawing.Color.LightGray)
            {
                resultAffichage = "Project Code: " + resultProjet + "<br/>" + "\nMinutes: " + resultMinutes + "<br/><br/>";
                lblResultMonday.Text += resultAffichage;

                if (LabelLundi.Text.Equals(""))
                {
                    result = "{\"project:\" " + resultProjet + "," + "\n\"minutes:\" " + resultMinutes + "}";
                    LabelLundi.Text += result;
                }
                else
                {
                    result = "\n,{\"project:\" " + resultProjet + "," + "\n\"minutes:\" " + resultMinutes + "}";
                    LabelLundi.Text += result;
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
                resultAffichage = "Project Code: " + resultProjet + "<br/>" + "\nMinutes: " + resultMinutes + "<br/><br/>";
                lblResultMonday.Text += resultAffichage;

                if (LabelLundi.Text.Equals(""))
                {
                    result = "{\"project:\" " + resultProjet + "," + "\n\"minutes:\" " + resultMinutes + "}";
                    LabelLundi.Text += result;
                }
                else
                {
                    result = "\n,{\"project:\" " + resultProjet + "," + "\n\"minutes:\" " + resultMinutes + "}";
                    LabelLundi.Text += result;
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
            string resultAffichage = "";

            resultProjet = txtProjetTuesday.Text;
            resultMinutes = txtMinutesTuesday.Text;

            if (txtProjetTuesday.BackColor != System.Drawing.Color.LightGray)
            {
                resultAffichage = "Project Code: " + resultProjet + "<br/>" + "\nMinutes: " + resultMinutes + "<br/><br/>";
                lblResultTuesday.Text += resultAffichage;

                if (LabelMardi.Text.Equals(""))
                {
                    result = "{\"project:\" " + resultProjet + "," + "\n\"minutes:\" " + resultMinutes + "}";
                    LabelMardi.Text += result;
                }
                else
                {
                    result = "\n,{\"project:\" " + resultProjet + "," + "\n\"minutes:\" " + resultMinutes + "}";
                    LabelMardi.Text += result;
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
                resultAffichage = "Project Code: " + resultProjet + "<br/>" + "\nMinutes: " + resultMinutes + "<br/><br/>";
                lblResultTuesday.Text += resultAffichage;

                if (LabelMardi.Text.Equals(""))
                {
                    result = "{\"project:\" " + resultProjet + "," + "\n\"minutes:\" " + resultMinutes + "}";
                    LabelMardi.Text += result;
                }
                else
                {
                    result = "\n,{\"project:\" " + resultProjet + "," + "\n\"minutes:\" " + resultMinutes + "}";
                    LabelMardi.Text += result;
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
            string resultAffichage = "";

            resultProjet = txtProjetWednesday.Text;
            resultMinutes = txtMinutesWednesday.Text;

            if (txtProjetWednesday.BackColor != System.Drawing.Color.LightGray)
            {
                resultAffichage = "Project Code: " + resultProjet + "<br/>" + "\nMinutes: " + resultMinutes + "<br/><br/>";
                lblResultWednesday.Text += resultAffichage;

                if (LabelMercredi.Text.Equals(""))
                {
                    result = "{\"project:\" " + resultProjet + "," + "\n\"minutes:\" " + resultMinutes + "}";
                    LabelMercredi.Text += result;
                }
                else
                {
                    result = "\n,{\"project:\" " + resultProjet + "," + "\n\"minutes:\" " + resultMinutes + "}";
                    LabelMercredi.Text += result;
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
                resultAffichage = "Project Code: " + resultProjet + "<br/>" + "\nMinutes: " + resultMinutes + "<br/><br/>";
                lblResultWednesday.Text += resultAffichage;

                if (LabelMercredi.Text.Equals(""))
                {
                    result = "{\"project:\" " + resultProjet + "," + "\n\"minutes:\" " + resultMinutes + "}";
                    LabelMercredi.Text += result;
                }
                else
                {
                    result = "\n,{\"project:\" " + resultProjet + "," + "\n\"minutes:\" " + resultMinutes + "}";
                    LabelMercredi.Text += result;
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
            string resultAffichage = "";

            resultProjet = txtProjetThursday.Text;
            resultMinutes = txtMinutesThursday.Text;

            if (txtProjetThursday.BackColor != System.Drawing.Color.LightGray)
            {
                resultAffichage = "Project Code: " + resultProjet + "<br/>" + "\nMinutes: " + resultMinutes + "<br/><br/>";
                lblResultThursday.Text += resultAffichage;

                if (LabelJeudi.Text.Equals(""))
                {
                    result = "{\"project:\" " + resultProjet + "," + "\n\"minutes:\" " + resultMinutes + "}";
                    LabelJeudi.Text += result;
                }
                else
                {
                    result = "\n,{\"project:\" " + resultProjet + "," + "\n\"minutes:\" " + resultMinutes + "}";
                    LabelJeudi.Text += result;
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
                resultAffichage = "Project Code: " + resultProjet + "<br/>" + "\nMinutes: " + resultMinutes + "<br/><br/>";
                lblResultThursday.Text += resultAffichage;

                if (LabelJeudi.Text.Equals(""))
                {
                    result = "{\"project:\" " + resultProjet + "," + "\n\"minutes:\" " + resultMinutes + "}";
                    LabelJeudi.Text += result;
                }
                else
                {
                    result = "\n,{\"project:\" " + resultProjet + "," + "\n\"minutes:\" " + resultMinutes + "}";
                    LabelJeudi.Text += result;
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
            string resultAffichage = "";

            resultProjet = txtProjetFriday.Text;
            resultMinutes = txtMinutesFriday.Text;

            if (txtProjetFriday.BackColor != System.Drawing.Color.LightGray) 
            {
                resultAffichage = "Project Code: " + resultProjet + "<br/>" + "\nMinutes: " + resultMinutes + "<br/><br/>";
                lblResultFriday.Text += resultAffichage;

                if (LabelVendredi.Text.Equals(""))
                {
                    result = "{\"project:\" " + resultProjet + "," + "\n\"minutes:\" " + resultMinutes + "}";
                    LabelVendredi.Text += result;
                }
                else
                {
                    result = "\n,{\"project:\" " + resultProjet + "," + "\n\"minutes:\" " + resultMinutes + "}";
                    LabelVendredi.Text += result;
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
                resultAffichage = "Project Code: " + resultProjet + "<br/>" + "\nMinutes: " + resultMinutes + "<br/><br/>";
                lblResultFriday.Text += resultAffichage;

                if (LabelVendredi.Text.Equals(""))
                {
                    result = "{\"project:\" " + resultProjet + "," + "\n\"minutes:\" " + resultMinutes + "}";
                    LabelVendredi.Text += result;
                }
                else
                {
                    result = "\n,{\"project:\" " + resultProjet + "," + "\n\"minutes:\" " + resultMinutes + "}";
                    LabelVendredi.Text += result;
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
            string resultAffichage = "";

            resultProjet = txtProjetSaturday.Text;
            resultMinutes = txtMinutesSaturday.Text;

            if (int.Parse(resultProjet) == 998)
                Response.Write("<script>alert('Les fériés ne sont pas permis durant la fin de semaine');</script>");
            else
            {
                resultAffichage = "Project Code: " + resultProjet + "<br/>" + "\nMinutes: " + resultMinutes + "<br/><br/>";
                lblResultSaturday.Text += resultAffichage;

                if (LabelSamedi.Text.Equals(""))
                {
                    result = "{\"project:\" " + resultProjet + "," + "\n\"minutes:\" " + resultMinutes + "}";
                    LabelSamedi.Text += result;
                }
                else
                {
                    result = "\n,{\"project:\" " + resultProjet + "," + "\n\"minutes:\" " + resultMinutes + "}";
                    LabelSamedi.Text += result;
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
            string resultAffichage = "";

            resultProjet = txtProjetSunday.Text;
            resultMinutes = txtMinutesSunday.Text;

            if (int.Parse(resultProjet) == 998)
                Response.Write("<script>alert('Les fériés ne sont pas permis durant la fin de semaine');</script>");
            else
            {
                resultAffichage = "Project Code: " + resultProjet + "<br/>" + "\nMinutes: " + resultMinutes + "<br/><br/>";
                lblResultSunday.Text += resultAffichage;

                if (LabelDimanche.Text.Equals(""))
                {
                    result = "{\"project:\" " + resultProjet + "," + "\n\"minutes:\" " + resultMinutes + "}";
                    LabelDimanche.Text += result;
                }
                else 
                {
                    result = "\n,{\"project:\" " + resultProjet + "," + "\n\"minutes:\" " + resultMinutes + "}";
                    LabelDimanche.Text += result;
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
                jsonName = id + "-" + year + "-" + weekNumber;
            }
            catch (Exception)
            {

                Response.Write("<script>alert('Un des champs est manquant!');</script>");

            }

            
            try
            {
                if (String.IsNullOrWhiteSpace(jsonName) || String.IsNullOrWhiteSpace(jsonFile))
                    LabelTestJson.Text = "Please enter File name and its content";
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

                LabelTestJson.Text = "Le fichier json a été sauvegardé dans le dossier: C:\\FeuillesTemps ";
            }
            catch (Exception ex)
            {
                LabelTestJson.Text = "Erreur survenue:" + ex.Message.ToString();
            }
        }
    }
}
