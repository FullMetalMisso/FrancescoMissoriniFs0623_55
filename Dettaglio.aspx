<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Template.Master" AutoEventWireup="true" CodeBehind="Dettaglio.aspx.cs" Inherits="E_commerce.Dettaglio" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            background-image: url('https://64.media.tumblr.com/55b3a4f1a1e17522d99acfc390884265/fa6b956b8965caed-24/s2048x3072/50803ae70bbbb5759638494524735eddd7083728.gifv');
            background-size: contain;
            background-size: 1920px 1080px;
            background-repeat: no-repeat;
            color: white;
        }
       div > img {
           
            border: 5px solid black; /* Aggiunge un bordo nero intorno all'immagine */
          
        
        }
    </style>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-lg m-4">
        <h2 id="ttlProduct" runat="server"></h2>
        <img id="img" alt="" class="w-50" runat="server" />
        <p id="txtDescription" runat="server"></p>
        <p id="txtPrice" runat="server"></p>
        <asp:Button id="btnAddCart" runat="server" Text="Aggiungi al carrello" CssClass="btn btn-primary" OnClick="btnAddCart_Click" />
    </div>
</asp:Content>