<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manager.aspx.cs" Inherits="PunchClock.Manager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
            font-size: x-large;
            color: #000099;
        }
        .auto-style2 {
            font-size: large;
        }
        .auto-style3 {
            text-align: center;
        }
        .auto-style4 {
            height: 35px;
        }
        .auto-style5 {
            text-align: center;
            height: 35px;
        }
        .auto-style6 {
            height: 48px;
        }
        .auto-style7 {
            text-align: center;
            height: 48px;
        }
        .auto-style8 {
            text-align: center;
            height: 66px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width:100%;">
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style1"><strong>Validate Timesheets</strong></td>
                    <td>&nbsp;</td>
                </tr>
               
                
            </table>
            <br/>
            <br/>
            <table style="width: 100%;">
                    <tr>
                        <td class="auto-style3">
                            <asp:Button ID="btnLoadTimesheet" runat="server" CssClass="auto-style2" Text="Load Timesheet" Width="220px" />
                        </td>
                        <td>&nbsp;</td>
                        <td class="auto-style3">
                            <asp:Button ID="btnValidate" runat="server" CssClass="auto-style2" Text="Validate TimeSheet" Width="220px" />
                        </td>
                    </tr>
                   
                </table>
            <table style="width: 100%;">
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4"></td>
                    <td class="auto-style5">//TODO, On va afficher ici les contenus de la feuille de temps chargé à partir d'un fichier json</td>
                    <td class="auto-style4"></td>
                </tr>
                <tr>
                    <td class="auto-style6"></td>
                    <td class="auto-style7">Le bouton Load Timesheet doit ouvrir l&#39;explorateur de fichier de windows pour que l&#39;utilisateur puisse charger la feuille de temps et l&#39;afficher</td>
                    <td class="auto-style6"></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style3">Le boutton Validate doit valider la feuille de temps, une fois elle soit chargé et affiché</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <>
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style8">
                            <asp:Button ID="btnLogout" runat="server" CssClass="auto-style2" Text="Logout" Width="220px" />
                        </td>
                    
                </tr>
                
            </table>
        </div>
    </form>
</body>
</html>
