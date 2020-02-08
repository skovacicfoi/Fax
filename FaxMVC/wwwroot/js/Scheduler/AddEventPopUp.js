const form = document.getElementById("add-new-event");
const overlay = document.getElementById("overlay");
const button = document.getElementById("toggleForm");

button.addEventListener("click", ToggleForm);
overlay.addEventListener("click", ToggleForm);

function ToggleForm() {
    form.classList.toggle("active");
    overlay.classList.toggle("active");
}