$(function () {

    $(".btnlist li").click(function () {
        var s = $(this).data("s");
        var url = $(this).data('url');

        $(".btnlist li").removeClass("active");
        $(this).addClass("active");

        $(".page-right .right").removeClass("active");
        $(".page .s-" + s).addClass("active");

        $(".left-image").css("background-image", "url(" + url + ")");
        if (s == "three") {
            $(".page-right").css("background-image", "url(/img/rightbg_3.jpg)");
        } else {
            $(".page-right").css("background-image", "url(/img/rightbg.jpg)");
        }
    });

    $(".content-right-nav-ddd li").click(function () {
        var id = $(this).text().trim();
        $(".content-right-content .item").hide();
        $(".content-right-content #" + id).show();

        $(".content-right-nav-ddd li").removeClass("active");
        $(this).addClass("active");
    });

    $.getJSON('/api/ThreeModule', function (data) {
        ko.applyBindings({ data: data }, document.getElementById('threemodule'));
    })

    $.getJSON("/api/SecondModule", null, function (data) {
        ko.applyBindings({ data: data }, document.getElementById('secondmodule'));
    });

    $.getJSON("/api/OneModule", null, function (data) {
        ko.applyBindings(data, document.getElementById("onemodule"))
    });

    $.getJSON("/api/HomeImage", null, function (images) {
        $(".loading").remove();
        $("#container").show();

        ko.applyBindings({
            images: images
        }, document.getElementById("homeimage"));

        var fp = $("#container").fullpage({
            scrollingSpeed: 1000,//
            loopHorizontal: true,
            slidesNavigation: true,//
            controlArrows: false
            //navigation:true,
            // slidesNavPosition:top,
            //continuousHorizontal:true,
        });

        if (window.ie) {
            ie();
        }

        setInterval(function () {
            $.fn.fullpage.moveSlideRight();
        }, 3000);
    });
});