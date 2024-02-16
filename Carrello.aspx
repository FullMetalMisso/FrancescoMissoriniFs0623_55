<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Template.Master" AutoEventWireup="true" CodeBehind="Carrello.aspx.cs" Inherits="E_commerce.Carrello" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            background-image: url('https://64.media.tumblr.com/55b3a4f1a1e17522d99acfc390884265/fa6b956b8965caed-24/s2048x3072/50803ae70bbbb5759638494524735eddd7083728.gifv');
            background-size: contain;
            background-size: 1920px 1080px;
            background-repeat: no-repeat;
            color: white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="contentTot" runat="server" class="my-3 mx-4"></div>
    <ul id="htmlContent" runat="server" class="m-5 w-50">
        <asp:Repeater ID="rptCartItems" runat="server" OnItemCommand="rptCartItems_ItemCommand">
            <ItemTemplate>
                <li class="d-flex justify-content-between" >
                    <p><%# Eval("Nome") %></p>
                    <div class="d-flex mb-2 align-items-baseline">
                        <p class="d-flex me-1"><%# Eval("Prezzo") %>€</p>
                        <asp:Button runat="server" CommandName="Delete" CommandArgument='<%# Eval("ID") %>'
                            CssClass="btn btn-danger w-75" Text="🗑" OnClientClick="return confirm('Sei sicuro di voler eliminare questo elemento?');" />
                    </div>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>


    <asp:Button runat="server" ID="btnClearSession" CssClass="btn btn-danger" Text="Svuota Carrello" OnClick="btnClearSession_Click" />
</asp:Content>
