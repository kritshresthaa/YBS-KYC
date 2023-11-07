const accountInput = document.getElementById("account");
const clearAccountButton = document.getElementById("clearAccount");

clearAccountButton.addEventListener("click", function () {
    accountInput.value = "";
});
const identificationTypeSelect =
    document.getElementById("identificationType");
const citizenshipFields = document.getElementById("citizenshipFields");
const passportFields = document.getElementById("passportFields");
const otherIdentificationFields = document.getElementById(
    "otherIdentificationFields"
);

identificationTypeSelect.addEventListener("change", function () {
    switch (identificationTypeSelect.value) {
        case "Citizenship":
            citizenshipFields.style.display = "flex";

            passportFields.style.display = "none";
            otherIdentificationFields.style.display = "none";
            break;
        case "Passport":
            citizenshipFields.style.display = "none";
            passportFields.style.display = "flex";

            otherIdentificationFields.style.display = "none";
            break;
        case "OtherIdentification":
            citizenshipFields.style.display = "none";
            passportFields.style.display = "none";
            otherIdentificationFields.style.display = "flex";
            break;
        default:
            citizenshipFields.style.display = "none";
            passportFields.style.display = "none";
            otherIdentificationFields.style.display = "none";
            break;
    }
});