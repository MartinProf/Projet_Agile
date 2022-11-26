using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PunchClock
{
    public partial class Employee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
    }
}