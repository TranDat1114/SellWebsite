$(document).ready(function () {
    $(".fa-regular.fa-star").mouseenter(function () {
        $(this).addClass("active");
        $(this).prevAll().addClass("active");
    });

    $(".fa-regular.fa-star").mouseleave(function () {
        $(this).removeClass("active");
        $(this).prevAll().removeClass("active");
    });

    $(".fa-regular.fa-star").click(function () {
        $(this).addClass("fa-solid");
        $(this).prevAll().addClass("fa-solid");
        $(this).nextAll().removeClass("fa-solid")
    });
});