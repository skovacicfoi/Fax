



function GetPartsOfSubject(select) {
    var subjectPicker = document.getElementById("subjectPicker");
    var partsPicker = document.getElementById("partsPicker");

    partsPicker.innerHTML = "";
    var id = select.options[select.selectedIndex].value;

    var categories = "";
    categories = categories + '<option value="" disabled selected>Odaberi kategoriju</option>';


    $.ajax({
        type: "GET",
        dataType: "json",
        url: "https://localhost:44315/api/SubjectsApi/parts/" + id,
        success: function (result) {
            $(result).each(function () {
                categories = categories + '<option value="' + this.Id + '">' + this.Name + '</option>';
                partsPicker.innerHTML = categories;
            });
        },
        error: function (error) {

        }
    });

    partsPicker
}