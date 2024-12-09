(function($) {
    "use strict";
	
	/* ..............................................
	   Loader 
	   ................................................. */
	$(window).on('load', function() {
		$('.preloader').fadeOut();
		$('#preloader').delay(550).fadeOut('slow');
		$('body').delay(450).css({
			'overflow': 'visible'
		});
	});

	/* ..............................................
	   Fixed Menu
	   ................................................. */

	$(window).on('scroll', function() {
		if ($(window).scrollTop() > 50) {
			$('.main-header').addClass('fixed-menu');
		} else {
			$('.main-header').removeClass('fixed-menu');
		}
	});

	/* ..............................................
	   Gallery
	   ................................................. */

	$('#slides-shop').superslides({
		inherit_width_from: '.cover-slides',
		inherit_height_from: '.cover-slides',
		play: 5000,
		animation: 'fade',
	});

	$(".cover-slides ul li").append("<div class='overlay-background'></div>");

	/* ..............................................
	   Map Full
	   ................................................. */

	$(document).ready(function() {
		$(window).on('scroll', function() {
			if ($(this).scrollTop() > 100) {
				$('#back-to-top').fadeIn();
			} else {
				$('#back-to-top').fadeOut();
			}
		});
		$('#back-to-top').click(function() {
			$("html, body").animate({
				scrollTop: 0
			}, 600);
			return false;
		});
	});

	/* ..............................................
	   Special Menu
	   ................................................. */

	var Container = $('.container');
	Container.imagesLoaded(function() {
		var portfolio = $('.special-menu');
		portfolio.on('click', 'button', function() {
			$(this).addClass('active').siblings().removeClass('active');
			var filterValue = $(this).attr('data-filter');
			$grid.isotope({
				filter: filterValue
			});
		});
		var $grid = $('.special-list').isotope({
			itemSelector: '.special-grid'
		});
	});

	/* ..............................................
	   BaguetteBox
	   ................................................. */

	baguetteBox.run('.tz-gallery', {
		animation: 'fadeIn',
		noScrollbars: true
	});

	/* ..............................................
	   Offer Box
	   ................................................. */

	$('.offer-box').inewsticker({
		speed: 3000,
		effect: 'fade',
		dir: 'ltr',
		font_size: 13,
		color: '#ffffff',
		font_family: 'Montserrat, sans-serif',
		delay_after: 1000
	});

	/* ..............................................
	   Tooltip
	   ................................................. */

	$(document).ready(function() {
		$('[data-toggle="tooltip"]').tooltip();
	});

	/* ..............................................
	   Owl Carousel Instagram Feed
	   ................................................. */

	$('.main-instagram').owlCarousel({
		loop: true,
		margin: 0,
		dots: false,
		autoplay: true,
		autoplayTimeout: 3000,
		autoplayHoverPause: true,
		navText: ["<i class='fas fa-arrow-left'></i>", "<i class='fas fa-arrow-right'></i>"],
		responsive: {
			0: {
				items: 2,
				nav: true
			},
			600: {
				items: 3,
				nav: true
			},
			1000: {
				items: 5,
				nav: true,
				loop: true
			}
		}
	});

	/* ..............................................
	   Featured Products
	   ................................................. */

	$('.featured-products-box').owlCarousel({
		loop: true,
		margin: 15,
		dots: false,
		autoplay: true,
		autoplayTimeout: 3000,
		autoplayHoverPause: true,
		navText: ["<i class='fas fa-arrow-left'></i>", "<i class='fas fa-arrow-right'></i>"],
		responsive: {
			0: {
				items: 1,
				nav: true
			},
			600: {
				items: 3,
				nav: true
			},
			1000: {
				items: 4,
				nav: true,
				loop: true
			}
		}
	});

	// Handle hidden-show chatbot
	$("#toggleButton").click(function() {
		$("#toggleElement").toggleClass("hidden");
	});

	// Handle stock
	$('.quantity .quan-inp').on('change', function () {
		console.log("Sự kiện đã kích hoạt!");
		const input = $(this);                 // Lấy input hiện tại
		const maxStock = input.attr('data-stock');  // Lấy giá trị từ data-stock
		const quantity = input.val();  // Lấy số lượng nhập vào
		
		console.log(maxStock, quantity);

		if (quantity > maxStock) {
			alert(`Số lượng vượt quá giới hạn! Tối đa: ${maxStock}`);
			input.attr('value', 10);  // Reset về giá trị tối đa
		} else if (quantity < 1 || isNaN(quantity)) {
			alert('Số lượng phải lớn hơn 0!');
			input.attr('value', 1);  // Reset về giá trị tối thiểu
		}
	});

	// Handle Product Quantity
	$('.quantity button').on('click', function () {
        let change = 0;

        var button = $(this);
        var oldValue = button.parent().parent().find('input').val();
        if (button.hasClass('btn-plus')) {
            var newVal = parseFloat(oldValue) + 1;
            change = 1;
        } else {
            if (oldValue > 1) {
                var newVal = parseFloat(oldValue) - 1;
                change = -1;
            } else {
                newVal = 1;
            }
        }
        const input = button.parent().parent().find('input');
        input.val(newVal);

        //set form index
        const index = input.attr("data-cart-detail-index")
        const el = document.getElementById(`cartItems${index}.quantity`);
		$(el).attr('value', newVal);
		// console.log(el, $(el).val());
		
        //get price
        const price = input.attr("data-cart-detail-price");
        const id = input.attr("data-cart-detail-id");

        const priceElement = $(`p[data-cart-detail-id='${id}']`);
        if (priceElement) {
            const newPrice = +price * newVal;
            priceElement.text('$' + parseFloat(newPrice).toFixed(2));
        }

        //update total cart price
        const totalPriceElement = $(`div[data-cart-total-price]`);
        const totalPriceElementFinal = $(`div[data-cart-total-price-final]`);

        if (totalPriceElement && totalPriceElement.length) {
            const currentTotal = totalPriceElement.first().attr("data-cart-total-price");
            let newTotal = +currentTotal;
            if (change === 0) {
                newTotal = +currentTotal;
            } else {
                newTotal = change * (+price) + (+currentTotal);
            }

            //reset change
            change = 0;

            //update
            totalPriceElement?.each(function (index, element) {
                //update text
                $(totalPriceElement[index]).text('$' + parseFloat(newTotal).toFixed(2));
                $(totalPriceElementFinal[index]).text('$' + (parseFloat(newTotal + 2.0).toFixed(2)));

                //update data-attribute
                $(totalPriceElement[index]).attr("data-cart-total-price", parseFloat(newTotal).toFixed(2));
                $(totalPriceElementFinal[index]).attr("data-cart-total-price-final", (parseFloat(newTotal + 2.0).toFixed(1)));
            });
        }
    });

	/* ..............................................
	   Scroll
	   ................................................. */

	$(document).ready(function() {
		$(window).on('scroll', function() {
			if ($(this).scrollTop() > 100) {
				$('#back-to-top').fadeIn();
			} else {
				$('#back-to-top').fadeOut();
			}
		});
		$('#back-to-top').click(function() {
			$("html, body").animate({
				scrollTop: 0
			}, 600);
			return false;
		});
	});


	/* ..............................................
	   Slider Range
	   ................................................. */

	$(function() {
		$("#slider-range").slider({
			range: true,
			min: 0,
			max: 4000,
			values: [1000, 3000],
			slide: function(event, ui) {
				$("#amount").val("$" + ui.values[0] + " - $" + ui.values[1]);
			}
		});
		$("#amount").val("$" + $("#slider-range").slider("values", 0) +
			" - $" + $("#slider-range").slider("values", 1));
	});

	/* ..............................................
	   NiceScroll
	   ................................................. */

	$(".brand-box").niceScroll({
		cursorcolor: "#9b9b9c",
	});
}(jQuery));

// Handle chatbot reply
function sendMessage() {
	const BASE_URL = "http://localhost:9966/shop";
    const userMessage = $("#userInput").val();
    $("#messages").append(`<br clear="both">
                            <div class="item right">
                                <div class="msg">
                                    <p>${userMessage}</p>
                                </div>
                            </div>`);

    $.ajax({
        url: `${BASE_URL}/api/chatbot/get-reply`,
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify({ message: userMessage }),
        success: function (data) {
            $("#messages").append(`<div class="item">
                                     <div class="icon">
                                       <i class="fa-solid fa-robot"></i>
                                     </div>
                                     <div class="msg">
                                         <p>${data.reply}</p>
                                     </div>
                                   </div>`);
        },
        error: function (xhr, status, error) {
            console.error("Error:", status, error);
        }
    });
}
