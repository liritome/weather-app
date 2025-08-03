document.addEventListener("DOMContentLoaded", function () {
    const btn = document.getElementById("settingsBtn");
    const settings = document.getElementById("settings");
    const settingsCloseBtn = document.getElementById("settingsCloseBtn");
    const overlay = document.getElementById("overlay");

    setSelectedUnits();

    btn.addEventListener("click", function (e) {
        e.stopPropagation();
        overlay.classList.add("active");
        settings.style.display = settings.style.display == "none" ? "block" : "none";
    });

    overlay.addEventListener("click", function () {
        settings.style.display = "none";
        overlay.classList.remove("active");
    });

    settingsCloseBtn.addEventListener("click", function () {
        settings.style.display = "none";
        overlay.classList.remove("active");
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