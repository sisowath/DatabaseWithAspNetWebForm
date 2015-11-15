<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication1.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenu" runat="server">

    <asp:Label ID="lblMessage" runat="server">
    
    </asp:Label>
    <table border="1px solid black">
        <tr>
            <td>Désignation du produit : </td>
            <td><asp:TextBox ID="txtDesignation" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Prix unitaire : </td>
            <td><asp:TextBox ID="txtPrixUnitaire" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Quantité en stock : </td>
            <td><asp:TextBox ID="txtQuantiteEnStock" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2"><asp:Button ID="btnAjouter" text="Ajouter" runat="server" Width="100%" 
                    onclick="btnAjouter_Click"></asp:Button></td>            
        </tr>
    </table>

</asp:Content>
