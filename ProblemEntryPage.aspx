<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProblemEntryPage.aspx.cs" Inherits="ServiceProjectDmitryKatkovFall2020.ProblemEntryPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Problem Entry</title>
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
          
        <h3 class="pageTitle">Problem Entry</h3>

<form id="form1" runat="server">
        <asp:Button class="returnButton" ID="btnReturnToService" runat="server" Text="Return to Service" OnClick="btnReturnToService_Click" CausesValidation="False" />

        <br />
            <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" Text="(Error Message)"></asp:Label>
        <br />        
        <table class="myTable">
             <colgroup>
                <col style="width:20%" />
                <col style="width:35%" />
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
                                <asp:Label class="labelFormated" ID="lblClient" runat="server" Text="Client: "></asp:Label>
                            </td>
                            <td>
                               <asp:Label ID="lblClientDisplayed" runat="server" Text="Client Displayed"></asp:Label>
                            </td>
                            <td>
                                <%--Empty Row--%>
                            </td>
                        </tr>
                 <%-- Product dropdown --%>
                        <tr>
                            <td>
                                <asp:Label class="labelFormated" ID="lblProduct" runat="server" Text="*Product: "></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlProduct" runat="server" AutoPostBack="True" Width="180px"></asp:DropDownList>
                            </td>
                            <td>
                                <%--Empty Row--%>
                                <asp:Label class="lblValidation" ID="lblValidationProduct" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                 <%-- Problem Description--%>
                        <tr>
                            <td>
                                <asp:Label class="labelFormated" ID="lblProblem" runat="server" Text="*Problem: "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtProblem" runat="server" MaxLength="500" Rows="5" Height="64px" TextMode="MultiLine" Width="180px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label class="lblValidation" ID="lblValidationProblemDescription" runat="server" ForeColor="Red"></asp:Label>
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
            <asp:Button class="smallButton" ID="btnClear" runat="server" Text="Clear" Width="100px" OnClick="btnClear_Click" CausesValidation="False" />         

     </form>
       
    </main>
  </div>
        
 
</body>
</html>
