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
            string fileName = btnLoadTimesheet.PostedFile.FileName;
            string a = "";
            string content = "";
            string FolderPath = @"C:\FeuillesTemps\";
            if (Directory.Exists(FolderPath))
            {
                if (File.Exists(FolderPath+fileName))
                {
                    
                    string jsonFile = File.ReadAllText(FolderPath + fileName);
                    dynamic test = JsonConvert.DeserializeObject(jsonFile);

                    content += "Employé:" + test.numero_employe + "<br>";
                    content += "Année:" + test.annee + "<br>";
                    content += "Semaine:" + test.numero_semaine + "<br>";
                    content += "Jour1:" + test.jour1 + "<br>";
                    content += "Jour2:" + test.jour2 + "<br>";
                    content += "Jour3:" + test.jour3 + "<br>";
                    content += "Jour4:" + test.jour4 + "<br>";
                    content += "Jour5:" + test.jour5 + "<br>";
                    content += "Jour5 minutes première occurence:" + test.jour5[0].minutes + "<br>";
                    content += "Weekend1:" + test.weekendl + "<br>";
                    content += "Weekend2:" + test.weekend2 + "<br><br><br>";

                    TimeSheetGenerator g = JsonConvert.DeserializeObject<TimeSheetGenerator>(jsonFile);

                    content = content + ($"Numero employe: {g.numero_employe}") + "<br>";

                    content = content + ($"Annee: {g.annee}") + "<br>";

                    content = content + ($"Semaine : {g.numero_semaine}") + "<br>";

                    foreach (var item in g.jour1)
                    {
                        
                        a = a+ "Code projet : "+(int.Parse($"{item.codeProject}")) + " ";
                        a = a + "Minutes : "+(int.Parse($"{item.minute}")) + " ";
                    }

                    
                    content = content + ("jour1 : " + a) + "<br>";

                    a = "";

                    foreach (var item in g.jour2)
                    {
                        a = a + ($"{item}");
                    }

                    content = content + ("jour2 : " + a) + "<br>";

                    a = "";

                    foreach (var item in g.jour3)
                    {
                        a = a + ($"{item}");
                    }

                    content = content + ("jour3 : " + a) + "<br>";

                    a = "";

                    foreach (var item in g.jour4)
                    {
                        a = a + ($"{item}");
                    }

                    content = content + ("jour4 : " + a) + "<br>";

                    a = "";

                    foreach (var item in g.jour5)
                    {
                        a = a + ($"{item}");
                    }

                    content = content + ("jour5 : " + a) + "<br>";

                    a = "";

                    foreach (var item in g.weekendl)
                    {
                        a = a + ($"{item}");
                    }

                    content = content + ("jour6 : " + a) + "<br>";

                    a = "";

                    foreach (var item in g.weekend2)
                    {
                        a = a + ($"{item}");
                    }

                    content = content + ("jour7 : " + a);


                    Response.Write( content );
                }
                else
                {
                    Response.Write("<script>alert('Fichier inexistant " + fileName + "')</script>");
                }
                lbFileName.Text = btnLoadTimesheet.PostedFile.FileName;
            }
            
        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            string fileName = lbFileName.Text;
            string folderPathA = @"c:\FeuillesTemps\FeuillesAccepte\";
            string path = @"c:\FeuillesTemps\";
            if (!Directory.Exists(folderPathA))
                Directory.CreateDirectory(folderPathA);
            try
            {
                
                 
                File.Move(path+fileName, folderPathA+fileName);
                
            }
            catch (Exception g)
            {
                Response.Write(g.ToString());
            }
        }

        protected void btnRefuse_Click(object sender, EventArgs e)
        {
            string fileName = lbFileName.Text;
            string folderPathR = @"c:\FeuillesTemps\FeuillesRefuser\";
            string path = @"c:\FeuillesTemps\";
            
            if (!Directory.Exists(folderPathR))
                Directory.CreateDirectory(folderPathR);
            try
            {


                File.Move(path + fileName, folderPathR + fileName);

            }
            catch (Exception g)
            {
                Response.Write(g.ToString());
            }
        }
    }
}