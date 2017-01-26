﻿<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToDoTasks.aspx.cs" Inherits="WebForms_ToDoTasks.Views.ToDoTasks" %>--%>
<%@ Page Title="ToDoTasks" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ToDoTasks.aspx.cs" Inherits="WebForms_ToDoTasks.Views.ToDoTasks" %>

<%@ Register Src="~/DynamicData/FieldTemplates/DateTime_Edit.ascx" TagPrefix="uc1" TagName="DateTime_Edit" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    

    <div>
     <h2>TODOTASKS</h2>
        <p>
            <asp:Button ID="SearchByDescription" runat="server" Text="SerchByDescription" OnClick="SearchByDescription_Click" />  <asp:TextBox ID="SerchByDescriptionTextBox" runat="server"></asp:TextBox>
            <asp:Button ID="SearchByDate" runat="server" Text="SearchByDate" Onclick="SearchByDate_Click"/>  <asp:TextBox ID="SearchByDateTextBox" runat="server"></asp:TextBox>
            <asp:Label ID="lblNoResultMessage" runat="server" Text="No Results found" Visible="false"></asp:Label>
            <juice:datepicker runat="server" id="t1" targetcontrolid="SearchByDateTextBox" />
        </p>
        <p>
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"/>
        </p>
        
        <asp:ValidationSummary ShowModelStateErrors="true" runat="server" />
        <asp:HyperLink NavigateUrl="~/Views/ToDoTaskAdd" Text="Add New ToDoTask" runat="server" />
        <asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns="False"
            ItemType="WebForms_ToDoTasks.Models.ToDoTask" DataKeyNames="Id"
            UpdateMethod="GridView1_UpdateItem"
            DeleteMethod="GridView1_DeleteItem"
            SelectMethod="GridView1_GetData"
            AutoGenerateEditButton="true" AutoGenerateDeleteButton="true"
            AllowSorting="true" AllowPaging="true" PageSize="5" OnDataBound="GridView1_DataBound"
            >
            <%--<Columns>
                <%--<asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID"></asp:BoundField>
                <asp:BoundField DataField="NAME" HeaderText="NAME" SortExpression="NAME"></asp:BoundField>
                <asp:BoundField DataField="DESCRIPTION" HeaderText="DESCRIPTION" SortExpression="DESCRIPTION"></asp:BoundField>
                <asp:BoundField DataField="TODODATE" HeaderText="TODODATE" SortExpression="TODODATE"></asp:BoundField>
                <asp:BoundField DataField="STATUS" HeaderText="Completed" SortExpression="STATUS"></asp:BoundField>
                <asp:BoundField DataField="CATEGORYID" HeaderText="CATEGORYID" SortExpression="CATEGORYID"></asp:BoundField>
            </Columns>--%>
            <Columns>
            <asp:DynamicField DataField="NAME"  HeaderText="NAME"/>
            <asp:DynamicField DataField="DESCRIPTION" HeaderText="DESCRIPTION" />
            <asp:DynamicField DataField="TODODATE"  HeaderText="To Do Date"/>
            <asp:DynamicField DataField="STATUS"  HeaderText="Completed"/>
            <asp:DynamicField DataField="CATEGORYID"  HeaderText="CATEGORY"/>          
        </Columns>
        </asp:GridView>
   <%--     <asp:SqlDataSource runat="server" ID="catid" ConnectionString='<%$ ConnectionStrings:UserKateto %>' ProviderName='<%$ ConnectionStrings:UserKateto.ProviderName %>' SelectCommand='SELECT "NAME", "DESCRIPTION", "TODODATE", "STATUS", "CATEGORYID" FROM "TASK"'></asp:SqlDataSource>
        <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:UserKateto %>' ProviderName='<%$ ConnectionStrings:UserKateto.ProviderName %>' SelectCommand='SELECT * FROM "TASK"'></asp:SqlDataSource>--%>
    </div>
</asp:Content>
