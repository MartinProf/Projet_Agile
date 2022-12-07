<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manager.aspx.cs" Inherits="PunchClock.Manager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        hr {
             border: 0;
            border-bottom: 1px dashed #ccc;
            background: #999;
        }
        body{
            background-color: #152238;
        }
        .auto-style1 {
            text-align: center;
            font-size: xx-large;
            color: #D7D6D4;
        }
        .auto-style2 {
            font-size: large;
        }
        .auto-style3 {
            text-align: center;
        }
        .auto-style8 {
            text-align: center;
            height: 66px;
        }
        .auto-style9 {
            width: 100%;
        }
        .auto-style10 {
            text-align: right;
            height: 45px;
        }
        .auto-style11 {
            text-align: left;
            height: 45px;
        }
        .auto-style12 {
            height: 45px;
        }
        .auto-style16 {
            font-size: large;
            color: #FFFFFF;
            background-color: #339933;
        }
        .auto-style17 {
            font-size: large;
            color: #FFFFFF;
            background-color: #990000;
        }
        .auto-style18 {
            font-size: large;
            color: #D7D6D4;
        }
        .auto-style19 {
            text-align: right;
        }
        .auto-style20 {
            text-align: left;
        }
        .auto-style21 {
            font-size: medium;
            color: #FFFFFF;
        }
        .auto-style24 {
            height: 65px;
        }
        .auto-style25 {
            height: 65px;
            text-align: center;
        }
        .auto-style26 {
            text-align: center;
            height: 24px;
        }
        .auto-style27 {
            color: #D7D6D4;
        }
        .auto-style28 {
            text-align: center;
            height: 24px;
            color: #FFFFFF;
        }
        .auto-style29 {
            text-align: center;
            color: #FFFFFF;
        }
        .auto-style30 {
            color: #FFE1FF;
        }
        .auto-style31 {
            font-size: large;
            color: #FFFFFF;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width:100%;">
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style1"><strong><em>Validate Timesheets</em></strong></td>
                    <td>&nbsp;</td>
                </tr>
               
                
            </table>
            <br/>
            <br/>
            <table style="width: 100%;">
                    <tr>
                        <td class="auto-style19">
                            
                            &nbsp;</td>
                        <td class="auto-style3">
                            
                            <strong>
                            
                            <asp:Label ID="Label1" runat="server" Text="Please, first load a timesheet" CssClass="auto-style18"></asp:Label>
                            </strong>
                        </td>
                        <td class="auto-style3">
                            &nbsp;</td>
                    </tr>
                   
                </table>
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style19">
                            
                            &nbsp;</td>
                    <td class="auto-style3">
                            
                            <asp:FileUpload ID="btnLoadTimesheet" runat="server" CssClass="auto-style21" Width="197px" />
                        </td>
                    <td class="auto-style20">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style3">
            <asp:Label ID="lbFileName" runat="server" Text="" CssClass="auto-style27"></asp:Label>
                        </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style24"></td>
                    <td class="auto-style25">
                            <asp:Button ID="btnValidate" runat="server" CssClass="auto-style2" Text="Validate TimeSheet" Width="220px" OnClick="btnValidate_Click" />
                    </td>
                    <td class="auto-style24"></td>
                </tr>
                
            </table>
            <hr>
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style28">
                        <strong>
                        <asp:Label ID="Label9" runat="server" Text="Year:" CssClass="auto-style31"></asp:Label>
                        <asp:Label ID="lblYear" runat="server" Text="" CssClass="auto-style31"></asp:Label>
                        </strong>
                    </td>
                    <td class="auto-style26">
                        <strong>
                        <asp:Label ID="Label10" runat="server" Text="Employee ID:" CssClass="auto-style31"></asp:Label>
                        <asp:Label ID="lblEmployeeId" runat="server" Text="" CssClass="auto-style31"></asp:Label>
                        </strong></td>
                    <td class="auto-style26">
                        <strong>
                        <asp:Label ID="Label11" runat="server" Text="Week:" CssClass="auto-style31"></asp:Label>
                        <asp:Label ID="lblWeekNumber" runat="server" Text="" CssClass="auto-style31"></asp:Label>
                        </strong>
                    </td>
                </tr>

                
            </table>

            <br>
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style29"><strong>
                        <asp:Label ID="Label2" runat="server" CssClass="auto-style21" Text="Monday"></asp:Label>
                        </strong></td>
                    <td class="auto-style3"><strong>
                        <asp:Label ID="Label3" runat="server" CssClass="auto-style21" Text="Tuesday"></asp:Label>
                        </strong></td>
                    <td class="auto-style3"><strong>
                        <asp:Label ID="Label4" runat="server" CssClass="auto-style21" Text="Wednesday"></asp:Label>
                        </strong></td>
                    <td class="auto-style3"><strong>
                        <asp:Label ID="Label5" runat="server" CssClass="auto-style21" Text="Thursday"></asp:Label>
                        </strong></td>
                    <td class="auto-style3"><strong>
                        <asp:Label ID="Label6" runat="server" CssClass="auto-style21" Text="Friday"></asp:Label>
                        </strong></td>
                    <td class="auto-style3"><strong>
                        <asp:Label ID="Label7" runat="server" CssClass="auto-style21" Text="Saturday"></asp:Label>
                        </strong></td>
                    <td class="auto-style3"><strong>
                        <asp:Label ID="Label8" runat="server" CssClass="auto-style21" Text="Sunday"></asp:Label>
                        </strong></td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="lblMonday" runat="server" Text="" CssClass="auto-style30"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:Label ID="lblTuesday" runat="server" Text="" CssClass="auto-style30"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:Label ID="lblWednesday" runat="server" Text="" CssClass="auto-style30"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:Label ID="lblThursday" runat="server" Text="" CssClass="auto-style30"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:Label ID="lblFriday" runat="server" Text="" CssClass="auto-style30"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:Label ID="lblSaturday" runat="server" Text="" CssClass="auto-style30"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:Label ID="lblSunday" runat="server" Text="" CssClass="auto-style30"></asp:Label>
                    </td>
                </tr>
                
            </table>
           
            <hr />
            <table style="width: 100%;">
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style3">
                            &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
               
            </table>
            <table class="auto-style9">
                
                <tr>
                    <td class="auto-style10">
                            <asp:Button ID="btnAccept" CssClass="auto-style16" Text="Accept TimeSheet" runat="server" OnClick="btnAccept_Click"  />
                            </td>
                    <td class="auto-style12"></td>
                    <td class="auto-style11">
                            <asp:Button ID="btnRefuse" CssClass="auto-style17" Text="Refuse TimeSheet" runat="server" OnClick="btnRefuse_Click"  />
                        </td>
                </tr>
                
            </table>
            <hr>
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style8">
                            <asp:Button ID="btnLogout" runat="server" CssClass="auto-style2" Text="Logout" Width="220px" OnClick="btnLogout_Click1" />
                        </td>
                    
                </tr>
                
            </table>
        </div>
    </form>
</body>
</html>
