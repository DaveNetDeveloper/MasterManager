<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Gallery.aspx.cs" Inherits="Gallery" %> 
<!DOCTYPE html>
<html>
<head>
	<meta charset="utf-8">
	<meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>Gallery</title> 

	<meta name="viewport" content="width=device-width, initial-scale=1">
	<meta name="description" content="" />
	<meta name="keywords" content="" />
	<meta name="author" content="" /> 
    <meta name="robots" content="" />
    
  	<!-- Facebook integration -->
	<meta property="og:title" content=""/>
	<meta property="og:image" content=""/>
	<meta property="og:url" content=""/>
	<meta property="og:site_name" content=""/>
	<meta property="og:description" content=""/>
	
	<!-- Animate.css -->
	<link rel="stylesheet" href="css/animate.css">
	<!-- Icomoon Icon Fonts-->
	<link rel="stylesheet" href="css/icomoon.css">
	<!-- Bootstrap  -->
	<link rel="stylesheet" href="css/bootstrap.css">

	<!-- Magnific Popup -->
	<link rel="stylesheet" href="css/magnific-popup.css">

	<!-- Owl Carousel  -->
	<link rel="stylesheet" href="css/owl.carousel.min.css">
	<link rel="stylesheet" href="css/owl.theme.default.min.css">

	<!-- Theme style  -->
	<link rel="stylesheet" href="css/style.css">

	<!-- Modernizr JS -->
	<script src="js/modernizr-2.6.2.min.js"></script>
  
      <%--Image Preview--%>
    <link href="assets/css/litebox.css" rel="stylesheet" type="text/css" media="all" />  
     
    <style type="text/css">
        @import url('https://fonts.googleapis.com/css?family=Lato');
         
        .h2class
         {  
             color: black !important;
         } 
        .h2class:hover
         { 
            color: #ab1f1c !important;
         }  
         button {
            position: relative;
            overflow: hidden;
            padding: 16px 32px;
        } 
         button:after {
            content: '';
            display: block;
            position: absolute;
            left: 50%;
            top: 50%;
            width: 120px;
            height: 120px;
            margin-left: -60px;
            margin-top: -60px;
            background: #3f51b5;
            border-radius: 100%;
            opacity: .6;
            transform: scale(0);
        } 
         @keyframes ripple {
            0% {
                transform: scale(0);
            }

            20% {
                transform: scale(1);
            }

            100% {
                opacity: 0;
                transform: scale(1);
            }
        } 
         button:not(:active):after {
            animation: ripple 1s ease-out;
        }  
         button:after {
            visibility: hidden;
        } 
         button:focus:after {
            visibility: visible;
        }  
        .outline-button {
            font-size: 16px;
            /* margin-right: 8px; */
        } 
        .outline-button {
                font-family: 'Lato', sans-serif;
            margin-top:25px;
            text-decoration: none;
            outline: 0;
            font-size: 20px; 
            -webkit-border-radius: 4px;
            -moz-border-radius: 4px;
            border-radius: 4px;
            border: 2px solid #FFF;
            color: #FFF;
            margin-right: 18px;
            padding: 10px 15px;
            -webkit-transition: all .15s cubic-bezier(.31,-.105,.43,1.4);
            -moz-transition: all .15s cubic-bezier(.31,-.105,.43,1.4);
            -o-transition: all .15s cubic-bezier(.31,-.105,.43,1.4);
            transition: all .15s cubic-bezier(.31,-.105,.43,1.4);
            background: transparent;
        }  
        .outline-button:before {
             background-image: url(icons/ir-a-web.svg); 
             background-position: center; 
             background-repeat: no-repeat; 
             background-size: 15px; 
             display: inline-block; 
             width: 15px; 
             height: 17px; 
             margin-right: 9px; 
        }
        .outline-button:before {
            margin-right: 6px;
            top: 2px;
            position: relative;
        }
        .outline-button:hover {
            border-color: white;
            background-color: white;
            cursor: pointer;
            text-decoration: none;
            outline: 0;
            color: #ab1f1c;
        }   
        @font-face{
            font-family: 'WOX~Modelist Italic Demo';
            src:url(fonts/WOX_Modelist_Light_Italic_demo.otf); 
        }  
    </style>  
    <style>
        body {
            font-family: 'Scada', sans-serif;
            background: #f6f6f6;
            color: #212121;
        }
        .galereya-top {
            position: fixed;
            background: #f6f6f6;
            background: rgba(246, 246, 246, 0.7);
        }
    </style>

    <link rel="stylesheet" href="src/css/jquery.galereya.css">
</head>
<body> 
<form id="form" runat="server">  
    <div id="page">  

        <div id="gallery"></div> 

        <script src="js/jquery-1.9.1.min.js"></script>
        <script src="src/js/jquery.galereya.js"></script>

        <script>
            $(function () {
                $('#gallery').galereya({
                    load: function (next) {
                        $.getJSON('images.json', function (data) {
                            next(data);
                        });
                    }
                });
            });
        </script> 
    </div>

    <!-- JavaScript for Image Preview -->
    <script src="assets/js/smoothscroll.js" type="text/javascript"></script>
    <script src="assets/js/images-loaded.min.js" type="text/javascript"></script>
    <script src="assets/js/litebox.js" type="text/javascript"></script>
    <script src="assets/js/backbone.js" type="text/javascript"></script>
    
    <script type="text/javascript">
        $('.litebox').liteBox();
    </script> 
</form>
</body>
</html>
