<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Template.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="E_commerce.Home" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="Style/Home.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    

    <div class="container-lg w-75 m-auto">
        <div id="contentHtml" runat="server" class="row">
        </div>


    </div>
    <footer class="bg-dark text-light py-4">
    <div class="container">
        <div class="row">
            <div class="col-md-4">
                <h5>Informazioni</h5>
                <ul class="list-unstyled">
                    <li><a href="#">Chi Siamo</a></li>
                    <li><a href="#">Contatti</a></li>
                    <li><a href="#">Termini e Condizioni</a></li>
                </ul>
            </div>
            <div class="col-md-4">
                <h5>Per conoscerci meglio</h5>
                <ul class="list-unstyled">
                    <li><a href="#">Opportunitá di lavoro</a></li>
                    <li><a href="#">Sostenibilitá</a></li>
                    <li><a href="#">Supporto psicologico</a></li>
                </ul>
            </div>
            <div class="col-md-4">
                <h5>Seguici</h5>
                <ul class="list-unstyled">
                    <li><a href="#">Facebook</a></li>
                    <li><a href="#">Twitter</a></li>
                    <li><a href="#">Instagram</a></li>
                </ul>
            </div>
        </div>
        <hr class="my-4">
        <div class="text-center">
            <p>&copy; 2024 La Bottega della Povertá. Tutti i diritti riservati.</p>
        </div>
    </div>
</footer>
</asp:Content>
