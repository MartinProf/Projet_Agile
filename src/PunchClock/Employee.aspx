<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="PunchClock.Employee" %>

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
        .auto-style3 {
            text-align: center;
            font-size: x-large;
            color: #000099;
            height: 75px;
        }
        .auto-style4 {
            height: 75px;
        }
        .auto-style5 {
            font-size: large;
            text-align: right;
            color: #000099;
        }
        .auto-style6 {
            font-size: medium;
        }
        .auto-style7 {
            text-align: center;
        }
        .auto-style8 {
            font-size: medium;
            color: #000099;
            text-align: center;
        }
        .auto-style9 {
            text-align: right;
            color: #000099;
        }
        .auto-style10 {
            text-align: right;
        }
        .auto-style11 {
            color: #000099;
        }
        .auto-style12 {
            color: #000099;
            font-size: medium;
        }
        .auto-style13 {
            text-align: center;
            color: #000099;
            font-size: large;
            height: 38px;
        }
        .auto-style14 {
            width: 100%;
            height: 131px;
        }
        .auto-style15 {
            text-align: center;
            color: #000099;
            font-size: large;
            height: 38px;
            width: 164px;
        }
        .auto-style16 {
            text-align: center;
            width: 164px;
        }
        .auto-style17 {
            font-size: medium;
            color: #000099;
            text-align: center;
            height: 34px;
        }
        .auto-style18 {
            text-align: center;
            height: 34px;
        }
        .auto-style19 {
            text-align: center;
            width: 164px;
            height: 34px;
        }
        .auto-style20 {
            text-align: center;
            height: 36px;
        }
        .auto-style21 {
            text-align: center;
            width: 164px;
            height: 36px;
        }
        .auto-style22 {
            text-align: center;
            height: 39px;
        }
        .auto-style23 {
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width:100%;">
                <tr>
                    
                    <td class="auto-style4"></td>
                    <td class="auto-style4"></td>
                    <td class="auto-style4"></td>
                    <td class="auto-style3"><strong>Employee timsheet form</strong></td>
                    <td class="auto-style4"></td>
                    <td class="auto-style4"></td>
                    <td class="auto-style4"></td>
                   
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style8">Please fill all&nbsp; areas with the required information.</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style7">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="auto-style10"><strong><span class="auto-style11">Year: </span>
                        <asp:TextBox ID="txtYear" runat="server" CssClass="auto-style6"></asp:TextBox>
                        </strong></td>
                    <td class="auto-style7"><strong><span class="auto-style11">Week number: </span>
                        <asp:DropDownList ID="dropDownListWeek" runat="server" CssClass="auto-style6"></asp:DropDownList>
                        </strong></td>
                    <td class="auto-style12"><strong>Emplopyee ID:
                        <asp:TextBox ID="txtEmpId" runat="server" CssClass="auto-style6"></asp:TextBox>
                        </strong></td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
              
            </table>
            <hr>
            <table class="auto-style14">
                <tr>
                    <td class="auto-style13"><strong>Monday</strong></td>
                    <td class="auto-style13"><strong>Tuesday</strong></td>
                    <td class="auto-style13"><strong>Wednesday</strong></td>
                    <td class="auto-style15"><strong>Thursday</strong></td>
                    <td class="auto-style13"><strong>Friday</strong></td>
                    <td class="auto-style13"><strong>Saturday</strong></td>
                    <td class="auto-style13"><strong>Sunday</strong></td>
                </tr>
                <tr>
                    <td class="auto-style7"><span class="auto-style11"><strong>Code projet</strong></span><strong><span class="auto-style11">: </span>
                        <asp:TextBox ID="txtProjetMonday" runat="server" CssClass="auto-style6" Width="60px"></asp:TextBox>
                        </strong></td>
                    <td class="auto-style7"><span class="auto-style11"><strong>Code projet</strong></span><strong><span class="auto-style11">: </span>
                        <asp:TextBox ID="txtProjetTuesday" runat="server" CssClass="auto-style6" Width="60px"></asp:TextBox>
                        </strong></td>
                    <td class="auto-style7"><span class="auto-style11"><strong>Code projet</strong></span><strong><span class="auto-style11">: </span>
                        <asp:TextBox ID="txtProjetWednesday" runat="server" CssClass="auto-style6" Width="60px"></asp:TextBox>
                        </strong></td>
                    <td class="auto-style16"><span class="auto-style11"><strong>Code projet</strong></span><strong><span class="auto-style11">: </span>
                        <asp:TextBox ID="txtProjetThursday" runat="server" CssClass="auto-style6" Width="60px"></asp:TextBox>
                        </strong></td>
                    <td class="auto-style7"><span class="auto-style11"><strong>Code projet</strong></span><strong><span class="auto-style11">: </span>
                        <asp:TextBox ID="txtProjetFriday" runat="server" CssClass="auto-style6" Width="60px"></asp:TextBox>
                        </strong></td>
                    <td class="auto-style7"><span class="auto-style11"><strong>Code projet</strong></span><strong><span class="auto-style11">: </span>
                        <asp:TextBox ID="txtProjetSaturday" runat="server" CssClass="auto-style6" Width="60px"></asp:TextBox>
                        </strong></td>
                    <td class="auto-style7"><span class="auto-style11"><strong>Code projet</strong></span><strong><span class="auto-style11">:</span><asp:TextBox ID="txtProjetSunday" runat="server" CssClass="auto-style6" Width="60px"></asp:TextBox>
                        </strong></td>
                </tr>
                <tr>
                    <td class="auto-style17"><strong>Minutes:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtMinutesMonday" runat="server" CssClass="auto-style12" Width="60px"></asp:TextBox>
                        </strong></td>
                    <td class="auto-style18"><strong><span class="auto-style11">Minutes:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
                        <asp:TextBox ID="txtMinutesTuesday" runat="server" CssClass="auto-style12" Width="60px"></asp:TextBox>
                        </strong></td>
                    <td class="auto-style18"><strong><span class="auto-style11">Minutes:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
                        <asp:TextBox ID="txtMinutesWednesday" runat="server" CssClass="auto-style12" Width="60px"></asp:TextBox>
                        </strong></td>
                    <td class="auto-style19"><strong><span class="auto-style11">Minutes:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
                        <asp:TextBox ID="txtMinutesThursday" runat="server" CssClass="auto-style12" Width="60px"></asp:TextBox>
                        </strong></td>
                    <td class="auto-style18"><strong><span class="auto-style11">Minutes:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
                        <asp:TextBox ID="txtMinutesFriday" runat="server" CssClass="auto-style12" Width="60px"></asp:TextBox>
                        </strong></td>
                    <td class="auto-style18"><strong><span class="auto-style11">Minutes:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
                        <asp:TextBox ID="txtMinutesSaturday" runat="server" CssClass="auto-style12" Width="60px"></asp:TextBox>
                        </strong></td>
                    <td class="auto-style18"><strong><span class="auto-style11">Minutes:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
                        <asp:TextBox ID="txtMinutesSunday" runat="server" CssClass="auto-style12" Width="60px"></asp:TextBox>
                        </strong></td>
                </tr>
                <tr>
                    <td class="auto-style20">
                        <strong>
                        <asp:CheckBox Text="Sick day" ID="cbSickMonday" runat="server" CssClass="auto-style12" OnCheckedChanged="cbSickMonday_CheckedChanged"  />
                        </strong>
                    </td>
                    <td class="auto-style20"><strong>
                        <asp:CheckBox Text="Sick day" ID="cbSickTuesday" runat="server" CssClass="auto-style12"  />
                        </strong></td>
                    <td class="auto-style20"><strong>
                        <asp:CheckBox Text="Sick day" ID="cbSickWednesday" runat="server" CssClass="auto-style12"  />
                        </strong></td>
                    <td class="auto-style21"><strong>
                        <asp:CheckBox Text="Sick day" ID="cbSickThursday" runat="server" CssClass="auto-style12"  />
                        </strong></td>
                    <td class="auto-style20"><strong>
                        <asp:CheckBox Text="Sick day" ID="cbSickFriday" runat="server" CssClass="auto-style12"  />
                        </strong></td>
                    <td class="auto-style20"><strong>
                        <asp:CheckBox Text="Sick day" ID="cbSickSaturday" runat="server" CssClass="auto-style12"  />
                        </strong></td>
                    <td class="auto-style20"><strong>
                        <asp:CheckBox Text="Sick day" ID="cbSickSunday" runat="server" CssClass="auto-style12"  />
                        </strong></td>
                </tr>
                <tr>
                    <td class="auto-style22">
                        <asp:Button ID="btnAddMonday" runat="server" Text="Add" Width="67px" OnClick="btnAddMonday_Click" />
                    &nbsp;
                        <asp:Button ID="btnRestartMonday" runat="server" Text="Restart" Width="67px" />
                    </td>
                    <td class="auto-style22">
                        <asp:Button ID="btnAddTuesday" runat="server" Text="Add" Width="67px" OnClick="btnAddTuesday_Click" />
                    &nbsp;
                        <asp:Button ID="btnRestartTuesday" runat="server" Text="Restart" Width="67px" />
                    </td>
                    <td class="auto-style22">
                        <asp:Button ID="btnAddWednesday" runat="server" Text="Add" Width="67px" OnClick="btnAddWednesday_Click" />
                    &nbsp;
                        <asp:Button ID="btnRestartWednesday" runat="server" Text="Restart" Width="67px" />
                    </td>
                    <td class="auto-style22">
                        <asp:Button ID="btnAddThursday" runat="server" Text="Add" Width="67px" OnClick="btnAddThursday_Click" />
                    &nbsp;
                        <asp:Button ID="btnRestartThursday" runat="server" Text="Restart" Width="67px" />
                    </td>
                    <td class="auto-style22">
                        <asp:Button ID="btnAddFriday" runat="server" Text="Add" Width="67px" OnClick="btnAddFriday_Click" />
                    &nbsp;
                        <asp:Button ID="btnRestartFriday" runat="server" Text="Restart" Width="67px" />
                    </td>
                    <td class="auto-style22">
                        <asp:Button ID="btnAddSaturday" runat="server" Text="Add" Width="67px" OnClick="btnAddSaturday_Click" />
                    &nbsp;
                        <asp:Button ID="btnRestartSaturday" runat="server" Text="Restart" Width="67px" />
                    </td>
                    <td class="auto-style22">
                        <asp:Button ID="btnAddSunday" runat="server" Text="Add" Width="67px" OnClick="btnAddSunday_Click" />
                    &nbsp;
                        <asp:Button ID="btnRestartSunday" runat="server" Text="Restart" Width="67px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:Label ID="lblResultMonday" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:Label ID="lblResultTuesday" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:Label ID="lblResultWednesday" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:Label ID="lblResultThursday" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:Label ID="lblResultFriday" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:Label ID="lblResultSaturday" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:Label ID="lblResultSunday" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
            <hr>
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style10">
                        <asp:Button ID="btnSubmit" runat="server" Height="30px" Text="Submit" Width="100px" />
                    </td>
                    <td class="auto-style7">
                        <asp:Button ID="btnReset" runat="server" Height="30px" Text="Reset" Width="100px" />
                    </td>
                    <td class="auto-style23">
                        <asp:Button ID="btnLogout" runat="server" Height="30px" Text="Logout" Width="100px" OnClick="btnLogout_Click" />
                    </td>
                </tr>
               
            </table>
        </div>
    </form>
</body>
</html>
