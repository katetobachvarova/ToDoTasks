<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToDoTaskAdd.aspx.cs" Inherits="WebForms_ToDoTasks.Views.ToDoTaskAdd" MasterPageFile="~/Site.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Add task</h2>
    <asp:ValidationSummary ShowModelStateErrors="true" runat="server" />
    <asp:FormView runat="server" ID="addToDoTaskForm"
    ItemType="WebForms_ToDoTasks.Models.ToDoTask"
    InsertMethod="addToDoTaskForm_InsertItem"
    DefaultMode="Insert"
    RenderOuterTable="false" 
    OnItemInserted="addToDoTaskForm_ItemInserted">
    <InsertItemTemplate>
        <fieldset>
            <%--<ol style="padding:0">
                <asp:DynamicEntity runat="server" Mode="Insert"  />
            </ol>--%>
            <div id="oladdtask">
                <asp:DynamicEntity runat="server" Mode="Insert" />
            </div>
            <asp:Button runat="server" Text="Insert" CommandName="Insert" class="btn btn-default" />
            <asp:Button runat="server" Text="Cancel" CausesValidation="false" OnClick="Cancel_Click"  class="btn btn-default" />
        </fieldset>
    </InsertItemTemplate>
    </asp:FormView>
</asp:Content>

