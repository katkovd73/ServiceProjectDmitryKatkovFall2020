<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainMenuPage.aspx.cs" Inherits="ServiceProjectDmitryKatkovFall2020.MainMenuPage" %>

<!DOCTYPE html>

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Service Center - Main Menu</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="Content/style.css" />
    <script src="Scripts/jquery-3.0.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        
    <div class="container">
      <header>
            <div class="jumbotron jumbotron-fluid">
                <h1 class="mainHeaderText">Service Center</h1>
            </div>
      </header>

      <main>
          
        <h3 class="pageTitle">Main Menu</h3>            

        <div>
                <asp:Button class="menuButton" ToolTip="Press to go to Service page" ID="btnService" runat="server" Text="Service" OnClick="btnService_Click"/>
                <br />
                <br />   
                <asp:Button class="menuButton" ID="btnProblem" runat="server" Text="Problem" OnClick="btnProblem_Click" ToolTip="Press to go to PROBLEM page" />
                <br />
                <br />
                <asp:Button class="menuButton" ID="btnReports" runat="server" Text="Reports" OnClick="btnReports_Click" ToolTip="Press to go to REPORTS page" />
                <br />
                <br />
                <asp:Button class="menuButton" ID="btnTechnicians" runat="server" Text="Technicians" OnClick="btnTechnicians_Click" ToolTip="Press to go to Technicians page"/>
          </div>
       
      </main>
    </div>
        
    </form>
</body>
</html>
