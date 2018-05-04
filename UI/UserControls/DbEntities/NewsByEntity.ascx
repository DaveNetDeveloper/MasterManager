<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewsByEntity.ascx.cs" Inherits="NewsByEntity" %>
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
<script type="text/javascript"> 
      
    function FillAreasFromDataBase() {

        $.ajax({
            type: "POST",
            url: "../WebServices/WsAreas.asmx/GetAll",
            async: true,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                data.d.forEach(function (area) {
                    //Informo de los detalles de cada Area
                    FillSectionByArea(area);
                });

                //Creo un elemento de tipo "p" y lo añado como hijo al elemento actual -> elementos "social-list"
                $('.social-list').append(CreateNewElement('p', 'p1', 'Texto de prueba injectado desde Javascript'));

                //Busca y reemplaza la clase antigua por la nueva 
                SearchAndReplaceClassIntoParent('.social-list', 'icon-facebook small', 'icon-twitter small');
            },
            error: function (error) {
                alert(error.responseText);
            }
        });
    }

    function FillSectionByArea(area) {

        var tagName = "#Area" + area.Id + "Name";
        var tagOwner = "#Area" + area.Id + "Owner";
        var tagDescription = "#Area" + area.Id + "Description";

        $(tagName).html(area.IP);
        $(tagOwner).html(area.Region);
        $(tagDescription).html(area.Ciudad);
    }

    function CreateNewElement(elementTag, elementName, textContent) {

        var element = document.createElement(elementTag);
        element.id = elementName;
        element.textContent = textContent;
        return element;
    }

    function SearchAndReplaceClassIntoParent(parentElement, pOldClass, pNewClass) {
        $(parentElement).each(function () {
            SearchAndReplaceClassRecursive($(this), pOldClass, pNewClass)
        });
    }

    function SearchAndReplaceClassRecursive(element, oldClass, newClass) {

        CheckClassAndReplace(element, oldClass, newClass)
        element.children().each(function () {

            CheckClassAndReplace($(this), oldClass, newClass)
            SearchAndReplaceClassRecursive($(this), oldClass, newClass);
        });
    }

    function CheckClassAndReplace(element, oldClass, newClass) {

        if (element.attr('class') == oldClass) {
            element.removeClass(oldClass);
            element.addClass(newClass);
        }
    } 
</script> 