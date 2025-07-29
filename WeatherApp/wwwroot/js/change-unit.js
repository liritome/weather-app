setSelectedUnits();

document.getElementById("temperatureUnitSwitcher").addEventListener("change", function () {
    const selectedUnit = this.value;
    document.cookie = `temperatureUnit=${selectedUnit}; path=/; max-age=31536000`;
    location.reload();
});

function setSelectedUnits() {
    const temperatureUnit = document.cookie.split('; ').find(c => c.startsWith("temperatureUnit="))?.split("=")[1] || "C";
    document.getElementById("temperatureUnitSwitcher").value = temperatureUnit;
}