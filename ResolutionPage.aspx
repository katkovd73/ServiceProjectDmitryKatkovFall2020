<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResolutionPage.aspx.cs" Inherits="ServiceProjectDmitryKatkovFall2020.ResolutionPage" %>

<!DOCTYPE html>

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Resolution Entry</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="Content/style.css" />
    <script src="Scripts/jquery-3.0.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</head>
<body>        
    <div class="container">
      <header>
            <div class="jumbotron">
                <h1 class="mainHeaderText">Service Center</h1>
            </div>
      </header>

      <main>
          
        <h3 class="pageTitle">Resolution Entry</h3>

<form id="form1" runat="server">
        <asp:Button class="returnButton" ID="btnReturnToOpenProblems" runat="server" Text="Return To Open Problems" OnClick="btnReturnToOpenProblems_Click" />

      <br />
            <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" Text="(Error Message)"></asp:Label>
        <br />        
        <table class="myTable">
             <colgroup>
                <col style="width:25%" />
                <col style="width:30%" />
                <col style="width:45%" />
           </colgroup>
            <tbody>
               
                 <%-- Ticket --%>
                        <tr>
                            <td>
                                <asp:Label class="labelFormated" ID="lblTicketNo" runat="server" Text="Ticket No: "></asp:Label>
                            </td>
                            <td>
                               <asp:Label ID="lblTicketNoDisplayed" runat="server" Text="Ticket No Displayed"></asp:Label>
                            </td>
                            <td>
                                <%--Empty Row--%>
                            </td>
                        </tr>
                 <%-- Problem --%>
                        <tr>
                            <td>
                                <asp:Label class="labelFormated" ID="lblProblemNo" runat="server" Text="Problem No: "></asp:Label>
                            </td>
                            <td>
                               <asp:Label ID="lblProblemNoDisplayed" runat="server" Text="Problem No Displayed"></asp:Label>
                            </td>
                            <td>
                                <%--Empty Row--%>
                            </td>
                        </tr>
                 <%-- Client --%>
                        <tr>
                            <td>
                                <asp:Label class="labelFormated" ID="lblResolutionNo" runat="server" Text="Resolution No: "></asp:Label>
                            </td>
                            <td>
                               <asp:Label ID="lblResolutionNoDisplayed" runat="server" Text="Resolution No Displayed"></asp:Label>
                            </td>
                            <td>
                                <%--Empty Row--%>
                            </td>
                        </tr>
                
                 <%-- Resolution --%>
                        <tr>
                            <td>
                                <asp:Label class="labelFormated" ID="lblResolution" runat="server" Text="*Resolution: "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtResolution" runat="server" MaxLength="500" Rows="5" Height="64px" TextMode="MultiLine" Width="180px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label class="lblValidation" ID="lblValidationResolution" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                 <%-- Technician dropdown --%>
                        <tr>
                            <td>
                                <asp:Label class="labelFormated" ID="lblTechnician" runat="server" Text="*Technician: "></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlTechnician" runat="server" AutoPostBack="True" Width="180px"></asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label class="lblValidation" ID="lblValidationTechnician" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                 <%-- Hours Row--%>
                        <tr>
                            <td>
                                <asp:Label class="labelFormated" ID="lblHours" runat="server" Text="*Hours: "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtHours" runat="server" MaxLength="30"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label class="lblValidation" ID="lblValidationHours" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                 <%-- Mileage Row--%>
                        <tr>
                            <td>
                                <asp:Label class="labelFormated" ID="lblMileage" runat="server" Text="Mileage: "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMileage" runat="server" MaxLength="30"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label class="lblValidation" ID="lblValidationMileage" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                 <%-- Miles Cost Row--%>
                        <tr>
                            <td>
                                <asp:Label class="labelFormated" ID="lblMilesCost" runat="server" Text="Miles Cost: "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMilesCost" runat="server" MaxLength="30"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label class="lblValidation" ID="lblValidationMilesCost" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                 <%-- Supplies Row--%>
                        <tr>
                            <td>
                                <asp:Label class="labelFormated" ID="lblSupplies" runat="server" Text="Supplies: "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSupplies" runat="server" MaxLength="30"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label class="lblValidation" ID="lblValidationSupplies" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                 <%-- Misc Row--%>
                        <tr>
                            <td>
                                <asp:Label class="labelFormated" ID="lblMisc" runat="server" Text="Misc: "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMisc" runat="server" MaxLength="30"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label class="lblValidation" ID="lblValidationMisc" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                 <%-- Date Fixed Row--%>
                        <tr>
                            <td>
                                <asp:Label class="labelFormated" ID="lblDateFixed" runat="server" Text="Date Fixed: "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDateFixed" runat="server" MaxLength="30" TextMode="Date"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label class="lblValidation" ID="lblValidationDateFixed" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                 <%-- Date Onsite Row--%>
                        <tr>
                            <td>
                                <asp:Label class="labelFormated" ID="lblDateOnsite" runat="server" Text="Date Onsite: "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDateOnsite" runat="server" MaxLength="30" TextMode="Date"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label class="lblValidation" ID="lblValidationDateOnSite" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                 <%-- No Charge Check Box Row--%>  
                        <tr>
                            <td colspan="3">
                                <asp:CheckBox ID="chkNoCharge" runat="server" Text=" No Charge" ForeColor="DarkBlue"/>
                            </td>
                        </tr>
                 <%-- Required Information Label Row--%>  
                        <tr>
                            <td colspan="3">
                               <h5 class="lblRequiredInformation">* Indicates required information</h5>
                            </td>
                        </tr>
                </tbody>
            </table>
            <asp:Button class="smallButton" ID="btnSubmit" runat="server" Text="Submit" Width="100px" OnClick="btnSubmit_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button class="smallButton" ID="btnClear" runat="server" Text="Clear" Width="100px" CausesValidation="False" OnClick="btnClear_Click" />         

     </form>
       
    </main>
  </div>
        
 
</body>
</html>
