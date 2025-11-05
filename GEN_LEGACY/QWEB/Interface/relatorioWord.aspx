<%@ Page Language="C#" AutoEventWireup="true" Codebehind="relatorioWord.aspx.cs" Inherits="CSGenio.relatorioWord" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
	<meta http-equiv="Pragma" content="no-cache"/>
    <meta http-equiv="Expires" content="-1"/>
</head>
<body style="background-color:white">
    <form id="form1" runat="server">
    <div>
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
            AutoDataBind="true" BorderColor="Gray" BorderStyle="Double" 
            GroupTreeStyle-BackColor="#F2F2F2" GroupTreeStyle-BorderStyle="None" 
            Height="50px" oninit="CrystalReportViewer1_Init" PageZoomFactor="99" 
            ToolbarStyle-BorderColor="Gray" Width="350px" />
    
    </div>
    </form>
</body>
</html>
