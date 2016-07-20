<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm_Main.aspx.cs" Inherits="TimeSheet_git.WebForm_Main" Async="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register TagPrefix="MyElem" TagName="Cell" Src="~/WebUserControl1.ascx"%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="Scripts/jquery-1.10.2.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="h2">Табель учёта рабочего времени</div>
    <div>
        Отчётный период
        <asp:TextBox ID="TextBox1" runat="server" CssClass="input-sm"></asp:TextBox> - <asp:TextBox ID="TextBox2" runat="server" CssClass="input-sm"></asp:TextBox>
        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBox1" Format="dd.MM.yyyy" />
        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TextBox2" Format="dd.MM.yyyy" />
        <asp:Button ID="Button1" runat="server" CssClass="btn-info" Text="Button" OnClick="Button1_Click" />
    </div>
        <br />
        <asp:Panel ID="DropPanel" runat="server" CssClass="ContextMenuPanel" Style="display: none; visibility: hidden;">
            <asp:LinkButton runat="server" ID="Option1" Text="Mocha Blast" CssClass="ContextMenuItem"/>
            <asp:LinkButton runat="server" ID="Option2" Text="Java Cyclone" CssClass="ContextMenuItem"/>
            <asp:LinkButton runat="server" ID="Option3" Text="Dry Fruit" CssClass="ContextMenuItem"/>
        </asp:Panel>
    </form>
</body>
</html>
