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
                string content = "";
                int heuresTotal = 0;
                string FolderPath = @"C:\FeuillesTemps\";
                if (Directory.Exists(FolderPath))
                {
                    if (File.Exists(FolderPath + fileName))
                    {

                        string jsonFile = File.ReadAllText(FolderPath + fileName);
                        dynamic test = JsonConvert.DeserializeObject(jsonFile);

                        content += "Employé: " + test.numero_employe + "<br>";
                        content += "Année: " + test.annee + "<br>";
                        content += "Semaine: " + test.numero_semaine + "<br>";

                        foreach (var item in test.jour1)
                        {
                            a = a + "Code du projet: " + item.codeProject + " ";
                            a = a + "Minutes: " + item.minutes + " ";
                            heuresTotal += (int)item.minutes;
                        }
                        content += "Lundi: " + a + "<br>";
                        a = "";
                        foreach (var item in test.jour2)
                        {
                            a = a + "Code du projet: " + item.codeProject + " ";
                            a = a + "Minutes: " + item.minutes + " ";
                            heuresTotal += (int)item.minutes;
                        }
                        content += "Mardi: " + a + "<br>";
                        a = "";
                        foreach (var item in test.jour3)
                        {
                            a = a + "Code du projet: " + item.codeProject + " ";
                            a = a + "Minutes: " + item.minutes + " ";
                            heuresTotal += (int)item.minutes;
                        }
                        content += "Mercredi: " + a + "<br>";
                        a = "";
                        foreach (var item in test.jour4)
                        {
                            a = a + "Code du projet: " + item.codeProject + " ";
                            a = a + "Minutes: " + item.minutes + " ";
                            heuresTotal += (int)item.minutes;
                        }
                        content += "Jeudi: " + a + "<br>";
                        a = "";
                        foreach (var item in test.jour5)
                        {
                            a = a + "Code du projet: " + item.codeProject + " ";
                            a = a + "Minutes: " + item.minutes + " ";
                            heuresTotal += (int)item.minutes;
                        }
                        content += "Vendredi: " + a + "<br>";
                        a = "";
                        foreach (var item in test.weekendl)
                        {
                            a = a + "Code du projet: " + item.codeProject + " ";
                            a = a + "Minutes: " + item.minutes + " ";
                            heuresTotal += (int)item.minutes;
                        }
                        content += "Samedi: " + a + "<br>";
                        a = "";
                        foreach (var item in test.weekend2)
                        {
                            a = a + "Code du projet: " + item.codeProject + " ";
                            a = a + "Minutes: " + item.minutes + " ";
                            heuresTotal += (int)item.minutes;
                        }
                        content += "Dimanche: " + a + "<br>";

                        Response.Write(content + "<br>" + "Heures total: " + heuresTotal / 60);
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