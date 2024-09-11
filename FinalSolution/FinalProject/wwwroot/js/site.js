// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
  // Get the referring URL
  var referringPage = document.referrer;

  // Check if the referring URL matches the specified URL
  if (referringPage.includes("/Account?")) {
    // Hide the element with id "elementToHide"
    $(".create-account").hide();
  }
});

$(document).ready(function () {
  $("#UserName").on("input", function () {
    // Check if there is text in the username input
    var username = $(this).val();
    if (username) {
      // Enable the submit button if there is text
      $("#accountSubmit").prop("disabled", false);
      $("#accountSubmit").css("background-color", "#FDC000");
    } else {
      // Otherwise, keep the button disabled
      $("#accountSubmit").prop("disabled", true);
      $("#accountSubmit").css("background-color", "white");
    }
  });
});

$(document).ready(function () {
  var loginData = document.getElementById("isLogin").value;
  if (loginData == 1) {
    $("#loginInput").css("display", "none");
    $("#loginSubmit").css("display", "none");
  }
});

$(document).ready(function () {
  var modelData = document.getElementById("hiddenData").value;
  if (modelData == 0) {
    $("button").attr("disabled", true);
    $("input").attr("disabled", true);
    $("select").attr("disabled", true);
    $(".filtered-movies").css("display", "none");
    $(".all-movies").css("display", "none");
  }
});

$(document).ready(function () {
  // Event listener for the form submission
  $("#movieForm").submit(function (event) {
    var canvas = document.getElementById("canvas");
    if (canvas) {
      var image = canvas.toDataURL("image/png");
      $("#canvasImage").val(image);
    }
  });
});

$(document).ready(function () {
  var canvas = document.getElementById("canvas");
  var ctx = canvas.getContext("2d");
  var drawing = false; // Flag to check if drawing is in progress

  // Function to calculate mouse position relative to canvas
  function getMousePosition(canvas, event) {
    var rect = canvas.getBoundingClientRect(); // Get canvas position and size
    return {
      x: event.clientX - rect.left, // X coordinate of mouse relative to canvas
      y: event.clientY - rect.top, // Y coordinate of mouse relative to canvas
    };
  }

  // Function to handle the start of drawing
  function startPosition(e) {
    drawing = true; // Set drawing flag to true
    draw(e); // Start drawing
  }

  // Function to handle the end of drawing
  function endPosition() {
    drawing = false; // Set drawing flag to false
    ctx.beginPath(); // Begin a new path for future drawing
  }

  function draw(e) {
    if (!drawing) return;
    var pos = getMousePosition(canvas, e);

    // Set drawing properties
    ctx.lineWidth = 5; // Width of the line
    ctx.lineCap = "round"; // Rounded end of the line
    ctx.strokeStyle = "black"; // Color of the line

    // Draw the line
    ctx.lineTo(pos.x, pos.y); // Draw line to new position
    ctx.stroke(); // Apply the line to the canvas
    ctx.beginPath(); // Begin a new path
    ctx.moveTo(pos.x, pos.y); // Move the path to the new position
  }

  // Start drawing on mouse down
  $("#canvas").mousedown(startPosition);
  // End drawing on mouse up
  $("#canvas").mouseup(endPosition);
  // Draw as the mouse moves
  $("#canvas").mousemove(draw);

  // Clear the canvas
  $("#clearBtn").click(function () {
    ctx.clearRect(0, 0, canvas.width, canvas.height);
  });
});

$(document).ready(function () {
  // Load the previously selected theme if any
  var selectedTheme = loadTheme();
  if (selectedTheme) {
    applyTheme(selectedTheme);
  }

  // Click event handlers for theme selection
  $("#Theme1").click(function () {
    applyTheme("Theme1");
    saveTheme("Theme1");
  });

  $("#Theme2").click(function () {
    applyTheme("Theme2");
    saveTheme("Theme2");
  });

  $("#Theme3").click(function () {
    applyTheme("Theme3");
    saveTheme("Theme3");
  });
});

