<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServiceEventPage.aspx.cs" Inherits="ServiceProjectDmitryKatkovFall2020.ServiceEventPage" %>

<!DOCTYPE html>

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Service Event Entry</title>
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
          
        <h3 class="pageTitle">Service Event Entry</h3>

<form id="form1" runat="server">
        <asp:Button class="returnButton" ID="btnReturnToMainMenu" runat="server" Text="Return to Main Menu" OnClick="btnReturnToMainMenu_Click" />

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
                <%-- Event Date Row--%>
                        <tr>
                            <td>
                                <asp:Label class="labelFormated" ID="lblEventDate" runat="server" Text="Event Date: "></asp:Label>
                            </td>
                            <td>
                               <asp:Label ID="lblEventDateDisplayed" runat="server" Text="Event Date Displayed"></asp:Label>
                            </td>
                            <td>
                                <%--Empty Row--%>
                            </td>
                        </tr>
                <%-- Clients Row--%>
                        <tr>
                            <td>
                                <asp:Label class="labelFormated" ID="lblClient" runat="server" Text="Client: "></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlClient" runat="server" AutoPostBack="True" Width="180px"></asp:DropDownList>
                            </td>
                            <td>
                                <%--Empty Row--%>
                                <asp:Label class="lblValidation" ID="lblValidationClient" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                <%-- Contact Row--%>
                        <tr>
                            <td>
                                <asp:Label class="labelFormated" ID="lblContact" runat="server" Text="*Contact: "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtContact" runat="server" MaxLength="30"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label class="lblValidation" ID="lblValidationContact" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                <%-- Phone Row--%>
                        <tr>
                            <td>
                                <asp:Label class="labelFormated" ID="lblPhone" runat="server" Text="*Phone: "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPhone" runat="server" CausesValidation="True" MaxLength="10"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label class="lblValidation" ID="lblValidationPhone" runat="server" ForeColor="Red"></asp:Label>
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
            <asp:Button class="smallButton" ID="btnNext" runat="server" Text="Next" Width="100px" OnClick="btnNext_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button class="smallButton" ID="btnClear" runat="server" Text="Clear" Width="100px" OnClick="btnClear_Click" />         

     </form>
       
    </main>
  </div>
        
 
</body>
</html>
