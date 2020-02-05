// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function ToggleMenu(toggleBtn){
    var navigation = document.getElementById("sideBarNav");
    toggleBtn.classList.toggle("change");

    if (navigation.style.width > "0px") {
        navigation.style.width = "0px";
        navigation.style.opacity = 0;
    }
    else {
        navigation.style.width = "300px";
        navigation.style.opacity = 1;
    }

}