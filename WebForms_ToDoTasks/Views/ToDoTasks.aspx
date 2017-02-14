﻿<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToDoTasks.aspx.cs" Inherits="WebForms_ToDoTasks.Views.ToDoTasks" %>--%>
<%@ Page Title="ToDoTasks" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ToDoTasks.aspx.cs" Inherits="WebForms_ToDoTasks.Views.ToDoTasks"  EnableEventValidation="false" Async="true"%>

<%@ Register Src="~/DynamicData/FieldTemplates/DateTime_Edit.ascx" TagPrefix="uc1" TagName="DateTime_Edit" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/jquery-3.1.1.min.js"></script> 
    <script type="text/javascript">
    //function getProducts() {
    //    $.getJSON("http://localhost:55404/api/tdt",
    //        function (data) {
    //            alert(data);
    //            $('#products').empty(); // Clear the table body.

    //            // Loop through the list of products.
    //            $.each(data, function (key, val) {
    //                // Add a table row for the product.
    //                var row = '<td>' + val.Name + '</td><td>' + val.Description + '</td>';
    //                $('<tr/>', { text: row })  // Append the name.
    //                    .appendTo($('#products'));
    //            });
    //        });
    //    }

    //    $(document).ready(getProducts);
</script>
<div>
    <%--<h2>Products</h2>
    <table>
    <thead>
        <tr><th>Name</th><th>Price</th></tr>
    </thead>
    <tbody id="products">
    </tbody>
    </table>
    <asp:Button ID="Button1" runat="server" Text="DeleteTest"  OnClick="TestDeleteClick" />
    <asp:Button ID="Button2" runat="server" Text="UpdateTest"  OnClick="TestUpdateClick"/>--%>
    <asp:Button ID="Button3" runat="server" Text="AddTest"  OnClick="TestCreateClick"/>
     <h2>
         <asp:Label ID="Label1" runat="server" Text="TODOTASKS"  ForeColor="#428bca"></asp:Label>
     </h2>
        <h1></h1>
        <p>
            <asp:Label ID="lblDescription" runat="server" Text="Description"  Font-Bold >  </asp:Label><asp:TextBox ID="SerchByDescriptionTextBox" runat="server"   CssClass="form-control" ></asp:TextBox>
            <asp:Label ID="lblDate" runat="server" Text="Date"  Font-Bold > </asp:Label><asp:TextBox ID="SearchByDateTextBox" runat="server"  CssClass="form-control" ></asp:TextBox>
            <asp:Label ID="lblNoResultMessage" runat="server" Text="No Results found" Visible="false"></asp:Label>
            <juice:datepicker runat="server" id="t1" targetcontrolid="SearchByDateTextBox"/>
        </p>
        <p>
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"   CssClass="btn btn-default" />
        </p>
        <asp:ValidationSummary ShowModelStateErrors="true" runat="server" />
        <h1></h1>
        <asp:HyperLink NavigateUrl="~/Views/ToDoTaskAdd" Text="Add New ToDoTask" runat="server" />
        <asp:GridView ID="gvToDoTasks" runat="server" AutoGenerateColumns="False" CssClass="table table-striped"
            ItemType="WebForms_ToDoTasks.Models.ToDoTask" DataKeyNames="Id"
            UpdateMethod="gvToDoTasks_UpdateItem"
            DeleteMethod="gvToDoTasks_DeleteItem"
            SelectMethod="gvToDoTasks_GetData"
            AutoGenerateEditButton="true" AutoGenerateDeleteButton="true" AutoGenerateSelectButton="false"
           
            OnDataBound="gvToDoTasks_DataBound"
            OnRowDataBound="gvToDoTasks_RowDataBound"
            OnRowDeleted="gvToDoTasks_RowDeleted">
            <Columns>
                <asp:DynamicField DataField="NAME" HeaderText="NAME"  />
                <asp:DynamicField DataField="DESCRIPTION" HeaderText="DESCRIPTION" />
                <asp:DynamicField DataField="TODODATE" HeaderText="To Do Date" />
                <asp:DynamicField DataField="STATUS" HeaderText="Completed" />
                <asp:DynamicField DataField="CATEGORYID" HeaderText="CATEGORY"  />
                <%--<asp:BoundField DataField="NAME" HeaderText="NAME" SortExpression="NAME"></asp:BoundField>--%>
                <%--<asp:TemplateField HeaderText="test">
                    <asp:ItemTemplate>
                        <asp:Label runat="server" Text='<%# Item.Name %>' />
                    </asp:ItemTemplate>
                    <asp:EditItemTemplate>
                        <asp:TextBox  runat="server" Text='<%# BindItem.Name %>'/>
                        </asp:EditItemTemplate>
                    </asp:TemplateField>--%>
                <%-- AllowSorting="true" AllowPaging="false" PageSize="5"--%>
            </Columns>
            <EditRowStyle BackColor="#FF9966" />
            <SelectedRowStyle BackColor="LightCyan"
                ForeColor="DarkBlue"
                Font-Bold="true" />  
        </asp:GridView>
    </div>
</asp:Content>
