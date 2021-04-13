<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OpenProblemPage.aspx.cs" Inherits="ServiceProjectDmitryKatkovFall2020.OpenProblemPage" %>

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

            <h3 class="pageTitle">Open Problems</h3>

            <form id="form1" runat="server">
                <asp:Button class="returnButton" ID="btnReturnToMainMenu" runat="server" Text="Return to Main Menu" OnClick="btnReturnToMainMenu_Click" />

                <br />
                <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" Text="(Error Message)"></asp:Label>
                <br />
                <br />

                <asp:GridView ID="dgvOpenProblems" runat="server" OnRowCommand="dgvOpenProblems_RowCommand" HeaderStyle-BackColor="PeachPuff" HeaderStyle-Font-Bold="true" BorderColor="Wheat" BorderWidth="5px" >
                    <Columns>
                        <asp:ButtonField CommandName="SELECT" Text="Select" ItemStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:ButtonField>
                    </Columns>
                </asp:GridView>

            </form>

        </main>
    </div>

</body>
</html>
