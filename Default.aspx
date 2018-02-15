<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PagingSortingGridView.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"  OnDataBound="GridView1_DataBound" OnPageIndexChanging="GridView1_PageIndexChanging" OnSorting="GridView1_Sorting" Height="292px" Width="600px"></asp:GridView>
    </div> 
    </form>
</body>
</html>
