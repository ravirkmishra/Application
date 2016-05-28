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
            display: none;
        }

        .showdisplay {
            display: show;
        }

        .tr {
            border: solid 1px black;
        }
    </style>

    <script src="Scripts/jquery-2.2.4.min.js"></script>
    <script>
        $(document).ready(function () {
            $("#imgbtnUpArrow0").before("0th Floor");
            $("#imgbtnUpArrow1").before("1st Floor");
            $("#imgbtnUpArrow2").before("2nd Floor");
            $("#imgbtnUpArrow3").before("3rd Floor");
            $("#imgbtnDownArrow4").before("4th Floor");
        });
    </script>

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
                            <td style="border: 1px solid black">The lift is at :<asp:Label runat="server" ID="lblFloorPosition"></asp:Label>
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
            <table style="border-collapse: collapse">
                <tr class="tr">

                    <td class="auto-style1;" colspan="2" runat="server" id="td8">
                        <asp:ImageButton runat="server" ID="imgbtnDownArrow4" ImageUrl="~/Images/Down.png" OnClick="imgbtnDownArrow4_Click" />
                    </td>
                </tr>
                <tr class="tr">
                    <td class="auto-style1;" runat="server" id="td5">
                        <asp:ImageButton runat="server" ID="imgbtnUpArrow3" ImageUrl="~/Images/Up.png" OnClick="imgbtnUpArrow3_Click" />
                    </td>
                    <td class="auto-style1;" runat="server" id="td6">
                        <asp:ImageButton runat="server" ID="imgbtnDownArrow3" ImageUrl="~/Images/Down.png" OnClick="imgbtnDownArrow3_Click" />
                    </td>
                </tr>
                <tr class="tr">
                    <td class="auto-style1;" runat="server" id="td3">
                        <asp:ImageButton runat="server" ID="imgbtnUpArrow2" ImageUrl="~/Images/Up.png" OnClick="imgbtnUpArrow2_Click" />
                    </td>
                    <td class="auto-style1;" runat="server" id="td4">
                        <asp:ImageButton runat="server" ID="imgbtnDownArrow2" ImageUrl="~/Images/Down.png" OnClick="imgbtnDownArrow2_Click" />
                    </td>
                </tr>
                 <tr class="tr">
                    <td class="auto-style1;" runat="server" id="td1">
                        <asp:ImageButton runat="server" ID="imgbtnUpArrow1" ImageUrl="~/Images/Up.png" OnClick="imgbtnUpArrow1_Click" />
                    </td>
                    <td class="auto-style1;" runat="server" id="td2">
                        <asp:ImageButton runat="server" ID="imgbtnDownArrow1" ImageUrl="~/Images/Down.png" OnClick="imgbtnDownArrow1_Click" />
                    </td>
                </tr>
                <tr class="tr">
                    <td class="auto-style1;" colspan="2" runat="server" id="tdUp">
                        <asp:ImageButton runat="server" ID="imgbtnUpArrow0" ImageUrl="~/Images/Up.png" OnClick="imgbtnUpArrow0_Click" />
                    </td>
                </tr>

                <tr runat="server" id="trInsideButton">
                    <td class="auto-style1">
                        <asp:ImageButton runat="server" ID="imgbtn1stFloor" ImageUrl="~/Images/1st.png" /></td>
                    <td>
                        <asp:ImageButton runat="server" ID="imgbtn2ndFloor" ImageUrl="~/Images/2nd.png" />
                    </td>
                    <td>
                        <asp:ImageButton runat="server" ID="imgbtn3rdFloor" ImageUrl="~/Images/3rd.png" />
                    </td>
                    <td>
                        <asp:ImageButton runat="server" ID="imgbtn4thFloor" ImageUrl="~/Images/4th.png" />
                    </td>
                    <td>
                        <asp:ImageButton runat="server" ID="imgbtn5thFloor" ImageUrl="~/Images/5th.png" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
