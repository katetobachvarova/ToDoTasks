<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToDoTaskAdd.aspx.cs" Inherits="WebForms_ToDoTasks.Views.ToDoTaskAdd" MasterPageFile="~/Site.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Add task</h2>
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

