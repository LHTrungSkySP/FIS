function showModalSex() {
    document.getElementById("listGender").style.display = "block;";
}
function myFunction() {
    // Get the snackbar DIV
    var x = document.getElementById("snackbar");

    // Add the "show" class to DIV
    x.className = "show";

    // After 3 seconds, remove the show class from DIV
    setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
}
function showModalSex() {
    if (document.getElementById("listGender").classList.contains("d-none")) {
        document.getElementById("listGender").classList.remove("d-none");
        document.getElementById("listGender").classList.add("d-flex");

    }
    else {
        document.getElementById("listGender").classList.remove("d-flex");
        document.getElementById("listGender").classList.add("d-none");
    }
}
function setManGender() {
    document.getElementById("listGender").classList.remove("d-flex");
    document.getElementById("listGender").classList.add("d-none");
    document.getElementById("Gender").value = "Nam";
}
function setWomanGender() {
    document.getElementById("listGender").classList.remove("d-flex");
    document.getElementById("listGender").classList.add("d-none");
    document.getElementById("Gender").value = "Nữ";
}