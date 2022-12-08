using Newtonsoft.Json;
using Projet_Agile;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PunchClock
{
    public partial class Manager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }


        protected void btnValidate_Click(object sender, EventArgs e)
        {
            if (btnLoadTimesheet.HasFile)
            {
                string fileName = btnLoadTimesheet.PostedFile.FileName;
                string a = "";
                string employeeID = "";
                string year = "";
                string week = "";
                string monday = "";
                string  tuesday= "";
                string wednesday = "";
                string thursday = "";
                string friday = "";
                string saturday = "";
                string sunday = "";
                int heuresTotal = 0;
                string FolderPath = @"C:\FeuillesTemps\";
                if (Directory.Exists(FolderPath))
                {
                    if (File.Exists(FolderPath + fileName))
                    {

                        string jsonFile = File.ReadAllText(FolderPath + fileName);
                        dynamic test = JsonConvert.DeserializeObject(jsonFile);

                        employeeID +=  test.numero_employe + "<br>";
                        year +=  test.annee + " <br> ";
                        week +=  test.numero_semaine + "<br>";

                        foreach (var item in test.jour1)
                        {
                            a = a + "<br>Project code: " + item.codeProject + "<br> ";
                            a = a + "Minutes: " + item.minutes + "<br> ";
                            heuresTotal += (int)item.minutes;
                        }
                        monday +=  a + "<br>";
                        a = "";
                        foreach (var item in test.jour2)
                        {
                            a = a + "Project code: " + item.codeProject + "<br> ";
                            a = a + "Minutes: " + item.minutes + "<br> ";
                            heuresTotal += (int)item.minutes;
                        }
                        tuesday += a + "<br>";
                        a = "";
                        foreach (var item in test.jour3)
                        {
                            a = a + "Project code: " + item.codeProject + " <br>";
                            a = a + "Minutes: " + item.minutes + "<br> ";
                            heuresTotal += (int)item.minutes;
                        }
                        wednesday +=  a + "<br>";
                        a = "";
                        foreach (var item in test.jour4)
                        {
                            a = a + "Project code: " + item.codeProject + "<br> ";
                            a = a + "Minutes: " + item.minutes + "<br> ";
                            heuresTotal += (int)item.minutes;
                        }
                        thursday +=  a + "<br>";
                        a = "";
                        foreach (var item in test.jour5)
                        {
                            a = a + "Project code: " + item.codeProject + "<br> ";
                            a = a + "Minutes: " + item.minutes + "<br> ";
                            heuresTotal += (int)item.minutes;
                        }
                        friday += a + "<br>";
                        a = "";
                        foreach (var item in test.weekendl)
                        {
                            a = a + "Project code: " + item.codeProject + "<br> ";
                            a = a + "Minutes: " + item.minutes + "<br> ";
                            heuresTotal += (int)item.minutes;
                        }
                        saturday +=  a + "<br>";
                        a = "";
                        foreach (var item in test.weekend2)
                        {
                            a = a + "Project code: " + item.codeProject + "<br> ";
                            a = a + "Minutes: " + item.minutes + "<br> ";
                            heuresTotal += (int)item.minutes;
                        }
                        sunday +=  a + "<br>";

                        //Response.Write(content + "<br>" + "Heures total: " + heuresTotal / 60);
                        // lblJsonOpened.Text = content;
                        lblYear.Text += year;
                        lblWeekNumber.Text += week;
                        lblEmployeeId.Text += employeeID;
                        lblMonday.Text = monday;
                        lblTuesday.Text = tuesday;
                        lblWednesday.Text = wednesday;
                        lblThursday.Text = thursday;
                        lblFriday.Text = friday;
                        lblSaturday.Text = saturday;
                        lblSunday.Text = sunday;
                    }
                    else
                    {
                        Response.Write("<script>alert('Le ficher " + fileName + " n'est pas un json')</script>");
                    }
                    lbFileName.Text = btnLoadTimesheet.PostedFile.FileName;
                }
            }

        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            if (lbFileName.Text != string.Empty)
            {
                string fileName = lbFileName.Text;
                string folderPathA = @"c:\FeuillesTemps\FeuillesAccepte\";
                string path = @"c:\FeuillesTemps\";
                if (!Directory.Exists(folderPathA))
                    Directory.CreateDirectory(folderPathA);
                try
                {
                    File.Move(path + fileName, folderPathA + fileName);
                    lbFileName.Text = string.Empty;
                    Response.Write("<script>alert('La feuille a ete accepte')</script>");
                    lblEmployeeId.Text = "";
                    lblYear.Text = "";
                    lblWeekNumber.Text = "";
                    lblMonday.Text = "";
                    lblTuesday.Text = "";
                    lblWednesday.Text = "";
                    lblThursday.Text = "";
                    lblFriday.Text = "";
                    lblSaturday.Text = "";
                    lblSunday.Text = "";
                }
                catch (Exception g)
                {
                    Response.Write(g.ToString());
                }
            }
            else
            {
                Response.Write("<script>alert('Veuillez appuyer sur le bouton validate avant')</script>");
            }
        }

        protected void btnRefuse_Click(object sender, EventArgs e)
        {
            if (lbFileName.Text != string.Empty)
            {
                string fileName = lbFileName.Text;
                string folderPathR = @"c:\FeuillesTemps\FeuillesRefuser\";
                string path = @"c:\FeuillesTemps\";

                if (!Directory.Exists(folderPathR))
                    Directory.CreateDirectory(folderPathR);
                try
                {
                    File.Move(path + fileName, folderPathR + fileName);
                    lbFileName.Text = string.Empty;
                    Response.Write("<script>alert('La feuille a ete refuse')</script>");
                    lblEmployeeId.Text = "";
                    lblYear.Text = "";
                    lblWeekNumber.Text = "";
                    lblMonday.Text = "";
                    lblTuesday.Text = "";
                    lblWednesday.Text = "";
                    lblThursday.Text = "";
                    lblFriday.Text = "";
                    lblSaturday.Text = "";
                    lblSunday.Text = "";
                }
                catch (Exception g)
                {
                    Response.Write(g.ToString());
                }
            }
            else
            {
                Response.Write("<script>alert('Veuillez appuyer sur le bouton validate avant')</script>");
            }
        }

        protected void btnLogout_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}