<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Welcome.aspx.cs" Inherits="PunchClock.Welcome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;

        }
        
        .auto-style2 {
            font-size: xx-large;
            color: #F7ECEA;
        }
        body{
            background-color: #152238;
        }
        label{
            color: #A0A3AF;
        }
        .auto-style3 {
            font-size: x-large;
            color: #F7ECEA;
        }
        
        .auto-style6 {
            font-size: x-large;
            color: #D7D6D4;
            background-color: #152238;
        }
        
        .auto-style7 {
            text-align: center;
            height: 111px;
        }
        
        .auto-style8 {
            text-align: right;
        }
        html, body{
            height:100%;
        }
        .main {
    align-items: center;
  display: flex;
  justify-content: center;
  height: 100%;
  width: 100%;
}
.wrapper {
    display: table-cell;
    height: 100%;
    vertical-align: middle;
}
        
    </style>
</head>
<body style="margin-top: 270px">
    <form id="form1" runat="server">
        <div class="main">
            <div class="wrapper">
            <table style="width: 100%;">
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style1"><strong><em>
                        <asp:Label ID="Label1" runat="server" CssClass="auto-style2" Text="Welcome to PunchClock!"></asp:Label>
                        </em></strong></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style1">
                        <asp:Label ID="Label2" runat="server" Text="Please choose one of the following options" CssClass="auto-style3"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>


            </table>
            <br>
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style8">
                        <asp:Button ID="btnManager" runat="server" CssClass="auto-style6" Text="Manager" Height="70px" Width="200px" OnClick="btnManager_Click" />
                    </td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="btnEmployee" runat="server" CssClass="auto-style6" Text="Coworker" Height="70px" Width="200px" OnClick="btnEmployee_Click" />
                    </td>
                </tr>
               
            </table>
                </div>
        </div>
    </form>
            
        </body>
</html>
