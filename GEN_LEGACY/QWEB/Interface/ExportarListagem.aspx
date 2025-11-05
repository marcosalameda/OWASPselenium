<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ExportarListagem.aspx.cs" Inherits="ExportList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        #form1
        {
            width: 700px;
        }
    </style>
</head>
<body bgcolor="White">
<%--    <form id="form1" runat="server">
--%>    <div style="width: 700px; margin-right: 0px">
<%--        <asp:Label ID="titulo" runat="server" Text="Label"></asp:Label>
    </div>--%>
   <asp:Table  ID="tabela" runat="server" BorderColor="#666666"
        BackColor="White" BorderWidth="1px" GridLines="Both" BorderStyle="Ridge">        
    </asp:Table>
    </div>
<%--    <p>
        <asp:Button ID="botaoExportar" runat="server" onclick="Button1_Click" 
            Text="Exportar (.xls)" Width="90px" />
    </p>--%>
<%--    </form>
--%>  
</body>
</html>
