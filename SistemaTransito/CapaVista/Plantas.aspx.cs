using System.Web.UI.WebControls;

using System.Web.UI;

<%@ Page Title = "Reporte de Plantas por Categoría" MasterPageFile="~/MasterPage.master" Language="C#" AutoEventWireup="true" CodeBehind="Reporte.aspx.cs" Inherits="TuProyecto.Reporte" %>

<asp:Content ID = "Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Reporte: Cantidad de Plantas por Categoría</h2>

    <asp:GridView ID = "gvReporte" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered">
        <Columns>
            <asp:BoundField DataField = "Categoria" HeaderText="Categoría" />
            <asp:BoundField DataField = "Cantidad" HeaderText="Cantidad de Plantas" />
        </Columns>
    </asp:GridView >
</ asp:Content >
