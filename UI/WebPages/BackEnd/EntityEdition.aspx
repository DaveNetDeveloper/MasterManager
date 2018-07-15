<%@ Page Language="C#" AutoEventWireup="true" EnableSessionState="True" EnableTheming="true" EnableViewState="true" CodeFile="EntityEdition.aspx.cs" Inherits="EntityEdition" %>
<%@ Register Src="~/UI/UserControls/DbEntities/EntityEdition.ascx" TagPrefix="uc" TagName="EntityEdit" %> 
<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8" />
	<meta content="width=device-width,initial-scale=1.0,maximum-scale=1.0" name="viewport">
	<meta name="twitter:widgets:theme" content="light">
	<meta property="og:title" content="Your-Title-Here" />
	<meta property="og:type" content="website" />
	<meta property="og:image" content="Your-Image-Url" />
	<meta property="og:description" content="Your-Page-Description" />

	<title>Test Template with UserControl</title>
	<link rel="shortcut icon" type="image/x-icon" href="images/theme-mountain-favicon.ico">
    
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/timber.master.min.js"></script>
    
    <link rel="stylesheet" href="../css/core.min.css" />
    <link rel="stylesheet" href="../css/skin.css" /> 
</head>
<body>
    <uc:EntityEdit BussinesObject="Usuario_Alumno" runat="server" ID="UcEntity" /> 
    <%--<uc:EntityEdit BussinesObject="Usuario_Gestor" runat="server" ID="UcEntity" /> --%>
</body>  
</html>

