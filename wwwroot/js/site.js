// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(".right").click(function () {
    // Clone image and info
    var sign = $(this).clone();
    var signInfo = $(this).next().clone();
    // Remove start up paragraph and display sign info in it's place
    $("p").remove(".astro-intro");
    $("#rgb-col").css("display", "none");
    $("#interpolation-col").css("display", "block");
  });

  $(".left").click(function () {
    // Clone image and info
    var sign = $(this).clone();
    var signInfo = $(this).next().clone();
    // Remove start up paragraph and display sign info in it's place
    $("p").remove(".astro-intro");
    $("#interpolation-col").css("display", "none");
    $("#rgb-col").css("display", "block");
  });

  function validateForm() {
    // Validation for hex value: Color1
    var color1Input = document.getElementById('color1');
    if (!/^#[0-9a-fA-F]{6}$/.test(color1Input.value)) {
        alert('Please enter a valid hex color code for the first color.');
        return false;
    }
    // Validation: Color2
    var color2Input = document.getElementById('color2');
    if (!/^#[0-9a-fA-F]{6}$/.test(color2Input.value)) {
        alert('Please enter a valid hex color code for the second color.');
        return false;
    }
    return true;
  }
