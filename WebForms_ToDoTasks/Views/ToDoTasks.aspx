﻿<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToDoTasks.aspx.cs" Inherits="WebForms_ToDoTasks.Views.ToDoTasks" %>--%>
<%@ Page Title="ToDoTasks" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ToDoTasks.aspx.cs" Inherits="WebForms_ToDoTasks.Views.ToDoTasks" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
     <h2>Test</h2>
        <p>
            Test
        </p>
        <asp:GridView ID="GridView1" runat="server" DataSourceID="catid" AutoGenerateColumns="False">
            <Columns>
                <%--<asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID"></asp:BoundField>--%>
                <asp:BoundField DataField="NAME" HeaderText="NAME" SortExpression="NAME"></asp:BoundField>
                <asp:BoundField DataField="DESCRIPTION" HeaderText="DESCRIPTION" SortExpression="DESCRIPTION"></asp:BoundField>
                <asp:BoundField DataField="TODODATE" HeaderText="TODODATE" SortExpression="TODODATE"></asp:BoundField>
                <asp:BoundField DataField="STATUS" HeaderText="STATUS" SortExpression="STATUS"></asp:BoundField>
                <asp:BoundField DataField="CATEGORYID" HeaderText="CATEGORYID" SortExpression="CATEGORYID"></asp:BoundField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource runat="server" ID="catid" ConnectionString='<%$ ConnectionStrings:UserKateto %>' ProviderName='<%$ ConnectionStrings:UserKateto.ProviderName %>' SelectCommand='SELECT "NAME", "DESCRIPTION", "TODODATE", "STATUS", "CATEGORYID" FROM "TASK"'></asp:SqlDataSource>
        <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:UserKateto %>' ProviderName='<%$ ConnectionStrings:UserKateto.ProviderName %>' SelectCommand='SELECT * FROM "TASK"'></asp:SqlDataSource>
        <asp:Button ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" />  
        <p>
            <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
        </p>
    </div>
</asp:Content>
