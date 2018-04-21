<%@ Page Title="Lista de tests" Language="C#" AutoEventWireup="true" CodeFile="TestList.aspx.cs" Inherits="TestList" %>
<!DOCTYPE html> 
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title title="Lista de Tests Online"></title>
    
    <script src="../Scripts/jquery-1.11.1.min.js"></script>
    <script src="http://code.jquery.com/jquery-latest.js" type="text/javascript"></script>
    <script src="../Scripts/vallenato.js" type="text/javascript"></script>

    <link rel="stylesheet" href="css/vallenato.css" type="text/css" media="screen" />
</head> 
<body>
    <form id="form" runat="server">
        <section class="wrapper" style="min-height:700px; margin-top: 40px; margin-bottom: 20px;"">
        <%--  <div id="maximage" style="height:100%;">
            <div>
                <img src="img/textura.png" alt="">
            </div>
        </div><!-- #maximage -->--%>
        <div runat="server" id="accordion_container"> 
            <h2 class="accordion-header">PER</h2> 
            <div runat="server" id="PERContent" class="accordion-content"></div> 
             
            <h2 class="accordion-header">PNB</h2> 
            <div id="PNBContent" runat="server" class="accordion-content"></div> 

            <h2 class="accordion-header">CY</h2> 
            <div id="CYContent" runat="server" class="accordion-content"></div> 

            <h2 class="accordion-header">PY</h2> 
            <div id="PYContent" runat="server" class="accordion-content"></div> 
            
            <h2 class="accordion-header">LNA</h2> 
            <div id="LNAContent" runat="server" class="accordion-content"></div> 
        </div>
        </section> 
    </form>
</body>  
</html>