//'position': 'sticky', does not work for IE
$(document).ready(function () {

    var column1 = $('.column1');
    var column2 = $('.column2');
    var column3 = $('.column3');
    var column4 = $('.column4');

    var floatingDivPosition = column2.position(); //position of highchart element
    $(window).scroll(function () {
        var scrollPosition = $(window).scrollTop(); //vertical position of scrollbar
        if (scrollPosition >= floatingDivPosition.top) {
           
                column2.css({
                    'position': 'sticky',
                    'top': '50px'

                }),
                column4.css({
                    'position': 'sticky',
                    'top': '50px'
                });

        } else {
            
                column2.css({
                    'position': 'relative',
                    'top': 0
                }),
                column4.css({
                    'position': 'relative',
                    'top': 0
                });
        }
    });
});