<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TechnicianPage.aspx.cs" Inherits="ServiceProjectDmitryKatkovFall2020.TechnicianPage" %>

<!DOCTYPE html>

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Service Event Entry</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="Content/style.css" />
    <script src="Scripts/jquery-3.0.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>    
    </style>
</head>
<body>
    <div class="container">
        <header>
            <div class="jumbotron">
                <h1 class="mainHeaderText">Service Center</h1>
            </div>
        </header>
        <main>
            <h3 class="pageTitle">Technician Maintanance</h3>

            <form id="form1" runat="server">
                <asp:Button class="returnButton" ID="btnReturnToMainMenu" runat="server" Text="Return to Main Menu" OnClick="btnReturnToMainMenu_Click" CausesValidation="False" />
                     
                <br />
                <asp:Label ID="lblErrorMessage" runat="server" class="lblErrorMessage" Text="(Error Message)" ></asp:Label>
                <br />

                <div>
                   
                    <table class="myTable">
                         <colgroup>
                            <col style="width:25%" />
                             <col style="width:40%" />
                             <col style="width:45%" />
                  </colgroup>
                  <tbody>
                        <%-- Technician Row--%>
                        <tr>
                            <td>
                                <asp:Label class="labelFormated" ID="lblTechnician" runat="server" Text="Technician: "></asp:Label>
                            </td>
                            <td>
                                 <asp:DropDownList ID="ddlTechnician" runat="server" AutoPostBack="True" Width="180px" OnSelectedIndexChanged="ddlTechnician_SelectedIndexChanged"></asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button class="technicianButton" ID="btnNewTechnician" runat="server" CausesValidation="False" OnClick="btnNewTechnician_Click" Text="New Technician" />
                            </td>
                        </tr>

                        <%-- First Name Row--%>
                        <tr>
                            <td>
                               <asp:Label class="labelFormated" ID="lblFirstName" runat="server" Text="*First Name: "></asp:Label>
                            </td>
                            <td>
                               <asp:TextBox ID="txtFirstName" runat="server" MaxLength="15" CausesValidation="True"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label class="lblValidation" ID="lblValidationFirstName" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <%-- Middle Initial Row--%>
                        <tr>
                            <td>
                                <asp:Label class="labelFormated" ID="lblMiddleInitial" runat="server" Text="Middle Initial: "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMiddleInitial" runat="server" MaxLength="1"></asp:TextBox>
                            </td>
                            <td>
                                 <%--Empty Cell--%>
                            </td>
                        </tr>
                        <%-- Last Name Row--%>
                        <tr>
                            <td class="auto-style1">
                                <asp:Label class="labelFormated" ID="lblLastName" runat="server" Text="*Last Name: "></asp:Label>                  
                            </td>
                            <td class="auto-style1">
                               <asp:TextBox ID="txtLastName" runat="server" MaxLength="25"></asp:TextBox>
                            </td>
                             <td class="auto-style1">
                                <asp:Label class="lblValidation" ID="lblValidationLastName" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <%--Email  Row--%>
                        <tr>
                            <td>
                                 <asp:Label class="labelFormated" ID="lblEmail" runat="server" Text="Email: "></asp:Label>
                            </td>
                            <td>
                                 <asp:TextBox ID="txtEmail" runat="server" MaxLength="50"></asp:TextBox>
                            </td>
                             <td>
                                 <%--Empty cell--%>
                            </td>
                        </tr>
                        <%--Department  Row--%>
                        <tr>
                            <td>
                                <asp:Label class="labelFormated" ID="lblDepartment" runat="server" Text="Department: "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDepartment" runat="server" MaxLength="15"></asp:TextBox>
                            </td>
                             <td>
                                 <%--Empty cell--%>
                            </td>
                        </tr>
                        <%--Phone Row--%>
                        <tr>
                            <td>
                                 <asp:Label class="labelFormated" ID="lblPhone" runat="server" Text="*Phone: "></asp:Label>
                            </td>
                            <td>
                                 <asp:TextBox ID="txtPhone" runat="server" MaxLength="10"></asp:TextBox>
                            </td>
                             <td>
                                <asp:Label class="lblValidation" ID="lblValidationPhone" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <%-- Hourly Hour Rate Row--%>                         
                        <tr>
                            <td>
                                <asp:Label class="labelFormated" ID="lblHourlyRate" runat="server" Text="*Hourly Rate: "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtHourlyRate" runat="server" MaxLength="10"></asp:TextBox>
                            </td>
                             <td>
                                <asp:Label class="lblValidation" ID="lblValidationHourlyRate" runat="server" ForeColor="Red"></asp:Label>
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
                    
                    <div class="container">
                        <div class="row">
                            <div class="col-6 col-sm-6 col-md-3">
                                <div class="smallButtonDiv">
                                    <asp:Button CssClass="smallButton" ID="btnSave" runat="server" Text="Save" Width="100px" OnClick="btnSave_Click" /></div>
                            </div>
                            <div class="col-6 col-sm-6 col-md-3">
                                <div class="smallButtonDiv">
                                    <asp:Button CssClass="smallButton" ID="btnCancel" runat="server" Text="Cancel" Width="100px" OnClick="btnCancel_Click" CausesValidation="False" /></div>
                            </div>
                            <div class="col-6 col-sm-6 col-md-3">
                                <div class="smallButtonDiv">
                                    <asp:Button CssClass="smallButton" ID="btnDelete" runat="server" Text="Delete" Width="100px" OnClick="btnDelete_Click" /></div>
                            </div>
                            <div class="col-6 col-sm-6 col-md-3">
                                <div class="smallButtonDiv">
                                    <asp:Button CssClass="smallButton" ID="btnClear" runat="server" Text="Clear" Width="100px" OnClick="btnClear_Click" CausesValidation="False" /></div>
                            </div>
                        </div>
                    </div>
                </div>
            </form>
        </main>
    </div>
</body>
</html>
