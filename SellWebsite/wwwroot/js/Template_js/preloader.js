(function ($) {
    "use strict";

    // Page loading animation
    $(window).on('load', function () {

        $('#js-preloader').addClass('loaded');

    });

	// Page loading animation
	$(window).on('load', function () {
		if ($('.cover').length) {
			$('.cover').parallax({
				imageSrc: $('.cover').data('image'),
				zIndex: '1'
			});
		}

		$("#preloader").animate({
			'opacity': '0'
		}, 600, function () {
			setTimeout(function () {
				$("#preloader").css("visibility", "hidden").fadeOut();
			}, 300);
		});
	});

})(window.jQuery);