$(function() {
    $(".btnlist li").click(function() {
        var s = $(this).data("s");

        $(".btnlist li").removeClass("active");
        $(this).addClass("active");

        $(".info .info-right").removeClass("active");
        $(".info .s-" + s).addClass("active");
    });

    $(".content-right-nav-ddd li").click(function() {
        var id = $(this).text().trim();
        $(".content-right-content .item").hide();
        $(".content-right-content #" + id).show();

        $(".content-right-nav-ddd li").removeClass("active");
        $(this).addClass("active");
    });

    // $.getJSON('/api/threeModule', function(data) {
    //     ko.applyBindings({ data: data }, document.getElementById('threemodule'));
    // })

    $.getJSON("/api/secondModule", null, function(data) {
        ko.applyBindings({ data: data.Item }, document.getElementById('secondmodule'));
    });

    // $.getJSON("/api/oneModule", null, function(data) {
    //     ko.applyBindings(data, document.getElementById("onemodule"))
    // });

    // $.getJSON("/api/homeImage", null, function(images) {
    //     ko.applyBindings({
    //         images: images
    //     }, document.getElementById("homeimage"));

    //     var fp = $("#container").fullpage({
    //         scrollingSpeed: 1000,
    //         loopHorizontal: true,
    //         slidesNavigation: true,
    //         controlArrows: false
    //             //navigation:true,
    //             // slidesNavPosition:top,
    //             //continuousHorizontal:true,
    //     });

    //     setInterval(function() {
    //         $.fn.fullpage.moveSlideRight();
    //     }, 3000);
    // });
});