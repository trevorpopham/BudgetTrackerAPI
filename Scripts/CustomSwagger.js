$(function () {
    $("#logo").removeAttr("href");
    $("#logo").addClass("navbar-brand");
    $("#header").addClass("navbar-header");
    $(".swagger-ui-wrap").addClass("navbar-collapse");
    $(".logo_image").remove();
    $("#api_info").remove();
    $(".input").remove();
    $("#logo").text("Budget Tracker API");
    $("title").text("Budget Tracker API");
})