// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener("DOMContentLoaded", function() {
    // Using the unique ID to select the element
    var clientPortalDiv = document.getElementById('clientPortal');
    var providerPortalDiv = document.getElementById('providerPortal');

    // Adding click event listener
    // Redirecting to SignIn.cshtml with a query string
    clientPortalDiv.addEventListener('click', function() {
        window.location.href = '/SignIn?Role=client';
    });

    providerPortalDiv.addEventListener('click', function () {
        window.location.href = '/SignIn?Role=provider';
    });
});

