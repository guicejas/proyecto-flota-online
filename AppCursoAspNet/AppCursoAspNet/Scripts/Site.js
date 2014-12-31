function Confirm() {
    var confirm_value = document.createElement("INPUT");
    confirm_value.type = "hidden";
    confirm_value.name = "confirm_value";
    if (confirm("Estas seguro que quieres borrar el registro?")) {
        confirm_value.value = "SI";
    } else {
        confirm_value.value = "NO";
    }
    document.forms[0].appendChild(confirm_value);
}