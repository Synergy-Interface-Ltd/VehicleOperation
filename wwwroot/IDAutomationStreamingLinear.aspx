<%@ Page language="c#" Inherits="ASPLinearServerControl.GenerateImage" CodeFile="IDAutomationStreamingLinear.aspx.cs" %>
<%@ Register TagPrefix="cc1" Namespace="IDAutomation.LinearServerControl" Assembly="IDAutomation.LinearServerControl" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ERUDITE</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form method="post" runat="server">
			<cc1:linearbarcode id="LinearBarcode1" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 0px"
				runat="server" StreamImage="True" Height="100px" Width="152px"></cc1:linearbarcode></form>
	</body>
</HTML>
