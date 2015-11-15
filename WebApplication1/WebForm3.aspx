<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="WebApplication1.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenu" runat="server">

    <asp:Label ID="lblMessage" runat="server">
    
    </asp:Label>
    <asp:HiddenField ID="HdnIndice" runat="server" />
    <br />
<asp:Button ID="btnFirst" runat="server" onclick="btnFirst_Click" 
    Text="&lt;&lt;" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button ID="btnPrevious" runat="server" onclick="btnPrevious_Click" 
    Text="&lt;" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button ID="btnNext" runat="server" onclick="btnNext_Click" Text="&gt;" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button ID="btnLast" runat="server" onclick="btnLast_Click" 
    Text="&gt;&gt;" />
&nbsp;
        <table border="1px solid black">
        <tr>
            <td>Numéro : </td>
            <td><asp:Label ID="lblNumero" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td>Désignation du produit : </td>
            <td><asp:TextBox ID="txtDesignation" runat="server" 
                    ontextchanged="txtDesignation_TextChanged"></asp:TextBox></td>            
        </tr>
        <tr>
            <td>Prix unitaire : </td>
            <td><asp:TextBox ID="txtPrixUnitaire" runat="server" 
                    ontextchanged="txtPrixUnitaire_TextChanged"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Quantité en stock : </td>
            <td><asp:TextBox ID="txtQuantiteEnStock" runat="server" 
                    ontextchanged="txtQuantiteEnStock_TextChanged"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2"><asp:Button ID="btnUpdate" text="Update" runat="server" Width="100%" 
                    onclick="btnUpdate_Click"></asp:Button></td>            
        </tr>        
    </table>
</asp:Content>
