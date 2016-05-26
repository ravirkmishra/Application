<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ElevatorFloorMgmt.aspx.cs" Inherits="ElevatorApplication.ElevatorFloorMgmt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Elevator Control Screen</title>
    <style type="text/css">
        .auto-style1 {
            width: 85px;
        }

        .hidedisplay {
            display:none;
        }
        .showdisplay {
            display:show;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="MainScriptManager" runat="server"></asp:ScriptManager>
        <asp:UpdateProgress ID="updProgress"
            AssociatedUpdatePanelID="upnlPostionTime"
            runat="server">
            <ProgressTemplate>
                <img alt="progress" src="images/ProgressBar.png" />
                Processing...           
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="upnlPostionTime" runat="server">
            <ContentTemplate>
                <div>
                    <table style="border: 1px solid black">
                        <tr>
                            <td style="border: 1px solid black">The lift is at :<asp:Label runat="server" ID="lblFloorPosition" Text="1st Floor"></asp:Label>
                            </td>
                            <td style="border: 1px solid black">You will reach your destination in:
                        <asp:Label runat="server" ID="lblTimeTaken" Text="5 Seconds"></asp:Label></td>
                            <td>
                                <asp:Button ID="btnInvoke" runat="server" Text="Click" OnClick="btnInvoke_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <br />
        <br />
        <div>
            <table>
                <tr>
                    <td class="auto-style1" runat="server" id="tdUp">
                        <asp:ImageButton runat="server" ID="imgbtnUpArrow" ImageUrl="~/Images/Up.png" OnClick="imgbtnUpArrow_Click" />
                    </td>
                    <td class="auto-style1" runat="server" id="tdDown">
                        <asp:ImageButton runat="server" ID="imgbtnDownArrow" ImageUrl="~/Images/Down.png" />
                    </td>
                </tr>
                <tr runat="server" id="trInsideButton">
                    <td class="auto-style1">
                        <asp:ImageButton runat="server" ID="imgbtn1stFloor" ImageUrl="~/Images/1st.png" OnClick="imgbtn1stFloor_Click" /></td>
                    <td>
                        <asp:ImageButton runat="server" ID="imgbtn2ndFloor" ImageUrl="~/Images/2nd.png" OnClick="imgbtn2ndFloor_Click" />
                    </td>
                    <td>
                        <asp:ImageButton runat="server" ID="imgbtn3rdFloor" ImageUrl="~/Images/3rd.png" OnClick="imgbtn3rdFloor_Click" />
                    </td>
                    <td>
                        <asp:ImageButton runat="server" ID="imgbtn4thFloor" ImageUrl="~/Images/4th.png" OnClick="imgbtn4thFloor_Click" />
                    </td>
                    <td>
                        <asp:ImageButton runat="server" ID="imgbtn5thFloor" ImageUrl="~/Images/5th.png" OnClick="imgbtn5thFloor_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
