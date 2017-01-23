<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToDoTaskAdd.aspx.cs" Inherits="WebForms_ToDoTasks.Views.ToDoTaskAdd" MasterPageFile="~/Site.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Add task</h2>
   <%-- <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label> <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <p> </p>
    <asp:Label ID="Label2" runat="server" Text="Description"></asp:Label> <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <p> </p>
    <asp:Label ID="Label3" runat="server" Text="Category"></asp:Label> <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
    <p> </p>
    <asp:Label ID="Label4" runat="server" Text="InProgress"></asp:Label> <asp:CheckBox ID="CheckBox1" runat="server" />--%>
    
    <asp:ValidationSummary runat="server" ShowModelStateErrors="true" />
    <asp:FormView runat="server" ID="addToDoTaskForm"
    ItemType="WebForms_ToDoTasks.Models.ToDoTask"
    InsertMethod="addToDoTaskForm_InsertItem"
    DefaultMode="Insert"
    RenderOuterTable="false" 
    OnItemInserted="addToDoTaskForm_ItemInserted">
    <InsertItemTemplate>
        <fieldset>
            <ol>
                <asp:DynamicEntity runat="server" Mode="Insert" />
            </ol>
            <asp:Button runat="server" Text="Insert" CommandName="Insert" />
            <asp:Button runat="server" Text="Cancel" CausesValidation="false" OnClick="Cancel_Click" />
        </fieldset>
    </InsertItemTemplate>
</asp:FormView>
</asp:Content>

