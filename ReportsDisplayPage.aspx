<%@ Page Title="" Language="C#" MasterPageFile="~/ReportsPage.Master" AutoEventWireup="true" CodeBehind="ReportsDisplayPage.aspx.cs" Inherits="ServiceProjectDmitryKatkovFall2020.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/styleReports.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
    <asp:Label CssClass="reportName" ID="lblReportName" runat="server" Text="Report's Name"></asp:Label>
    <br />
    <asp:GridView ID="gvReport" runat="server" HeaderStyle-BackColor="PeachPuff" HeaderStyle-Font-Bold="true" BorderColor="Wheat" BorderWidth="5px" OnRowDataBound="gvReport_RowDataBound"></asp:GridView>
    <br />
    <br />
    <asp:Label ID="lblError" runat="server" ForeColor="Red" Text=""></asp:Label>
    <br />
    <asp:Button class="returnButton" ID="btnReturnToService" runat="server" Text="Back to Reports Menu" OnClick="btnReturnToService_Click" CausesValidation="False" />
    <br />
</asp:Content>
