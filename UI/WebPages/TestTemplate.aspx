<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestTemplate.aspx.cs" Inherits="TestTemplate" %>

<%@ Register Src="~/UI/UserControls/SectionNewForEntity.ascx" TagPrefix="ucNews" TagName="SectionNewForEntity" %>

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
    
    <script src="js/jquery-1.8.2.min.js"></script>
    <%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>--%>
	
    <script src="../js/timber.master.min.js"></script>
    <link rel="stylesheet" href="css/core.min.css" />
    <link rel="stylesheet" href="css/skin.css" />
	<!--[if lt IE 9]>
    	<script type="text/javascript" src="http://html5shiv.googlecode.com/svn/trunk/html5.js"></script>
    <![endif]--> 

</head>
<body onload="FillAreasFromDataBase()">

    <br /><br />
    <ucNews:SectionNewForEntity runat="server" ID="SectionNewByEntity" />

    <script type="text/javascript">

        //$(document).ready(function () {
        //    alert("ready!");
        //    //FillAreasFromDataBase();
        //});

    </script>

</body>  
</html>

