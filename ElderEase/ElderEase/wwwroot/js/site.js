// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener("DOMContentLoaded", function() {
    // Using the unique ID to select the element
    var memberDashboardDiv = document.getElementById('memberPortal');

// Adding click event listener
memberDashboardDiv.addEventListener('click', function() {
    // Redirecting to SignIn.cshtml
    window.location.href = '/SignIn';
    });
});

