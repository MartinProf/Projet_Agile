<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PunchClock.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            color: #000099;
            text-align: center;
            font-size: x-large;
            height: 61px;
            width: 517px;
        }
        body{
            background-color: #152238;
        }
        .auto-style4 {
            width: 573px;
        }
        .auto-style5 {
            font-size: medium;
        }
        .auto-style6 {
            text-align: right;
            color: #D7D6D4;
            height: 53px;
            width: 517px;
            font-size: x-large;
        }
        .auto-style7 {
            height: 53px;
            width: 573px;
        }
        .auto-style9 {
            text-align: right;
            color: #D7D6D4;
            height: 60px;
            width: 517px;
            font-size: x-large;
        }
        .auto-style10 {
            height: 60px;
            width: 573px;
        }
        .auto-style12 {
            color: #D7D6D4;
            font-size: xx-large;
            height: 61px;
            width: 573px;
        }
        .auto-style13 {
            width: 517px;
        }
        .auto-style14 {
            text-align: center;
            height: 54px;
        }
        .auto-style15 {
            color: #CC0000;
            font-size: large;
        }
        .auto-style16 {
            font-size: x-large;
        }
    </style>
</head>
<body style="margin-top: 270px">
    <form id="form1" runat="server">
        <div>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style2"></td>
                    <td class="auto-style12"><strong><em>Manager Login</em></strong></td>
                    
                </tr>
                <tr>
                    <td class="auto-style6"><strong>Username:</strong></td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtUsername" runat="server" CssClass="auto-style16"></asp:TextBox>
                    
                </tr>
                <tr>
                    <td class="auto-style9"><strong>Password:</strong></td>
                    <td class="auto-style10">
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="auto-style16" TextMode="Password"></asp:TextBox>
                    </td>
                    
                </tr>
                <tr>
                    <td class="auto-style13">&nbsp;</td>
                    <td class="auto-style4">
                        <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="auto-style5" OnClick="btnLogin_Click" Width="73px" />
                        <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="auto-style5" Width="76px" OnClick="btnReset_Click" />
                        <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="auto-style5" Width="76px" OnClick="btnBack_Click"  />
                    </td>
                    

                </tr>
               
            </table>
            <div class="auto-style14">
                <br>
                <asp:Label ID="lblResult" runat="server" Text="" CssClass="auto-style15"></asp:Label> </div>
        </div>
    </form>
</body>
</html>
