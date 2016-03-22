<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListagemPet.aspx.cs" Inherits="PetShop.ListagemPet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PetShop</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="Content/font-awesome.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.9.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/edita.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="well">
            <div class="container">
                <h1>
                    <img src="logo.png" id="imagem" />&nbsp;Gerenciador de Pets
                </h1>
            </div>
        </div>
        <div class="panel panel-default">
            <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                <HeaderTemplate>
                    <table class="table">
                        <thead>
                            <tr>
                                <th>Id</th>
                                <th>Nome</th>
                                <th>Idade</th>
                                <th>Raça</th>
                                <th>Tipo</th>
                                <th>Donos</th>
                                <th>Vacinação</th>
                                <th colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Opções</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="maior">
                        <td>
                            <asp:Label ID="lblId" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblNome" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblIdade" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblRaca" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblTipo" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblDonos" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblVacinacao" runat="server"></asp:Label></td>
                        <td>
                            <asp:HyperLink ID="lnkEditar" runat="server"><i class="fa fa-edit"></i>&nbsp;Editar</asp:HyperLink></td>
                        <td>
                            <asp:HyperLink ID="lnkExcluir" runat="server"><i class="fa fa-edit"></i>&nbsp;Excluir</asp:HyperLink></td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr class="maior" style="background-color: #f2f2f2">
                        <td>
                            <asp:Label ID="lblId" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblNome" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblIdade" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblRaca" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblTipo" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblDonos" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblVacinacao" runat="server"></asp:Label></td>
                        <td>
                            <asp:HyperLink ID="lnkEditar" runat="server"><i class="fa fa-edit"></i>&nbsp;Editar</asp:HyperLink></td>
                        <td>
                            <asp:HyperLink ID="lnkExcluir" runat="server"><i class="fa fa-edit"></i>&nbsp;Excluir</asp:HyperLink></td>
                    </tr>
                </AlternatingItemTemplate>
                <FooterTemplate>
                    </tbody>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <asp:Label ID="lblMensagem" CssClass="listagem" Text="" runat="server"></asp:Label>
        </div>
        <div style="margin-left: 10px; margin-bottom: 10px">
            <a class="btn btn-lg btn-success" href="\CadastroPet.aspx">
                <i class="glyphicon glyphicon-plus"></i>&nbsp;Cadastrar</a>
        </div>
    </form>
</body>
</html>
