$(document).ready(function () {
    $(".fancybox").fancybox();
});

$(document).ready(function () {
    $(".fancybox-thumb").fancybox({
        prevEffect: 'none',
        nextEffect: 'none',
        helpers: {
            thumbs: {
                width: 117,
                height: 65
            }
        }
    });
});