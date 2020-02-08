const form = document.getElementById("add-new-event");
const overlay = document.getElementById("overlay");
const button = document.getElementById("toggleForm");

button.addEventListener("click", ToggleForm);
overlay.addEventListener("click", ToggleForm);

function ToggleForm() {
    GetSubjects();
    form.classList.toggle("active");
    overlay.classList.toggle("active");
}


function GetSubjects() {
    var id = select.options[select.selectedIndex].value;

    var subCateList = document.getElementById("subjectPicker");


    var categories = "";
    categories = categories + '<option value="" disabled selected>Odaberi predmet</option>';



    $.ajax({
        type: "GET",
        dataType: "json",
        url: "https://localhost:44315/api/SubjectsApi/schedule/" + id,
        success: function (result) {
            $(result).each(function () {
                console.log(this.Id);
                categories = categories + '<option value="' + this.Id + '">' + this.Name + '</option>';
                subCateList.innerHTML = categories;
            });
        },
        error: function (error) {

        }
    });
}