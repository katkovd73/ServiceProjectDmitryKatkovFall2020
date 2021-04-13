<%@ Page Title="" Language="C#" MasterPageFile="~/ReportsPage.Master" AutoEventWireup="true" CodeBehind="ReportsMenu.aspx.cs" Inherits="ServiceProjectDmitryKatkovFall2020.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/styleReports.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">           
        <div>
                <asp:Button class="menuButton" ID="btnProblemsbyInstitution" runat="server" Text="Problems by Institution" OnClick="btnProblems_Click" ToolTip="Problems by Institution" TabIndex="0"/>
                <br />
                <br />   
                <asp:Button class="menuButton" ID="btnProblemsbyClients" runat="server" Text="Problems by Clients" ToolTip="Problems by Clients" TabIndex="1" OnClick="btnProblems_Click" />
                <br />
                <br />
                <asp:Button class="menuButton" ID="btnProblemsbyProduct" runat="server" Text="Problems by Product" ToolTip="Problems by Product" TabIndex="2" OnClick="btnProblems_Click" />
                <br />
                <br />
                <asp:Button class="menuButton" ID="btnProblemsbyTechnicians" runat="server" Text="Problems by Technician" ToolTip="Problems by Technicians" TabIndex="3" OnClick="btnProblems_Click"/>
                <br />
                <br />
                <br />
                <asp:Button class="returnButton" ID="btnReturnToService" runat="server" Text="Back to Main Menu" CausesValidation="False" OnClick="btnReturnToService_Click" />
                <br />

          </div>
</asp:Content>
