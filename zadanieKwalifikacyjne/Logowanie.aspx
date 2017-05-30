<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logowanie.aspx.cs" Inherits="zadanieKwalifikacyjne.Logowanie" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Logowanie</title>
    <script src="Scripts/jquery-1.9.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row" style="margin-top: 15%;">
                <div class="col-md-8 col-md-offset-2">
                    <div class="h3 text-center">Wybierz użytkownika</div>
                </div>
            </div>
            <div class="row" style="padding: 5%;">
                <div class="col-md-6 col-md-offset-3">
                    <asp:Button CssClass="btn btn-primary col-md-5" ID="btnLoginAdmin" runat="server" Text="Administrator" OnClick="btnLoginAdmin_Click" />
                    <asp:Button CssClass="btn btn-primary col-md-5 col-md-offset-2" ID="btnLoginUser" runat="server" Text="Użytkownik" OnClick="btnLoginUser_Click" />
                </div>

            </div>
        </div>
    </form>
</body>
</html>
