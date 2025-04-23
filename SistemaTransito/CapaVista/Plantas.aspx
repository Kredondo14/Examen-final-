<%@ Page Title="Gestión de Plantas" MasterPageFile="~/MasterPage.master" Language="C#" AutoEventWireup="true" CodeBehind="Plantas.aspx.cs" Inherits="TuProyecto.Plantas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Gestión de Plantas</h2>

    <asp:Label ID="lblMensaje" runat="server" ForeColor="Green"></asp:Label>

    <asp:Panel ID="PanelForm" runat="server" CssClass="formulario">
        <asp:HiddenField ID="hfIdPlanta" runat="server" />
        
        <label>Nombre:</label>
        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
        <asp:RequiredFieldValidator ControlToValidate="txtNombre" runat="server" ErrorMessage="* Campo requerido" ForeColor="Red" />

        <label>Descripción:</label>
        <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" CssClass="form-control" Rows="3" />

        <label>Categoría:</label>
        <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-control" />
        <asp:RequiredFieldValidator ControlToValidate="ddlCategoria" InitialValue="-1" runat="server" ErrorMessage="* Selecciona una categoría" ForeColor="Red" />

        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary mt-2" OnClick="btnGuardar_Click" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary mt-2" OnClick="btnCancelar_Click" />
    </asp:Panel>

    <hr />

    <asp:GridView ID="gvPlantas" runat="server" AutoGenerateColumns="False" DataKeyNames="IdPlanta" CssClass="table table-bordered"
        OnRowEditing="gvPlantas_RowEditing" OnRowDeleting="gvPlantas_RowDeleting">
        <Columns>
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
            <asp:BoundField DataField="Categoria" HeaderText="Categoría" />
            <asp:CommandField ShowEditButton="True" EditText="Editar" />
            <asp:CommandField ShowDeleteButton="True" DeleteText="Eliminar" />
        </Columns>
    </asp:GridView>
</asp:Content>

