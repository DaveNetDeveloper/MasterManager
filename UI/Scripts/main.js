$(document).ready(function () {
	$('#maximage').maximage({
		cycleOptions: {
			fx: 'fade',
			speed: 1000, // Has to match the speed for CSS transitions in jQuery.maximage.css (lines 30 - 33)
			timeout: 0,
			prev: '#arrow_left',
			next: '#arrow_right',
			pause: 1/*,
			before: function(last,current){
				if(!$.browser.msie){
					// Start HTML5 video when you arrive
					if($(current).find('video').length > 0) $(current).find('video')[0].play();
				}
			},
			after: function(last,current){
				if(!$.browser.msie){
					// Pauses HTML5 video when you leave it
					if($(last).find('video').length > 0) $(last).find('video')[0].pause();
				}
			}*/
		},
		onFirstImageLoaded: function(){
			jQuery('#cycle-loader').hide();
			jQuery('#maximage').fadeIn('fast');
		}
	});
	
	// Helper function to Fill and Center the HTML5 Video
	jQuery('video,object').maximage('maxcover');
	
	// To show it is dynamic html text
	jQuery('.in-slide-content').delay(1200).fadeIn();
	
	$('.icon-circle-empty').hover(function() {
		$(this).toggleClass('icon-circle');
		$(this).css('cursor','pointer');
	});
	
	$('td').hover(function() {
		$(this).parent().children().toggleClass('td-select');
	});
	
	$('nav.global.mobile li.active-top-mob').mousedown(function(){
		if($('nav.top-mob').hasClass('activeNav')) {
			$('section.mobile').css('display','none');
			$('section.mobile').css('visibility','hidden');
			$('nav.top-mob').removeClass('activeNav');
		} else {
			$('section.mobile').css('display','block');
			$('section.mobile').css('visibility','visible');
			$('nav.top-mob').addClass('activeNav');
		}
	});
	
	if($(".fancybox").length) {
		$(".fancybox").fancybox();
	}
	
	/* Solucion iPhone */
	
	// Assign a variable for the application being used
	var nVer = navigator.appVersion;
	// Assign a variable for the device being used
	var nAgt = navigator.userAgent;
	var nameOffset,verOffset,ix;
 
	// First check to see if the platform is an iPhone or iPod
	if(navigator.platform == 'iPhone' || navigator.platform == 'iPod' || navigator.platform == 'iPhone Simulator'){
		// In Safari, the true version is after "Safari" 
		if ((verOffset=nAgt.indexOf('Safari'))!=-1) {
		  // Set a variable to use later
		  var mobileSafari = 'Safari';
		}
	}
 
	// If is mobile Safari set window height +60
	if (mobileSafari == 'Safari') { 
		// Height + 60px
		$('#maximage, #maximage > div').css('height',(($(window).height()) + 61)+'px');
	} else {
		// Else use the default window height
		$('#maximage, #maximage > div').css({'height':(($(window).height()))+'px'});	
	};
	
	// On window resize run through the sizing again
	$(window).resize(function(){
		// If is mobile Safari set window height +60
		if (mobileSafari == 'Safari') { 
			// Height + 60px
			$('#maximage, #maximage > div').css('height',(($(window).height()) + 61)+'px');
		} else {
			// Else use the default window height
			$('#maximage, #maximage > div').css({'height':(($(window).height()))+'px'});	
		};
	});



	if($("section.wrapper[role='fotos']").length) {
		$.supersized({
		
			// Functionality
			slide_interval: 3000,		// Length between transitions
			transition: 1, 			// 0-None, 1-Fade, 2-Slide Top, 3-Slide Right, 4-Slide Bottom, 5-Slide Left, 6-Carousel Right, 7-Carousel Left
			transition_speed: 700,		// Speed of transition
													   
			// Components							
			slide_links: 'blank',	// Individual links for each slide (Options: false, 'num', 'name', 'blank')
			slides: [		// Slideshow Images
                                    {image : 'http://buildinternet.s3.amazonaws.com/projects/supersized/3.2/slides/kazvan-1.jpg', title : 'Image Credit: Maria Kazvan', thumb : 'http://buildinternet.s3.amazonaws.com/projects/supersized/3.2/thumbs/kazvan-1.jpg', url : 'http://www.nonsensesociety.com/2011/04/maria-kazvan/'},
                                    {image : 'http://buildinternet.s3.amazonaws.com/projects/supersized/3.2/slides/kazvan-2.jpg', title : 'Image Credit: Maria Kazvan', thumb : 'http://buildinternet.s3.amazonaws.com/projects/supersized/3.2/thumbs/kazvan-2.jpg', url : 'http://www.nonsensesociety.com/2011/04/maria-kazvan/'},  
                                    {image : 'http://buildinternet.s3.amazonaws.com/projects/supersized/3.2/slides/kazvan-3.jpg', title : 'Image Credit: Maria Kazvan', thumb : 'http://buildinternet.s3.amazonaws.com/projects/supersized/3.2/thumbs/kazvan-3.jpg', url : 'http://www.nonsensesociety.com/2011/04/maria-kazvan/'},
                                    {image : 'http://buildinternet.s3.amazonaws.com/projects/supersized/3.2/slides/wojno-1.jpg', title : 'Image Credit: Colin Wojno', thumb : 'http://buildinternet.s3.amazonaws.com/projects/supersized/3.2/thumbs/wojno-1.jpg', url : 'http://www.nonsensesociety.com/2011/03/colin/'},
                                    {image : 'http://buildinternet.s3.amazonaws.com/projects/supersized/3.2/slides/wojno-2.jpg', title : 'Image Credit: Colin Wojno', thumb : 'http://buildinternet.s3.amazonaws.com/projects/supersized/3.2/thumbs/wojno-2.jpg', url : 'http://www.nonsensesociety.com/2011/03/colin/'},
                                    {image : 'http://buildinternet.s3.amazonaws.com/projects/supersized/3.2/slides/wojno-3.jpg', title : 'Image Credit: Colin Wojno', thumb : 'http://buildinternet.s3.amazonaws.com/projects/supersized/3.2/thumbs/wojno-3.jpg', url : 'http://www.nonsensesociety.com/2011/03/colin/'},
                                    {image : 'http://buildinternet.s3.amazonaws.com/projects/supersized/3.2/slides/shaden-1.jpg', title : 'Image Credit: Brooke Shaden', thumb : 'http://buildinternet.s3.amazonaws.com/projects/supersized/3.2/thumbs/shaden-1.jpg', url : 'http://www.nonsensesociety.com/2011/06/brooke-shaden/'},
                                    {image : 'http://buildinternet.s3.amazonaws.com/projects/supersized/3.2/slides/shaden-2.jpg', title : 'Image Credit: Brooke Shaden', thumb : 'http://buildinternet.s3.amazonaws.com/projects/supersized/3.2/thumbs/shaden-2.jpg', url : 'http://www.nonsensesociety.com/2011/06/brooke-shaden/'},
                                    {image : 'http://buildinternet.s3.amazonaws.com/projects/supersized/3.2/slides/shaden-3.jpg', title : 'Image Credit: Brooke Shaden', thumb : 'http://buildinternet.s3.amazonaws.com/projects/supersized/3.2/thumbs/shaden-3.jpg', url : 'http://www.nonsensesociety.com/2011/06/brooke-shaden/'}
                                ]
			
		});
	}
	
	if($('section.wrapper').is('[role="contacto"]')) {
		//$('header.global').css('background','rgba(0,0,0,0.2)');
	} else {
		//$('header.global').css('background','rgba(255,255,255,0.3)');
	}
});