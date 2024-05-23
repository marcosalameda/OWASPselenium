<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ReportViewerWebForm.aspx.cs" Inherits="GenioMVC.ReportViewerWebForm" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<head runat="server">
    <title></title>
</head>
<body style="margin: 0px; padding: 0px;">
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="0">
                <Scripts>
                    <%--<asp:ScriptReference Assembly="GenioMVC" Name="GenioMVC.Scripts.PostMessage.js" />--%>
                </Scripts>
            </asp:ScriptManager>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server"></rsweb:ReportViewer>
        </div>
    </form>
</body>
<script>
    Sys.Application.add_load(function () {
        $find("ReportViewer1").add_propertyChanged(viewerPropertyChanged);
    });

    function viewerPropertyChanged(sender, e) {
        if (e.get_propertyName() === "isLoading") {
            top.postMessage("", '*'); //Trigger resize.
        }
    }

//TODO: Get control ID dynamically.
</script>
</html>
