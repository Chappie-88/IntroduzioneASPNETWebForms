<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Import.aspx.cs" Inherits="Introduzione.Import" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Import</title>
    <link href="wwwroot/bootstrap-4.4.1-dist/css/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <asp:Label ID="LBLWelcome" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-4">
                    Nome:
                    <asp:TextBox ID="TXTNome" runat="server" class="form-control"></asp:TextBox>
                </div>
                <div class="col-4">
                    Cognome:
                   <asp:TextBox ID="TXTCognome" runat="server" class="form-control"></asp:TextBox>
                </div>
                <div class="col-4">
                    Età:
                     <asp:TextBox ID="TXTEta" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-2"></div>
                <div class="col-4">
                    Username:
                   <asp:TextBox ID="TXTUsername" runat="server" class="form-control"></asp:TextBox>
                </div>
                <div class="col-4">
                    Password:
                     <asp:TextBox ID="TXTPassword" runat="server" TextMode="Password" class="form-control"></asp:TextBox>
                </div>
                <div class="col-2"></div>
            </div>
        <div class="row">
            <div class="col-12 text-center">
                <asp:Button ID="BTNSubmit" runat="server" Text="Submit" OnClick="BTNSubmit_Click" class="btn btn-sm btn-success" />
            </div>
        </div>
        <div class="row">
            <div class="col-12">
                <!--<asp:GridView ID="GRDPerson" runat="server"></asp:GridView>-->
                <asp:Table ID="TBLPerson" runat="server"></asp:Table>
            </div>
        </div>
        </div>
    </form>
</body>
</html>
