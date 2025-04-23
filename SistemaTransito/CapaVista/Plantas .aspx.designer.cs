using System.Web.UI.WebControls;

using System.Web.UI;

<%@ Page Title = "Gestión de Categorías" MasterPageFile="~/MasterPage.master" Language="C#" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="TuProyecto.Categorias" %>

<asp:Content ID = "Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Gestión de Categorías</h2>

    <asp:Label ID = "lblMensaje" runat="server" ForeColor="Green"></asp:Label >

    < asp:Panel ID = "PanelForm" runat="server" CssClass="formulario">
        <asp:HiddenField ID = "hfIdCategoria" runat="server" />

        <label>Nombre:</ label >
        < asp:TextBox ID = "txtNombre" runat="server" CssClass="form-control" />
        <asp:RequiredFieldValidator ControlToValidate = "txtNombre" runat="server" ErrorMessage="* Campo requerido" ForeColor="Red" />

        <asp:Button ID = "btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary mt-2" OnClick="btnGuardar_Click" />
        <asp:Button ID = "btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary mt-2" OnClick="btnCancelar_Click" />
    </asp:Panel >

    < hr />

    < asp:GridView ID = "gvCategorias" runat="server" AutoGenerateColumns="False" DataKeyNames="IdCategoria" CssClass="table table-bordered"
        OnRowEditing="gvCategorias_RowEditing" OnRowDeleting="gvCategorias_RowDeleting">
        <Columns>
            <asp:BoundField DataField = "Nombre" HeaderText="Nombre" />
            <asp:CommandField ShowEditButton = "True" EditText="Editar" />
            <asp:CommandField ShowDeleteButton = "True" DeleteText="Eliminar" />
        </Columns>
    </asp:GridView >
</ asp:Content >
