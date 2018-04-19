<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestTemplate.aspx.cs" Inherits="TestTemplate" %>
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
	<title>Test Template </title>
	<link rel="shortcut icon" type="image/x-icon" href="images/theme-mountain-favicon.ico">

	<!-- Font -->
	<link href='https://fonts.googleapis.com/css?family=Open+Sans:300,400,700%7CLato:300,400,700' rel='stylesheet' type='text/css'>
	
   <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>

	<!-- Css -->
	<link rel="stylesheet" href="css/core.min.css" />
	<link rel="stylesheet" href="css/skin.css" />

	<!--[if lt IE 9]>
    	<script type="text/javascript" src="http://html5shiv.googlecode.com/svn/trunk/html5.js"></script>
    <![endif]-->

    <script type="text/javascript" src="http://code.jquery.com/jquery-1.7.1.min.js"></script> 
</head>
<body>
    <input id="btnUpdateArea" type="button" value="Cargar areas desde base de datos" onclick="FillAreas();"/> 
	<div class="row">
		<div class="column width-12">
			<div class="row content-grid-3">
                                 
				<div class="grid-item horizon" data-animate-in="preset:slideInUpShort;duration:1000ms;" data-threshold="0.3">
					<div class="thumbnail no-margin-bottom" data-hover-easing="easeInOut" data-hover-speed="500" data-hover-bkg-color="#ffffff" data-hover-bkg-opacity="0.9">
						<img src="images/team/team-member-1.jpg" width="760" height="500" alt=""/>
					</div>
					<div class="team-content-info">
						<h4 id="Area1Name" class="mb-5"></h4>
						<h4 id="Area1Owner" class="occupation"></h4>
						<p id="Area1Description"></p>
						<ul  class="social-list list-horizontal">
							<li><a href="#"><span class="icon-facebook small"></span></a></li>
							<li><a href="#"><span class="icon-twitter small"></span></a></li>
							<li><a href="#"><span class="icon-dribbble small"></span></a></li>
						</ul>
					</div>
				</div> 
                 
				<div class="grid-item horizon" data-animate-in="preset:slideInUpShort;duration:1000ms;delay:300ms;" data-threshold="0.3">
					<div class="thumbnail no-margin-bottom" data-hover-easing="easeInOut" data-hover-speed="500" data-hover-bkg-color="#ffffff" data-hover-bkg-opacity="0.9">
						<img src="images/team/team-member-3.jpg" width="760" height="500" alt=""/>
					</div>
					<div class="team-content-info">
						<h4 id="Area2Name" class="mb-5"></h4>
						<h4 id="Area2Owner" class="occupation"></h4>
						<p id="Area2Description"></p>
						<ul class="social-list list-horizontal">
							<li><a href="#"><span class="icon-facebook small"></span></a></li>
							<li><a href="#"><span class="icon-twitter small"></span></a></li>
							<li><a href="#"><span class="icon-github small"></span></a></li>
						</ul>
					</div>
				</div>

				<div class="grid-item horizon" data-animate-in="preset:slideInUpShort;duration:1000ms;delay:600ms;" data-threshold="0.3">
					<div class="thumbnail no-margin-bottom" data-hover-easing="easeInOut" data-hover-speed="500" data-hover-bkg-color="#ffffff" data-hover-bkg-opacity="0.9">
						<img src="images/team/team-member-4.jpg" width="760" height="500" alt=""/>
					</div>
					<div class="team-content-info">
						<h4 id="Area3Name" class="mb-5"></h4>
						<h4 id="Area3Owner" class="occupation"></h4>
						<p id="Area3Description"></p>
						<ul class="social-list list-horizontal">
							<li><a href="#"><span class="icon-facebook small"></span></a></li>
							<li><a href="#"><span class="icon-behance small"></span></a></li>
							<li><a href="#"><span class="icon-dribbble small"></span></a></li>
						</ul>
					</div>
				</div> 
			</div>
		</div>
	 </div> 
	<script src="js/timber.master.min.js"></script>
</body> 
<script type="text/javascript">
     
    function FillAreas() { 
        $.ajax({
            type: "POST",
            url: "WebServices/wsAreas.asmx/GetAllAreas",
            async: true,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                data.d.forEach(function (area) {

                    var tagName = "#Area" + area.Id + "Name";
                    var tagOwner = "#Area" + area.Id + "Owner";
                    var tagDescription = "#Area" + area.Id + "Description"; 
                     
                    $(tagName).html(area.IP);
                    $(tagOwner).html(area.Region); 
                    $(tagDescription).html(area.Ciudad);   
                }); 
                 
                $('.social-list').each(function () {

                    var pElement = document.createElement("p");
                    pElement.id = "p1";
                    pElement.textContent = "Texto de prueba injectado desde Javascript";

                    $(this).append(pElement);
                }); 
            },
            error: function (error) {
                alert("error");
                alert(error.responseText);
            }
        }); 
    }   
</script>  
</html>