function addTag() {
  var input = document.getElementById("movieTags");
  var tagsContainer = document.getElementById("tagsContainer");
  var form = document.getElementById("movieForm");

  if (input.value.trim() === "") return; // Prevent empty tags

  // Create a span element to show the tag
  var tagSpan = document.createElement("span");
  tagSpan.innerHTML = input.value.trim();
  tagSpan.classList.add("tag");

  // Create a hidden input for the tag
  var hiddenInput = document.createElement("input");
  hiddenInput.type = "hidden";
  hiddenInput.name = "tags";
  hiddenInput.value = input.value.trim();

  // Add a delete function to the tag
  var deleteBtn = document.createElement("button");
  deleteBtn.innerHTML = "x";
  deleteBtn.onclick = function () {
    // Remove tag span and corresponding hidden input
    tagSpan.remove();
    hiddenInput.remove();
  };
  tagSpan.appendChild(deleteBtn);

  // Append the tag span and the hidden input to the form
  tagsContainer.appendChild(tagSpan);
  form.appendChild(hiddenInput);

  // Clear the input field
  input.value = "";
}

// On account form submission check what theme is clicked
// Adjust css according to theme
// Function to apply the theme

function applyTheme(theme) {
  switch (theme) {
    case "Theme1":
      $("nav").css("background-color", "grey");
      $(".nav-link").css("color", "black");
      $("#nav-dropdown").css("background-color", "grey");
      $("body").css("background-color", "lightgrey");
      $("footer").css("background-color", "lightgrey");
      $(".contentContainer").css("background-color", "lightgrey");
      $(".profileRow").css("background-color", "lightgrey");
      $("button").css("background-color", "grey");
      $(".movieDetails").css("background-color", "black");
      $("#indexRow1").css("background-color", "lightgrey");
      $("#indexCol1").css({ "background-color": "black", border: "black" });
      break;
    case "Theme2":
      $("nav").css("background-color", "");
      $(".nav-link").css("color", "");
      $("#nav-dropdown").css("background-color", "");
      $("body").css("background-color", "");
      $("footer").css("background-color", "");
      $(".contentContainer").css("background-color", "");
      $(".profileRow").css("background-color", "");
      $("button").css("background-color", "");
      $(".movieDetails").css("background-color", "");
      $("#indexRow1").css("background-color", "");
      $("#indexCol1").css({ "background-color": "", border: "" });
      break;
    case "Theme3":
      $("nav").css("background-color", "hotpink");
      $(".nav-link").css("color", "lightblue");
      $("#nav-dropdown").css("background-color", "purple");
      $("body").css("background-color", "#0068FF");
      $("footer").css("background-color", "#45FF1B");
      $(".contentContainer").css("background-color", "#C4A5F0");
      $(".profileRow").css("background-color", "#750677");
      $("button").css("background-color", "#00BA82");
      $(".movieDetails").css("background-color", "#55FFFF");
      $("#indexRow1").css("background-color", "#C4A5F0");
      $("#indexCol1").css({ "background-color": "#FF0083", border: "#FF00A6" });
      break;
    default:
      break;
  }
}

// Function to save the selected theme in localStorage
function saveTheme(theme) {
  localStorage.setItem("selectedTheme", theme);
}

// Function to load the selected theme from localStorage
function loadTheme() {
  return localStorage.getItem("selectedTheme");
}

function changeCanvasBackground(color) {
  var canvas = document.getElementById("canvas");
  var ctx = canvas.getContext("2d");

  // Save current canvas content
  ctx.save();

  // Draw the background
  ctx.fillStyle = color;
  ctx.fillRect(0, 0, canvas.width, canvas.height);

  // Restore the canvas content so that this change is underneath other drawings
  ctx.restore();
}
document.getElementById("red").addEventListener("click", function () {
  changeCanvasBackground("red");
});
document.getElementById("white").addEventListener("click", function () {
  changeCanvasBackground("white");
});
document.getElementById("purple").addEventListener("click", function () {
  changeCanvasBackground("purple");
});
document.getElementById("green").addEventListener("click", function () {
  changeCanvasBackground("green");
});
document.getElementById("yellow").addEventListener("click", function () {
  changeCanvasBackground("yellow");
});
document.getElementById("orange").addEventListener("click", function () {
  changeCanvasBackground("orange");
});
document.getElementById("pink").addEventListener("click", function () {
  changeCanvasBackground("pink");
});
document.getElementById("blue").addEventListener("click", function () {
  changeCanvasBackground("rgb(16, 177, 231)");
});

document.getElementById("create").addEventListener("submit", function () {
  var canvas = document.getElementById("canvas");
  var imageData = canvas.toDataURL();
  document.getElementById("canvasImage").value = imageData;
});
