document.addEventListener("DOMContentLoaded", function () {
    setSelectedUnits();

    document.getElementById("temperatureUnitSwitcher").addEventListener("change", function () {
        const selectedUnit = this.value;
        document.cookie = `temperatureUnit=${selectedUnit}; path=/; max-age=31536000`;
        location.reload();
    });

    document.getElementById("speedUnitSwitcher").addEventListener("change", function () {
        const selectedUnit = this.value;
        document.cookie = `speedUnit=${selectedUnit}; path=/; max-age=31536000`;
        location.reload();
    });

    document.getElementById("precipUnitSwitcher").addEventListener("change", function () {
        const selectedUnit = this.value;
        document.cookie = `precipUnit=${selectedUnit}; path=/; max-age=31536000`;
        location.reload();
    });

    document.getElementById("pressureUnitSwitcher").addEventListener("change", function () {
        const selectedUnit = this.value;
        document.cookie = `pressureUnit=${selectedUnit}; path=/; max-age=31536000`;
        location.reload();
    });
});

function setSelectedUnits() {
    const temperatureUnit = document.cookie.split('; ').find(c => c.startsWith("temperatureUnit="))?.split("=")[1] || "C";
    document.getElementById("temperatureUnitSwitcher").value = temperatureUnit;

    const speedUnit = document.cookie.split('; ').find(c => c.startsWith("speedUnit="))?.split("=")[1] || "m/s";
    document.getElementById("speedUnitSwitcher").value = speedUnit;

    const precipUnit = document.cookie.split('; ').find(c => c.startsWith("precipUnit="))?.split("=")[1] || "mm";
    document.getElementById("precipUnitSwitcher").value = precipUnit;

    const pressureUnit = document.cookie.split('; ').find(c => c.startsWith("pressureUnit="))?.split("=")[1] || "mmHg";
    document.getElementById("pressureUnitSwitcher").value = pressureUnit;
}