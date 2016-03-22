<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroPet.aspx.cs" Inherits="PetShop.CadastroPet" %>

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
        <legend id="legenda">Cadastro de Animais</legend>
        <div id="centro">
            <fieldset>
                <table>
                    <tr>
                        <td>Nome: </td>
                        <td>
                            <asp:TextBox ID="txtNome" CssClass="form-control" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>Idade: </td>
                        <td>
                            <asp:TextBox ID="txtIdade" CssClass="form-control" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>Raça: </td>
                        <td>
                            <asp:TextBox ID="txtRaca" CssClass="form-control" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>Vacinação:&nbsp;&nbsp;&nbsp;</td>
                        <td>
                            <asp:DropDownList ID="ddlVacinacao" CssClass="form-control" runat="server"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>Donos: </td>
                        <td>
                            <asp:TextBox ID="txtDonos" CssClass="form-control" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>Tipo: </td>
                        <td>
                            <asp:DropDownList ID="ddlTipo" CssClass="form-control" runat="server"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnVoltar" class="btn btn-primary" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnCadastrar" class="btn btn-primary" runat="server" Text="Cadastrar" OnClick="btnCadastrar_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblMensagem" CssClass="cadastro" runat="server" Text="" /></td>
                    </tr>
                </table>
            </fieldset>
        </div>
    </form>
</body>
</html>
