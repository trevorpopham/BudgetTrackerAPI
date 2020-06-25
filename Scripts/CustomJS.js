$(document).ready(function () {


    console.log("New page loaded")
    // remove link
    $("#logo").removeAttr("href")
    // probably doesnt do anything
    $("#logo").addClass("navbar-brand")
    // dont think this does anything either
    $("#header").addClass("navbar-header")
    // same with this
    $(".swagger-ui-wrap").addClass("navbar-collapse")
    // removes the logo image
    $(".logo_image").remove()
    // this removes the footer info, I think
    $("#api_info").remove()
    // this removes search boxes
    $(".input").remove()
    //$("#logo").html("&nbsp; &nbsp; Financial Portal API")
    $("#logo").text("Financial Portal API")
    $("title").text("Financial Portal API")


    $("#validator").remove()
    $(".footer").remove()



})