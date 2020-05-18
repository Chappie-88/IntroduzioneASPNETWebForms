<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Introduzione.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="wwwroot/bootstrap-4.4.1-dist/css/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container" style="text-align: center; margin-top: 10%;">
            <div class="row">
                <div class="col-12">
                    <table style="margin: auto;">
                        <tr>
                            <td>Username:</td>
                            <td colspan="2">
                                <asp:TextBox ID="TXTUserName" runat="server" class="form-control"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Password:</td>
                            <td colspan="2">
                                <asp:TextBox ID="TXTPassword" runat="server" TextMode="Password" class="form-control"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:Button ID="BTNLogin" runat="server" Text="Login" OnClick="BTNLogin_Click" class="btn btn-sm btn-success"></asp:Button>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="row">
                <div class="col-12">
                    <asp:Label ID="LBLOutput" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
