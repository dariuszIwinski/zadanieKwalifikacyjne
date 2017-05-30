<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="zadanieKwalifikacyjne.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Admin</title>
    <script src="Scripts/jquery-1.9.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/general.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row" style="margin-top: 10%;" id="rowInforForUserAdmin" runat="server">
                <div class="panel panel-success">
                    <div class="panel-body text-center h4" runat="server" id="InfoForUserAdmin">
                    </div>
                </div>
            </div>
            <div class="row" style="margin-top: 5%;">
                <div class="col-md-8 col-md-offset-2">
                    <div class="h3 text-center">Administrator</div>
                </div>
            </div>
            <hr />
            <div class="row" style="margin-top: 5%;">
                <div class="col-md-6">
                    <div class="row">
                        <div class="col-md-4 col-md-offset-8 control-label">
                            <h4>Wybierz miasto: </h4>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4 col-md-offset-8 control-label">
                            <h4>Wybierz dzień: </h4>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="row">
                        <div class="form-group">
                            <div class="input-group">
                                <asp:DropDownList CssClass="form-control col-md-6 col-md-offset-3" ID="ddlAdminCity" runat="server">
                                    <asp:ListItem Selected="True">Gdynia</asp:ListItem>
                                    <asp:ListItem>London</asp:ListItem>
                                    <asp:ListItem>Paris</asp:ListItem>
                                    <asp:ListItem>Barcelona</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">

                            <div class="input-group">
                                <asp:TextBox CssClass="form-control text-center col-md-6 col-md-offset-3" ID="txtAdminDay" runat="server" Text="2017-05-01"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
            <div class="row">
            </div>
            <div class="row" style="margin-top: 5%;">
                <div class="col-md-6 col-md-offset-3">
                    <asp:Button CssClass="btn btn-primary col-md-4 col-md-offset-4" ID="btnAdminUpdateDatabase" runat="server" Text="Aktualizuj dane" OnClick="btnAdminUpdateDatabase_Click" />
                </div>

            </div>
        </div>
    </form>
</body>
</html>
