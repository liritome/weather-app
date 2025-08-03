document.addEventListener("DOMContentLoaded", function () {
    const btn = document.getElementById("datasetBtn");
    const datasetWindow = document.getElementById("datasetWindow");
    const datasetCloseBtn = document.getElementById("datasetCloseBtn");
    const overlay = document.getElementById("overlay");

    setSelected();

    btn.addEventListener("click", function (e) {
        e.stopPropagation();
        overlay.classList.add("active");
        datasetWindow.style.display = datasetWindow.style.display == "none" ? "block" : "none";
    });

    overlay.addEventListener("click", function () {
        datasetWindow.style.display = "none";
        overlay.classList.remove("active");
    });

    datasetCloseBtn.addEventListener("click", function () {
        datasetWindow.style.display = "none";
        overlay.classList.remove("active");
    });
});

function setSelected() {
    const temperature = document.cookie.split('; ').find(c => c.startsWith("temperatureDataset="))?.split("=")[1] || "true";
    document.getElementById("temperatureSwitch").checked = (temperature === "true");

    const apparentTemperature = document.cookie.split('; ').find(c => c.startsWith("apparentTemperatureDataset="))?.split("=")[1] || "false";
    document.getElementById("apparentTemperatureSwitch").checked = (apparentTemperature === "true");

    const windDirection = document.cookie.split('; ').find(c => c.startsWith("windDirectionDataset="))?.split("=")[1] || "true";
    document.getElementById("windDirectionSwitch").checked = (windDirection === "true");

    const windSpeed = document.cookie.split('; ').find(c => c.startsWith("windSpeedDataset="))?.split("=")[1] || "false";
    document.getElementById("windSpeedSwitch").checked = (windSpeed === "true");

    const windGusts = document.cookie.split('; ').find(c => c.startsWith("windGustsDataset="))?.split("=")[1] || "true";
    document.getElementById("windGustsSwitch").checked = (windGusts === "true");

    const precipProb = document.cookie.split('; ').find(c => c.startsWith("precipitationProbabilityDataset="))?.split("=")[1] || "false";
    document.getElementById("precipitationProbabilitySwitch").checked = (precipProb === "true");

    const precip = document.cookie.split('; ').find(c => c.startsWith("precipitationDataset="))?.split("=")[1] || "true";
    document.getElementById("precipitationSwitch").checked = (precip === "true");

    const pressure = document.cookie.split('; ').find(c => c.startsWith("pressureDataset="))?.split("=")[1] || "true";
    document.getElementById("pressureSwitch").checked = (pressure === "true");

    const humidity = document.cookie.split('; ').find(c => c.startsWith("humidityDataset="))?.split("=")[1] || "false";
    document.getElementById("humiditySwitch").checked = (humidity === "true");

    const uvIndex = document.cookie.split('; ').find(c => c.startsWith("uvIndexDataset="))?.split("=")[1] || "false";
    document.getElementById("uvIndexSwitch").checked = (uvIndex === "true");

    const cloudCover = document.cookie.split('; ').find(c => c.startsWith("cloudCoverDataset="))?.split("=")[1] || "false";
    document.getElementById("cloudCoverSwitch").checked = (cloudCover === "true");
}